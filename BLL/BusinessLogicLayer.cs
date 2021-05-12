using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class BusinessLogicLayer
    {
        private static BusinessLogicLayer _Instance;
        public static BusinessLogicLayer Instance
        {
            get
            {
                if (_Instance == null) return _Instance = new BusinessLogicLayer();
                return _Instance;
            }
        }
        private BusinessLogicLayer() { }
        public List<CBBItem> GetCBBItems()
        {
            List<CBBItem> data = new List<CBBItem>();
            data.Add(new CBBItem
            {
                IdDanhMuc = 0,
                DanhMuc = "All"
            });
            foreach (DanhMuc i in getAllDanhMuc_BLL())
            {
                data.Add(new CBBItem
                {
                    IdDanhMuc = i.IdDanhMuc,
                    DanhMuc = i.TenDanhMuc
                });
            }
            return data;
        }
        public List<DanhMuc> getAllDanhMuc_BLL()
        {
            return DataAccessLayer.Instance.getAllDanhMuc_DAL();
        }
        public List<Mon> getAllMon_BLL()
        {
            return DataAccessLayer.Instance.getAllMon_DAL();
        }
        public List<MonView> getListMonBySearch_BLL(int id,string st)
        {
            List<MonView> data = new List<MonView>();
            data = ConvertToListMonview(DataAccessLayer.Instance.getListMonBySearch_DAL(id, st));
            return data;
        }
        public MonView ConvertToMonView(Mon m)
        {
            MonView mv = new MonView();
            foreach(DanhMuc i in getAllDanhMuc_BLL())
            {
                if(m.IdDanhMuc==i.IdDanhMuc)
                {
                    mv.IdMon = m.IdMon;
                    mv.TenMon = m.TenMon;
                    mv.GiaTien = m.GiaTien;
                    mv.SoLuong = 1000;
                    mv.SoLanGoiMon = m.SoLanGoiMon;
                    mv.DanhMuc = i.TenDanhMuc;
                    break;
                }    
            }
            return mv;
        }
        public List<MonView> ConvertToListMonview(List<Mon> m)
        {
            List<MonView> mv = new List<MonView>();
            foreach(Mon i in m)
            {
                mv.Add(ConvertToMonView(i));
            }
            return mv;
        }
    }
}
