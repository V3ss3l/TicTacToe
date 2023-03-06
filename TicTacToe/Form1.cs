using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public enum Player
        {
            X, O
        }
        private bool _firstPlayer = true;
        private Player realPlayer;
        private Player pcPlayer;
        private int[,] _gameBoard;
        private List<Button> _buttonArr;
        private Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            /* _gameBoard = new int[,]
             {
                 { 0, 0, 0 },
                 { 0, 0, 0 },
                 { 0, 0, 0}
             };*/
            loadButtons();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _firstPlayer = false;
            realPlayer = Player.O;
            pcPlayer = Player.X;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _firstPlayer = true;
            realPlayer = Player.X;
            pcPlayer = Player.O;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button playButton = (Button)sender;
            if (_firstPlayer) playButton.BackColor = Color.Cyan;
            else playButton.BackColor = Color.Red;
            playButton.Text = realPlayer.ToString();
            playButton.Enabled = false;
            //var index = _buttonArr.IndexOf(playButton);
            _buttonArr.Remove(playButton);
            Check();
            label_Message.Text = "Компьютер делает свой выбор...";
            AITimer.Start();
        }

        private void pcMove(object sender, EventArgs e)
        {
            if(_buttonArr.Count > 0)
            {
                var index = rand.Next(_buttonArr.Count);
                _buttonArr[index].Enabled = false;
                _buttonArr[index].Text = pcPlayer.ToString();
                if (_firstPlayer) _buttonArr[index].BackColor = Color.Red;
                else _buttonArr[index].BackColor = Color.Cyan;
                _buttonArr.RemoveAt(index);
                label_Message.Text = "Компьютер ждет ваш ход!";
                AITimer.Stop();
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            resetGame();
        }

        private void resetGame()
        {
            foreach (Control X in this.Controls)
            {
                if (X is Button && X.Tag == "play")
                {
                    ((Button)X).Enabled = true;
                    ((Button)X).Text = string.Empty;
                    ((Button)X).BackColor = default(Color);
                }
            }
            loadButtons();
            label_Message.Text = "Нажмите играть";
        }

        private void button_Play_Click(object sender, EventArgs e)
        {
            if (!_firstPlayer)
            {
                label_Message.Text = "Компьютер делает свой ход...";
                button_5.Enabled = false;
                button_5.Text = pcPlayer.ToString();
                button_5.BackColor = Color.Red;
                _buttonArr.Remove(button_5);
            }
            else
            {
                label_Message.Text = "Компьютер ждет ваш ход!";
            }
        }

        private void loadButtons()
        {
            _buttonArr = new List<Button> {
                button_1, button_2, button_3, button_4, button_5, button_6, button_7, button_8, button_9
            };
        }

        private void Check()
        {
            if (button_1.Text == "X" && button_2.Text == "X" && button_3.Text == "X"
               || button_4.Text == "X" && button_5.Text == "X" && button_6.Text == "X"
               || button_7.Text == "X" && button_9.Text == "X" && button_8.Text == "X"
               || button_1.Text == "X" && button_4.Text == "X" && button_7.Text == "X"
               || button_2.Text == "X" && button_5.Text == "X" && button_8.Text == "X"
               || button_3.Text == "X" && button_6.Text == "X" && button_9.Text == "X"
               || button_1.Text == "X" && button_5.Text == "X" && button_9.Text == "X"
               || button_3.Text == "X" && button_5.Text == "X" && button_7.Text == "X")
            {
                AITimer.Stop();
                MessageBox.Show("Игрок выиграл!");
                //label_Message.Text = "Игрок выиграл!";
                resetGame();
            }
            else if (button_1.Text == "O" && button_2.Text == "O" && button_3.Text == "O"
            || button_4.Text == "O" && button_5.Text == "O" && button_6.Text == "O"
            || button_7.Text == "O" && button_9.Text == "O" && button_8.Text == "O"
            || button_1.Text == "O" && button_4.Text == "O" && button_7.Text == "O"
            || button_2.Text == "O" && button_5.Text == "O" && button_8.Text == "O"
            || button_3.Text == "O" && button_6.Text == "O" && button_9.Text == "O"
            || button_1.Text == "O" && button_5.Text == "O" && button_9.Text == "O"
            || button_3.Text == "O" && button_5.Text == "O" && button_7.Text == "O")
            {
                AITimer.Stop();
                MessageBox.Show("Игрок выиграл!");
                resetGame();
            }
        }
    }
}
