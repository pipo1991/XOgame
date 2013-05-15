using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            newGame();
        }

        private void newGame()
        {
            turn = 0;
            scX = 0;
            scY = 0;
            nextGame();
        }

        private void nextGame()
        {
            arrX = new bool[3, 3];
            arrY = new bool[3, 3];
            clicked = 0;
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            score1.Text = scX + "";
            score2.Text = scY + "";
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is game is developed by Patrick Ragi.", "About"); ;
        }

        private void actionPreformed(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            if (!(but.Text == "X" && but.Text == "O"))
            {
                clicked++;
                int index = mapKey(but.Name);
                if (turn == 0)
                {
                    but.Text = "X";
                    arrX[index / 3,index % 3]=true;
                    if (checkWin(arrX))
                    {
                        MessageBox.Show("X wins", "Congratulations!");
                        turn = 0;
                        turnLab.Text = "X";
                        scX++;
                        nextGame();
                    }
                    else
                    {
                        turn = 1;
                        turnLab.Text = "O";
                        if (clicked == 9)
                        {
                            MessageBox.Show("It is a tie", "OOPS!!");
                            nextGame();
                        }
                    }
                }
                else
                {
                    but.Text = "O";
                    arrY[index / 3, index % 3] = true;
                    if (checkWin(arrY))
                    {
                        MessageBox.Show("O wins","Congratulations!");
                        turn = 1;
                        turnLab.Text = "O";
                        scY++;
                        nextGame();
                    }
                    else
                    {
                        turn = 0;
                        turnLab.Text = "X";
                        if (clicked == 9)
                        {
                            MessageBox.Show("It is a tie", "OOPS!!");
                            nextGame();
                        }
                    }
                }
            }
            
        }

        private bool checkWin(bool[,]arr){
            for (int i = 0; i < 3; i++)
            {
                bool flag1 = true;
                bool flag2 = true;
                for (int j = 0; j < 3; j++)
                {
                    flag1 &= arr[i,j];
                    flag2 &= arr[j,i];
                }
                if (flag1 || flag2)
                {
                    return true;
                }
            }
            if (arr[0,0] && arr[1,1] && arr[2,2])
            {
                return true;
            }
            if (arr[2,0] && arr[1,1] && arr[0,2])
            {
                return true;
            }
            return false;
        }

        private int mapKey(String s)
        {
            return int.Parse(s.Substring(6)) - 1;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private int turn;
        private int scX;
        private int scY;
        private bool[,] arrX;
        private bool[,] arrY;
        private int clicked;
    }
}
