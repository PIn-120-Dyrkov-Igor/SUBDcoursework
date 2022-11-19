using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;         //Запрет на изменение размера формы
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string commandText = "select * from myphoto";
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + db_connect.path + ";New=True;Version=3");
            SQLiteCommand cmd = new SQLiteCommand(commandText, conn);
            conn.Open();
            try
            {
                SQLiteDataReader sqlReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;//Убираем пустую строку
                dt.Load(sqlReader);

                dataGridView1.DataSource = dt;
                //Для чтения изображений
                //DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                //imgCol = (DataGridViewImageColumn)dataGridView1.Columns[1];
                //imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось выбрать данные из таблицы\nОшибка: " + ex);
                return;
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string commandText = "select * from ticket";
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + db_connect.path + ";New=True;Version=3");
            SQLiteCommand cmd = new SQLiteCommand(commandText, conn);
            conn.Open();


            try
            {
                SQLiteDataReader sqlReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToAddRows = false;//Убираем пустую строку
                dt.Load(sqlReader);

                dataGridView1.DataSource = dt;
                //Для чтения изображений
                //DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                //imgCol = (DataGridViewImageColumn)dataGridView1.Columns[1];
                //imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось выбрать данные из таблицы\nОшибка: " + ex);
                return;
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 Add = new Form4();
            Add.ShowDialog();
        }
    }
}
