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
    public partial class Form4 : Form
    {

        public string key = "";
        public string number = "";
        public bool test = false;
        public string sum = "";
        public string opertaion = "Перевод средств"; //Название операции


        public Form4()
        {
            InitializeComponent();
            label1.Visible = false;
            textBox2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Visible = false;
            button15.Visible = false;
        }

        public Form4(string key)
        {
            InitializeComponent();
            label1.Visible = false;
            textBox2.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Visible = false;
            button15.Visible = false;
            this.key = key;
        }
        public void soundButton()
        {
            SoundPlayer soundPlayer = new SoundPlayer("b.wav");
            soundPlayer.Load();
            soundPlayer.PlaySync();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            soundButton();
            if (number.Length == 16)
            {
              
                textBox1.Text = null;
                test = true;
                label1.Visible = true;
                monthCalendar1.Visible = false;
                textBox2.Visible = true;
                button15.Visible = true;
            }
            else
                MessageBox.Show("Проверьте номер карты", "Ошибка");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            soundButton();
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            soundButton();
            SoundPlayer soundPlayer = new SoundPlayer("before.wav");
            soundPlayer.Load();
            soundPlayer.Play();
            MessageBox.Show("Заберите карту", "Уведомление");
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            soundButton();
            if (number.Length < 16)
            {
                number += "1";
                textBox1.Text += "1";
            }
            if (test == true && sum.Length < 4)
            {
                sum += "1";
                textBox2.Text += "1";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            soundButton();
            if (number.Length < 16)
            {
                number += "2";
                textBox1.Text += "2";
            }
            if (test == true && sum.Length < 4)
            {
                sum += "2";
                textBox2.Text += "2";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            soundButton();
            if (number.Length < 16)
            {
                number += "3";
                textBox1.Text += "3";
            }
            if (test == true && sum.Length < 4)
            {
                sum += "3";
                textBox2.Text += "3";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            soundButton();
            if (number.Length < 16)
            {
                number += "4";
                textBox1.Text += "4";
            }
            if (test == true && sum.Length < 4)
            {
                sum += "4";
                textBox2.Text += "4";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            soundButton();
            if (number.Length < 16)
            {
                number += "5";
                textBox1.Text += "5";
            }
            if (test == true && sum.Length < 4)
            {
                sum += "5";
                textBox2.Text += "5";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            soundButton();
            if (number.Length < 16)
            {
                number += "6";
                textBox1.Text += "6";
            }
            if (test == true && sum.Length < 4)
            {
                sum += "6";
                textBox2.Text += "6";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            soundButton();
            if (number.Length < 16)
            {
                number += "7";
                textBox1.Text += "7";
            }
            if (test == true && sum.Length < 4)
            {
                sum += "7";
                textBox2.Text += "7";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            soundButton();
            if (number.Length < 16)
            {
                number += "8";
                textBox1.Text += "8";
            }
            if (test == true && sum.Length < 4)
            {
                sum += "8";
                textBox2.Text += "8";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            soundButton();
            if (number.Length < 16)
            {
                number += "9";
                textBox1.Text += "9";
            }
            if (test == true && sum.Length < 4)
            {
                sum += "9";
                textBox2.Text += "9";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            soundButton();
            if (number.Length < 16)
            {
                number += "0";
                textBox1.Text += "0";
            }
            if (test == true && sum.Length>0 && sum.Length < 4 )
            {
                sum += "0";
                textBox2.Text += "0";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            soundButton();
            if (test == false)
            {
                textBox1.Text = null;
            }

            else
            {
                sum = "";
                textBox2.Text = null;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            soundButton();
            MessageBox.Show($"{number}");
            if (Convert.ToInt32(sum) < 1000)
            {
                //Работа с БД (уменьшение средств на счете)
                BD bD = new BD();
                DataSet dataTable = new DataSet();
                DataSet dataTable2 = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT money FROM clients WHERE code = @uc", bD.getConnection());
                command.Parameters.Add("@uc", MySqlDbType.VarChar).Value = key;

                MySqlCommand command2 = new MySqlCommand("SELECT money FROM clients WHERE number = @un", bD.getConnection());
                command2.Parameters.Add("@un", MySqlDbType.VarChar).Value = number;


                adapter.SelectCommand = command;
                adapter.Fill(dataTable);
                MessageBox.Show($"{number}");

                adapter1.SelectCommand = command2;
                adapter1.Fill(dataTable2);

                int summa = int.Parse(textBox2.Text); 
                int amount = 0;
                int new_amount = 0; //Баланс получателя

                if (dataTable.Tables[0].Rows.Count > 0)
                    amount = int.Parse(dataTable.Tables[0].Rows[0][0].ToString());
        
                if (amount < summa)
                {
                    MessageBox.Show("Недостаточно средств","Ошибка");
                }
                else
                {
                    if (dataTable2.Tables[0].Rows.Count > 0)
                        new_amount = int.Parse(dataTable2.Tables[0].Rows[0][0].ToString());

                    MySqlConnection conn = bD.getConnection();
                    string result = (amount - summa).ToString();
                    string new_result = (new_amount + summa).ToString();
                    MessageBox.Show($"Result {result}");
                    MessageBox.Show($"Result {new_result}");
                    MySqlCommand command1 = conn.CreateCommand();
                    MySqlCommand command3 = conn.CreateCommand();
                    command1.CommandText = "UPDATE clients SET money = @res WHERE code = @uckey";
                    command1.Parameters.Add("@res", MySqlDbType.VarChar).Value = result;
                    command1.Parameters.Add("@uckey", MySqlDbType.VarChar).Value = key;

                    command3.CommandText = "UPDATE clients SET money = @newres WHERE number = @un";
                    command3.Parameters.Add("@newres", MySqlDbType.VarChar).Value = new_result;
                    command3.Parameters.Add("@un", MySqlDbType.VarChar).Value = number;

                    conn.Open();
                    command1.ExecuteNonQuery();
                    command3.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Перевод осуществлен", "Уведомление");
                    Form7 form7 = new Form7(summa, opertaion);
                    textBox2.Text = null;
                    this.Close();
                    form7.Show();
                }
            }
            else
            {
                MessageBox.Show("Превышен лимит!", "Ошибка");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
