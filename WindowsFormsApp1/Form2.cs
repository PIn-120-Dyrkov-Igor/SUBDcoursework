using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        string filePath = string.Empty;                             //Путь к файлу
        string fileExt = string.Empty;

        private sqliteclass mydb = null;                            //Класс
        private string sSql = string.Empty;                         //Запрос

        public Form2()
        {
            InitializeComponent();
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;         //Запрет на изменение размера формы

            //tabControl1.Selected += new TabControlEventHandler(tabControl1_Selected);

            if (db_connect.path == null)
            {
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;


            }

        }

        private void button1_Click(object sender, EventArgs e)      //Поиск уже существующей базы данных
        {
            openFileDialog1.Filter = "Database(*.db)|*.db";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileExt = Path.GetExtension(openFileDialog1.FileName);
                if (fileExt.CompareTo(".db") == 0)
                {
                    try
                    {
                        filePath = openFileDialog1.FileName;//
                        db_connect.path = openFileDialog1.FileName;
                        //Что-то надо сделать, чтобы проверить
                        mydb = new sqliteclass();
                        sSql = "select * from myphoto";
                        DataRow[] datarows = mydb.drExecute(db_connect.path, sSql);

                        if (datarows == null)
                        {
                            Text = "Ошибка чтения!";
                            mydb = null;
                            return;
                        }
                        Text = "";

                        dataGridView1.Rows.Clear();

                        //foreach (DataRow dr in datarows)
                        //{

                        //    dataGridView1.Rows.Add(dr["id"], dr["name"], dr["format"], dr["date"]);
                        //}
                      
                        mydb = null;
                        MessageBox.Show("База данных добавлена");
                        button3.Enabled = true;
                        button4.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Невозможно открыть выбранный файл\nОшибка: " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Выберите файл с расширением .db", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)      //Создание новой базы данных
        {
            filePath = Path.Combine(Application.StartupPath, "kursovayadb.db");
            db_connect.path = filePath;
            //Подключение и создание базы данных
            mydb = new sqliteclass();
            sSql = @"CREATE TABLE if not exists [myphoto]([id] INTEGER PRIMARY KEY AUTOINCREMENT,[name] TEXT,[format] TEXT,[date] REAl,[photo] BLOP);";
            sSql += @"CREATE TABLE if not exists [ticket]([id] INTEGER PRIMARY KEY AUTOINCREMENT,[numberticet] INTEGER,[fio] TEXT,[numbermarsh] INTEGER,[path] TEXT,[data] REAl,[datatwo] REAl,[value] INTEGER);";
            mydb.iExecuteNonQuery(db_connect.path, sSql, 0);
            Text = "Таблица создана!";

            DateTime now = DateTime.Now;
            //Проверка работы
            sSql = @"insert into myphoto (name,format,date) values('Название фотографии','Расширение','" + now + "');";
            if (mydb.iExecuteNonQuery(db_connect.path, sSql, 1) == 0)
            {
                Text = "Ошибка проверки таблицы на запись,";
                Text += " таблица или не создана или не прошла запись тестовой строки!";
                mydb = null;
                return;
            }
            sSql = "select * from myphoto";
            DataRow[] datarows = mydb.drExecute(db_connect.path, sSql);
            if (datarows == null)
            {
                Text = "Ошибка проверки таблицы на чтение!";
                mydb = null;
                return;
            }
            Text = "";
            foreach (DataRow dr in datarows)
            {
                Text += dr["id"].ToString().Trim() + dr["name"].ToString().Trim() + dr["format"].ToString().Trim() + " ";
            }
            sSql = "delete from myphoto";
            if (mydb.iExecuteNonQuery(db_connect.path, sSql, 1) == 0)
            {
                Text = "Ошибка проверки таблицы на удаление записи!";
                mydb = null;
                return;
            }
            //Добавление записи для чтения
            sSql = @"insert into myphoto (name,format,date) values('Название фотографии','Расширение','" + now + "');";
            if (mydb.iExecuteNonQuery(db_connect.path, sSql, 1) == 0)
            {
                Text = "Ошибка проверки таблицы на запись,";
                Text += " таблица или не создана или не прошла запись тестовой строки!";
                mydb = null;
                return;
            }
            sSql = @"insert into ticket (numberticet,fio,numbermarsh,path,data,datatwo,value) values('123','ФИО','105','Муром-Москва','" + now + "','" + now + "','500');";
            if (mydb.iExecuteNonQuery(db_connect.path, sSql, 1) == 0)
            {
                Text = "Ошибка проверки таблицы на запись,";
                Text += " таблица или не создана или не прошла запись тестовой строки!";
                mydb = null;
                return;
            }
            //////////////////////////////
            Text = "Таблица создана!";
            mydb = null;
            button3.Enabled = true;
            button4.Enabled = true;
            return;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //commandText = "select * from myphoto";
            //SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + filePath + ";New=False;Version=3");
            //SQLiteCommand cmd = new SQLiteCommand(commandText, conn);
            //try
            //{
            //    SQLiteDataReader reader = cmd.ExecuteReader();
            //    DataTable dt = new DataTable();
            //    dt.Load(reader);
            //    dataGridView1.DataSource = dt;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Не удалось выбрать данные из таблицы\nОшибка: " + ex);
            //    return;
            //}
            //conn.Close();



            //mydb = new sqliteclass();
            //sSql = "select * from myphoto";
            //DataRow[] datarows = mydb.drExecute(filePath, sSql);

            //if (datarows == null)
            //{
            //    Text = "Ошибка чтения!";
            //    mydb = null;
            //    return;
            //}
            //Text = "";

            //dataGridView1.Rows.Clear();

            //foreach (DataRow dr in datarows)
            //{

            //    dataGridView1.Rows.Add(dr["id"], dr["name"], dr["format"], dr["date"]);
            //}

            //foreach (DataRow dr in datarows)
            //{
            //    Text += dr["id"].ToString().Trim() + " " + dr["name"].ToString().Trim() + " " + dr["format"].ToString().Trim() + " " + dr["date"].ToString().Trim() + " ";
            //}
            //mydb = null;

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

        //private void tabControl1_Selected(object sender, TabControlEventArgs e)
        //{
        //    //MessageBox.Show(e.TabPage.Text.ToString());
        //    switch (e.TabPageIndex)
        //    {
        //        case 0:                   
        //            break;
        //        case 1:
        //            MessageBox.Show("Выбрана вторая вкладка");
        //            break;
        //        case 2:
        //            MessageBox.Show("Выбрана третья вкладка");
        //            break;
        //        case 3:
        //            MessageBox.Show("Выбрана четвертая вкладка");
        //            break;
        //        default:
        //            MessageBox.Show("Что-то пошло не так!");
        //            break;
        //    }
        //}

        private void TabControl1_Selecting(Object sender, TabControlCancelEventArgs e)//Запрет на изменение таб до подключения к бд
        {
            if (db_connect.path == null)
            {
                MessageBox.Show("БД еще не выбрана");
                e.Cancel = true;
            }                          
        }

        private void button4_Click(object sender, EventArgs e)
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
    }
}
