using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SignInApp.DriveInteraction
{
    class AppState
    {

        public Aes SystemAes = Aes.Create();
        public Aes PasswordAes = Encryption.Encryptors.LoadPasswordKey();

        public DriveService Service;

        public Team OurTeam;

        public SignInEventList CurrentlyIn;

        public SignInEventList SignedOut;

        public byte[] PasswordBytes = null;

        public AppState()
        {
            UserCredential credential;
            using (var stream =
                new FileStream(DriveConstants.CREDENTIAL_PATH, FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string tokenPath = DriveConstants.TOKEN_PATH;
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    DriveConstants.SCOPES,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(tokenPath, true)).Result;
            }

            // Create Drive API service.
            Service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = DriveConstants.APPLICATION_NAME,
            });
        }

    }
}
