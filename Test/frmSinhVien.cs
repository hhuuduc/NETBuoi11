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
    public partial class frmSinhVien : Form
    {
        public string conStr = "Data Source=A209PC39;Initial Catalog=QLSV;Integrated Security=True";

        List<SinhVien> dssv = new List<SinhVien>();

        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDSSV();
        }

        public void LoadDSSV()
        {
            dssv.Clear();
            SqlConnection conn = new SqlConnection(conStr);
            string sql = "select * from SINHVIEN";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int ma = Convert.ToInt32(rdr.GetValue(0).ToString());
                string ten = rdr.GetValue(1).ToString();
                dssv.Add(new SinhVien(ma, ten));
            }
            conn.Close();
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            LoadDSSV();
            dtgv_SinhVien.DataSource = null;
            dtgv_SinhVien.DataSource = dssv;
        }

        private void dtgv_SinhVien_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dtgv_SinhVien.CurrentRow != null)
            {
                txt_Ma.Text = dtgv_SinhVien.Rows[dtgv_SinhVien.CurrentRow.Index].Cells[0].Value.ToString();
                txt_HoTen.Text = dtgv_SinhVien.Rows[dtgv_SinhVien.CurrentRow.Index].Cells[1].Value.ToString();
            }
        }

        public void Clear()
        {
            txt_Ma.Text = "";
            txt_HoTen.Text = "";
        }

        public bool CheckThongTin()
        {
            if (txt_Ma.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_Ma.Focus();
                return false;
            }
            if (txt_HoTen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_HoTen.Focus();
                return false;
            }
            return true;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (CheckThongTin())
            {
                try
                {
                    SqlConnection conn = new SqlConnection(conStr);
                    conn.Open();
                    string sql = "insert into SINHVIEN(MASV, HOTEN) values (" + Convert.ToInt32(txt_Ma.Text) + ", N'" + txt_HoTen.Text + "')";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Clear();
                    MessageBox.Show("Thêm mới sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (CheckThongTin())
            {
                try
                {
                    if(Convert.ToInt32(dtgv_SinhVien.Rows[dtgv_SinhVien.CurrentRow.Index].Cells[0].Value.ToString()) == Convert.ToInt32(txt_Ma.Text))
                    {
                        SqlConnection conn = new SqlConnection(conStr);
                        conn.Open();
                        string sql = "update SINHVIEN set HOTEN = N'" + txt_HoTen.Text + "' where MASV = " + Convert.ToInt32(txt_Ma.Text) + "";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Clear();
                        MessageBox.Show("Sửa thông tin sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Mã sinh viên không được sửa !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_Ma.Text = dtgv_SinhVien.Rows[dtgv_SinhVien.CurrentRow.Index].Cells[0].Value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (CheckThongTin())
            {
                try
                {
                    SqlConnection conn = new SqlConnection(conStr);
                    conn.Open();
                    string sql = "delete from SINHVIEN where MASV = " + Convert.ToInt32(txt_Ma.Text) + "";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Clear();
                    MessageBox.Show("Xóa sinh viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void frmSinhVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmDangNhap frmDN = new frmDangNhap();
            frmDN.ShowDialog();
            this.Close();
            
        }


    }
}
