using System;
namespace SINGIT.Helper
{
    public class UserValidations
    {
        public static bool IsnotEmpty(string data)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(data))
            {
                result = true;
            }
            return result;
        }
        public static bool IsEqual(string password, string confirmPassword)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(confirmPassword))
            {
                if (password.Equals(confirmPassword))
                    result = true;
            }
            else
                result = false;

            return result;
        }
        public static bool NumberIsNotEmpty(int data)
        {
            bool result = false;
            if (data != 0)
            {
                result = true;
            }
            return result;
        }
    }
}
