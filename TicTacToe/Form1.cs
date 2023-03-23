using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe
{
    
    public partial class Form1 : Form
    {
        #region variables
        public enum Player
        {
            X = 'X', O = 'O'
        }
        private bool _firstPlayer;
        private bool _finishGame;
        private int _playerWins;
        private int _pcWins;
        private char realPlayer;
        private char pcPlayer;
        private char[] _gameBoard;
        private Button[] _buttonArr;
        private Random rand = new Random();
        #endregion
        public Form1()
        {
            InitializeComponent();
            _gameBoard = new char[] {
                '-', '-', '-' ,
                '-', '-', '-',
                '-', '-', '-' };
            LoadButtons();
            _firstPlayer = true;
            realPlayer = (char) Player.X;
            pcPlayer = (char) Player.O;
            _finishGame = true;
            _playerWins = 0;
            _pcWins = 0;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (!(_gameBoard.Contains('X') || _gameBoard.Contains('O')) && _finishGame)
            {
                MessageBox.Show("Нажмите кнопку ИГРАТЬ для начала игры!");
                return;
            }
            Button playButton = (Button)sender;
            var index = int.Parse(playButton.Name.Last<char>().ToString());
            _gameBoard[index - 1] = realPlayer;
            if (_firstPlayer) MakeMove(Color.Cyan, realPlayer.ToString(), playButton);
            else MakeMove(Color.Red, realPlayer.ToString(), playButton);
            Check();
            if (!_finishGame)
            {
                label_Message.Text = "Компьютер делает свой выбор...";
                AITimer.Start();
            }
        }

        private void pcMove(object sender, EventArgs e)
        {
            if (!_gameBoard.Contains('-'))
            {
                AITimer.Stop();
                return;
            }
            var moveI = Minimax(_gameBoard, pcPlayer).Index;
            _gameBoard[moveI] = pcPlayer;
            if(_firstPlayer) MakeMove(Color.Red, pcPlayer.ToString(), _buttonArr[moveI]);
            else MakeMove(Color.Cyan, pcPlayer.ToString(), _buttonArr[moveI]);
            Check();
            label_Message.Text = "Компьютер ждет ваш ход!";
            AITimer.Stop();
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
            LoadButtons();
            _gameBoard = new char[9] { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
            label_Message.Text = "Нажмите играть";
            _finishGame = true;
        }

        private void button_Play_Click(object sender, EventArgs e)
        {
            _finishGame = false;
            if (_firstPlayer) { label_Message.Text = "Компьютер ждет ваш ход!"; }
            else
            {
                label_Message.Text = "Компьютер делает свой выбор...";
                _gameBoard[4] = pcPlayer;
                MakeMove(Color.Cyan, pcPlayer.ToString(), _buttonArr[4]);
                label_Message.Text = "Компьютер ждет ваш ход!";
            }
        }

        private void MakeMove(Color color, string text, Button button)
        {
            button.BackColor = color;
            button.Text = text;
            button.Enabled = false;
        }


        private void LoadButtons()
        {
            _buttonArr = new Button[] {
                button_1, button_2, button_3, button_4, button_5, button_6, button_7, button_8, button_9
            };
        }

        private void Check()
        {
            if (IsWin(_gameBoard, realPlayer))
            {
                AITimer.Stop();
                Score(1);
                resetGame();
            }
            else if (IsWin(_gameBoard, pcPlayer))
            {
                AITimer.Stop();
                Score(2);
                resetGame();
            }
            if (!_gameBoard.Contains('-'))
            {
                MessageBox.Show("Ничья!");
                resetGame();
            }
        }

        private void Score(int choice)
        {
            switch (choice)
            {
                case 1:
                    MessageBox.Show("Игрок выиграл!");
                    _playerWins++;
                    labelPlayer.Text = "Игрок выиграл - " + _playerWins;
                    break;
                case 2:
                    MessageBox.Show("Компьютер выиграл!");
                    _pcWins++;
                    labelPC.Text = "Компьютер выиграл - " + _pcWins;
                    break;
            }
        }

        private bool IsWin(char[] board, char str) => board[0] == str && board[1] == str && board[2] == str
               || board[3] == str && board[4] == str && board[5] == str
               || board[6] == str && board[7] == str && board[8] == str
               || board[0] == str && board[3] == str && board[6] == str
               || board[1] == str && board[4] == str && board[7] == str
               || board[2] == str && board[5] == str && board[8] == str
               || board[0] == str && board[4] == str && board[8] == str
               || board[2] == str && board[4] == str && board[6] == str;

        private List<int> EmptyIndexes(char[] board)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == '-') list.Add(i);
            }
            return list;
        }

        private Move Minimax(char[] board, char forWho)
        {
            var availSpots = EmptyIndexes(board);
            Move resultMove = new Move();
            if (IsWin(board, 'X'))
            {
                resultMove.Score = -10;
                return resultMove;
            }
            else if (IsWin(board, 'O'))
            {
                resultMove.Score = 10;
                return resultMove;
            }
            else if (availSpots.Count == 0)
            {
                resultMove.Score = 0;
                return resultMove;
            }


            List<Move> moves = new List<Move>();
            for (int i = 0; i < availSpots.Count; i++)
            {
                Move move = new Move();
                move.Symbol = board[availSpots[i]];

                board[availSpots[i]] = forWho;

                if (forWho == 'O')
                {
                    var result = Minimax(board, 'X');
                    move.Score = result.Score;
                }
                else
                {
                    var result = Minimax(board, 'O');
                    move.Score = result.Score;
                }

                board[availSpots[i]] = move.Symbol;
                move.Index = availSpots[i];
                moves.Add(move);
            }

            var bestMove = 0;
            if (forWho == 'O')
            {
                var bestScore = -10000;
                for (int i = 0; i < moves.Count; i++)
                {
                    if (moves[i].Score > bestScore)
                    {
                        bestScore = moves[i].Score;
                        bestMove = i;
                    }
                }
            }
            else
            {
                var bestScore = 10000;
                for (int i = 0; i < moves.Count; i++)
                {
                    if (moves[i].Score < bestScore)
                    {
                        bestScore = moves[i].Score;
                        bestMove = i;
                    }
                }
            }
            return moves[bestMove];
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _firstPlayer = true;
            pcPlayer =(char) Player.O;
            realPlayer = (char) Player.X;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _firstPlayer = false;
            pcPlayer = (char) Player.X;
            realPlayer =(char) Player.O;
        }
    }
    public class Move
    {
        public int Index { get; set; }

        public char Symbol { get; set; }
        public int Score { get; set; }
        public Move()
        {
            Score = 0;
            Index = 0;
            Symbol = '-';
        }
    }
}
