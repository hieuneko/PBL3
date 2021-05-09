using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DTO;
using DAL;
using DBProvider;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Admin
{
    public partial class ImageForm : Form
    {
        public ImageForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            string ImagesPath = startupPath + @"\AnhMinhhoa";
            //MessageBox.Show(ImagesPath);
            foreach (string path in Directory.GetFiles(ImagesPath))
            {
            
                Image img = Image.FromFile(path);
                pictureBox1.Image = img;
                
                MessageBox.Show(path, "sa", MessageBoxButtons.OK, MessageBoxIcon.Error);

                byte[] Anh = null;
                FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(stream);
                Anh = br.ReadBytes((int)stream.Length);
                string query = "insert into AnhMinhHoa(TenAnh,Anh) values( @ten , @anh )";
                string picName = path.Substring(path.LastIndexOf("\\"));
                object[] param={ picName, Anh};
                try
                {
                    DBHelper.Instance.ExecuteNonQuery(query, param);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Loi trung anh" + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            List<AnhMinhHoa> list = new List<AnhMinhHoa>();
            list = DataAccessLayer.Instance.GetListAnhMinhHoa();

            foreach(AnhMinhHoa i in list)
            {
                if(int.Parse(txtID.Text) == i.IdAnh)
                {
                    try
                    {
                        MemoryStream ms = new MemoryStream(i.Anh, 0, i.Anh.Length);
                        ms.Write(i.Anh, 0, i.Anh.Length);
                        pictureBox1.Image = Image.FromStream(ms, true);
                        txtTen.Text = i.TenAnh;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Loi: " + ex.Message);
                    }
                }
            }


        }
        
    }
}
