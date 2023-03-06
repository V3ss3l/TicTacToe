using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        private bool _firstPlayer = true;
        private bool isMoveFinished = false;
        private int[,] _gameBoard;
        public Form1()
        {
            InitializeComponent();
            _gameBoard = new int[,]
            {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 0, 0, 0}
            };
            foreach (Label i in tableLayoutPanel1.Controls)
            { 
                i.Click += new EventHandler(label_Click);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _firstPlayer = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _firstPlayer = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_firstPlayer)
            {
                _gameBoard[2, 2] = 2;
                label_5.Text = "X";
                label_Message.Text = "Теперь ваш ход!";
            }
            else
            {
                label_Message.Text = "Ваш ход первый!";
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            Label buff = (Label)sender;
            if(_firstPlayer)
            {
                buff.Text = "X";
                pcMove()
            }
            else
            {
                buff.Text = "X";
            }
        }

        private void pcMove()
        {

        }
    }
}
