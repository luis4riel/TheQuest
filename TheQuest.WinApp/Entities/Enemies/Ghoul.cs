using System;
using System.Drawing;

namespace TheQuest.WinApp
{
    internal class Ghoul : Enemy
    {
        public Ghoul(Game game, Point location) : base(game, location, 10){ }

        //está fixo igual ao do bat
        public override void Move(Random random)
        {
            if (HitPoints > 0)
            {
                var action = random.Next(1, 4);
                switch (action)
                {
                    case 1:
                        break;

                    case 2:
                    case 3:
                        Direction moveDirection = FindPlayerDirection(_game.PlayerLocation);
                        this._location = this.Move(moveDirection, _game.Boundaries);
                        break;
                }
            }

            if (NearPlayer() && !Dead)
                _game.HitPlayer(4, random);
        }
    }
}