using System.Drawing;

namespace TheQuest.WinApp
{
    internal class Ghost : Enemy
    {
        private Game game;
        private Point point;
        private Rectangle _boundaries;

        public Ghost(Game game, Point location) : base(game, location)
        {
        }
    }
}