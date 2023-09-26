using jalgpallmäng;
namespace jalgpallmäng
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(130, 30);
            Walls walls = new Walls(120, 30);
            walls.Draw();
            List<Figure> wallList = new List<Figure> { };
            // Отрисовка точек			
            Point p = new Point(4, 5, '*');
            Stadium stadium = new Stadium(110, 130);
            Team team11 = new Team("gtarp");
            Team team1 = new Team("nohomo");
            Game game = new Game(team11, team1, stadium);
            Ball ball = new Ball(340, 24,game);
            Player palyer1 = new Player("leha");
            Player player2 = new Player("TOHA");
            Build build = new Build();           

            team11.AddPlayer(palyer1);
            team11.AddPlayer(player2);
            team11.StartGame(126, 28);
            team1.StartGame(126, 28);
            build.SetPlayer(palyer1.X, palyer1.Y, "leha");
            build.SetPlayer(player2.X, player2.Y, "TOHA");
            

            game.Start();
            while (true) ;
        }
    }
}
