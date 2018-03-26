using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheQuest.WinApp
{
    public class Game
    {
        public List<Enemy> Enemies;
        public Weapon WeaponInRoom;
        private Player player;
        public Point PlayerLocation { get { return player.Location; } }
        public int PlayerHitPoints { get { return player.HitPoints; } }
        public List<string> PlayerWeapons { get { return player.Weapons; } }
        private int _level = 0;
        public int Level { get { return _level; } }
        private Rectangle _boundaries;
        public Rectangle Boundaries { get { return _boundaries; } }

        public Game(Rectangle boundaries)
        {
            this._boundaries = boundaries;
            player = new Player(this, new Point(boundaries.Left + 10, boundaries.Top + 70), boundaries);
        }

        public void Move(Direction direction, Random random)
        {
            player.Move(direction); ;
            foreach (Enemy enemy in Enemies)
                enemy.Move(random);
        }
        public void Equip(string weaponName)
        {
            player.Equip(weaponName);
        }
        public bool CheckPlayerInventory(string weaponName)
        {
            return player.Weapons.Contains(weaponName);
        }
        public void HitPlayer(int maxDamage, Random random)
        {
            player.Hit(maxDamage, random);
        }
        public void IncreasePlayerHealth(int health, Random random)
        {
            player.IncreaseHealth(health, random);
        }
        public void Attack(Direction direction, Random random)
        {
            player.Attack(direction, random); ;
            foreach (Enemy enemy in Enemies)
                enemy.Move(random);
        }
        private Point GetRandomLocation(Random random)
        {
            return new Point(
                    _boundaries.Left +
                random.Next(Boundaries.Right / 10 - _boundaries.Left / 10) * 10,
                    _boundaries.Top +
                random.Next(_boundaries.Bottom / 10 - _boundaries.Top / 10) * 10);
        }
        public void NewLevel(Random random)
        {
            _level++;
            switch (_level)
            {
                case 1:
                    Enemies = new List<Enemy>();
                    Enemies.Add(new Bat(this, GetRandomLocation(random)));
                    WeaponInRoom = new Sword(this, GetRandomLocation(random));
                    break;
                case 2:
                    Enemies.Clear();
                    Enemies.Add(new Ghost(this, GetRandomLocation(random)));
                    WeaponInRoom = new BluePotion(this, GetRandomLocation(random));
                    break;
                case 3:
                    Enemies.Clear();
                   Enemies.Add(new Ghoul(this, GetRandomLocation(random)));
                    WeaponInRoom = new Bow(this, GetRandomLocation(random));
                    break;
                case 4:
                    Enemies.Clear();
                    Enemies.Add(new Bat(this, GetRandomLocation(random)));
                   Enemies.Add(new Ghost(this, GetRandomLocation(random)));
                    WeaponInRoom = null;
                    if (CheckPlayerInventory("Bow"))
                    {
                        WeaponInRoom = new BluePotion(this, GetRandomLocation(random));
                    }
                    else
                    {
                        WeaponInRoom = new Bow(this, GetRandomLocation(random));
                    }
                    break;
                case 5:
                    Enemies.Clear();
                   Enemies.Add(new Bat(this, GetRandomLocation(random)));
                  Enemies.Add(new Ghoul(this, GetRandomLocation(random)));
                    WeaponInRoom = new RedPotion(this, GetRandomLocation(random));
                    break;
                case 6:
                    Enemies.Clear();
                  Enemies.Add(new Ghost(this, GetRandomLocation(random)));
                  Enemies.Add(new Ghoul(this, GetRandomLocation(random)));
                    WeaponInRoom = new Mace(this, GetRandomLocation(random));
                    break;
                case 7:
                    Enemies.Clear();
                   Enemies.Add(new Bat(this, GetRandomLocation(random)));
                    Enemies.Add(new Ghost(this, GetRandomLocation(random)));
                    Enemies.Add(new Ghoul(this, GetRandomLocation(random)));
                    WeaponInRoom = null;
                    if (CheckPlayerInventory("Mace"))
                    {
                        WeaponInRoom = new RedPotion(this, GetRandomLocation(random));
                    }
                    else
                    {
                        WeaponInRoom = new Mace(this, GetRandomLocation(random));
                    }
                    break;
                case 8:
                    Application.Exit();
                    break;
            }
        }

        internal bool IsWeaponEquipped(string name)
        {
            throw new NotImplementedException();
        }
    }
}
