using System;
using System.Drawing;

namespace TheQuest.WinApp
{
    public class Enemy : Mover
    {
        public Enemy(Game game, Point location) 
            : base(game, location)
        {
        }

        internal void Move(Random random)
        {
            throw new NotImplementedException();
        }

        internal void Hit(int damage, Random random)
        {
            throw new NotImplementedException();
        }
    }
}