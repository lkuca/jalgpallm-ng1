using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jalgpallmäng
{
    public class Player
    {
        //поля и атрибуты
        public string Name { get; } //mängija ja nimi
        public double X { get; private set; }//mängija x kordinaat
        public double Y { get; private set; }//mängija y kordinaat
        private double _vx, _vy;// mängija ja palli kaugus
        public Team? Team { get; set; } = null;//meiskond kus mängija mängib

        private const double MaxSpeed = 5;//max kiirus
        private const double MaxKickSpeed = 25;//max löögi kiirus
        private const double BallKickDistance = 10;//löögi kaugus

        private Random _random = new Random();// juhuslik arv

        public Player(string name)//конструктор
        {
            Name = name;//приравнивание к полю имя
        }

        public Player(string name, double x, double y, Team team)//конструктор игрок на поле
        {
            Name = name;//приравнивание к полю имя
            X = x;//приравнивание к полю x
            Y = y;//приравнивание к полю y
            Team = team;//приравнивание к полю команда
        }

        public void SetPosition(double x, double y)//ставит позицию по коардинатам
        {
            X = x;//приравнивание к полю x
            Y = y;//приравнивание к полю y
        }

        public (double, double) GetAbsolutePosition()//paneb positsioonid 
        {
            return Team!.Game.GetPositionForTeam(Team, X, Y);
        }

        public double GetDistanceToBall()//расчитываем дистанцию мяча по теореме пифогора
        {
            var ballPosition = Team!.GetBallPosition();//
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public void MoveTowardsBall()// двинуть мячь между игроком и мячом
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            var ratio = Math.Sqrt(dx * dx + dy * dy) / MaxSpeed;
            _vx = dx / ratio;
            _vy = dy / ratio;
        }

        public void Move()//движение
        {
            if (Team.GetClosestPlayerToBall() != this)//если игрока рядом нет
            {
                _vx = 0;
                _vy = 0;
            }

            if (GetDistanceToBall() < BallKickDistance)//если дистанция удара мяча не долетела до игрока
            {
                Team.SetBallSpeed(
                    MaxKickSpeed * _random.NextDouble(),
                    MaxKickSpeed * (_random.NextDouble() - 0.5)
                    );
            }

            var newX = X + _vx;
            var newY = Y + _vy;
            var newAbsolutePosition = Team.Game.GetPositionForTeam(Team, newX, newY);
            if (Team.Game.Stadium.IsIn(newAbsolutePosition.Item1, newAbsolutePosition.Item2))
            {
                X = newX;
                Y = newY;
            }
            else
            {
                _vx = _vy = 0;
            }
        }
    }
}