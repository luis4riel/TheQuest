using System;
using System.Drawing;

namespace TheQuest.WinApp
{
    internal class Ghost : Enemy
    {
        public Ghost(Game game, Point location) : base(game, location, 8){ }

        //está fixo igual ao do bat
        public override void Move(Random random)
        {
            if (HitPoints > 0)
            {
                var action = random.Next(1, 4);
                switch (action)
                {
                    case 1:
                        Direction moveDirection = FindPlayerDirection(_game.PlayerLocation);
                        this._location = this.Move(moveDirection, _game.Boundaries);
                        break;

                    case 2:
                    case 3:
                        break;
                }
            }

            if (NearPlayer() && !Dead)
                _game.HitPlayer(3, random);

        }
    }
}