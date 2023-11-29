using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Test
{
    public partial class frmDangNhap : Form
    {

        public string conStr = "Data Source=A209PC39;Initial Catalog=QLSV;Integrated Security=True";

        List<user> dsus = new List<user>();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        public void LoadDSUS()
        {
            dsus.Clear();
            SqlConnection conn = new SqlConnection(conStr);
            string sql = "select * from DANGNHAP";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                string name = rdr.GetValue(0).ToString();
                string pass = rdr.GetValue(1).ToString();
                bool save = Convert.ToBoolean(rdr.GetValue(2).ToString());
                
                dsus.Add(new user(name, pass, save));
            }
            conn.Close();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            LoadDSUS();
        }

        private void txt_DangNhap_Leave(object sender, EventArgs e)
        {

        }

        private void txt_DangNhap_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dsus.Count(); i++)
            {
                if (String.Compare(txt_DangNhap.Text, dsus[i].name.ToString(), false) == 0 && dsus[i].save == true)
                {
                    txt_MatKhau.Text = dsus[i].pass.ToString();
                    rdbtn_Save.Checked = true;
                }
            }
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dsus.Count(); i++)
            {
                if (String.Compare(txt_DangNhap.Text, dsus[i].name.ToString(), false) == 0 && String.Compare(txt_MatKhau.Text, dsus[i].pass.ToString(), false) == 0)
                {
                    if (rdbtn_Save.Checked == true)
                    {
                        SqlConnection conn = new SqlConnection(conStr);
                        conn.Open();
                        string sql = "update DANGNHAP set [SAVE] = 'True' where USERNAME = N'" + txt_DangNhap.Text.ToString() + "'";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    this.Hide();
                    frmSinhVien frmSV = new frmSinhVien();
                    frmSV.ShowDialog();
                    this.Close();
                }
            }
            MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
