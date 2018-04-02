using System;
using System.Drawing;

namespace TheQuest.WinApp
{
    internal class Sword : Weapon
    {
        public Sword(Game game, Point location) : base(game, location)
        {
        }

        public override string Name { get { return "Sword"; } }

        public override void Attack(Direction direction, Random random)
        {
            DamageEnemy(direction, 10, 5, random);

            //var directionForAttack = direction;

            //while (!DamageEnemy(directionForAttack, 10, 3, random) && (int)directionForAttack <= 3)
            //{
            //    directionForAttack++;
            //}

            //while (!DamageEnemy(directionForAttack, 10, 3, random) && (int)directionForAttack >= 0)
            //{
            //    directionForAttack--;
            //}
        }
    }
        
}