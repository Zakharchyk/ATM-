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
    public partial class Form2 : Form
    {
        public string key; //ПИН-код пользователя

        public Form2()
        {
            InitializeComponent();
            button6.Visible = false;
            textBox1.Enabled = false;
        }
        public Form2(string key)
        {
            InitializeComponent();
            button6.Visible = false;
            textBox1.Enabled = false;
            this.key = key;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        //Метод, который включает звук нажатия на клавишу
        public void soundButton() 
        {
            SoundPlayer soundPlayer = new SoundPlayer("b.wav");
            soundPlayer.Load();
            soundPlayer.Play();
        }

        //Метод, который завершает работу
        private void button4_Click(object sender, EventArgs e)
        {
            soundButton();

            //Звук завершающий работу банкомата
            SoundPlayer soundPlayer = new SoundPlayer("before.wav");
            soundPlayer.Load();
            soundPlayer.Play();

            //Уведомление о завершении работы
            MessageBox.Show("Заберите карту","Уведомление");
            Application.Exit();
        }

        //Метод, который отвечает за перевод на карту
        private void button2_Click(object sender, EventArgs e)
        {
            soundButton();
            Form4 form4 = new Form4(key);
            form4.Show();
            this.Close();
        }

        //Метод, который отвечает за перевод на мобильный телефон
        private void button1_Click(object sender, EventArgs e)
        {
            soundButton();
            Form6 form6 = new Form6(key);
            form6.Show();
            this.Close();
        }

        //Метод, который отвечает за снятие наличных 
        private void button3_Click(object sender, EventArgs e)
        {
            soundButton();
            Form5 form5 = new Form5(key);
            form5.Show();
            this.Close();
        }

        //Поле отображения состояния счет
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Метод скрывающий состояние счета
        private void button5_Click(object sender, EventArgs e)
        {
            soundButton();
            button6.Visible = true;
            textBox1.Text = "****";
        }

        //Метод, который отображает состояние счета
        private void button6_Click(object sender, EventArgs e)
        {
            soundButton();
            button6.Visible = false;
            textBox1.Text = null;
            
            // Работа с БД
            BD bD = new BD();
            DataSet dataTable = new DataSet();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT money FROM clients WHERE code = @uc", bD.getConnection());
            command.Parameters.Add("@uc", MySqlDbType.VarChar).Value = key;
     
            adapter.SelectCommand = command;
            adapter.Fill(dataTable);

            if (dataTable.Tables[0].Rows.Count > 0)
                textBox1.Text = $"{dataTable.Tables[0].Rows[0][0]}";
            else 
                MessageBox.Show("Технический сбой","Ошибка");

        }
    }
}
