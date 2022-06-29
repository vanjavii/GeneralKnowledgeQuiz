using Controller;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class FrmServer : Form
    {
        private Server server = new Server();
        static int numOfPlayers;

        public FrmServer()
        {
            InitializeComponent();
            dgvResults.Visible = false;
            cbQuizSelection.DataSource = Controller.Controller.Instance.GetAllQuizzes();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Quiz selectedQuiz = (Quiz)cbQuizSelection.SelectedItem;
            if (rbTwo.Checked) numOfPlayers = 2;
            if (rbThree.Checked) numOfPlayers = 3;
            if (rbFour.Checked) numOfPlayers = 4;

            Thread thread = new Thread(() => { server.StartGame(selectedQuiz, numOfPlayers); });
            thread.Start();
            MessageBox.Show("Server is running!", "Server state info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnStart.Enabled = false;
            rbTwo.Enabled = false;
            rbThree.Enabled = false;
            rbFour.Enabled = false;
            cbQuizSelection.Enabled = false;
            dgvResults.Visible = true;


            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            dgvResults.DataSource = new BindingList<ClientHandler>(server.Players);
            dgvResults.Columns[0].HeaderText = "Player";
            dgvResults.Columns[1].HeaderText = "Correct answers";
            dgvResults.Columns[2].HeaderText = "Incorrect answers";
            dgvResults.Columns[3].HeaderText = "Current points";
        }

        private void cbQuizSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbQuizSelection.SelectedIndex == 0)
            {
                this.BackgroundImage = Properties.Resources.history;
                this.BackgroundImageLayout = ImageLayout.Stretch; 
            }
            if (cbQuizSelection.SelectedIndex == 1)
            {
                this.BackgroundImage = Properties.Resources.geography;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            if (cbQuizSelection.SelectedIndex == 2)
            {
                this.BackgroundImage = Properties.Resources.biology;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
