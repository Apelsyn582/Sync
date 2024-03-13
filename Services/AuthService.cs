using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2024.Services
{
    public class AuthService
    {
        private const string AuthStateKey = "AuthState";

        public async Task<bool> IsAuthenticatedAsync()
        {
            await Task.Delay(2000);

            return Preferences.Default.Get<bool>(AuthStateKey, false);
        }

        public void LogIn()
        {
            Preferences.Default.Set<bool>(AuthStateKey, true);
        }
        public void LogOut()
        {
            Preferences.Default.Remove(AuthStateKey);
        }
    }

}
