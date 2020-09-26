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

namespace DatabaseInsert
{
    public partial class Form1 : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=EREN\\SQLEXPRESS;Integrated Security=True");
        
        private void Getir()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from Plaza.dbo.kisiler", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["adsoyad"].ToString();
                ekle.SubItems.Add (oku ["firma"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["semt"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Getir();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut2 = new SqlCommand("Insert Into Plaza.dbo.kisiler (adsoyad,firma,telefon,semt) Values('" + textBox1.Text.ToString() + " ','" + textBox2.Text.ToString() + "','"+textBox3.Text.ToString() + " ' ,' "+comboBox1.Text.ToString()+ " ')", baglan);
            komut2.ExecuteNonQuery();
            baglan.Close();
            Getir();
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            comboBox1.Text = " ";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
