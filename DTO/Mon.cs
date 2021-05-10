using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Mon
    {
        public int IdMon { get; set; }
        public string TenMon { get; set; }
        public int GiaTien { get; set; }
        public int SoLanGoiMon { get; set; }
        public int IdDanhMuc { get; set; }
        public byte[] IdAnh { get; set; }
        public override string ToString()
        {
            return TenMon;
        }
    }
}
