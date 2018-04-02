using System;
using System.Drawing;

namespace TheQuest.WinApp
{
    internal class Mace : Weapon
    {

        public Mace(Game game, Point location) : base(game, location)
        {
        }

        public override string Name{ get { return "Mace"; }}

        public override void Attack(Direction direction, Random random)
        {   
            //esta jogada faz com que a arma atinja um angulo de 360° completo
            for (int i = 0; i < 4; i++)
            {
                DamageEnemy((Direction)i, 20, 6, random);
            }
        }
    }
}