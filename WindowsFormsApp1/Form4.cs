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
    public partial class Form4 : Form
    {
        private sqliteclass mydb = null;                            //Класс
        private string sSql = string.Empty;                         //Запрос

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            mydb = new sqliteclass();
            sSql = @"insert into ticket (numberticet,fio,numbermarsh,path,data,datatwo,value) values('123','ФИО','105','Муром-Москва','" + now + "','" + now + "','500');";
            mydb.iExecuteNonQuery(db_connect.path, sSql, 0);
            mydb = null;

            Close();
        }
    }
}
