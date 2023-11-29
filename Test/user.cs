using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class user
    {
        public string name { get; set; }
        public string pass { get; set; }
        public bool save { get; set; }

        public user() { }

        public user(string us, string ps, bool sv)
        {
            this.name = us;
            this.pass = ps;
            this.save = sv;
        }
    }
}
