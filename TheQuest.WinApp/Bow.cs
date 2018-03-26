using System;
using System.Drawing;

namespace TheQuest.WinApp
{
    internal class Bow : Weapon
    {
        private Game game;
        private Point point;

        public Bow(Game game, Point location) : base(game, location)
        {
        }

        public override string Name => "Bow";

        public override void Attack(Direction direction, Random random)
        {
            throw new NotImplementedException();
        }
    }
}