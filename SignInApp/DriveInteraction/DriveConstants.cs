using Google.Apis.Drive.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignInApp.DriveInteraction
{
    class DriveConstants
    {

        public const string DEFAULT_PASSWORD = "49462020";

        public const string PASSWORD_DRIVE_NAME = "password";
        public const string TEAMINFO_DRIVE_NAME = "teaminfo";
        public const string EVENT_DRIVE_NAME = "signinevents";

        public static readonly string[] SCOPES = { DriveService.Scope.Drive, DriveService.Scope.DriveAppdata };
        public const string APPLICATION_NAME = "Alpha Dogs Sign In";

        public const string CREDENTIAL_PATH = "login\\credentials\\credentials.json";
        public const string TOKEN_PATH = "login\\tokens";

    }
}
