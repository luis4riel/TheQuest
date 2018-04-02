using System;
using System.Drawing;

namespace TheQuest.WinApp
{
    internal class Bat : Enemy
    {
        public Bat(Game game, Point location) : base(game, location, 6) { }
        public override void Move(Random random)
        {
            if (random.Next(1, 2) == 1 && HitPoints > 0)
            {
                _location = Move(FindPlayerDirection(_game.PlayerLocation), _game.Boundaries);
            }
            else
            {
                _location = Move((Direction)random.Next(1, 4), _game.Boundaries);
            }
            if (NearPlayer())
            {
                _game.HitPlayer(2, random);
            }
        }
    }
}