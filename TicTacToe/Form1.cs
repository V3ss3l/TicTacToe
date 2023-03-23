//
// Программа создана студентом 3-ИАИТ-3 Анисимовым Г.А.
//
//23.03.23

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TicTacToe
{

    public partial class TicTacToe : Form
    {
        #region variables
        public enum Player // перечисления для удобного задания символа игрока и ИИ
        {
            X = 'X', O = 'O'
        }
        private bool _firstPlayer; // булевая переменная для проверки, кто первый ходит (пользователь или компьютер)
        private bool _finishGame; // булевая переменная для проверки на окончание игры
        private int _playerWins; // счетчик побед игрока
        private int _pcWins; // счетчик побед компьютера
        private char realPlayer; // символ пользователя (Х или О)
        private char pcPlayer; // символ компьютера (О или Х)
        private char[] _gameBoard; // переменная игрового поля
        private Button[] _buttonArr; // массив кнопок с формы
        #endregion
        public TicTacToe()
        {
            InitializeComponent();
            
            _gameBoard = new char[] {
                '-', '-', '-' ,
                '-', '-', '-',
                '-', '-', '-' };
            _buttonArr = new Button[] {
                button_1, button_2, button_3, button_4, button_5, button_6, button_7, button_8, button_9
            };
            _firstPlayer = true;
            realPlayer = (char)Player.X;
            pcPlayer = (char)Player.O;
            _finishGame = true;
            _playerWins = 0;
            _pcWins = 0;
        }

        /// <summary>
        /// Метод, обрабатывающий клик на кнопку со стороны пользователя (сделать ход за пользователя)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Метод отвечающий за ход компьютера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pcMove(object sender, EventArgs e)
        {
            if (!_gameBoard.Contains('-'))
            {
                AITimer.Stop();
                return;
            }
            var moveI = Minimax(_gameBoard, pcPlayer).Index;
            _gameBoard[moveI] = pcPlayer;
            if (_firstPlayer) MakeMove(Color.Red, pcPlayer.ToString(), _buttonArr[moveI]);
            else MakeMove(Color.Cyan, pcPlayer.ToString(), _buttonArr[moveI]);
            Check();
            label_Message.Text = "Компьютер ждет ваш ход!";
            AITimer.Stop();
        }

        /// <summary>
        /// Обработчик события очистки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Clear_Click(object sender, EventArgs e)
        {
            resetGame();
        }

        /// <summary>
        /// Метод очищающий всю игру (все состояния и ходы)
        /// </summary>
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
            _buttonArr = new Button[] { button_1, button_2, button_3, button_4, button_5, button_6, button_7, button_8, button_9 };
            _gameBoard = new char[9] { '-', '-', '-', '-', '-', '-', '-', '-', '-' };
            label_Message.Text = "Нажмите играть";
            _finishGame = true;
        }

        /// <summary>
        /// Обработчик события нажатия на клавишу старта игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Метод отвечающий за исполнения хода игрока или компьютера
        /// </summary>
        /// <param name="color"></param>
        /// <param name="text"></param>
        /// <param name="button"></param>
        private void MakeMove(Color color, string text, Button button)
        {
            button.BackColor = color;
            button.Text = text;
            button.Enabled = false;
        }

        /// <summary>
        /// Метод отвечающий за проверки победы или поражения или ничьи в игре
        /// </summary>
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

        /// <summary>
        /// Метод подсчитывающий количество побед игроков и вывод сообщений о победе или проигрыше или ничье
        /// </summary>
        /// <param name="choice"></param>
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

        /// <summary>
        /// Метод проверяющий выигрыш пользователя или компьютера
        /// </summary>
        /// <param name="board"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool IsWin(char[] board, char str) => board[0] == str && board[1] == str && board[2] == str
               || board[3] == str && board[4] == str && board[5] == str
               || board[6] == str && board[7] == str && board[8] == str
               || board[0] == str && board[3] == str && board[6] == str
               || board[1] == str && board[4] == str && board[7] == str
               || board[2] == str && board[5] == str && board[8] == str
               || board[0] == str && board[4] == str && board[8] == str
               || board[2] == str && board[4] == str && board[6] == str;

        /// <summary>
        /// Метод находящий пустые индексы в игровом поле
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private List<int> EmptyIndexes(char[] board)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == '-') list.Add(i);
            }
            return list;
        }

        /// <summary>
        /// Метод реализующий алгоритм Минимакс для исполнения хода компьютера
        /// </summary>
        /// <param name="board"></param>
        /// <param name="forWho"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Обработчик события кнопки выбора первого игрока - пользователь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _firstPlayer = true;
            pcPlayer = (char)Player.O;
            realPlayer = (char)Player.X;
        }

        /// <summary>
        /// Обработчик события кнопки выбора первого игрока - ИИ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _firstPlayer = false;
            pcPlayer = (char)Player.X;
            realPlayer = (char)Player.O;
        }
    }
    /// <summary>
    /// Вспомагательный класс реализующий ход компьютера (поля: Символ, Индекс, Счет)
    /// </summary>
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
