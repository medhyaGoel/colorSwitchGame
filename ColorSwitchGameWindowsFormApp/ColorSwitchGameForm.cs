using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorSwitchGameWindowsFormApp
{
    public partial class ColorSwitchGameForm : Form
    {
        string name = "";
        int colorID = 0;
        Random r = new Random();
        int time = 0;
        int[] highestScores = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        String[] initials = {null, null, null, null, null, null, null, null, null, null};
        int score = 0;
        public Boolean _isRunning = false;
        Color[] colors = { Color.Blue, Color.Green, Color.Red, Color.Purple, Color.Yellow };
        String HIGH_SCORE_FULL_PATH;
        public ColorSwitchGameForm()
        {
            InitializeComponent();
            // initialize the path to the high scores file
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            appDataPath = System.IO.Path.Combine(appDataPath, "ColorSwitchGame");
            System.IO.Directory.CreateDirectory(appDataPath);
            HIGH_SCORE_FULL_PATH = System.IO.Path.Combine(appDataPath, "HighScores.txt");
            LoadHighScores();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //random colors
            time = 0;
            foreach (Control c in this.Controls)
            {
                if (c.Tag != null && c.Tag.ToString().StartsWith("obstacle"))
                {
                    //random color assignment;

                    if (c.Tag.ToString().Equals("obstacle1"))
                    {
                        c.Top = 0;
                        c.BackColor = colors[r.Next(0, 4)];
                    }
                    else if (c.Tag.ToString().Equals("obstacle2"))
                    {
                        c.Top = -20;
                        c.BackColor = colors[r.Next(0, 4)];
                    }
                }
            }
            //start/reset timer
            timerGame.Start();
            _isRunning = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_isRunning) {
                time += 2;
                //when started, move boxes
                foreach(Control c in this.panel.Controls)
                {
                    if(c.Tag != null && c.Tag.ToString().StartsWith("obstacle"))
                    {
                        c.Top += 10;
                        if (c.Bottom >= 360)
                        {
                            c.Top = 0;
                            //random color assignment;
                            c.BackColor = colors[r.Next(0, 4)];
                        }
                    }
                }
                //if box touches player box and colors match
                if (playerBox.Bounds.IntersectsWith(obstacle1.Bounds) && playerBox.BackColor.Equals(obstacle1.BackColor))
                    score++;
                else if (playerBox.Bounds.IntersectsWith(obstacle2.Bounds) && playerBox.BackColor.Equals(obstacle2.BackColor))
                    score++;
                else if (playerBox.Bounds.IntersectsWith(obstacle1.Bounds) || playerBox.Bounds.IntersectsWith(obstacle2.Bounds)) {
                  //end timer
                    timerGame.Stop();
                    _isRunning = false;
                    //update leaderboard text file
                    WriteHighScores(score);
                    //refresh leaderboard in game
                    LoadHighScores();
                    score = 0;
                }
                 scoreLabel.Text = "Your score is: " + score.ToString();
            }
        }

        public static string GetInitials(string title, string text)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 140,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 10, Top = 10, Text = text, Width = 250 };
            TextBox textBox = new TextBox() { Left = 10, Top = 30, Width = 250 };
            Button okButton = new Button()
            {
                Text = "OK",
                Left = 10,
                Width = 50,
                Top = 60,
                DialogResult = DialogResult.OK
            };
            okButton.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(okButton);
            prompt.Controls.Add(textLabel);
            prompt.MaximizeBox = false;
            prompt.MinimizeBox = false;
            prompt.AcceptButton = okButton;
            prompt.ShowDialog();

            return textBox.Text.Trim();
        }

        private void ColorSwitchGameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isRunning)
            {
                if(e.KeyCode == Keys.Space)
                {
                    colorID++;
                    if (colorID == colors.Length)
                        colorID = 0;
                    playerBox.BackColor = colors[colorID];
                }
            }
        }

        private void ColorSwitchGameForm_Load(object sender, EventArgs e)
        {
            LoadHighScores();
        }

        private void LoadHighScores()
        {
            topScoreTextBox.Text = "";
            // load up the high scores
            try
            {
                //creates reader
                StreamReader reader = new StreamReader(HIGH_SCORE_FULL_PATH);
                using (reader)
                {
                    //reads first line
                    string line = reader.ReadLine();
                    int indexer = 0;
                    while (line != null)
                    {

                        // process the current line
                        string[] parts = line.Split(',');
                        string initial = parts[0];
                        initials[indexer] = initial;
                        string scoreA = parts[1];
                        int x;
                            int.TryParse(scoreA, out x);
                        highestScores[indexer] = x;
                        // append the formatted high score to the textBox
                        topScoreTextBox.AppendText($"{initial} {scoreA,6}\r\n");
                        indexer++;
                        // read the next line
                        line = reader.ReadLine();

                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                // do nothing... no high scores yet!
            }
            catch (IOException ex)
            {
                scoreLabel.Text = ("Exception " + ex.Message);
            }
        }

        //write in file
        public void WriteHighScores(int score)
        {
            LoadHighScores();
            //find point in [highest scores] at which to insert high score
            for(int i = 0; i<10; i++)
            {
                //if score is good enough for leader board
                if (score > highestScores[i])
                {
                    //ask for username
                    name = GetInitials("New" + " High Score!", "Enter your initials:");
                    //insert score in array of scores + name in array of initials
                    for(int k = 9; k>i; k--)
                    {
                        highestScores[k] = highestScores[k - 1];
                        initials[k] = initials[k - 1];
                    }
                    highestScores[i] = score;
                    initials[i] = name;
                    //rewrite entire text file
                    try
                    {
                        //creates writer
                        StreamWriter writer = new StreamWriter(HIGH_SCORE_FULL_PATH);
                        using (writer)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                if (highestScores[j] != -1)
                                {
                                    writer.WriteLine(initials[j] + "," + highestScores[j].ToString());
                                }
                            }
                        }
                    }
                    catch (IOException ex)
                    {
                        scoreLabel.Text = ("Exception " + ex.Message);
                    }
                    return;
                }
            }
        }
    }
}
