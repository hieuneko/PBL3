using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace Admin
{
    public partial class AdminMainForm : Form
    {
        public AdminMainForm()
        {
            InitializeComponent();
            setCBBItem();
        }
        public void setCBBItem()
        {
            comboBox2.Items.AddRange(BusinessLogicLayer.Instance.GetCBBItems().ToArray());
        }
        public void ShowList(string st)
        {
            dataGridView1.DataSource = null;
            if (comboBox2.SelectedIndex == -1) MessageBox.Show("Chon Danh Muc");
            else
            {
                int ID = ((CBBItem)comboBox2.SelectedItem).IdDanhMuc;
                dataGridView2.DataSource = BusinessLogicLayer.Instance.getListMonBySearch_BLL(ID,st);
                this.dataGridView1.Columns[0].Visible = false;
            }
        }
        private void button_Show(object sender, EventArgs e)
        {
            ShowList("");
        }
        private void button_Search(object sender, EventArgs e)
        {
            string st = textBox2.Text;
            ShowList(st);
        }

    }
}
