using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DBProvider;
using System.Data;
using System.Windows.Forms;

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
        public List<DanhMuc> getAllDanhMuc_DAL()
        {
            string query = "select * from DanhMuc";
            List<DanhMuc> lisDanhMuc = new List<DanhMuc>();
            foreach (DataRow i in DBHelper.Instance.GetDataTable(query).Rows)
            {
                lisDanhMuc.Add(getDanhMuc(i));
            }
            return lisDanhMuc;
        }
        private DanhMuc getDanhMuc(DataRow i)
        {
            return new DanhMuc
            {
                TenDanhMuc = i["TenDanhMuc"].ToString(),
                IdDanhMuc = int.Parse(i["IdDanhMuc"].ToString())
            };
        }
        /////
        public List<Mon> getAllMon_DAL()
        {
            try
            {
                string query = "select * from Mon";
                List<Mon> listMon = new List<Mon>();
                foreach (DataRow i in DBHelper.Instance.GetDataTable(query).Rows)
                {
                    listMon.Add(getMon(i));
                }
                return listMon;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        private Mon getMon(DataRow i)
        {
            return new Mon
            {
                IdMon = int.Parse(i["IdMon"].ToString()),
                TenMon = i["TenMon"].ToString(),
                SoLanGoiMon = int.Parse(i["SoLanGoiMon"].ToString()),
                GiaTien = int.Parse(i["GiaTien"].ToString()),
                IdDanhMuc = Convert.ToInt32(i["IdDanhMuc"].ToString()),
                IdAnh = Convert.ToInt32(i["IdAnh"].ToString()),

            };
        }

        public List<Mon> getListMonById(int ID)
        {
            List<Mon> data = new List<Mon>();
            if (ID == 0) return getAllMon_DAL();
            else
            {
                foreach (Mon i in getAllMon_DAL())
                {
                    if (ID == i.IdDanhMuc)
                    {
                        data.Add(i);
                    }
                }
            }
            return data;
        }
        public List<Mon> getListMonBySearch_DAL(int ID, string st)
        {
            List<Mon> data = new List<Mon>();
            if (ID == 0 && st == "")
            {
                return getAllMon_DAL();
            }
            if (ID == 0 && st != "")
            {
                foreach (Mon i in getAllMon_DAL())
                {
                    if ((i.TenMon).Contains(st) == true || ((i.GiaTien).ToString()).Contains(st) == true)
                    {
                        data.Add(i);
                    }
                }
            }
            if (ID != 0 && st == "")
            {
                return getListMonById(ID);
            }
            if (ID != 0 && st != "")
            {
                foreach (Mon i in getListMonById(ID))
                {
                    if ((i.TenMon).Contains(st) == true || ((i.GiaTien).ToString()).Contains(st) == true)
                    {
                        data.Add(i);
                    }
                }
            }
            return data;
        }
        public bool XoaMonTheoIdMon(int IdMon)
        {
            try
            {
                string query = "delete from Mon where IdMon = @ms ";
                object[] prams = { IdMon };
                return DBHelper.Instance.ExecuteNonQuery(query, prams) > 0;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool checkMon(int IdMon)
        {
            try
            {
                foreach (Mon i in getAllMon_DAL())
                {
                    if (i.IdMon == IdMon)
                    {
                        return true;
                        
                    }
                    break;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ThemMon(Mon Mon)
        {
            try
            {
                string query = "insert into Mon( IdMon, TenMon, GiaTien, SoLanGoiMon, IdDanhMuc, IdAnh)" +
                                   "values ( @idmon , @name , @gia , @solangoi , @idDm , @idAnh )";
                object[] prams = { Mon.IdMon, Mon.TenMon, Mon.SoLanGoiMon, Mon.IdDanhMuc, Mon.IdAnh };
                return DBHelper.Instance.ExecuteNonQuery(query, prams) > 0;
            }
            catch (Exception)
            {
                MessageBox.Show("ID món đã tồn tại!");
                return false;
            }
        }
        public bool EditMon(Mon Mon)
        {
            try
            {
                string query = "update Mon set TenMon = @name , GiaTien = @gia ," +
                        " SoLanGoiMon = @solangoi , IdDanhMuc = @idDm , IdAnh = @idAnh where IdMon = @idmon ";
                object[] prams = { Mon.TenMon, Mon.GiaTien, Mon.SoLanGoiMon, Mon.IdDanhMuc, Mon.IdAnh };
                return DBHelper.Instance.ExecuteNonQuery(query, prams) > 0;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
