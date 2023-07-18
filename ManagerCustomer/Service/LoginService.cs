using ManagerCustomer.Ulti;

namespace ManagerCustomer.Service
{
    internal static class LoginService
    {
        public static bool isLoged { get; set; } = false;

        public static bool Login(string? username, string? password)
        {
            var arr = new string[]
            {
                username, password
            };
            if (Common.checkStringsIsNullOrEmpty(arr))
            {
                return false;
            }
            var user = Common.getDataInSetting(GlobalStrings.USERNAME);
            var pass = Common.getDataInSetting(GlobalStrings.PASSWORD);
            try
            {
                if(user == username.Trim() && pass == password.Trim())
                {
                    isLoged = true;
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
