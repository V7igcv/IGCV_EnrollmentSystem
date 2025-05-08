using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDP_WinProject102
{
    internal class Session
    {
        public static int UserId { get; set; }
        public static string Email { get; set; }
        public static string FirstName { get; set; }

        public static void Clear()
        {
            UserId = 0;
            Email = null;
            FirstName = null;
        }
    }
}
