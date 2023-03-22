using System;
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
            X, O
        }
        private bool _finishGame;
        private int _playerWins;
        private int _pcWins;
        private Player realPlayer;
        private Player pcPlayer;
        private char[] _gameBoard;
        private Button[] _buttonArr;
        private Random rand = new Random();
        #endregion
        public Form1()
        {
            InitializeComponent();
            _gameBoard = new char[9] { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
            LoadButtons();
            realPlayer = Player.X;
            pcPlayer = Player.O;
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
            _gameBoard[index - 1] = 'X';
            MakeMove(Color.Cyan, realPlayer.ToString(), playButton);
            Check();
            if (!_finishGame)
            {
                label_Message.Text = "Компьютер делает свой выбор...";
                AITimer.Start();
            }
        }

        private void pcMove(object sender, EventArgs e)
        {
            if (!_gameBoard.Contains('-')) AITimer.Stop();
            var bestScore = int.MinValue;
            var moveI = -1;
            for (int i = 0; i < _gameBoard.Length; i++)
            {
                if (_gameBoard[i] == '-')
                {
                    _gameBoard[i] = 'O';
                    var score = Minimax(_gameBoard, 'O');
                    _gameBoard[i] = '-';
                    if (score > bestScore)
                    {
                        bestScore = score;
                        moveI = i;
                    }
                }
            }
            _gameBoard[moveI] = 'O';
            MakeMove(Color.Red, pcPlayer.ToString(), _buttonArr[moveI]);
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
            label_Message.Text = "Компьютер ждет ваш ход!";
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
            if (IsWin(_gameBoard, 'X'))
            {
                AITimer.Stop();
                Score(1);
                resetGame();
            }
            else if (IsWin(_gameBoard, 'O'))
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

        private int CheckWhoWins(char[] board, char str)
        {
            if (IsWin(board, str))
            {
                var score = 1;
                for (int i = 0; i < board.Length; i++)
                    if (board[i] == '-') score++;
                return score;
            }
            else return 0;
        }

        private int EmptyIndexes(char[] board)
        {
            var count = 0;
            for(int i = 0; i < board.Length; i++)
            {
                if (board[i] == '-') count++;
            }
            return count;
        }

        private int Minimax(char[] board, char forWho)
        {
           var availSpots = EmptyIndexes(board);

           if(IsWin(board, 'X')) { return -10; }
           else if(IsWin(board, 'O')) { return 10; }
           else if(availSpots == 0) { return 0; }

            /* var score = CheckWhoWins(board, forWho);
            if (score != 0)
            {
                return score;
            }

            var bestScore = forWho == 'O' ? int.MinValue : int.MaxValue;

            int CalcBest(int x, int y) => (forWho == 'O' ? x > y : y > x) ? x : y;

            for (var i = 0; i < board.Length; i++)
            {
                if (board[i] == '-')
                {
                    board[i] = forWho;
                    var currentScore = Minimax(board, forWho == 'O' ? 'X' : 'O');
                    board[i] = '-';

                    bestScore = CalcBest(bestScore, currentScore);
                }
            }
            return bestScore;*/
        }
    }
}
