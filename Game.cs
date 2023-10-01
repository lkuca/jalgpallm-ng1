using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpallmäng
{
    public class Game
    {
        public Team HomeTeam { get; }
        public Team AwayTeam { get; }
        public Stadium Stadium { get; }
        public Ball Ball { get; private set; }

        public Build Build { get; }


        public Game(Team homeTeam, Team awayTeam, Stadium stadium, Build build)
        {
            HomeTeam = homeTeam;
            homeTeam.Game = this;
            AwayTeam = awayTeam;
            awayTeam.Game = this;
            Stadium = stadium;
            Build = build;
            
        }

        public void Start()
        {
            Ball = new Ball(Stadium.Width / 2, Stadium.Height / 2, this);
            HomeTeam.StartGame(Stadium.Width / 2, Stadium.Height);
            AwayTeam.StartGame(Stadium.Width / 2, Stadium.Height);
            Build.SetPlayer(Ball.X, Ball.Y, "⚫");
            
        }
        private (double, double) GetPositionForAwayTeam(double x, double y)
        {
            return (Stadium.Width - x, Stadium.Height - y);
        }

        public (double, double) GetPositionForTeam(Team team, double x, double y)
        {
            return team == HomeTeam ? (x, y) : GetPositionForAwayTeam(x, y);
        }

        public (double, double) GetBallPositionForTeam(Team team)
        {
            return GetPositionForTeam(team, Ball.X, Ball.Y);
        }

        public void SetBallSpeedForTeam(Team team, double vx, double vy)
        {
            if (team == HomeTeam)
            {
                Ball.SetSpeed(vx, vy);
            }
            else
            {
                Ball.SetSpeed(-vx, -vy);
            }
        }
        public (double, double) GetPositionForBall(Ball ball, double x, double y, string sym)
        {
            return GetPositionForBall(ball, ball.X, ball.Y, sym);
        }


        public void Move()
        {
            HomeTeam.Move();
            AwayTeam.Move();
            Ball.Move();
        }
    }
}
