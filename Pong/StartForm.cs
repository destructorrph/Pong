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
    public partial class StartForm : Form
    {
        private readonly Form1 _form1;
        public StartForm(Form1 form)
        {
            InitializeComponent();
            _form1 = form;
            CenterToScreen();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            _form1.startGame();
            this.Close();
        }
    }
}
