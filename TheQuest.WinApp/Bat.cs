using System.Drawing;

namespace TheQuest.WinApp
{
    internal class Bat : Enemy
    {
        private Game game;
        private Point point;
        private Rectangle _boundaries;

        public Bat(Game game, Point location) : base(game, location)
        {
        }
    }
}