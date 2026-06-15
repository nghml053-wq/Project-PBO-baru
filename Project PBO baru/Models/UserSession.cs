using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO_baru.Models
{
    internal static class UserSession
    {
        public static User CurrentUser { get; set; }

        public static bool IsAuthenticated => CurrentUser != null;

        public static bool IsAdmin => CurrentUser != null && CurrentUser.RoleUserId == 1;

        public static bool IsCustomer => CurrentUser != null && CurrentUser.RoleUserId == 2;

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
