using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DanhMuc
    {
        public int IdDanhMuc { get; set; }
        public string TenDanhMuc { get; set; }
        public override string ToString()
        {
            return TenDanhMuc;

        }
    }
}
