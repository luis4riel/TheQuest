using System;
using System.Collections.Generic;
using System.Drawing;

namespace TheQuest.WinApp
{
    internal class Player : Mover
    {
        private Weapon _equippedWeapon;
        private int _hitPoints = 100;
        private List<Weapon> _inventory = new List<Weapon>();

        public int HitPoints { get { return _hitPoints; } }
        public List<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in _inventory)
                    names.Add(weapon.Name);
                return names;
            }
        }

        public Player(Game game, Point location, Rectangle boundaries) : base(game, location)
        {
            _hitPoints = 10;
        }

        internal void Hit(int maxDamage, Random random)
        {
            _hitPoints -= random.Next(1, maxDamage);
        }

        internal void IncreaseHealth(int health, Random random)
        {
            _hitPoints += random.Next(1, health);
        }
        internal void Equip(string weaponName)
        {
            foreach (Weapon weapon in _inventory)
                if (weapon.Name == weaponName)
                    _equippedWeapon = weapon;
        }
        internal void Move(Direction direction)
        {
            _location = Move(direction, _game.Boundaries);
            if (!_game.WeaponInRoom.PickedUp)
            {
                if (Nearby(_game.WeaponInRoom.Location, 25))
                {
                    _inventory.Add(_game.WeaponInRoom);
                    _game.WeaponInRoom.PickUpWeapon();
                }
            }
        }
               
        public void Attack(Direction direction, Random random)
        {
            if (_equippedWeapon != null)
            {
                _equippedWeapon.Attack(direction, random);
            }
        }
    }
}