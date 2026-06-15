using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PBO_baru.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string NamaUser { get; set; }
        public int NoHp { get; set; }
        public int RoleUserId { get; set; }

        public User()
        {
        }
    }
}
