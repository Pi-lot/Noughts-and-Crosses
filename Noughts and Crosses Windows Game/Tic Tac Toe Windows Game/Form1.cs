using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Tic_Tac_Toe_Windows_Game
{
    public partial class Form1 : Form
    {
        // This player plays a sound whenever the player loses to the computer.
        private MP3Player lose;
        private MP3Player win;
        private MP3Player tie;
        private MP3Player aiMove;

        // This will be used when the AI needs to be placed at random.
        Random aiRandom = new Random();

        // This will store the character required for the AI to win.
        string aiWinTxt = "X";

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The Label's Click events are controlled by this Event
        /// Handler. When a Label is clicked it changes the Label's
        /// Text to "O".
        /// </summary>
        /// <param name="sender">The label that was clicked</param>
        /// <param name="e"></param>
        public void label_Click(object sender, EventArgs e)
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label labelCursor = control as Label;
                //Label.
            }
            // The Timer is only on for one second after the player clicks.
            // Ingnore any clicks after this.
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel.Text == "")
            {
                clickedLabel.Text = "O";

                if (aiMove != null)
                {
                    aiMove.Stop();
                    timer3.Stop();
                }

                if ((chkPlrLblOne() && chkPlrLblTwo() && chkPlrLblThree()) ||
                    (chkPlrLblFour() && chkPlrLblFive() && chkPlrLblSix()) ||
                    (chkPlrLblSeven() && chkPlrLblEight() && chkPlrLblNine()) ||
                    (chkPlrLblOne() && chkPlrLblFive() && chkPlrLblNine()) ||
                    (chkPlrLblThree() && chkPlrLblFive() && chkPlrLblSeven()) ||
                    (chkPlrLblOne() && chkPlrLblFour() && chkPlrLblSeven()) ||
                    (chkPlrLblTwo() && chkPlrLblFive() && chkPlrLblEight()) ||
                    (chkPlrLblThree() && chkPlrLblSix() && chkPlrLblNine()))
                {
                    win = new MP3Player("Resources/Everything Is AWESOME!!!.mp3");
                    win.Play();

                    // If the Player wins Display a message and clear the board.
                    MessageBox.Show("How DID You DO THAT?!?!?! You Win!!!!", "Player Wins");

                    if (win != null)
                    {
                        win.Stop();
                    }

                    label1.Text = "";
                    label2.Text = "";
                    label3.Text = "";
                    label4.Text = "";
                    label5.Text = "";
                    label6.Text = "";
                    label7.Text = "";
                    label8.Text = "";
                    label9.Text = "";

                    return;
                }

                chkTie();

                timer1.Start();
            }
        }

        private void chkTie()
        {
            if (chkLblOneBl() && chkLblTwoBl() && chkLblThreeBl() && chkLblFourBl() && chkLblFiveBl() &&
                    chkLblSixBl() && chkLblSevenBl() && chkLblEightBl() && chkLblNineBl())
            {
                if (aiMove != null)
                {
                    aiMove.Stop();
                    timer3.Stop();
                }

                timer2.Start();
                tie = new MP3Player("Resources/Sad_Trombone.mp3");
                tie.Play();

                // If neither has won display a message and clear the board
                MessageBox.Show("It's a TIE!!", "Tie");

                if (tie != null)
                {
                    tie.Stop();
                }

                label1.Text = "";
                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
                label5.Text = "";
                label6.Text = "";
                label7.Text = "";
                label8.Text = "";
                label9.Text = "";

                return;
            }
        }

        private bool chkAIWin()
        {
            if ((label1.Text == aiWinTxt && label2.Text == aiWinTxt && label3.Text == aiWinTxt) ||
                (label4.Text == aiWinTxt && label5.Text == aiWinTxt && label6.Text == aiWinTxt) ||
                (label7.Text == aiWinTxt && label8.Text == aiWinTxt && label9.Text == aiWinTxt) ||
                (label1.Text == aiWinTxt && label5.Text == aiWinTxt && label9.Text == aiWinTxt) ||
                (label3.Text == aiWinTxt && label5.Text == aiWinTxt && label7.Text == aiWinTxt) ||
                (label1.Text == aiWinTxt && label4.Text == aiWinTxt && label7.Text == aiWinTxt) ||
                (label2.Text == aiWinTxt && label5.Text == aiWinTxt && label8.Text == aiWinTxt) ||
                (label3.Text == aiWinTxt && label6.Text == aiWinTxt && label9.Text == aiWinTxt))
                return true;
            else
                return false;
        }

        // These Bools are to check if the AI has placed in any labels.
        private bool chkAIOne()
        {
            if (label1.Text == "X")
                return true;
            else
                return false;
        }
        private bool chkAITwo()
        {
            if (label2.Text == "X")
                return true;
            else
                return false;
        }
        private bool chkAIThree()
        {
            if (label3.Text == "X")
                return true;
            else
                return false;
        }
        private bool chkAIFour()
        {
            if (label4.Text == "X")
                return true;
            else
                return false;
        }
        private bool chkAIFive()
        {
            if (label5.Text == "X")
                return true;
            else
                return false;
        }
        private bool chkAISix()
        {
            if (label6.Text == "X")
                return true;
            else
                return false;
        }
        private bool chkAISeven()
        {
            if (label7.Text == "X")
                return true;
            else
                return false;
        }
        private bool chkAIEight()
        {
            if (label8.Text == "X")
                return true;
            else
                return false;
        }
        private bool chkAINine()
        {
            if (label9.Text == "X")
                return true;
            else
                return false;
        }

        // These Bools are to check if the label is not black.
        private bool chkLblFiveBl()
        {
            if (label5.Text != "")
                return true;
            else
                return false;
        }
        private bool chkLblOneBl()
        {
            if (label1.Text != "")
                return true;
            else
                return false;
        }
        private bool chkLblThreeBl()
        {
            if (label3.Text != "")
                return true;
            else
                return false;
        }
        private bool chkLblTwoBl()
        {
            if (label2.Text != "")
                return true;
            else
                return false;
        }
        private bool chkLblSixBl()
        {
            if (label6.Text != "")
                return true;
            else
                return false;
        }
        private bool chkLblFourBl()
        {
            if (label4.Text != "")
                return true;
            else
                return false;
        }
        private bool chkLblSevenBl()
        {
            if (label7.Text != "")
                return true;
            else
                return false;
        }
        private bool chkLblEightBl()
        {
            if (label8.Text != "")
                return true;
            else
                return false;
        }
        private bool chkLblNineBl()
        {
            if (label9.Text != "")
                return true;
            else
                return false;
        }

        // These Bools are to check if there is anything in any of these labels.
        private bool chkLblFive()
        {
            if (label5.Text == "")
                return true;
            else
                return false;
        }
        private bool chkLblOne()
        {
            if (label1.Text == "")
                return true;
            else
                return false;
        }
        private bool chkLblThree()
        {
            if (label3.Text == "")
                return true;
            else
                return false;
        }
        private bool chkLblTwo()
        {
            if (label2.Text == "")
                return true;
            else
                return false;
        }
        private bool chkLblSix()
        {
            if (label6.Text == "")
                return true;
            else
                return false;
        }
        private bool chkLblFour()
        {
            if (label4.Text == "")
                return true;
            else
                return false;
        }
        private bool chkLblSeven()
        {
            if (label7.Text == "")
                return true;
            else
                return false;
        }
        private bool chkLblEight()
        {
            if (label8.Text == "")
                return true;
            else
                return false;
        }
        private bool chkLblNine()
        {
            if (label9.Text == "")
                return true;
            else
                return false;
        }

        // These bools are to check if the player has placed in these labels.
        private bool chkPlrLblOne()
        {
            if (label1.Text == "O")
                return true;
            else
                return false;
        }
        private bool chkPlrLblTwo()
        {
            if (label2.Text == "O")
                return true;
            else
                return false;
        }
        private bool chkPlrLblThree()
        {
            if (label3.Text == "O")
                return true;
            else
                return false;
        }
        private bool chkPlrLblFour()
        {
            if (label4.Text == "O")
                return true;
            else
                return false;
        }
        private bool chkPlrLblFive()
        {
            if (label5.Text == "O")
                return true;
            else
                return false;
        }
        private bool chkPlrLblSix()
        {
            if (label6.Text == "O")
                return true;
            else
                return false;
        }
        private bool chkPlrLblSeven()
        {
            if (label7.Text == "O")
                return true;
            else
                return false;
        }
        private bool chkPlrLblEight()
        {
            if (label8.Text == "O")
                return true;
            else
                return false;
        }
        private bool chkPlrLblNine()
        {
            if (label9.Text == "O")
                return true;
            else
                return false;
        }

        /// <summary>
        /// The program checks if the AI has won.
        /// </summary>
        private void checkAIWin()
        {
            if (chkAIWin())
            {
                if (aiMove != null)
                {
                    aiMove.Stop();
                    timer3.Stop();
                }

                timer2.Start();
                lose = new MP3Player("Resources/fail.mp3");
                lose.Play();

                // If the Player loses Display a message and clear the board.
                MessageBox.Show("You lost. Better luck next time", "Computer Wins");
                
                if (lose != null)
                {
                    lose.Stop();
                }

                label1.Text = "";
                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
                label5.Text = "";
                label6.Text = "";
                label7.Text = "";
                label8.Text = "";
                label9.Text = "";

                return;
            }
        }

        /// <summary>
        /// Creates a music player and plays the first part of the jaws theme
        /// when the AI makes a move.
        /// </summary>
        private void jaws()
        {
            timer3.Start();
            aiMove = new MP3Player("Resources/jaws_theme.mp3");
            aiMove.Play();
        }

        /// <summary>
        /// The AI makes decisions and deploys its strategy from here.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer.
            timer1.Stop();

            // This code will finish a player diagonal down right win.
            if (chkAIOne() && chkAINine() && chkLblFive())
            {
                label5.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAIOne() && chkAIFive() && chkLblNine())
            {
                label9.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAIFive() && chkAINine() && chkLblOne())
            {
                label1.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }

            // This will finish a diagonal down left win.
            if (chkAIThree() && chkAISeven() && chkLblFive())
            {
                label5.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAISeven() && chkAIFive() && chkLblThree())
            {
                label3.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAIThree() && chkAIFive() && chkLblSeven())
            {
                label7.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }

            // This will finish a top row win.
            if (chkAIOne() && chkAITwo() && chkLblThree())
            {
                label3.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAIOne() && chkAIThree() && chkLblTwo())
            {
                label2.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAITwo() && chkAIThree() && chkLblOne())
            {
                label1.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }

            // This will finish a middle row win.
            if (chkAIFour() && chkAIFive() && chkLblSix())
            {
                label6.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAIFour() && chkAISix() && chkLblFive())
            {
                label5.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAIFive() && chkAISix() && chkLblFour())
            {
                label4.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }

            // This will finish a bottom row win.
            if (chkAISeven() && chkAIEight() && chkLblNine())
            {
                label9.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAISeven() && chkAINine() && chkLblEight())
            {
                label8.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAIEight() && chkAINine() && chkLblSeven())
            {
                label7.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }

            // This will finish a left column win.
            if (chkAIOne() && chkAIFour() && chkLblSeven())
            {
                label7.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAIOne() && chkAISeven() && chkLblFour())
            {
                label4.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAIFour() && chkAISeven() && chkLblOne())
            {
                label1.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }

            // This will finish a middle column win.
            if (chkAITwo() && chkAIFive() && chkLblEight())
            {
                label8.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAITwo() && chkAIEight() && chkLblFive())
            {
                label5.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAIFive() && chkAIEight() && chkLblTwo())
            {
                label2.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }

            // This will finish a right column win.
            if (chkAIThree() && chkAISix() && chkLblNine())
            {
                label9.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAIThree() && chkAINine() && chkLblSix())
            {
                label6.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }
            if (chkAISix() && chkAINine() && chkLblThree())
            {
                label3.Text = "X";

                checkAIWin();
                chkTie();
                return;
            }

            // This code will counter a player diagonal down right win.
            if (chkPlrLblOne() && chkPlrLblNine() && chkLblFive())
            {
                label5.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblOne() && chkPlrLblFive() && chkLblNine())
            {
                label9.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblFive() && chkPlrLblNine() && chkLblOne())
            {
                label1.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }

            // This will counter a diagonal down left win.
            if (chkPlrLblThree() && chkPlrLblSeven() && chkLblFive())
            {
                label5.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblSeven() && chkPlrLblFive() && chkLblThree())
            {
                label3.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblThree() && chkPlrLblFive() && chkLblSeven())
            {
                label7.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }

            // This will counter a top row win.
            if (chkPlrLblOne() && chkPlrLblTwo() && chkLblThree())
            {
                label3.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblOne() && chkPlrLblThree() && chkLblTwo())
            {
                label2.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblTwo() && chkPlrLblThree() && chkLblOne())
            {
                label1.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }

            // This will counter a middle row win.
            if (chkPlrLblFour() && chkPlrLblFive() && chkLblSix())
            {
                label6.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblFour() && chkPlrLblSix() && chkLblFive())
            {
                label5.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblFive() && chkPlrLblSix() && chkLblFour())
            {
                label4.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }

            // This will counter a bottom row win.
            if (chkPlrLblSeven() && chkPlrLblEight() && chkLblNine())
            {
                label9.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblSeven() && chkPlrLblNine() && chkLblEight())
            {
                label8.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblEight() && chkPlrLblNine() && chkLblSeven())
            {
                label7.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }

            // This will counter a left column win.
            if (chkPlrLblOne() && chkPlrLblFour() && chkLblSeven())
            {
                label7.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblOne() && chkPlrLblSeven() && chkLblFour())
            {
                label4.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblFour() && chkPlrLblSeven() && chkLblOne())
            {
                label1.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }

            // This will counter a middle column win.
            if (chkPlrLblTwo() && chkPlrLblFive() && chkLblEight())
            {
                label8.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblTwo() && chkPlrLblEight() && chkLblFive())
            {
                label5.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblFive() && chkPlrLblEight() && chkLblTwo())
            {
                label2.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }

            // This will counter a right column win.
            if (chkPlrLblThree() && chkPlrLblSix() && chkLblNine())
            {
                label9.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblThree() && chkPlrLblNine() && chkLblSix())
            {
                label6.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblSix() && chkPlrLblNine() && chkLblThree())
            {
                label3.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }

            // This is the first part of the strategy if the player first places in a corner.
            if (chkPlrLblOne() && chkLblFive())
            {
                label5.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblThree() && chkLblFive())
            {
                label5.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblSeven() && chkLblFive())
            {
                label5.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblNine() && chkLblFive())
            {
                label5.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }

            // This is the second part of the stategy if the player first places in a corner,
            // then places in the corner diagonally away from it.
            if (((chkPlrLblOne() && chkPlrLblNine()) || (chkPlrLblThree() && chkPlrLblSeven())) &&
                chkLblTwo() && chkLblFour() && chkLblSix() && chkLblEight() && chkAIFive())
            {
                int ranNumb = aiRandom.Next(1, 5);

                if (ranNumb == 1)
                {
                    label2.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (ranNumb == 2)
                {
                    label4.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (ranNumb == 3)
                {
                    label6.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (ranNumb == 4)
                {
                    label8.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }

            // This is again the second part but the player places in a middle row.
            if (chkPlrLblOne() && chkAIFive() && chkPlrLblEight() && chkLblFour() && chkLblSix() && chkLblSeven() && chkLblNine())
            {
                int num = aiRandom.Next(1, 5);

                if (num == 1)
                {
                    label4.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label6.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 3)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 4)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblOne() && chkAIFive() && chkPlrLblSix() && chkLblTwo() && chkLblEight() && chkLblThree() && chkLblNine())
            {
                int num = aiRandom.Next(1, 5);

                if (num == 1)
                {
                    label2.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label8.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 3)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 4)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblThree() && chkAIFive() && chkPlrLblFour() && chkLblTwo() && chkLblEight() && chkLblOne() && chkLblSeven())
            {
                int num = aiRandom.Next(1, 5);

                if (num == 1)
                {
                    label2.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label8.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 3)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 4)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblThree() && chkAIFive() && chkPlrLblEight() && chkLblFour() && chkLblSix() && chkLblSeven() && chkLblNine())
            {
                int num = aiRandom.Next(1, 5);

                if (num == 1)
                {
                    label4.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label6.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 3)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 4)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblSeven() && chkAIFive() && chkPlrLblSix() && chkLblTwo() && chkLblEight() && chkLblThree() && chkLblNine())
            {
                int num = aiRandom.Next(1, 5);

                if (num == 1)
                {
                    label2.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label8.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 3)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 4)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblSeven() && chkAIFive() && chkPlrLblTwo() && chkLblFour() && chkLblOne() && chkLblThree() && chkLblSix())
            {
                int num = aiRandom.Next(1, 5);

                if (num == 1)
                {
                    label4.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 3)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 4)
                {
                    label6.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblNine() && chkAIFive() && chkPlrLblTwo() && chkLblFour() && chkLblOne() && chkLblThree() && chkLblSix())
            {
                int num = aiRandom.Next(1, 5);

                if (num == 1)
                {
                    label4.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 3)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 4)
                {
                    label6.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblNine() && chkAIFive() && chkPlrLblFour() && chkLblOne() && chkLblTwo() && chkLblSeven() && chkLblEight())
            {
                int num = aiRandom.Next(1, 5);

                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label2.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 3)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 4)
                {
                    label8.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }

            // This is the Third part of the stategy if the player first places in a corner,
            // then places in a middle section.
            if (chkPlrLblOne() && chkAIFour() && chkAIFive() && chkPlrLblSix() && chkPlrLblEight() && chkLblThree() && chkLblNine())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblOne() && chkAITwo() && chkAIFive() && chkPlrLblSix() && chkPlrLblEight() && chkLblSeven() && chkLblNine())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblThree() && chkAISix() && chkAIFive() && chkPlrLblFour() && chkPlrLblEight() && chkLblOne() && chkLblSeven())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblThree() && chkAITwo() && chkAIFive() && chkPlrLblFour() && chkPlrLblEight() && chkLblNine() && chkLblSeven())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblSeven() && chkAIFour() && chkAIFive() && chkPlrLblTwo() && chkPlrLblSix() && chkLblThree() && chkLblNine())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblSeven() && chkAIEight() && chkAIFive() && chkPlrLblTwo() && chkPlrLblSix() && chkLblThree() && chkLblOne())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblNine() && chkAIEight() && chkAIFive() && chkPlrLblTwo() && chkPlrLblFour() && chkLblThree() && chkLblOne())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblNine() && chkAIFour() && chkAIFive() && chkPlrLblTwo() && chkPlrLblFour() && chkLblSeven() && chkLblOne())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }


            // This will start to counter the player placing in the middle section.
            if (chkPlrLblFive() && chkLblOne() && chkLblThree() && chkLblSeven() && chkLblNine())
            {
                int num = aiRandom.Next(1, 5);

                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 3)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 4)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }

            // This is the second part of the strategy where the player has placed in the middle
            // then placed in the opposite corner to the AI.
            if (chkPlrLblFive() && chkPlrLblOne() && chkAINine() && chkLblThree() && chkLblSeven())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblFive() && chkPlrLblNine() && chkAIOne() && chkLblThree() && chkLblSeven())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblFive() && chkPlrLblSeven() && chkAIThree() && chkLblOne() && chkLblNine())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblFive() && chkPlrLblThree() && chkAISeven() && chkLblOne() && chkLblNine())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }

            // This is the second part of the strategy where the the player
            // has placed on the edge in the middle the placed on the next
            // closest middle edge with the AI in the middle.
            if (chkPlrLblTwo() && chkPlrLblFour() && chkAIOne() && chkLblFive())
            {
                label5.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblTwo() && chkPlrLblSix() && chkAIThree() && chkLblFive())
            {
                label5.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblFour() && chkPlrLblEight() && chkAISeven() && chkLblFive())
            {
                label5.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }
            if (chkPlrLblSix() && chkPlrLblEight() && chkAINine() && chkLblFive())
            {
                label5.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }

            // This is the second part of the strategy where the the player
            // has placed on the edge in the middle. Similar to the last but
            // the opposite middle edge.
            if ((chkPlrLblTwo() && chkPlrLblSix() && chkAIOne()) ||
                (chkPlrLblTwo() && chkPlrLblFour() && chkAIThree()) ||
                (chkPlrLblFour() && chkPlrLblTwo() && chkAISeven())||
                (chkPlrLblFour() && chkPlrLblEight() && chkAIOne()) ||
                (chkPlrLblSix() && chkPlrLblTwo() && chkAINine()) ||
                (chkPlrLblSix() && chkPlrLblEight() && chkAIThree()) ||
                (chkPlrLblEight() && chkPlrLblFour() && chkAINine())||
                (chkPlrLblEight() && chkPlrLblSix() && chkAISeven()) && chkLblFive())
            {
                label5.Text = "X";
                jaws();

                checkAIWin();
                chkTie();
                return;
            }

            // This is the first part of the strategy where the the player
            // has placed on the edge in the middle.
            if (chkPlrLblTwo() && chkLblOne() && chkLblThree())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblFour() && chkLblOne() && chkLblSeven())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblEight() && chkLblSeven() && chkLblNine())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblSix() && chkLblThree() && chkLblNine())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }

            // This is the third part of the strategy where the player has placed
            // in the middle edges then the closest middle with the AI in the middle.
            if (chkPlrLblTwo() && chkPlrLblSix() && chkAIThree() && chkAIFive() && chkPlrLblSeven() && chkLblOne() && chkLblFour() && chkLblEight() && chkLblNine())
            {
                int num = aiRandom.Next(1, 5);

                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label4.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 3)
                {
                    label8.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 4)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblTwo() && chkPlrLblFour() && chkAIOne() && chkAIFive() && chkPlrLblNine() && chkLblThree() && chkLblSix() && chkLblEight() && chkLblSeven())
            {
                int num = aiRandom.Next(1, 5);

                if (num == 1)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label6.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 3)
                {
                    label8.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 4)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblFour() && chkPlrLblEight() && chkAISeven() && chkAIFive() && chkPlrLblThree() && chkLblOne() && chkLblTwo() && chkLblSix() && chkLblNine())
            {
                int num = aiRandom.Next(1, 5);

                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label2.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 3)
                {
                    label6.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 4)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblEight() && chkPlrLblFour() && chkAISeven() && chkAIFive() && chkPlrLblThree() && chkLblOne() && chkLblSix() && chkLblTwo() && chkLblNine())
            {
                int num = aiRandom.Next(1, 5);

                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label6.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 3)
                {
                    label2.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 4)
                {
                    label9.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkPlrLblEight() && chkPlrLblSix() && chkAINine() && chkAIFive() && chkPlrLblOne() && chkLblThree() && chkLblFour() && chkLblTwo() && chkLblSeven())
            {
                int num = aiRandom.Next(1, 5);

                if (num == 1)
                {
                    label3.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label4.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 3)
                {
                    label2.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 4)
                {
                    label7.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            
            // If there are only two spaces left and it doesn't matter where
            // the item is placed pick one and place in there.
            if (chkLblOne() && chkLblTwo() && chkLblThreeBl() && chkLblFourBl() && chkLblFiveBl() &&
                chkLblSixBl() && chkLblSevenBl() && chkLblEightBl() && chkLblNineBl())
            {
                int num = aiRandom.Next(1, 3);
                
                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label2.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkLblThree() && chkLblTwo() && chkLblOneBl() && chkLblFourBl() && chkLblFiveBl() &&
                chkLblSixBl() && chkLblSevenBl() && chkLblEightBl() && chkLblNineBl())
            {
                int num = aiRandom.Next(1, 3);
                
                if (num == 1)
                {
                    label3.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label2.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkLblOne() && chkLblFour() && chkLblThreeBl() && chkLblFourBl() && chkLblFiveBl() &&
                chkLblSixBl() && chkLblSevenBl() && chkLblEightBl() && chkLblNineBl())
            {
                int num = aiRandom.Next(1, 3);
                
                if (num == 1)
                {
                    label1.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label4.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkLblSix() && chkLblThree() && chkLblTwoBl() && chkLblFourBl() && chkLblFiveBl() &&
                chkLblOneBl() && chkLblSevenBl() && chkLblEightBl() && chkLblNineBl())
            {
                int num = aiRandom.Next(1, 3);
                
                if (num == 1)
                {
                    label6.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label3.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkLblSeven() && chkLblEight() && chkLblThreeBl() && chkLblFourBl() && chkLblFiveBl() &&
                chkLblSixBl() && chkLblOneBl() && chkLblTwoBl() && chkLblNineBl())
            {
                int num = aiRandom.Next(1, 3);
                
                if (num == 1)
                {
                    label7.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label8.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkLblSeven() && chkLblFour() && chkLblThreeBl() && chkLblEightBl() && chkLblFiveBl() &&
                chkLblSixBl() && chkLblOneBl() && chkLblTwoBl() && chkLblNineBl())
            {
                int num = aiRandom.Next(1, 3);
                
                if (num == 1)
                {
                    label7.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label4.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkLblNine() && chkLblEight() && chkLblThreeBl() && chkLblFourBl() && chkLblFiveBl() &&
                chkLblSixBl() && chkLblOneBl() && chkLblTwoBl() && chkLblSevenBl())
            {
                int num = aiRandom.Next(1, 3);
                
                if (num == 1)
                {
                    label9.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label8.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkLblSix() && chkLblNine() && chkLblThreeBl() && chkLblEightBl() && chkLblFiveBl() &&
                chkLblSevenBl() && chkLblOneBl() && chkLblTwoBl() && chkLblFourBl())
            {
                int num = aiRandom.Next(1, 3);
                
                if (num == 1)
                {
                    label6.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label9.Text = "X";
                    jaws();
                    
                    checkAIWin();
                    chkTie();
                    return;
                }
            }

            // If there are two places left that are opposite each other and they not corners
            // then the AI picks one at random.
            if (chkLblOneBl() && chkLblTwo() && chkLblThreeBl() && chkLblFourBl() && chkLblFiveBl() && chkLblSixBl() && chkLblSevenBl() && chkLblEight() && chkLblNineBl())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label2.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label8.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
            if (chkLblOneBl() && chkLblTwoBl() && chkLblThreeBl() && chkLblFour() && chkLblFiveBl() && chkLblSix() && chkLblSevenBl() && chkLblEightBl() && chkLblNineBl())
            {
                int num = aiRandom.Next(1, 3);

                if (num == 1)
                {
                    label4.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
                if (num == 2)
                {
                    label6.Text = "X";
                    jaws();

                    checkAIWin();
                    chkTie();
                    return;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (lose != null)
            {
                lose.Stop();
            }
            timer2.Stop();
            return;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            aiMove.Stop();
            timer3.Stop();
            return;
        }
    }
}
