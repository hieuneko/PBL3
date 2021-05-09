using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DBProvider;
using System.Data;
namespace DAL
{
    public class DataAccessLayer
    {
        private static DataAccessLayer _Instance;
        public static DataAccessLayer Instance
        {
            get
            {
                if (_Instance == null) return _Instance = new DataAccessLayer();
                return _Instance;
            }
        }
        private DataAccessLayer() { }
        /// <summary>
        /// lay anh minh hoa tu DataTable
        /// </summary>
        /// <param name="i">1 data row of datatable</param>
        /// <returns></returns>
        private AnhMinhHoa getAnh(DataRow i)
        {
            return new AnhMinhHoa
            {
                IdAnh = int.Parse(i["IdAnh"].ToString()),
                TenAnh = i["TenAnh"].ToString(),
                Anh = (byte[])i["Anh"]
            };
        }
        /// <summary>
        /// Lay toan bo anh minh hoa tu DB => List<Anhminhhoa>
        /// </summary>
        /// <returns>List<AnhMinhHoa></returns>
        public List<AnhMinhHoa> GetListAnhMinhHoa()
        {
            try
            {
                List<AnhMinhHoa> anhMinhHoas = new List<AnhMinhHoa>();
                string query = "select * from AnhMinhHoa";
                foreach (DataRow i in DBHelper.Instance.GetDataTable(query).Rows)
                {
                    anhMinhHoas.Add(getAnh(i));
                }
                return anhMinhHoas;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}
