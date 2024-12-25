namespace Tic_Tac_Toe.Models
{
    public class GameField
    {
        public List<Box> Fields { get; set; } = new List<Box>();
    }

    public class Box
    {
        public int BoxNumber { get; set; }
    }
}
