﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpallmäng
{
    public class Team
    {
        public List<Player> Players { get; } = new List<Player>();
        public string Name { get; private set; }
        public Game Game { get; set; }

        public Team(string name)
        {
            Name = name;
        }

        public void StartGame(int width, int height)
        {
            Random rnd = new Random();
            foreach (var player in Players)
            {
                player.SetPosition(
                    rnd.Next(1, width-1),
                    rnd.Next(4, height-1)
                    );

            }
        }

        public void AddPlayer(Player player)
        {
            if (player.Team != null) return;
            Players.Add(player);
            player.Team = this;
        }

        public (double, double) GetBallPosition()
        {
            return (Game.Ball.X, Game.Ball.Y);
        }

        public void SetBallSpeed(double vx, double vy)
        {
            Game.SetBallSpeedForTeam(this, vx, vy);
        }

        public Player GetClosestPlayerToBall()
        {
            Player closestPlayer = Players[0];
            double bestDistance = Double.MaxValue;
            foreach (var player in Players)
            {
                var distance = player.GetDistanceToBall();
                if (distance < bestDistance)
                {
                    closestPlayer = player;
                    bestDistance = distance;
                }
            }

            return closestPlayer;
        }

        public void Move()
        {
            GetClosestPlayerToBall().MoveTowardsBall();
            Players.ForEach(player => player.Move());
        }
    }
}
