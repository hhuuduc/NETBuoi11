using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class SinhVien
    {
        public int MaSV { get; set; }
        public string HoTen { get; set; }

        public SinhVien() {}

        public SinhVien(int ma, string ten)
        {
            this.MaSV = ma;
            this.HoTen = ten;
        }
    }
}
