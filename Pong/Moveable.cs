using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    public interface Moveable
    {
        void move();
        void changeDirection(Moveable m);
        void changeDirection(KeyEventArgs e);
        void paint(Graphics g);
        void setRectangle(Point p);
        Point getStartingPoint();
        Rectangle getRectangle();
    }
}
