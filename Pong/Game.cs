using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    
    public class Game
    {
        const int NUMBER_OF_BALLS = 1;
        const int NUMBER_OF_PADDLES = 2;
        const int LOSING_NUM = 10;
        const int BALL_SIZE = 10;
        const int PADDLE_SIZE = 50;
        const int EDGE_SPACE = 50;
        const int SPEED = 5;
        private Rectangle myBounds;
        List<Moveable> Movables = new List<Moveable> ();
        static Random rand = new Random();
        int playerOneScore = 0;
        int playerTwoScore = 0;

        public Game(Rectangle bounds)
        {
            myBounds = bounds;
            for (int i = 0; i <= NUMBER_OF_PADDLES; i++)
            {
                switch (i)
                {
                    case 1: Movables.Add(new Paddle(10, PADDLE_SIZE, bounds.Left + EDGE_SPACE, bounds.Height / 2, SPEED, bounds)); break;
                    case 2: Movables.Add(new Paddle(10, PADDLE_SIZE, bounds.Right - EDGE_SPACE, bounds.Height / 2, SPEED, bounds)); break;
                }
            }
            
                Movables.Add(new Ball(BALL_SIZE, bounds.Width / 2, bounds.Height / 2, bounds, SPEED, rand.Next(4)));
                
        }

        /// <summary>
        /// Paints all the items
        /// </summary>
        /// <param name="g">Graphics Object</param>
        public void paint(Graphics g)
        {
            foreach (Moveable item in Movables)
            {
                item.paint(g);
            }
        } 

        /// <summary>
        /// Moves the objects
        /// </summary>
        public void move()
        {
            foreach (Moveable item in Movables)
            {
                item.move();
            }
        }

        /// <summary>
        /// Detects collision
        /// </summary>
        public void detectCollision()
        {
            for (int i = 0; i < Movables.Count; i++)
            {
                for (int x = 0; x < Movables.Count; x++)
                {
                    if (Movables[i] != Movables[x] && Movables[i].getRectangle().IntersectsWith(Movables[x].getRectangle()))
                    {
                        Movables[i].changeDirection(Movables[x]);
                    }
                }
            }
            
        }

        /// <summary>
        /// Checks if someone has won
        /// </summary>
        /// <returns></returns>
        public bool checkForWin()
        {
            if (playerOneScore >= 11)
            {
                return true;
            }
            else if (playerTwoScore >= 11)
            {
                return true;
            }
            else { return false; }

        }

        /// <summary>
        /// Displays the winning player
        /// </summary>
        public void displayWin()
        {
            if (playerOneScore >= 11)
            {
                MessageBox.Show("Player One Has Won!");
            }
            else if (playerTwoScore >= 11)
            {
                MessageBox.Show("Player Two Has Won!");
            }
            else{ }

        }

        /// <summary>
        /// Changes the direction of the object when it hits something
        /// </summary>
        /// <param name="e">Graphics object</param>
        public void changeDirection(KeyEventArgs e)
        {
            if (e.KeyData == Keys.W || e.KeyData == Keys.S)
            {
                Movables[0].changeDirection(e);
            }

            if(e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                Movables[1].changeDirection(e);
            }

        }

        /// <summary>
        /// Checks if a ball has scored
        /// </summary>
        public void checkForScore()
        {
            for (int i = 0; i < Movables.Count; i++)
            {
                if (Movables[i].getRectangle().Right >= myBounds.Right)
                {
                    Movables[i].setRectangle(Movables[i].getStartingPoint());
                    playerOneScore++;
                }

                if (Movables[i].getRectangle().Left <= myBounds.Left)
                {
                    Movables[i].setRectangle(Movables[i].getStartingPoint());
                    playerTwoScore++;
                }
            }
            
        }

        /// <summary>
        /// Gets the scores of each player
        /// </summary>
        /// <param name="player"></param>
        /// <returns>The scores of the given player</returns>
        public int getScores(int player)
        {
            if (player == 0)
            {
                return playerOneScore;
            }
            else
            {
                return playerTwoScore;
            }
        }
        
    }
}
