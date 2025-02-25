using System.Diagnostics;

class Player
{
    private string initials { get; set; }
    private int score { get; set; }

    public string Initials { get; set; }

    public int Score { get; set; }

    public Player(string initials, int score)
    {
        this.Initials = initials;
        this.Score = score;
    }


    static void Main()
    {
        Player bob = new Player("JRS", 200);
        Console.WriteLine($"Player: {bob.Initials} Score: {bob.Score}");
    }
}






