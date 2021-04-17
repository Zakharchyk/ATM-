using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        
        //Поля для отображения в чеке
        public string text = "";
        public string operation = "";
        public int summa = 0;
        
        public Form7()
        {
            InitializeComponent();
        }
        public Form7(int summa,string operation)
        {
            InitializeComponent();
            this.operation = operation;
            this.summa = summa;
        }

        //Звук нажатия на кнопку 
        public void soundButton()
        {
            SoundPlayer soundPlayer = new SoundPlayer("b.wav");
            soundPlayer.Load();
            soundPlayer.Play();
        }

        //Открыть форму для ввода ПИН-кода
        public void exitForm()
        {
            Form3 form3 = new Form3();
            this.Close();
            form3.Show();
        }

        //  Не печатать чек
        private void button2_Click(object sender, EventArgs e)
        {
            soundButton();
            exitForm();
        }

        
       //Печать чека 
        private void button1_Click(object sender, EventArgs e)
        {
            soundButton();
            
            //Вид чека 
            text = "TINKOF-BANK \n" +
                "MINSK,BELARUS \n" +
                $"ОПЕРАЦИЯ: {operation}" +
                $"ДАТА: {DateTime.Now} \n" +
                $"СУММА: {summa} \n" +
                "******* \n" +
                "ОФРМИТЕ КРЕДИТ НА САЙТЕ: \n" +
                "WWW.TINKOFBANK.BY \n";

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += PrintPageHandler;

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print();

            exitForm();
        }

        void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(text,new Font("Arial",14),Brushes.Black,0,0);
        }

        //Забрать карту
        private void button3_Click_1(object sender, EventArgs e)
        {
            soundButton();
            SoundPlayer soundPlayer = new SoundPlayer("before.wav");
            MessageBox.Show("Заберите карту","Уведомление");
            soundPlayer.Load();
            soundPlayer.Play();
            Application.Exit();
        }
    }
}
