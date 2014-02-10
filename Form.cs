/*
 *  Filename:           Blackjack project
 *  Author:             Lerenzo Willoughby
 *  Date Created:       18/07/2011
 *  Operating system:   Windows Vista
 *
 *  Description: 
 *  This program was created to play the game blackjack, where the closet score to 21
 *  or 21 wins the round.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Blackjack
{
    public partial class Blackjack : Form
    {
        public Blackjack()
        {
            InitializeComponent();
        }

        #region declarations
        //Stores the deck of cards.
        SortedList cards = new SortedList();

        //Declare ArrayLists.
        ArrayList player = new ArrayList();
        ArrayList dealer = new ArrayList();
        ArrayList deck = new ArrayList();

        //Declare random numbers.
        Random r = new Random();
        
        //Declare variables.
        int pScore = 0;
        int dScore = 0;
        int counter = 24;
        int counter1 = 24;
        int playerHit = 2;
        int dealerHit = 2;
        //Scoreboard variables.
        int pWins = 0;
        int pLosses = 0;
        int pTies = 0;
        int dWins = 0;
        int dLosses = 0;
        int dTies = 0;

        #endregion

        #region methods

        //loads cards into game.
        public void loadCards()
        {
            //naming cards.
            cards.Add("Clubs-Ace", 11);
            cards.Add("Clubs-Two", 2);
            cards.Add("Clubs-Three", 3);
            cards.Add("Clubs-Four", 4);
            cards.Add("Clubs-Five", 5);
            cards.Add("Clubs-Six", 6);
            cards.Add("Clubs-Seven", 7);
            cards.Add("Clubs-Eight", 8);
            cards.Add("Clubs-Nine", 9);
            cards.Add("Clubs-Ten", 10);
            cards.Add("Clubs-Jack", 10);
            cards.Add("Clubs-Queen", 10);
            cards.Add("Clubs-King", 10);
            cards.Add("Diamonds-Ace", 11);
            cards.Add("Diamonds-Two", 2);
            cards.Add("Diamonds-Three", 3);
            cards.Add("Diamonds-Four", 4);
            cards.Add("Diamonds-Five", 5);
            cards.Add("Diamonds-Six", 6);
            cards.Add("Diamonds-Seven", 7);
            cards.Add("Diamonds-Eight", 8);
            cards.Add("Diamonds-Nine", 9);
            cards.Add("Diamonds-Ten", 10);
            cards.Add("Diamonds-Jack", 10);
            cards.Add("Diamonds-Queen", 10);
            cards.Add("Diamonds-King", 10);
            cards.Add("Hearts-Ace", 11);
            cards.Add("Hearts-Two", 2);
            cards.Add("Hearts-Three", 3);
            cards.Add("Hearts-Four", 4);
            cards.Add("Hearts-Five", 5);
            cards.Add("Hearts-Six", 6);
            cards.Add("Hearts-Seven", 7);
            cards.Add("Hearts-Eight", 8);
            cards.Add("Hearts-Nine", 9);
            cards.Add("Hearts-Ten", 10);
            cards.Add("Hearts-Jack", 10);
            cards.Add("Hearts-Queen", 10);
            cards.Add("Hearts-King", 10);
            cards.Add("Spades-Ace", 11);
            cards.Add("Spades-Two", 2);
            cards.Add("Spades-Three", 3);
            cards.Add("Spades-Four", 4);
            cards.Add("Spades-Five", 5);
            cards.Add("Spades-Six", 6);
            cards.Add("Spades-Seven", 7);
            cards.Add("Spades-Eight", 8);
            cards.Add("Spades-Nine", 9);
            cards.Add("Spades-Ten", 10);
            cards.Add("Spades-Jack", 10);
            cards.Add("Spades-Queen", 10);
            cards.Add("Spades-King", 10);
        }

        //gets random numbers.
        public int Ran()
        {
            //getting the next random number.
            int rN = r.Next(52);
            //checks if number is in the 'deck' array list.
            while (deck.Contains(rN))
            {
                rN = r.Next(52);
            }
            //adds the random number to the array list.
            deck.Add(rN);
            return rN;
        }

        //sets label if player busts.
        public void Bust()
        {
            lblResultP.Text = "Player Bust!";
            lblResultD.Text = "Dealer Wins!";
        }

        //dealer play method.
        public void DealerPlay()
        {
            //Get card name.
            string d2 = cards.GetKey(Int32.Parse(dealer[1].ToString())).ToString();

            //Direct path to the image.
            picBox4.Image = Image.FromFile("../../Resources/" + d2 + ".png");

            //Calculating total.
            int four = Int32.Parse(cards.GetByIndex(Int32.Parse(dealer[1].ToString())).ToString());

            dScore = dScore + four;
            lblNum2.Text = dScore.ToString();

            //Making ace = 1.
            if (dScore > 21)
            {
                if (four == 11)
                {
                    dScore = dScore - 10;
                    lblNum2.Text = dScore.ToString();
                }
            }

            //Checks if dealer's score is less than 17 and adding another
            //card if score is below.
            while (dScore < 17)
            {
                dealer.Add(Ran());
                //Get added cards name.
                string d3 = cards.GetKey(Int32.Parse(dealer[dealerHit].ToString())).ToString();

                //Add new picture box.
                counter1 = counter1 + 30;
                PictureBox pb2 = new PictureBox();
                pb2.Location = new Point(counter1, 14);
                pb2.Size = new System.Drawing.Size(79, 123);
                this.pnlDealer.Controls.Add(pb2);
                pb2.Image = Image.FromFile("../../Resources/" + d3 + ".png");

                //Calculating combined total.
                int dHs = Int32.Parse(cards.GetByIndex(Int32.Parse(dealer[dealerHit].ToString())).ToString());
                dScore = dScore + dHs;
                lblNum2.Text = dScore.ToString();

                //Making ace = 1.
                if (dScore > 21)
                {
                    if (dHs == 11)
                    {
                        dScore = dScore - 10;
                        lblNum2.Text = dScore.ToString();
                    }
                }

                if (dScore > 21)
                {
                    if (pScore == 21)
                    {
                        lblResultP.Text = "Blackjack!";
                        lblResultD.Text = "Dealer Bust!";
                    }
                    else
                    {
                        lblResultD.Text = "Dealer Bust!";
                        lblResultP.Text = "Player Wins!";
                    }
                    //Scoreboard.
                    dLosses++;
                    pWins++;
                    lblDlosses.Text = dLosses.ToString();
                    lblPwins.Text = pWins.ToString();
                }
                //Increasing the number of times the dealer added another card.
                dealerHit++;
            }
            //Enable deal button.
            btnDeal.Enabled = true;
        }

        //compares the scores between player and dealer.
        public void CheckScores()
        {
            //Checking scores.
            if (dScore <= 21 && pScore <= 21)
            {
                //Hand is a tie when player and dealer has the same score.
                if (pScore == dScore)
                {
                    lblResultP.Text = "Hand is a Tie!";
                    lblResultD.Text = "Hand is a Tie!";
                    pTies++;
                    dTies++;
                    lblPties.Text = pTies.ToString();
                    lblDties.Text = dTies.ToString();
                }
                else if (pScore == 21)
                {
                    lblResultP.Text = "Blackjack!";
                    lblResultD.Text = "Dealer Lose!";
                    pWins++;
                    dLosses++;
                    lblPwins.Text = pWins.ToString();
                    lblDlosses.Text = dLosses.ToString();
                }
                else if (dScore == 21)
                {
                    lblResultD.Text = "Blackjack!";
                    lblResultP.Text = "Player Lose!";
                    dWins++;
                    pLosses++;
                    lblDwins.Text = dWins.ToString();
                    lblPlosses.Text = pLosses.ToString();
                }
                else if (pScore > dScore)
                {
                    lblResultP.Text = "Player Wins!";
                    lblResultD.Text = "Dealer Lose!";
                    pWins++;
                    dLosses++;
                    lblPwins.Text = pWins.ToString();
                    lblDlosses.Text = dLosses.ToString();
                }
                else if (dScore > pScore)
                {
                    lblResultD.Text = "Dealer Wins!";
                    lblResultP.Text = "Player Lose!";
                    dWins++;
                    pLosses++;
                    lblDwins.Text = dWins.ToString();
                    lblPlosses.Text = pLosses.ToString();
                }
            }
        }

        #endregion

        #region events

        private void Blackjack_Load_1(object sender, EventArgs e)
        {
            //Adds the cards when blackjack loads.
            loadCards();
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            //Enable and disable buttons.
            btnHit.Enabled = true;
            btnStand.Enabled = true;
            btnDeal.Enabled = false;

            //Sets the dealer's second card to default.
            picBox4.Image = Image.FromFile("../../Resources/CardBack.png");
            
            //Reset variables and clear controls.
            pScore = 0;
            dScore = 0;
            counter = 24;
            counter1 = 24;
            playerHit = 2;
            dealerHit = 2;

            player.Clear();
            dealer.Clear();
            deck.Clear();
            pnlPlayer.Controls.Clear();
            pnlDealer.Controls.Clear();
            lblResultP.Text = "";
            lblResultD.Text = "";

            //Add some random values of varying types to array lists.
            player.Add(Ran());
            player.Add(Ran());
            dealer.Add(Ran());
            dealer.Add(Ran());

            //Get card names.
            string p1 = cards.GetKey(Int32.Parse(player[0].ToString())).ToString();
            string p2 = cards.GetKey(Int32.Parse(player[1].ToString())).ToString();
            string d1 = cards.GetKey(Int32.Parse(dealer[0].ToString())).ToString();

            //Direct path to the images.
            picBox1.Image = Image.FromFile("../../Resources/"+p1 + ".png");
            picBox2.Image = Image.FromFile("../../Resources/"+p2 + ".png");
            picBox3.Image = Image.FromFile("../../Resources/"+d1 + ".png");

            //Calculating totals.
            int one = Int32.Parse(cards.GetByIndex(Int32.Parse(player[0].ToString())).ToString());
            int two = Int32.Parse(cards.GetByIndex(Int32.Parse(player[1].ToString())).ToString());
            pScore = one + two;
            dScore = Int32.Parse(cards.GetByIndex(Int32.Parse(dealer[0].ToString())).ToString());

            //Sets labels.
            lblNum1.Text = pScore.ToString();
            lblNum2.Text = dScore.ToString();

            //Making ace = 1.
            if (pScore > 21)
            {
                if (two == 11)
                {
                    pScore = pScore - 10;
                    lblNum1.Text = pScore.ToString();
                }
            }

            //Player gets blackjack on the deal.
            if (pScore == 21)
            {
                btnHit.Enabled = false;
                btnStand.Enabled = false;
                DealerPlay();
                CheckScores();
            }
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            //Add a random value of varying types.
            player.Add(Ran());

            //Get card name.
            string p3 = cards.GetKey(Int32.Parse(player[playerHit].ToString())).ToString();

            //Add new picture box.
            counter = counter+30;
            PictureBox pb1 = new PictureBox();
            pb1.Location = new Point(counter, 14);
            pb1.Size = new System.Drawing.Size(79, 123);
            this.pnlPlayer.Controls.Add(pb1);
            pb1.Image = Image.FromFile("../../Resources/" + p3 + ".png");

            //Calculating combined total.
            int hS = Int32.Parse(cards.GetByIndex(Int32.Parse(player[playerHit].ToString())).ToString());
            pScore = pScore + hS;
            lblNum1.Text = pScore.ToString();

            //Making ace = 1.
            if (pScore > 21)
            {
                if (hS == 11)
                {
                    pScore = pScore - 10;
                    lblNum1.Text = pScore.ToString();
                }
            }

            //Checking if player score is more than 21.
            if (pScore > 21)
            {
                Bust();
                btnHit.Enabled = false;
                btnStand.Enabled = false;
                btnDeal.Enabled = true;
                //Scoreboard.
                pLosses++;
                dWins++;
                lblPlosses.Text = pLosses.ToString();
                lblDwins.Text = dWins.ToString();
            }
            else if (pScore == 21)
            {
                btnHit.Enabled = false;
                btnStand.Enabled = false;
                DealerPlay();
                CheckScores();
            }

            //Increasing the number of times the player hits.
            playerHit++;
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            //Disable stand and hit buttons.
            btnStand.Enabled = false;
            btnHit.Enabled = false;
            //Calling methods.
            DealerPlay();
            CheckScores();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            //Exits the application in the menu.
            Application.Exit();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            //Exits the application.
            Application.Exit();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnDeal.Enabled = true;
            btnHit.Enabled = false;
            btnStand.Enabled = false;

            //Default cards.
            picBox1.Image = Image.FromFile("../../Resources/CardBack.png");
            picBox2.Image = Image.FromFile("../../Resources/CardBack.png");
            picBox3.Image = Image.FromFile("../../Resources/CardBack.png");
            picBox4.Image = Image.FromFile("../../Resources/CardBack.png");

            //Reset variables.
            pScore = 0;
            dScore = 0;
            counter = 24;
            counter1 = 24;
            playerHit = 2;
            dealerHit = 2;

            //Reset variables and clear controls.
            player.Clear();
            dealer.Clear();
            deck.Clear();
            pnlPlayer.Controls.Clear();
            pnlDealer.Controls.Clear();
            lblResultP.Text = "";
            lblResultD.Text = "";

            //Reset Scoreboard.
            pWins = 0;
            pLosses = 0;
            pTies = 0;
            dWins = 0;
            dLosses = 0;
            dTies = 0;

            //Clearing all labels.
            lblNum1.Text = "";
            lblNum2.Text = "";
            lblPwins.Text = "";
            lblPlosses.Text = "";
            lblPties.Text = "";
            lblDwins.Text = "";
            lblDlosses.Text = "";
            lblDties.Text = "";
        }

        private void newGameMenuItem_Click(object sender, EventArgs e)
        {
            btnDeal.Enabled = true;
            btnHit.Enabled = false;
            btnStand.Enabled = false;

            //Default cards.
            picBox1.Image = Image.FromFile("../../Resources/CardBack.png");
            picBox2.Image = Image.FromFile("../../Resources/CardBack.png");
            picBox3.Image = Image.FromFile("../../Resources/CardBack.png");
            picBox4.Image = Image.FromFile("../../Resources/CardBack.png");

            //Reset variables.
            pScore = 0;
            dScore = 0;
            counter = 24;
            counter1 = 24;
            playerHit = 2;
            dealerHit = 2;

            player.Clear();
            dealer.Clear();
            deck.Clear();
            pnlPlayer.Controls.Clear();
            pnlDealer.Controls.Clear();
            lblResultP.Text = "";
            lblResultD.Text = "";

            //Reset Scoreboard.
            pWins = 0;
            pLosses = 0;
            pTies = 0;
            dWins = 0;
            dLosses = 0;
            dTies = 0;
            
            //Clearing all labels.
            lblNum1.Text = "";
            lblNum2.Text = "";
            lblPwins.Text = "";
            lblPlosses.Text = "";
            lblPties.Text = "";
            lblDwins.Text = "";
            lblDlosses.Text = "";
            lblDties.Text = "";
        }

        private void aboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This game has been created by: Lerenzo, version v1.0");
            MessageBoxButtons.OK.ToString();
        }

        #endregion
    }
}
