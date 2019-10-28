using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignInApp.DriveInteraction
{
    class Interactions
    {

        public static bool AuthenticatePassword(string passString)
        {
            if (MainProgram.AppState.PasswordBytes == null)
            {
                MainProgram.AppState.PasswordBytes = DownloadPassword().ToArray();
            }

            return Encryption.Encryptors.CompareHash(passString, Encryption.Encryptors.DecryptWithStoredIV(MainProgram.AppState.PasswordBytes, MainProgram.AppState.PasswordAes.Key, Encryption.EncryptionConstants.IV_LENGTH));
        }

        public static MemoryStream DownloadPassword()
        {
            Google.Apis.Drive.v3.Data.File passwordFile = new Google.Apis.Drive.v3.Data.File();

            try
            {
                passwordFile = GetAppdataByName(DriveConstants.PASSWORD_DRIVE_NAME);
            } catch (InternetAccessException e)
            {
                bool end = true;
                do
                {
                    if (WindowInteraction.Interactions.RecoverInternetAccess())
                        break;
                    end = true;
                    try
                    {
                        passwordFile = GetAppdataByName(DriveConstants.PASSWORD_DRIVE_NAME);
                    }
                    catch (InternetAccessException q)
                    {
                        end = false;
                    }
                } while (!end);
            }

            if (passwordFile == null) //didn't exist
            {
                passwordFile = UploadPassword(DriveConstants.DEFAULT_PASSWORD);
            }
            
            using (MemoryStream passwordStream = new MemoryStream())
            {
                var request = MainProgram.AppState.Service.Files.Get(passwordFile.Id);

                if (request.DownloadWithStatus(passwordStream).Status == DownloadStatus.Failed)
                {
                    if (WindowInteraction.Interactions.RecoverInternetAccess())
                        return null;
                    request.DownloadWithStatus(passwordStream);
                }
                return passwordStream;
            }
        }

        public static Google.Apis.Drive.v3.Data.File UploadPassword(string password)
        {
            Google.Apis.Drive.v3.Data.File passwordFile;
            byte[] bytes = { };

            using (FileStream passwordUpload = File.Create(DriveConstants.PASSWORD_DRIVE_NAME))
            {
                try
                {
                    bytes = Encryption.Encryptors.EncryptAndStoreIV(Encryption.Encryptors.SaltAndHashPassword(password), MainProgram.AppState.PasswordAes.Key);
                    passwordUpload.Write(bytes, 0, bytes.Length);
                }
                catch (IOException e)
                {

                }

                Google.Apis.Drive.v3.Data.File metadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = DriveConstants.PASSWORD_DRIVE_NAME,
                    Description = DriveConstants.PASSWORD_DRIVE_NAME,
                    MimeType = "application/octet-stream",
                    Parents = new List<string>()
                        {
                            "appDataFolder"
                        }
                };

                passwordUpload.Dispose();

                using (var passwordReader = new FileStream(DriveConstants.PASSWORD_DRIVE_NAME,
                    FileMode.Open))
                {
                    FilesResource.CreateMediaUpload request = MainProgram.AppState.Service.Files.Create(metadata, passwordReader, "application/octet-stream");
                    request.Fields = "id";
                    try
                    {
                        request.Upload();
                    } catch (Exception e)
                    {
                        bool end = true;
                        do
                        {
                            if (WindowInteraction.Interactions.RecoverInternetAccess())
                                break;
                            end = true;
                            try
                            {
                                request.Upload();
                            }
                            catch (InternetAccessException q)
                            {
                                end = false;
                            }
                        } while (!end);
                    }
                    passwordFile = request.ResponseBody;
                }
            }
            File.Delete(DriveConstants.PASSWORD_DRIVE_NAME);
            MainProgram.AppState.PasswordBytes = bytes;
            return passwordFile;
        }

        public static Google.Apis.Drive.v3.Data.File UpdatePassword(string password)
        {
            Google.Apis.Drive.v3.Data.File passwordFile = new Google.Apis.Drive.v3.Data.File();
            try
            {
                passwordFile = GetAppdataByName(DriveConstants.PASSWORD_DRIVE_NAME);
            } catch (InternetAccessException e)
            {
                bool end = true;
                do
                {
                    if (WindowInteraction.Interactions.RecoverInternetAccess())
                        break;
                    end = true;
                    try
                    {
                        passwordFile = GetAppdataByName(DriveConstants.PASSWORD_DRIVE_NAME);
                    } catch (InternetAccessException q)
                    {
                        end = false;
                    }
                } while (!end);
            }

            Google.Apis.Drive.v3.Data.File metadata = new Google.Apis.Drive.v3.Data.File();

            MemoryStream ms = new MemoryStream(Encryption.Encryptors.EncryptAndStoreIV(Encryption.Encryptors.SaltAndHashPassword(password), MainProgram.AppState.PasswordAes.Key));

            FilesResource.UpdateMediaUpload request = MainProgram.AppState.Service.Files.Update(metadata, passwordFile.Id, ms, passwordFile.MimeType);

            try
            {
                request.Upload();
            } catch (Exception e)
            {
                bool end = true;
                do
                {
                    if (WindowInteraction.Interactions.RecoverInternetAccess())
                        break;
                    end = true;
                    try
                    {
                        request.Upload();
                    }
                    catch (Exception q)
                    {
                        end = false;
                    }
                } while (!end);
            }

            MainProgram.AppState.PasswordBytes = ms.ToArray();

            //reencrypt all files

            ReEncryptAll(Encryption.Encryptors.KeyGenFromPassword(password));

            return request.ResponseBody;
        }

        public static Google.Apis.Drive.v3.Data.File GetAppdataByName(string fileName)
        {
            string pageToken = null;
            do
            {
                FilesResource.ListRequest fileListRequest = MainProgram.AppState.Service.Files.List();
                fileListRequest.Q = "name = '" + fileName + "'";
                fileListRequest.Spaces = "appDataFolder";
                fileListRequest.PageSize = 50;
                fileListRequest.Fields = "nextPageToken, files(id, name)";
                fileListRequest.PageToken = pageToken;

                IList<Google.Apis.Drive.v3.Data.File> foundFiles;

                try
                {
                    foundFiles = fileListRequest.Execute().Files;
                } catch (Exception e)
                {
                    throw new InternetAccessException(); 
                }
                
                
                foreach (Google.Apis.Drive.v3.Data.File file in foundFiles)
                {
                    if (file.Name == fileName)
                        return file;
                }

                pageToken = fileListRequest.PageToken;

            } while (pageToken != null);

            return null;

        }

        public static Member LookupMember(int number)
        {

            foreach (Member member in MainProgram.AppState.OurTeam.Members)
            {
                if (member.Number == number)
                    return member;
            }
            return null;
        }

        /**
         *  @return true if operation completed, false if member already exists 
         */
        public static bool RegisterMember(int number, string firstName, string lastName)
        {

            foreach (Member member in MainProgram.AppState.OurTeam.Members)
            {
                if (member.Number == number)
                    return false;
            }
            MainProgram.AppState.OurTeam.AddMember(number, firstName, lastName);

            UpdateFile(DriveConstants.TEAMINFO_DRIVE_NAME, MainProgram.AppState.OurTeam.Serialize());

            return true;
        }

        public static void DeleteMember(int number)
        {
            MainProgram.AppState.OurTeam.Members.Remove(LookupMember(number));

            UpdateFile(DriveConstants.TEAMINFO_DRIVE_NAME, MainProgram.AppState.OurTeam.Serialize());
        }

        public static MemoryStream DownloadFile(string name)
        {
            Google.Apis.Drive.v3.Data.File file = new Google.Apis.Drive.v3.Data.File();

            try
            {
                file = GetAppdataByName(name);
            } catch (InternetAccessException e)
            {
                bool end = true;
                do
                {
                    if (WindowInteraction.Interactions.RecoverInternetAccess())
                        break;
                    end = true;
                    try
                    {
                        file = GetAppdataByName(name);
                    }
                    catch (InternetAccessException q)
                    {
                        end = false;
                    }
                } while (!end);
            }
            

            if (file == null) //didn't exist
            {
                return null;
            }

            using (MemoryStream fileStream = new MemoryStream())
            {
                var request = MainProgram.AppState.Service.Files.Get(file.Id);

                if (request.DownloadWithStatus(fileStream).Status == DownloadStatus.Failed)
                {
                    if (WindowInteraction.Interactions.RecoverInternetAccess())
                        return null;
                    request.DownloadWithStatus(fileStream);
                }
                return fileStream;
            }
        }

        public static Google.Apis.Drive.v3.Data.File UploadFile(string name, string content)
        {
            Google.Apis.Drive.v3.Data.File file;

            using (FileStream uploadFile = File.Create(name))
            {
                try
                {
                    byte[] bytes = Encryption.Encryptors.EncryptAndStoreIV(content, MainProgram.AppState.SystemAes.Key);
                    uploadFile.Write(bytes, 0, bytes.Length);
                }
                catch (IOException e)
                {
                    //Console.WriteLine(e.StackTrace);
                }

                Google.Apis.Drive.v3.Data.File metadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = name,
                    Description = name,
                    MimeType = "application/octet-stream",
                    Parents = new List<string>()
                        {
                            "appDataFolder"
                        }
                };

                uploadFile.Dispose();

                using (var fileReader = new FileStream(name,
                    FileMode.Open))
                {
                    FilesResource.CreateMediaUpload request = MainProgram.AppState.Service.Files.Create(metadata, fileReader, "application/octet-stream");
                    request.Fields = "id";
                    try
                    {
                        request.Upload();
                    } catch (Exception e)
                    {
                        bool end = true;
                        do
                        {
                            if (WindowInteraction.Interactions.RecoverInternetAccess())
                                break;
                            end = true;
                            try
                            {
                                request.Upload();
                            }
                            catch (InternetAccessException q)
                            {
                                end = false;
                            }
                        } while (!end);
                    }
                    file = request.ResponseBody;
                }
            }
            File.Delete(name);
            return file;
        }

        public static Google.Apis.Drive.v3.Data.File UpdateFile(string name, string content)
        {
            Google.Apis.Drive.v3.Data.File existingFile = new Google.Apis.Drive.v3.Data.File();

            try
            {
                existingFile = GetAppdataByName(name);
            }
            catch (InternetAccessException e)
            {
                bool end = true;
                do
                {
                    if (WindowInteraction.Interactions.RecoverInternetAccess())
                        break;
                    end = true;
                    try
                    {
                        existingFile = GetAppdataByName(name);
                    }
                    catch (InternetAccessException q)
                    {
                        end = false;
                    }
                } while (!end);
            }

            if (existingFile == null)
                existingFile = UploadFile(name, content);
            else
            {
                Google.Apis.Drive.v3.Data.File metadata = new Google.Apis.Drive.v3.Data.File();

                MemoryStream ms = new MemoryStream(Encryption.Encryptors.EncryptAndStoreIV(content, MainProgram.AppState.SystemAes.Key));

                FilesResource.UpdateMediaUpload request = MainProgram.AppState.Service.Files.Update(metadata, existingFile.Id, ms, existingFile.MimeType);
                try
                {
                    request.Upload();
                }
                catch (Exception e)
                {
                    bool end = true;
                    do
                    {
                        if (WindowInteraction.Interactions.RecoverInternetAccess())
                            break;
                        end = true;
                        try
                        {
                            request.Upload();
                        }
                        catch (InternetAccessException q)
                        {
                            end = false;
                        }
                    } while (!end);
                }

                return request.ResponseBody;
            }

            return existingFile;
        }

        public static Google.Apis.Drive.v3.Data.File ReEncryptFile(string name, byte[] oldKey)
        {
            string fileContents = Encryption.Encryptors.DecryptWithStoredIV(DownloadFile(name).ToArray(), oldKey, Encryption.EncryptionConstants.IV_LENGTH);
            return UpdateFile(name, fileContents);
        }

        public static void ReEncryptAll(byte[] newKey)
        {

            byte[] oldKey = MainProgram.AppState.SystemAes.Key;
            MainProgram.AppState.SystemAes.Key = newKey;

            if (ReEncryptFile(DriveConstants.TEAMINFO_DRIVE_NAME, oldKey) == null)
            {
                UploadFile(DriveConstants.TEAMINFO_DRIVE_NAME, MainProgram.AppState.OurTeam.Serialize());
            }

            if (ReEncryptFile(DriveConstants.EVENT_DRIVE_NAME, oldKey) == null)
            {
                UploadFile(DriveConstants.EVENT_DRIVE_NAME, MainProgram.AppState.SignedOut.Serialize());
            }

        }

    }

    public class InternetAccessException : Exception
    {
        public InternetAccessException()
        {

        }
    }
}
