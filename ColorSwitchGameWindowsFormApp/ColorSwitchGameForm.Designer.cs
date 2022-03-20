
namespace ColorSwitchGameWindowsFormApp
{
    partial class ColorSwitchGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel = new System.Windows.Forms.Panel();
            this.obstacle2 = new System.Windows.Forms.PictureBox();
            this.obstacle1 = new System.Windows.Forms.PictureBox();
            this.playerBox = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.topScoresLabel = new System.Windows.Forms.Label();
            this.topScoreTextBox = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.timerGame = new System.Windows.Forms.Timer(this.components);
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel.Controls.Add(this.obstacle2);
            this.panel.Controls.Add(this.obstacle1);
            this.panel.Controls.Add(this.playerBox);
            this.panel.Location = new System.Drawing.Point(0, 1);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(200, 456);
            this.panel.TabIndex = 0;
            // 
            // obstacle2
            // 
            this.obstacle2.BackColor = System.Drawing.Color.Red;
            this.obstacle2.Location = new System.Drawing.Point(0, 0);
            this.obstacle2.Name = "obstacle2";
            this.obstacle2.Size = new System.Drawing.Size(200, 23);
            this.obstacle2.TabIndex = 2;
            this.obstacle2.TabStop = false;
            this.obstacle2.Tag = "obstacle2";
            // 
            // obstacle1
            // 
            this.obstacle1.BackColor = System.Drawing.Color.Blue;
            this.obstacle1.Location = new System.Drawing.Point(0, 143);
            this.obstacle1.Name = "obstacle1";
            this.obstacle1.Size = new System.Drawing.Size(200, 23);
            this.obstacle1.TabIndex = 1;
            this.obstacle1.TabStop = false;
            this.obstacle1.Tag = "obstacle1";
            // 
            // playerBox
            // 
            this.playerBox.BackColor = System.Drawing.Color.AliceBlue;
            this.playerBox.Location = new System.Drawing.Point(60, 349);
            this.playerBox.Name = "playerBox";
            this.playerBox.Size = new System.Drawing.Size(100, 26);
            this.playerBox.TabIndex = 0;
            this.playerBox.TabStop = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(236, 27);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(70, 13);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "Your score: 0";
            // 
            // topScoresLabel
            // 
            this.topScoresLabel.AutoSize = true;
            this.topScoresLabel.Location = new System.Drawing.Point(236, 71);
            this.topScoresLabel.Name = "topScoresLabel";
            this.topScoresLabel.Size = new System.Drawing.Size(78, 13);
            this.topScoresLabel.TabIndex = 2;
            this.topScoresLabel.Text = "Top 10 scores:";
            // 
            // topScoreTextBox
            // 
            this.topScoreTextBox.Location = new System.Drawing.Point(239, 99);
            this.topScoreTextBox.Multiline = true;
            this.topScoreTextBox.Name = "topScoreTextBox";
            this.topScoreTextBox.ReadOnly = true;
            this.topScoreTextBox.Size = new System.Drawing.Size(100, 204);
            this.topScoreTextBox.TabIndex = 3;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(239, 326);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start/restart";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(239, 364);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // timerGame
            // 
            this.timerGame.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ColorSwitchGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 456);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.topScoreTextBox);
            this.Controls.Add(this.topScoresLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.panel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ColorSwitchGameForm";
            this.Text = "Color Switch Game";
            this.Load += new System.EventHandler(this.ColorSwitchGameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ColorSwitchGameForm_KeyDown);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.obstacle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox playerBox;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label topScoresLabel;
        private System.Windows.Forms.TextBox topScoreTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Timer timerGame;
        private System.Windows.Forms.PictureBox obstacle2;
        private System.Windows.Forms.PictureBox obstacle1;
    }
}

