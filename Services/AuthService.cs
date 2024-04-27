using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2024.Services
{
    public static class AuthService
    {
        private const string AuthStateKey = "AuthState";

        public static async Task<bool> IsAuthenticatedAsync()
        {
            await Task.Delay(2000);

            return Preferences.Default.Get<bool>(AuthStateKey, false);
        }

        public static void LogIn()
        {
            Preferences.Default.Set<bool>(AuthStateKey, true);
        }
        public static void LogOut()
        {
            Preferences.Default.Remove(AuthStateKey);
        }
    }

}
