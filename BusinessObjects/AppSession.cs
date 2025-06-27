using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public static class AppSession
    {
        public static Customers CurrentCustomer { get; set; }
    }
}
