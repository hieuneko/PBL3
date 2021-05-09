using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AnhMinhHoa
    {
        public int IdAnh { get; set; }
        public string TenAnh { get; set; }
        public byte[] Anh { get; set; }
        public override string ToString()
        {
            return TenAnh;
        }
    }
}
