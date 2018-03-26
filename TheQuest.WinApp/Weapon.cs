using System;
using System.Drawing;

namespace TheQuest.WinApp
{
    public abstract class Weapon : Mover
    {
        protected Game game;
        private bool _pickedUp;
        private Point _location;
        public bool PickedUp { get { return _pickedUp; } }
        public Point Location { get { return _location; } }

        public Weapon(Game game, Point location) : base(game, location)
        {
            this.game = game;
            this._location = location;
            _pickedUp = false;
        }
        public void PickUpWeapon() { _pickedUp = true; }
        public abstract string Name { get; }
        public abstract void Attack(Direction direction, Random random);
        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            Point target = game.PlayerLocation;
            for (int distance = 0; distance < radius; distance++)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                    if (Nearby(enemy.Location, target, radius))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
                target = Move(direction, target, game.Boundaries);
            }
            return false;
        }

        private Point Move(Direction direction, Point target, Rectangle boundaries)
        {
            throw new NotImplementedException();
        }

        private bool Nearby(Point location, Point target, int radius)
        {
            throw new NotImplementedException();
        }
    }
}