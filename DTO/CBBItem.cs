using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CBBItem
    {
        public int IdDanhMuc { get; set; }
        public string DanhMuc { get; set; }
        public override string ToString()
        {
            return DanhMuc;
        }
    }
}
