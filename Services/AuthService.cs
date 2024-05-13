

namespace Project2024.Services
{
    public static class AuthService
    {
        private const string AuthStateFileName = "AuthState.txt";

        public static async Task<bool> IsAuthenticatedAsync()
        {
            await Task.Delay(2000);

            string authStateKey = GetAuthStateKey();
            bool isAuthenticated = Preferences.Default.Get(authStateKey, false);
            return isAuthenticated;
        }

        public static void LogIn()
        {
            string authStateKey = GenerateAuthStateKey();
            Preferences.Default.Set(authStateKey, true);
            SaveAuthStateKeyToFile(authStateKey);
        }

        public static void LogOut()
        {
            string authStateKey = GetAuthStateKey();
            Preferences.Default.Remove(authStateKey);
            DeleteAuthStateKeyFile();
        }

        private static string GetAuthStateKey()
        {
            string authStateKey;
            if (File.Exists(GetAuthStateKeyFilePath()))
            {
                authStateKey = File.ReadAllText(GetAuthStateKeyFilePath());
            }
            else
            {
                authStateKey = GenerateAuthStateKey();
                SaveAuthStateKeyToFile(authStateKey);
            }
            return authStateKey;
        }

        private static string GenerateAuthStateKey()
        {
            // Генерувати випадковий ключ
            string authStateKey = Guid.NewGuid().ToString();
            return authStateKey;
        }

        private static void SaveAuthStateKeyToFile(string authStateKey)
        {
            File.WriteAllText(GetAuthStateKeyFilePath(), authStateKey);
        }

        private static void DeleteAuthStateKeyFile()
        {
            if (File.Exists(GetAuthStateKeyFilePath()))
            {
                File.Delete(GetAuthStateKeyFilePath());
            }
        }

        private static string GetAuthStateKeyFilePath()
        {
            return Path.Combine(FileSystem.AppDataDirectory, AuthStateFileName);
        }
    }
}

