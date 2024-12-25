using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TicTacToeApp.Controllers
{
    public class TicTacToeController : Controller
    {
        private static int[] _board = new int[9];
        private static int _currentPlayer = 1;
        private static int _player1Score = 0;
        private static int _player2Score = 0;

        public IActionResult Index()
        {
            return View(new TicTacToeViewModel
            {
                Board = _board,
                CurrentPlayer = _currentPlayer,
                Player1Score = _player1Score,
                Player2Score = _player2Score
            });
        }

        [HttpPost]
        public IActionResult MakeMove(int cellIndex)
        {
            if (_board[cellIndex] == 0) // Check if the cell is empty
            {
                _board[cellIndex] = _currentPlayer;

                int? winner = CheckWinner();
                if (winner != null)
                {
                    if (winner == 1)
                        _player1Score++;
                    else if (winner == 2)
                        _player2Score++;

                    // Reset the board after a win
                    _board = new int[9];
                }
                else
                {
                    // Switch to the other player
                    _currentPlayer = _currentPlayer == 1 ? 2 : 1;
                }
            }

            return RedirectToAction("Index");
        }

        private int? CheckWinner()
        {
            int[][] winningPatterns = new int[][]
            {
                new int[] { 0, 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 6, 7, 8 }, // Rows
                new int[] { 0, 3, 6 }, new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 }, // Columns
                new int[] { 0, 4, 8 }, new int[] { 2, 4, 6 }                         // Diagonals
            };

            foreach (var pattern in winningPatterns)
            {
                int a = pattern[0], b = pattern[1], c = pattern[2];
                if (_board[a] != 0 && _board[a] == _board[b] && _board[a] == _board[c])
                {
                    return _board[a];
                }
            }

            return null;
        }
    }

    public class TicTacToeViewModel
    {
        public int[] Board { get; set; }
        public int CurrentPlayer { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
    }
}
