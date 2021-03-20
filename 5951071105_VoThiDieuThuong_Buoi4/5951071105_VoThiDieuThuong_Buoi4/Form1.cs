using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace _5951071105_VoThiDieuThuong_Buoi4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetStudentsRecord();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            GetStudentsRecord();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
        private void GetStudentsRecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E01MG43U\SQLEXPRESS02;Initial Catalog=DemoCRUD;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM StudentsTable",con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
        
            StudentsRecordData.DataSource = dt;
            con.Close();
        }
        private bool IsvaliData()
        {
            if (txtHo.Text == string.Empty || txtTen.Text == string.Empty || txtDc.Text == string.Empty || string.IsNullOrEmpty(txtSDT.Text) || string.IsNullOrEmpty(txtSBD.Text)) 
            {
                MessageBox.Show("Bạn nhập thiếu dữ liệu. Vui lòng nhập đủ");
                    return false;
            }
            return true;
        }
        public int StudentID;
        private void StudentsRecordData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentID = Convert.ToInt32(StudentsRecordData.Rows[0].Cells[0].Value);
            txtTen.Text = StudentsRecordData.SelectedRows[0].Cells[1].Value.ToString();
           txtHo.Text = StudentsRecordData.SelectedRows[0].Cells[2].Value.ToString();
          txtSBD.Text = StudentsRecordData.SelectedRows[0].Cells[3].Value.ToString();
            txtDc.Text = StudentsRecordData.SelectedRows[0].Cells[4].Value.ToString();
            txtSDT.Text = StudentsRecordData.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (IsvaliData())
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E01MG43U\SQLEXPRESS02;Initial Catalog=DemoCRUD;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("INSERT INTO StudentsTable VALUES " + "(@Name,@FatherName,@RollNumber,@Address,@Mobile)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtTen.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtHo.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtSBD.Text);
                cmd.Parameters.AddWithValue("@Address", txtDc.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtSDT.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();




            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (StudentID > 0)
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E01MG43U\SQLEXPRESS02;Initial Catalog=DemoCRUD;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("UPDATE StudentsTable SET " + "Name=@Name, FatherName=@FatherName, RollNumber=@RollNumber,Address=@Address,Mobile=@Mobile WHERE StudentID=@ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtTen.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtHo.Text);
                cmd.Parameters.AddWithValue("@RollNumber", txtSBD.Text);
                cmd.Parameters.AddWithValue("@Address", txtDc.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtSDT.Text);
                cmd.Parameters.AddWithValue("@ID",this.StudentID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();
            }
            else { MessageBox.Show("Lỗi cập nhập!!!!","",MessageBoxButtons.OK,MessageBoxIcon.Error); }

            }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (StudentID > 0)
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-E01MG43U\SQLEXPRESS02;Initial Catalog=DemoCRUD;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("DELETE StudentsTable WHERE StudentID=@ID ", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.StudentID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentsRecord();
            
            }
            else
            {
                MessageBox.Show("Lỗi xóa !!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
       

    }

