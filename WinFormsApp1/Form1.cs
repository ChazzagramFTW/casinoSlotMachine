using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        bool holdbtn1on = false;
        bool holdbtn2on = false;
        bool holdbtn3on = false;
        bool holdbtn4on = false;
        bool allowHold1 = true;
        bool allowHold2 = true;
        bool allowHold3 = true;
        bool allowHold4 = true;
        int slot1num = 1;
        int slot2num = 2;
        int slot3num = 3;
        int slot4num = 4;
        bool doubleOrNothing = false;
        bool tripleOrNothing = false;
        decimal credit = 2.0M;
        decimal cost = 0.50M;
        decimal bank = 50.0M;
        int holdtotal = 0;
        int rollAmount = 0;
        bool luckySpin = false;
        int thespinner2 = 0;
        Random MrsRandom = new Random();
        bool cancontinue = true;
        System.Drawing.Bitmap[] fruits = {casinoSlotMachine.Resource3.bell,
                                            casinoSlotMachine.Resource3.boris,
                                            casinoSlotMachine.Resource3.cherry,
                                            casinoSlotMachine.Resource3.grape,
                                            casinoSlotMachine.Resource3.melon,
                                            casinoSlotMachine.Resource3.lemon,
                                            casinoSlotMachine.Resource3.orange,
                                            casinoSlotMachine.Resource3.strawberry};

        public Form1()
        {
            InitializeComponent();
        }

        private void lblText1_Click(object sender, EventArgs e)
        {

        }

        private void btnHold1_Click(object sender, EventArgs e)
        {
            if (cancontinue == true)
            {
                if (allowHold1 == true)
                {
                    holdbtn1on = !holdbtn1on;
                    if (holdbtn1on == false)
                    {
                        btnHold1.BackColor = Color.White;
                        cost = cost - 0.25M;
                        holdtotal++;
                    }



                    if (holdbtn1on == true)
                    {
                        btnHold1.BackColor = Color.Gray;
                        cost = cost + 0.25M;
                        holdtotal--;
                    }
                }
            }
        }

        private void btnHold2_Click(object sender, EventArgs e)
        {
            if (cancontinue == true)
            {
                if (allowHold2 == true)
                {
                    holdbtn2on = !holdbtn2on;
                    if (holdbtn2on == false)
                    {
                        btnHold2.BackColor = Color.White;
                        cost = cost - 0.25M;
                        holdtotal++;
                    }



                    if (holdbtn2on == true)
                    {
                        btnHold2.BackColor = Color.Gray;
                        cost = cost + 0.25M;
                        holdtotal--;
                    }
                }
            }
        }

        private void btnHold3_Click(object sender, EventArgs e)
        {
            if (cancontinue == true)
            {
                if (allowHold3 == true)
                {
                    holdbtn3on = !holdbtn3on;
                    if (holdbtn3on == false)
                    {
                        btnHold3.BackColor = Color.White;
                        cost = cost - 0.25M;
                        holdtotal++;
                    }



                    if (holdbtn3on == true)
                    {
                        btnHold3.BackColor = Color.Gray;
                        cost = cost + 0.25M;
                        holdtotal--;
                    }
                }
            }
        }

        private void btnHold4_Click(object sender, EventArgs e)
        {
            if (cancontinue == true)
            {
                if (allowHold4 == true)
                {
                    holdbtn4on = !holdbtn4on;
                    if (holdbtn4on == false)
                    {
                        btnHold4.BackColor = Color.White;
                        cost = cost - 0.25M;
                        holdtotal++;
                    }



                    if (holdbtn4on == true)
                    {
                        btnHold4.BackColor = Color.Gray;
                        cost = cost + 0.25M;
                        holdtotal--;
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void holdAllow()
        {
            if (holdbtn4on == true)
            {
                holdbtn4on = !holdbtn4on;
                btnHold4.BackColor = Color.White;
                cost = cost - 0.25M;
                holdtotal--;
                allowHold4 = false;
            }

            if (holdbtn3on == true)
            {
                holdbtn3on = !holdbtn3on;
                btnHold3.BackColor = Color.White;
                cost = cost - 0.25M;
                holdtotal--;
                allowHold3 = false;
            }

            if (holdbtn2on == true)
            {
                holdbtn2on = !holdbtn2on;
                btnHold2.BackColor = Color.White;
                cost = cost - 0.25M;
                holdtotal--;
                allowHold2 = false;
            }

            if (holdbtn1on == true)
            {
                holdbtn1on = !holdbtn1on;
                btnHold1.BackColor = Color.White;
                cost = cost - 0.25M;
                holdtotal--;
                allowHold1 = false;
            }
        }

        private async void btnRoll_Click(object sender, EventArgs e)
        {
            if (cancontinue == true)
            {
                rollAmount++;
                if (rollAmount >= 10)
                {
                    luckySpin = true;
                    rollAmount = 0;
                    button1.BackColor = Color.Yellow;
                }

                if (credit >= cost)
                {
                    skillstop = false;
                    allowHold1 = true;
                    allowHold2 = true;
                    allowHold3 = true;
                    allowHold4 = true;

                    spinnyspin.Enabled = true;
                    cancontinue = false;
                    await Task.Delay(1100);
                    cancontinue = true;
                    credit = credit - cost;
                    lblCredit.Text = "Credit: " + credit;


                    //
                    // BORIS
                    //

                    if (slot1num == 1 && slot2num == 1 && slot3num == 1 && slot4num == 1)
                    {
                        richTextBox1.Text += "HOLY THATS ALOT OF BORIS! (Extra £50)" + Environment.NewLine;
                        bank = bank + 50.0M;
                        lblBank.Text = "Bank: " + bank;
                        holdAllow();
                    }

                    //
                    // 4 NUMBERS MATCH
                    //

                    else if (slot2num == slot1num && slot3num == slot1num && slot4num == slot1num)
                    {
                        richTextBox1.Text += "JACKPOT! You have won £5!" + Environment.NewLine;
                        bank = bank + 5.0M;
                        lblBank.Text = "Bank: " + bank;
                        holdAllow();
                    }

                    //
                    // 3 NUMBERS MATCH
                    //

                    else if (slot1num == slot2num && slot2num == slot3num)
                    {
                        richTextBox1.Text += "You have won £1!" + Environment.NewLine;
                        bank = bank + 1.0M;
                        lblBank.Text = "Bank: " + bank;
                        holdAllow();
                    }

                    else if (slot2num == slot3num && slot3num == slot4num)
                    {
                        richTextBox1.Text += "You have won £1!" + Environment.NewLine;
                        bank = bank + 1.0M;
                        lblBank.Text = "Bank: " + bank;
                        holdAllow();
                    }

                    else if (slot1num == slot3num && slot3num == slot4num)
                    {
                        richTextBox1.Text += "You have won £1!" + Environment.NewLine;
                        bank = bank + 1.0M;
                        lblBank.Text = "Bank: " + bank;
                        holdAllow();
                    }

                    else if (slot1num == slot2num && slot2num == slot4num)
                    {
                        richTextBox1.Text += "You have won £1!" + Environment.NewLine;
                        bank = bank + 1.0M;
                        lblBank.Text = "Bank: " + bank;
                        holdAllow();
                    }

                    //
                    // 2 NUMBERS MATCH
                    //

                    else if (slot1num == slot2num)
                    {
                        richTextBox1.Text += "You have won 50p!" + Environment.NewLine;
                        bank = bank + 0.50M;
                        lblBank.Text = "Bank: " + bank;
                        holdAllow();
                    }

                    else if (slot1num == slot3num)
                    {
                        richTextBox1.Text += "You have won 50p!" + Environment.NewLine;
                        bank = bank + 0.50M;
                        lblBank.Text = "Bank: " + bank;
                        holdAllow();
                    }

                    else if (slot1num == slot4num)
                    {
                        richTextBox1.Text += "You have won 50p!" + Environment.NewLine;
                        bank = bank + 0.50M;
                        lblBank.Text = "Bank: " + bank;
                        holdAllow();
                    }

                    else if (slot2num == slot3num)
                    {
                        richTextBox1.Text += "You have won 50p!" + Environment.NewLine;
                        bank = bank + 0.50M;
                        lblBank.Text = "Bank: " + bank;
                        holdAllow();
                    }

                    else if (slot2num == slot4num)
                    {
                        richTextBox1.Text += "You have won 50p!" + Environment.NewLine;
                        bank = bank + 0.50M;
                        lblBank.Text = "Bank: " + bank;
                        holdAllow();
                    }

                    else if (slot3num == slot4num)
                    {
                        richTextBox1.Text += "You have won 50p!" + Environment.NewLine;
                        bank = bank + 0.50M;
                        lblBank.Text = "Bank: " + bank;
                        holdAllow();
                    }
                }
            }
        }


        bool onoff = false;
        public void timerTick(object sender, EventArgs e)
        {
            if (credit >= cost)
            {
                if (onoff == false)
                {
                    btnRoll.BackColor = Color.Moccasin;
                    onoff = true;
                }
                else if (onoff == true)
                {
                    btnRoll.BackColor = Color.Orange;
                    onoff = false;
                }


                if (holdbtn1on == false)
                {
                    if (onoff == false)
                    {
                        btnHold1.BackColor = Color.White;
                    }
                    else if (onoff == true)
                    {
                        btnHold1.BackColor = Color.LightGray;
                    }
                }

                if (holdbtn2on == false)
                {
                    if (onoff == false)
                    {
                        btnHold2.BackColor = Color.White;
                    }
                    else if (onoff == true)
                    {
                        btnHold2.BackColor = Color.LightGray;
                    }
                }

                if (holdbtn3on == false)
                {
                    if (onoff == false)
                    {
                        btnHold3.BackColor = Color.White;
                    }
                    else if (onoff == true)
                    {
                        btnHold3.BackColor = Color.LightGray;
                    }
                }

                if (holdbtn4on == false)
                {
                    if (onoff == false)
                    {
                        btnHold4.BackColor = Color.White;
                    }
                    else if (onoff == true)
                    {
                        btnHold4.BackColor = Color.LightGray;
                    }
                }
            }
            
            
        }

        private void creditAdd100_Click(object sender, EventArgs e)
        {
            if (bank >= 1.0M)
            {
                credit = credit + 1.0M;
                bank = bank - 1.0M;
                lblCredit.Text = "Credit: " + credit;
                lblBank.Text = "Bank: " + bank;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
            lblBank.Text = "Bank: " + bank.ToString();
            lblCredit.Text = "Credit: " + credit.ToString();
        }

        private void creditAdd20_Click_1(object sender, EventArgs e)
        {
            if (bank >= 0.2M)
            {
                credit = credit + 0.2M;
                bank = bank - 0.2M;
                lblCredit.Text = "Credit: " + credit;
                lblBank.Text = "Bank: " + bank;
            }
        }

        private void creditAdd10_Click(object sender, EventArgs e)
        {
            if (bank >= 0.1M)
            {
                credit = credit + 0.1M;
                bank = bank - 0.1M;
                lblCredit.Text = "Credit: " + credit;
                lblBank.Text = "Bank: " + bank;
            }
        }

        private void creditAdd50_Click(object sender, EventArgs e)
        {
            if (bank >= 0.5M)
            {
                credit = credit + 0.5M;
                bank = bank - 0.5M;
                lblCredit.Text = "Credit: " + credit;
                lblBank.Text = "Bank: " + bank;
            }
        }

        private void creditAdd200_Click(object sender, EventArgs e)
        {
            if (bank >= 2.0M)
            {
                credit = credit + 2.0M;
                bank = bank - 2.0M;
                lblCredit.Text = "Credit: " + credit;
                lblBank.Text = "Bank: " + bank;
            }
        }

        private void btnDouble_Click(object sender, EventArgs e)
        {
            if (doubleOrNothing == true)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (luckySpin == true)
            {
                luckySpin = false;
                button1.BackColor = Color.LemonChiffon;
                skillstop = true;
                if(skill == 1 || skill == 5 || skill == 9 || skill == 13)
                {
                    richTextBox1.Text += "You have won £3!" + Environment.NewLine;
                    bank = bank + 3.0M;
                    lblBank.Text = "Bank: " + bank;
                }
                else if (skill == 3)
                {
                    richTextBox1.Text += "You have won £5!" + Environment.NewLine;
                    bank = bank + 5.0M;
                    lblBank.Text = "Bank: " + bank;
                }
                else if (skill == 6 || skill == 10 || skill == 12 || skill == 0)
                {
                    richTextBox1.Text += "You have won £2!" + Environment.NewLine;
                    bank = bank + 2.0M;
                    lblBank.Text = "Bank: " + bank;
                }
                else if (skill == 7 || skill == 14)
                {
                    richTextBox1.Text += "You have won £10!" + Environment.NewLine;
                    bank = bank + 10.0M;
                    lblBank.Text = "Bank: " + bank;
                }
                else
                {
                    richTextBox1.Text += "You have lost! L bozo." + Environment.NewLine;
                }
            }
        }

        int skill = 0;
        bool skillstop = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (skillstop == false)
            {
                skill++;
                if (skill <= 15)
                {
                    if (skill == 1)
                    {
                        lblRandom1.BackColor = Color.Gray;
                        lblRandom16.BackColor = Color.Gainsboro;
                    }
                    if (skill == 2)
                    {
                        lblRandom2.BackColor = Color.Gray;
                        lblRandom1.BackColor = Color.Gainsboro;
                    }

                    if (skill == 3)
                    {
                        lblRandom3.BackColor = Color.Gray;
                        lblRandom2.BackColor = Color.Gainsboro;
                    }
                    if (skill == 4)
                    {
                        lblRandom4.BackColor = Color.Gray;
                        lblRandom3.BackColor = Color.Gainsboro;
                    }
                    if (skill == 5)
                    {
                        lblRandom5.BackColor = Color.Gray;
                        lblRandom4.BackColor = Color.Gainsboro;
                    }
                    if (skill == 6)
                    {
                        lblRandom6.BackColor = Color.Gray;
                        lblRandom5.BackColor = Color.Gainsboro;
                    }
                    if (skill == 7)
                    {
                        lblRandom7.BackColor = Color.Gray;
                        lblRandom6.BackColor = Color.Gainsboro;
                    }
                    if (skill == 8)
                    {
                        lblRandom8.BackColor = Color.Gray;
                        lblRandom7.BackColor = Color.Gainsboro;
                    }
                    if (skill == 9)
                    {
                        lblRandom9.BackColor = Color.Gray;
                        lblRandom8.BackColor = Color.Gainsboro;
                    }
                    if (skill == 10)
                    {
                        lblRandom10.BackColor = Color.Gray;
                        lblRandom9.BackColor = Color.Gainsboro;
                    }
                    if (skill == 11)
                    {
                        lblRandom11.BackColor = Color.Gray;
                        lblRandom10.BackColor = Color.Gainsboro;
                    }
                    if (skill == 12)
                    {
                        lblRandom12.BackColor = Color.Gray;
                        lblRandom11.BackColor = Color.Gainsboro;
                    }
                    if (skill == 13)
                    {
                        lblRandom13.BackColor = Color.Gray;
                        lblRandom12.BackColor = Color.Gainsboro;
                    }
                    if (skill == 14)
                    {
                        lblRandom14.BackColor = Color.Gray;
                        lblRandom13.BackColor = Color.Gainsboro;
                    }
                    if (skill == 15)
                    {
                        lblRandom15.BackColor = Color.Gray;
                        lblRandom14.BackColor = Color.Gainsboro;
                    }

                }
                else
                {
                    skill = 0;
                    lblRandom16.BackColor = Color.Gray;
                    lblRandom15.BackColor = Color.Gainsboro;
                }
            }
        }

        private void Spinnyspin_Tick(object sender, EventArgs e)
        {
            if (thespinner2 < 10)
            {
                if (holdbtn1on == false)
                {
                    slot1num = MrsRandom.Next(0, 7);
                    pbSlot1.BackgroundImage = fruits[slot1num];

                }
                if (holdbtn2on == false)
                {
                    slot2num = MrsRandom.Next(0, 7);
                    pbSlot2.BackgroundImage = fruits[slot2num];
                }
                if (holdbtn3on == false)
                {
                    slot3num = MrsRandom.Next(0, 7);
                    pbSlot3.BackgroundImage = fruits[slot3num];
                }
                if (holdbtn4on == false)
                {
                    slot4num = MrsRandom.Next(0, 7);
                    pbSlot4.BackgroundImage = fruits[slot4num];

                }
                thespinner2++;
            }
            else
            {
                thespinner2 = 0;
                spinnyspin.Enabled = false;
            }
        }
    }
}

