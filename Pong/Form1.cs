using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    public partial class Form1 : Form
    {
        Game g;
        public Form1()
        {
            InitializeComponent();
            g = new Game(pictureBox1.ClientRectangle);
            StartForm start = new StartForm(this);
            start.Show();
            start.TopMost = true;
            CenterToScreen();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
                lblPlayerOne.Parent = pictureBox1;
                lblPlayerTwo.Parent = pictureBox1;
                g.paint(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g.move();
            g.detectCollision();
            g.checkForScore();
            if (g.checkForWin()) {timer1.Stop(); g.displayWin();}
            if (!timer1.Enabled) { Application.Exit(); }
            displayScores(g.getScores(0), g.getScores(1));
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            g.changeDirection(e);
        }

        private void displayScores(int p1, int p2)
        {
            lblPlayerOne.Text = p1 + "";
            lblPlayerTwo.Text = p2 + "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void startGame()
        {
            timer1.Enabled = true;
        }

       
    }
}
