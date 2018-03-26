using System;
using System.Drawing;

namespace TheQuest.WinApp
{
    internal class Sword : Weapon
    {
        private Game game;
        private Point location;

        public Sword(Game game, Point location) : base(game, location)
        {
        }

        public override string Name { get { return "Sword"; } }

        public override void Attack(Direction direction, Random random)
        {
           
        }
    }
        
}