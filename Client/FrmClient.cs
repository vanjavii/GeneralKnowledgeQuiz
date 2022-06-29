using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmClient : Form
    {
        static double numOfPoints = 0;

        public FrmClient()
        {
            InitializeComponent();
            gbQuiz.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Communication.Instance.Login(txtUsername.Text);                              
                gbLogin.Enabled = false;                
                gbQuiz.Visible = true;                              
                ReadQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server stopped working!","Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
        }

        private void ReadQuestion()
        {
            try
            {
                Response response = Communication.Instance.ReadMessageFromServer();
                txtQuestion.Visible = true;
                txtAnswer.Visible = true;
                txtServerResponse.Visible = true;
                txtSumOfPoints.Visible = true;
                if (response.Winner != null)
                {
                    MessageBox.Show($"WINNER IS : {response.Winner} ({response.Points} points)!", "Winner announcement", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    txtQuestion.Text = response.Question;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Server stopped working!","Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                Request answer = new Request { Answer = txtAnswer.Text };
                Communication.Instance.SendMessage(answer);
                txtAnswer.Text = "";
                Response response = Communication.Instance.ReadMessageFromServer();
                txtServerResponse.Text = response.PorukaOdServera;
                numOfPoints += response.Points;
                txtSumOfPoints.Text = numOfPoints.ToString();

                ReadQuestion();
            }
            catch (Exception)
            {
                MessageBox.Show("Server stopped working!", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }          
        }

        private void FrmClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
