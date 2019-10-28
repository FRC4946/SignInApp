using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignInApp.Encryption
{
    class EncryptionConstants
    {

        public const int IV_LENGTH = 16;
        public const int HASH_REPITIONS = 10000;
        public const int HASH_LENGTH = 64;
        public const int SALT_LENGTH = 32;
        public const int KEY_LENGTH = 32;
        public static readonly byte[] PASSWORD_KEY = { 177, 172, 161, 72, 48, 226, 173, 79, 55, 164, 72, 53, 250, 230, 253, 156, 173, 172, 40, 90, 47, 165, 99, 83, 31, 254, 29, 104, 87, 109, 198, 38 };
        public static readonly byte[] PASSWORD_SALT = { 55, 35, 50, 217, 4, 218, 143, 170, 243, 240, 12, 108, 164, 125, 86, 164, 99, 198, 209, 237, 57, 154, 18, 141, 189, 142, 242, 4, 188, 133, 228, 27 };

    }
}
