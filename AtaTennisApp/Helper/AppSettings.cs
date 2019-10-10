using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtaTennisApp.Helper
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public bool UseInMemoryDB { get; set; } = false;
    }
}
