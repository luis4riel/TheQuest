using System.Drawing;

namespace TheQuest.WinApp
{
    internal class Ghoul : Enemy
    {
        private Game game;
        private Point point;
        private Rectangle _boundaries;

        public Ghoul(Game game, Point location) : base(game, location)
        {
        }
    }
}