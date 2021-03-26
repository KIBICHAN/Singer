using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Castle.Components.DictionaryAdapter;
using SingerLibrary;

namespace SingerMaintain
{
    public partial class Form1 : Form
    {
        SingerData sd = new SingerData();
        DataTable dtSinger;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnView_Click_1(object sender, EventArgs e)
        {
            getAllSinger();
        }

        private void getAllSinger()
        {
            dtSinger = sd.getSinger();

            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtAge.DataBindings.Clear();
            txtEmail.DataBindings.Clear();

            txtID.DataBindings.Add("Text", dtSinger, "SingerID");
            txtName.DataBindings.Add("Text", dtSinger, "SingerName");
            txtAge.DataBindings.Add("Text", dtSinger, "SingerAge");
            txtEmail.DataBindings.Add("Text", dtSinger, "SingerEmail");

            dgvSingerList.DataSource = dtSinger;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            string Name = txtName.Text;
            int Age = int.Parse(txtAge.Text);
            string Email = txtEmail.Text;
            Singer singer = new Singer
            {
                SingerID = ID,
                SingerName = Name,
                SingerAge = Age,
                SingerEmail = Email
            };
            bool check = sd.addSinger(singer);
            string message = (check == true ? "successfull" : "fail");
            MessageBox.Show("Add " + message);
            getAllSinger();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            Singer singer = sd.findSinger(ID);
            string message = (singer != null ? "succesfull" : "fail");
            MessageBox.Show("Find " + message);
            BindingList<Singer> bl = new BindingList<Singer>();
            bl.Add(singer);
            dgvSingerList.DataSource = bl;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            bool check = sd.deleteSinger(ID);
            string message = (check == true ? "succesfull" : "fail");
            MessageBox.Show("Delete " + message);
            getAllSinger();
        }
    }
}
