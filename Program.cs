using jalgpallmäng;
namespace jalgpallmäng
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(130, 60);
            Walls walls = new Walls(42, 22);
            walls.Draw();
            List<Figure> wallList = new List<Figure> { };
            // Отрисовка точек			
            Point p = new Point(4, 5, '*');
            Stadium stadium = new Stadium(40, 20);
            Team team11 = new Team("gtarp");
            Team team1 = new Team("nohomo");
            Build build = new Build();
            Game game = new Game(team11, team1, stadium,build);
            //Ball ball = new Ball(100, 190,game);
            Player palyer1 = new Player("leha");
            Player player2 = new Player("TOHA");
                       
            //codewars
            team11.AddPlayer(palyer1);
            team1.AddPlayer(player2);
            team11.StartGame(40, 20);
            team1.StartGame(40, 20);
            //build.SetPlayer(palyer1.X, palyer1.Y, "L");
            //build.SetPlayer(player2.X, player2.Y, "T");

            //build.GetPositionForBall( ball ,ball.X, ball.Y, "☀");

            game.Start();
            while (true)
            {
                build.SetPlayer(palyer1.X, palyer1.Y, "L");
                build.SetPlayer(player2.X, player2.Y, "T");
                build.SetPlayer(game.Ball.X, game.Ball.Y, "o");

                Thread.Sleep(500);
                build.SetPlayer(palyer1.X, palyer1.Y, " ");
                build.SetPlayer(player2.X, player2.Y, " ");
                build.SetPlayer(game.Ball.X, game.Ball.Y, " ");

                game.Move();

            }
        }
    }

}