using System;
using System.Drawing;

namespace TheQuest.WinApp
{
    internal class Mace : Weapon
    {
        private Game game;
        private Point point;
        public Mace(Game game, Point location) : base(game, location)
        {
        }

        public override string Name => "Mace";

        public override void Attack(Direction direction, Random random)
        {
            throw new NotImplementedException();
        }
    }
}