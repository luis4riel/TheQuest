using System;
using System.Drawing;

namespace TheQuest.WinApp
{
    public abstract class Enemy : Mover
    {
        private const int NearPlayerDistance = 25;
        private int _hitPoints;
        public int HitPoints { get { return _hitPoints; } }
        public bool Dead
        {
            get
            {
                if (_hitPoints <= 0)
                    return true;
                else return false;
            }
        }
        public Enemy(Game game, Point location, int hitPoints) : base(game, location)
        {
            this._hitPoints = hitPoints;
        }
        public abstract void Move(Random random);
        public void Hit(int maxDamage, Random random)
        {
            _hitPoints -= random.Next(1, maxDamage);
        }
        protected bool NearPlayer()
        {
            return (Nearby(_game.PlayerLocation, NearPlayerDistance));
        }
        protected Direction FindPlayerDirection(Point playerLocation)
        {
            Direction directionToMove;
            if (playerLocation.X > _location.X + 10)
                directionToMove = Direction.RIGHT;
            else if (playerLocation.X < _location.X - 10)
                directionToMove = Direction.LEFT;
            else if (playerLocation.X < _location.Y - 10)
                directionToMove = Direction.UP;
            else
                directionToMove = Direction.DOWN;
            return directionToMove;
        }
    }
}