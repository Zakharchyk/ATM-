using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {

       public string key = ""; //ПИН-код пользователя
       public int error = 0; //Неправильный ПИН-код

        public Form3()
        {
            InitializeComponent();
            textBox1.Enabled = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }


        //Метод, который включает звук нажатия на клавишу
        public void soundButton()
        {
            SoundPlayer soundPlayer = new SoundPlayer("b.wav");
            soundPlayer.Load();
            soundPlayer.PlaySync();
        }

        //Цифра 1 (кнопка)
        private void button1_Click(object sender, EventArgs e)
        {
            soundButton();
            if (key.Length < 4)
            {
                textBox1.Text += "*";
                key += "1";
            }
        }

        //Цифра 2 (кнопка)
        private void button2_Click(object sender, EventArgs e)
        {
            soundButton();
            if (key.Length < 4)
            {
                textBox1.Text += "*";
                key += "2";
            }
        }

        //Цифра 3 (кнопка)
        private void button3_Click(object sender, EventArgs e)
        {
            soundButton();
            if (key.Length < 4)
            {
                textBox1.Text += "*";
                key += "3";
            }
        }

        //Цифра 4 (кнопка)
        private void button4_Click(object sender, EventArgs e)
        {
            soundButton();
            if (key.Length < 4)
            {
                textBox1.Text += "*";
                key += "4";
            }
        }

        //Цифра 5 (кнопка)
        private void button5_Click(object sender, EventArgs e)
        {
            soundButton();
            if (key.Length < 4)
            {
                textBox1.Text += "*";
                key += "5";
            }
        }

        //Цифра 6 (кнопка)
        private void button6_Click(object sender, EventArgs e)
        {
            soundButton();
            if (key.Length < 4)
            {
                textBox1.Text += "*";
                key += "6";
            }
        }

        //Цифра 7 (кнопка)
        private void button7_Click(object sender, EventArgs e)
        {
            soundButton();
            if (key.Length < 4)
            {
                textBox1.Text += "*";
                key += "7";
            }
        }

        //Цифра 8 (кнопка)
        private void button8_Click(object sender, EventArgs e)
        {
            soundButton();
            if (key.Length < 4)
            {
                textBox1.Text += "*";
                key += "8";
            }
        }

        //Цифра 9 (кнопка)
        private void button9_Click(object sender, EventArgs e)
        {
            soundButton();
            if (key.Length < 4)
            {
                textBox1.Text += "*";
                key += "9";
            }
        }

        //Цифра 0 (кнопка)
        private void button12_Click(object sender, EventArgs e)
        {
            soundButton();
            if (key.Length < 4)
            {
                textBox1.Text += "*";
                key += "0";
            }
        }

        //Кнопка удаление строки
        private void button11_Click(object sender, EventArgs e)
        {
            soundButton();
            key = "";
            textBox1.Text = null;
            MessageBox.Show("Поле очищено", "Уведомеление");
        }

        //Проверка ПИН-кода
        private void button10_Click_1(object sender, EventArgs e)
        {
            soundButton();

            BD bD = new BD();
            DataTable dataTable = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
          
            MySqlCommand command = new MySqlCommand("SELECT * FROM clients WHERE code = @uc",bD.getConnection());
            command.Parameters.Add("@uc",MySqlDbType.VarChar).Value = key;
            adapter.SelectCommand = command;
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0) {                 
                error = 0;
                Form2 form2 = new Form2(key);
                form2.Show();
                this.Close();
            }
            else
            {
                error++;
                MessageBox.Show($"Неверный ввод! Осталось {3 - error} попытки(попыток)", "Ошибка");
                textBox1.Text = null;
                key = "";
            }
            //Емли количество ошибок 3, то происходит блокировка системы
            if (error == 3)
            {
                MessageBox.Show("Вы превысили число допустимых попыток ввода. Достаньте карту", "Доступ заблокирован");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;
                button11.Enabled = false;
                button12.Enabled = false;
            }
            key = "";
        }

        

        //Поле вывода ПИН-кода
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
        
    }
}