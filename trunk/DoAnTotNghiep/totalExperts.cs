using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnTotNghiep
{
    public partial class totalExperts : Form
    {
        public totalExperts()
        {
            InitializeComponent();
        }


        private void buttonOkClick(object sender, EventArgs e)
        {
            //Truyền lại cho form 1 biến chuyên gia
            Main.totalExperts = txtChuyenGia.Text;
            this.Close();
        }
    }
}
