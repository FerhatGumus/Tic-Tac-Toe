namespace Tic_Tac_Toe.Models
{
    public class TicTacToeViewModel
    {
        public int[] Board { get; set; }
        public int CurrentPlayer { get; set; }
        public int Player1Score { get; set; }
        public int Player2Score { get; set; }
    }
}
