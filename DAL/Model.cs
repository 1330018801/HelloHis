using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace DAL
{
    public class HisContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
    
    public class User
    {
        public enum LoginStatus { invalid, unknow, logout, login };
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginStatus Status { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
