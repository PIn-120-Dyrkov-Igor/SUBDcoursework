using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;         //Запрет на изменение размера формы
            comboBox1.SelectedIndex = 0;                            //Выбор первой строки листБокса при открытии формы
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;   //Запрет на ввод текста в листБокс

            textBox1.PasswordChar = '*';                            //Маска для поля ввода пароля
            textBox1.MaxLength = 12;                                //Максимальная длина пароля
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0 && textBox1.Text == "1")
            {
                Form3 start = new Form3();
                start.ShowDialog();                                 //Открытие формы "Рабочая касса"
                textBox1.Text = "";                                 //Очистка поля с паролем
            }
            else if (comboBox1.SelectedIndex == 1 && textBox1.Text == "1")
            {
                Form2 admin = new Form2();
                admin.ShowDialog();                                 //Открытие формы "Администрирование"
                textBox1.Text = "";                                 //Очистка поля с паролем
            }
            else
                MessageBox.Show("Не верный пароль для выбранного пользователя.", "Ошибка");
        }
    }
}
