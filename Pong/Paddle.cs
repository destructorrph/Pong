using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    public class Paddle : Moveable
    {
        Rectangle rect;
        private int dY;
        private Rectangle myBounds;
        private Point startingPoint;

        /// <summary>
        /// Constructs the paddle
        /// </summary>
        /// <param name="sizex"></param>
        /// <param name="sizey"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Paddle(int sizex, int sizey, int x, int y, int speed, Rectangle bounds)
        {
            rect = new Rectangle(x, y, sizex, sizey);
            dY = speed;
            myBounds = bounds;
        }

        /// <summary>
        /// Paints the paddle
        /// </summary>
        /// <param name="g"></param>
        public void paint(Graphics g)
        {
            g.FillRectangle(Brushes.White, rect);
        }

        /// <summary>
        /// Moves the paddle
        /// </summary>
        public void move()
        {
            rect.Offset(0, dY);

            if (rect.Bottom >= myBounds.Bottom || rect.Top <= myBounds.Top)
            {
                dY = dY * -1;
            }
            
        }
        
        /// <summary>
        /// Ignore
        /// </summary>
        /// <param name="m">Pls ignore</param>
        public void changeDirection(Moveable m)
        {

        }

        /// <summary>
        /// Changes the direction based on a keypress
        /// </summary>
        /// <param name="e"></param>
        public void changeDirection(KeyEventArgs e)
        {
            if (e.KeyData == Keys.W || e.KeyData == Keys.Up)
            {
                dY = -Math.Abs(dY);
            }

            if (e.KeyData == Keys.S || e.KeyData == Keys.Down)
            {
                dY = Math.Abs(dY);
            }
        }
        
        /// <summary>
        /// Returns the hitbox
        /// </summary>
        /// <returns>Rectangle</returns>
        public Rectangle getRectangle()
        {
            return rect;
        }

        /// <summary>
        /// Returns the starting point
        /// </summary>
        /// <returns></returns>
        public Point getStartingPoint()
        {
            return startingPoint;
        }

        /// <summary>
        /// Is required to be implemented but is to be ignored
        /// </summary>
        /// <param name="p"></param>
        public void setRectangle(Point p)
        {

        }
    }
}
