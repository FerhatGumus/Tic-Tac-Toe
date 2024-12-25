namespace Tic_Tac_Toe.Models
{
    public class User
    {
        public int PlayerNumber { get; set; }
        public List <Score> { get; set; } = new List<Score>();
    }

    public class Score
    {
        public int ScorePoint { get; set; }
    }
}
