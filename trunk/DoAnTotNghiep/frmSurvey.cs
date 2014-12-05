﻿using System;
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
    public partial class frmSurvey : Form
    {
        public frmSurvey()
        {
            InitializeComponent();
        }

        private void frmSurvey_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dATNDataSet.survey_target' table. You can move, or remove it, as needed.
            this.survey_targetTableAdapter.Fill(this.dATNDataSet.survey_target);

        }

        private void btnTieuChi_Click(object sender, EventArgs e)
        {
            if (grvSurvey.CurrentRow.Index < grvSurvey.RowCount)
            {
                string nameMucTieu = grvSurvey.Rows[grvSurvey.CurrentRow.Index].Cells[1].Value.ToString();
                int idMucTieu = Convert.ToInt32(grvSurvey.Rows[grvSurvey.CurrentRow.Index].Cells[0].Value.ToString());
                //new frmTieuChi(idMucTieu, nameMucTieu, ahpDataSet).Show();
                new Main(nameMucTieu, idMucTieu, dATNDataSet).ShowDialog();
            }
            else
                MessageBox.Show("Vui long chon dong can tao");
        }
    }
}
