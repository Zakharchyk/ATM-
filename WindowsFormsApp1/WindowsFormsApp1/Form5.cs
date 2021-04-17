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
    public partial class Form5 : Form
    {
        private string sum=""; //Сумма 
        public string key; //ПИН-код
        public string opertaion = "Выдача наличных"; //Название операции
        public Form5()
        {
            InitializeComponent();
            textBox1.Enabled = false;
        }

        public Form5(string key)
        {
            InitializeComponent();
            textBox1.Enabled = false;
            this.key = key;
        }
        private void Form5_Load(object sender, EventArgs e)
        {

        }

        //Метод, который включает звук нажатия на клавишу
        public void soundButton()
        {
            SoundPlayer soundPlayer = new SoundPlayer("b.wav");
            soundPlayer.Load();
            soundPlayer.PlaySync();
        }

        //Выдача денег 
        private void button10_Click(object sender, EventArgs e)
        {
            soundButton();

            //Работа с БД (уменьшение средств на счете)
            BD bD = new BD();
            DataSet dataTable = new DataSet();
            
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT money FROM clients WHERE code = @uc", bD.getConnection());
            command.Parameters.Add("@uc", MySqlDbType.VarChar).Value = key;

            adapter.SelectCommand = command;
            adapter.Fill(dataTable);

            int summa = int.Parse(textBox1.Text);
            int amount = 0;
            if (dataTable.Tables[0].Rows.Count > 0)
                amount = int.Parse(dataTable.Tables[0].Rows[0][0].ToString());
            if (amount < summa)
            {
                MessageBox.Show("Недостаточно средств", "Ошибка");
            }
            else
            {

                MessageBox.Show($"Баланс {amount}");
                if (summa > 1000 || summa < 1)
                {
                    MessageBox.Show("Вы нарушили лимит (от 0 до 1000 рублей)", "Ошибка");
                    textBox1.Text = "";
                }
                else
                {
                    if (summa % 5 == 0) //Проверка н кратность (так как наличная сумма в любом случаи должна делиться на 5)
                    {
                        MySqlConnection conn = bD.getConnection();
                        string result = (amount - summa).ToString();
                        MessageBox.Show($"Result {result}");
                        MySqlCommand command1 = conn.CreateCommand();
                        command1.CommandText = "UPDATE clients SET money = @res WHERE code = @uckey";
                        command1.Parameters.Add("@res", MySqlDbType.VarChar).Value = result;
                        command1.Parameters.Add("@uckey", MySqlDbType.VarChar).Value = key;
                        conn.Open();
                        command1.ExecuteNonQuery();
                        conn.Close();

                        SoundPlayer soundPlayer1 = new SoundPlayer("after.wav");
                        SoundPlayer soundPlayer = new SoundPlayer("cash.wav");
                        soundPlayer1.Load();
                        soundPlayer1.PlaySync();
                        soundPlayer.Load();
                        soundPlayer.PlaySync();
                        textBox1.Text = null;
                        sum = "";
                        Form7 form7 = new Form7(summa, opertaion);
                        form7.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Мы не можем выдыть сумму с таким номиналом", "Ошибка");
                        textBox1.Text = null;
                        sum = "";
                    }
                }
            }
        }

        //Вернуться в меню
        private void button11_Click(object sender, EventArgs e)
        {
            soundButton();
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        //Забрать карту
        private void button12_Click(object sender, EventArgs e)
        {
            soundButton();
            SoundPlayer soundPlayer = new SoundPlayer("before.wav");
            soundPlayer.Load();
            soundPlayer.Play();
            MessageBox.Show("Заберите карту", "Уведомление");
            Application.Exit();
        }

        //Цифра 1 
        private void button1_Click(object sender, EventArgs e)
        {
            soundButton();
            if (sum.Length < 4)
            {
                sum += "1";
                textBox1.Text += "1";
            }
        }

        //Цифра 2
        private void button2_Click(object sender, EventArgs e)
        {
            soundButton();
            if (sum.Length < 4)
            {
                sum += "2";
                textBox1.Text += "2";
            }
        }

        //Цифра 3
        private void button3_Click(object sender, EventArgs e)
        {
            soundButton();
            if (sum.Length < 4)
            {
                sum += "3";
                textBox1.Text += "3";
            }
        }

        //Цифра 4
        private void button4_Click(object sender, EventArgs e)
        {
            soundButton();
            if (sum.Length < 4)
            {
                sum += "4";
                textBox1.Text += "4";
            }
        }

        //Цифра 5
        private void button5_Click(object sender, EventArgs e)
        {
            soundButton();
            if (sum.Length < 4)
            {
                sum += "5";
                textBox1.Text += "5";
            }
        }

        //Цифра 6
        private void button6_Click(object sender, EventArgs e)
        {
            soundButton();
            if (sum.Length < 4)
            {
                sum += "6";
                textBox1.Text += "6";
            }
        }

        //Цифра 7
        private void button7_Click(object sender, EventArgs e)
        {
            soundButton();
            if (sum.Length < 4)
            {
                sum += "7";
                textBox1.Text += "7";
            }
        }
        //Цифра 8
        private void button8_Click(object sender, EventArgs e)
        {
            soundButton();
            if (sum.Length < 4)
            {
                sum += "8";
                textBox1.Text += "8";
            }
        }

        //Цифра 9
        private void button9_Click(object sender, EventArgs e)
        {
            soundButton();
            if (sum.Length < 4)
            {
                sum += "9";
                textBox1.Text += "9";
            }
        }

        //Цифра 0
        private void button13_Click(object sender, EventArgs e)
        {
            soundButton();
            if (sum.Length < 4)
            {
                sum += "0";
                textBox1.Text += "0";
            }
        }

        //Кнопка для очищения строки
        private void button14_Click(object sender, EventArgs e)
        {
            soundButton();
            textBox1.Text = null;
            sum = "";
        }


        //Панель для вывода вводимой суммы 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
