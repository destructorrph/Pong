using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    public class Ball : Moveable
    {
        private Point startingPoint;
        private Rectangle rect;
        private Rectangle myBounds;
        private int dx, dy;

        /// <summary>
        /// Constructs a new ball object
        /// </summary>
        /// <param name="size">Size of the ball</param>
        /// <param name="x">X Location</param>
        /// <param name="y">Y location</param>
        /// <param name="bounds">Bounds</param>
        /// <param name="speed">Speed of the ball</param>
        /// <param name="startDir">The direction in which the balls go</param>
        public Ball(int size, int x, int y, Rectangle bounds, int speed, int startDir)
        {
            rect = new Rectangle(x, y, size, size);
            dx = dy = speed / 2;
            myBounds = bounds;
            startDirection(startDir);
            startingPoint = rect.Location;
        }

        /// <summary>
        /// Paints the ball
        /// </summary>
        /// <param name="g">Graphics object</param>
        public void paint(Graphics g)
        {
            g.FillEllipse(Brushes.White, rect);
        }

        /// <summary>
        /// Generates a starting direction to go
        /// </summary>
        /// <param name="startDir"></param>
        public void startDirection(int startDir)
        {
            switch (startDir)
            {
                case 0: break;
                case 1: dx = dx * -1; break;
                case 2: dy = dy * -1; break;
                case 3: dx = dx * -1; dy = dy * -1; break;
            }
        }

        /// <summary>
        /// Moves the ball
        /// </summary>
        public void move()
        {
            rect.Offset(dx, dy);
            
             if (rect.Bottom >= myBounds.Bottom ||
                rect.Top <= myBounds.Top)
            {
                dy = -dy;
            }

            
        }

        /// <summary>
        /// Changes the direction given the object
        /// </summary>
        /// <param name="m"></param>
        public void changeDirection(Moveable m)
        {
            if (m is Paddle)
            {
                dx = dx * -1;
            }
            else if (m is Ball)
            {
                dy = dy * -1;
            }

        }

        /// <summary>
        /// Does nothing, please ignore
        /// </summary>
        /// <param name="e"></param>
        public void changeDirection(KeyEventArgs e)
        {

        }
        
        /// <summary>
        /// Returns a rectangle
        /// </summary>
        /// <returns>A rectangle</returns>
        public Rectangle getRectangle()
        {
            return rect;
        }

        /// <summary>
        /// Returns the starting point
        /// </summary>
        /// <returns>The starting point</returns>
        public Point getStartingPoint()
        {
            return startingPoint;
        }

        /// <summary>
        /// Sets the rectangle
        /// </summary>
        /// <param name="r"></param>
        public void setRectangle(Point r)
        {
            rect.Location = r;
        }
    }
}
