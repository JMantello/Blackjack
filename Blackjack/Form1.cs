using System;
using System.Windows.Forms;

namespace Blackjack
{
    public partial class Form1 : Form
    {
        //create a new game
        Game game = new Game();

        public Form1()
        {
            InitializeComponent();
            StartNewGame();
        }

        //hit, stay, and new game buttons
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            StartNewGame();
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            Hit();
        }

        private void btnStay_Click(object sender, EventArgs e)
        {
            FinishRound();
        }

        //methods
        private void StartNewGame()
        {
            game.NewRound();
            DisplayToStartingVisibility();
            if (game.PlayerDealt21) //dealt a blackjack
                FinishRound();
        }

        private void Hit()
        {
            if (game.Status == "Playing")
            {
                if (game.PlayerCanHit)
                {
                    game.PlayerHits();
                    DisplayPlayersDrawnCards();
                    UpdatePlayerPoints();
                }

                if (!game.PlayerCanHit)
                    FinishRound();
            }
        }

        private void DisplayToStartingVisibility()
        {
            //hide cards that don't exist yet
            pbDealerCard2.Visible = false;
            pbDealerCard3.Visible = false;
            pbDealerCard4.Visible = false;
            pbPlayerCard2.Visible = false;
            pbPlayerCard3.Visible = false;
            pbPlayerCard4.Visible = false;

            //hide dealers points
            lbDealerPoints.Visible = false;

            //hide new game button
            btnNewGame.Visible = false;

            //enable players controls
            btnHit.Enabled = true;
            btnStay.Enabled = true;

            //display player starting cards and points
            lbPlayerPoints.Text = game.PlayerPoints.ToString();
            pbPlayerCard0.Image = game.PlayerHand[0].Image;
            pbPlayerCard1.Image = game.PlayerHand[1].Image;

            //set dealers starting card images
            pbDealerCard0.Image = Properties.Resources.purple_back; //hide first card
            pbDealerCard1.Image = game.CpuHand[1].Image;
        }

        private void DisplayPlayersDrawnCards()
        {
            //players hand 
            for (int i = 0; i < game.PlayerHand.Length; i++)
            {
                switch (i)
                {
                    case 2:
                        pbPlayerCard2.Image = game.PlayerHand[2].Image;
                        pbPlayerCard2.Visible = true;
                        break;
                    case 3:
                        pbPlayerCard3.Image = game.PlayerHand[3].Image;
                        pbPlayerCard3.Visible = true;
                        break;
                    case 4:
                        pbPlayerCard4.Image = game.PlayerHand[4].Image;
                        pbPlayerCard4.Visible = true;
                        break;
                    default: break;
                }
            }
        }
        private void DisplayDealersDrawnCards()
        {
            //dealers hand 
            for (int i = 0; i < game.CpuHand.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        pbDealerCard0.Image = game.CpuHand[0].Image;
                        pbDealerCard0.Visible = true;
                        break;
                    case 2:
                        pbDealerCard2.Image = game.CpuHand[2].Image;
                        pbDealerCard2.Visible = true;
                        break;
                    case 3:
                        pbDealerCard3.Image = game.CpuHand[3].Image;
                        pbDealerCard3.Visible = true;
                        break;
                    case 4:
                        pbDealerCard4.Image = game.CpuHand[4].Image;
                        pbDealerCard4.Visible = true;
                        break;
                }
            }
        }

        private void ShowDealersPoints()
        {
            lbDealerPoints.Text = game.CpuPoints.ToString();
            lbDealerPoints.Visible = true;
        }

        private void UpdatePlayerPoints()
        {
            lbPlayerPoints.Text = game.PlayerPoints.ToString();
        }

        private void AddWinnerToScoreboard()
        {
            lbScoreboard.Items.Add(game.Winner);
        }

        private void FinishRound()
        {
            if (game.Status == "Playing")
            {
                game.ScoreGame();
                DisplayDealersDrawnCards();
                ShowDealersPoints();
                AddWinnerToScoreboard();

                //show new game button
                btnNewGame.Visible = true;

                //disable players controls
                btnHit.Enabled = false;
                btnStay.Enabled = false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This app was made by Jonathan Mantello in April-May of 2021.");
        }
    }
}
