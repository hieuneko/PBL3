using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Admin
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string path in Directory.GetFiles(@"F:\FoodOrder\Admin\Resources")){
                imageListMon.Images.Add(Image.FromFile(path));
                MessageBox.Show(imageListMon.Images.Count + "   " + path);
            }
            

            
        }
    }
}
