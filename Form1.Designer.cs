namespace Rummy
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.drawDiscardBtn = new System.Windows.Forms.Button();
            this.discardDeckList = new System.Windows.Forms.ListBox();
            this.drawDeckBtn = new System.Windows.Forms.Button();
            this.newGameBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.handDeckList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.deckLbl = new System.Windows.Forms.Label();
            this.fullDeckList = new System.Windows.Forms.ListBox();
            this.comDeckList = new System.Windows.Forms.ListBox();
            this.discardFromHandBtn = new System.Windows.Forms.Button();
            this.turnLbl = new System.Windows.Forms.Label();
            this.winnerLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sortValueBtn = new System.Windows.Forms.Button();
            this.sortSuitBtn = new System.Windows.Forms.Button();
            this.AI2Check = new System.Windows.Forms.CheckBox();
            this.oddsLbl = new System.Windows.Forms.Label();
            this.comLvl = new System.Windows.Forms.NumericUpDown();
            this.playLvl = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comLvl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playLvl)).BeginInit();
            this.SuspendLayout();
            // 
            // drawDiscardBtn
            // 
            this.drawDiscardBtn.Enabled = false;
            this.drawDiscardBtn.Location = new System.Drawing.Point(203, 134);
            this.drawDiscardBtn.Name = "drawDiscardBtn";
            this.drawDiscardBtn.Size = new System.Drawing.Size(131, 51);
            this.drawDiscardBtn.TabIndex = 0;
            this.drawDiscardBtn.Text = "Draw from Discard";
            this.drawDiscardBtn.UseVisualStyleBackColor = true;
            this.drawDiscardBtn.Click += new System.EventHandler(this.drawDiscardBtn_Click);
            // 
            // discardDeckList
            // 
            this.discardDeckList.FormattingEnabled = true;
            this.discardDeckList.Location = new System.Drawing.Point(17, 134);
            this.discardDeckList.Name = "discardDeckList";
            this.discardDeckList.Size = new System.Drawing.Size(180, 199);
            this.discardDeckList.TabIndex = 1;
            // 
            // drawDeckBtn
            // 
            this.drawDeckBtn.Enabled = false;
            this.drawDeckBtn.Location = new System.Drawing.Point(203, 191);
            this.drawDeckBtn.Name = "drawDeckBtn";
            this.drawDeckBtn.Size = new System.Drawing.Size(131, 51);
            this.drawDeckBtn.TabIndex = 2;
            this.drawDeckBtn.Text = "Draw from Deck";
            this.drawDeckBtn.UseVisualStyleBackColor = true;
            this.drawDeckBtn.Click += new System.EventHandler(this.drawDeckBtn_Click);
            // 
            // newGameBtn
            // 
            this.newGameBtn.Location = new System.Drawing.Point(203, 248);
            this.newGameBtn.Name = "newGameBtn";
            this.newGameBtn.Size = new System.Drawing.Size(131, 51);
            this.newGameBtn.TabIndex = 3;
            this.newGameBtn.Text = "New Game";
            this.newGameBtn.UseVisualStyleBackColor = true;
            this.newGameBtn.Click += new System.EventHandler(this.newGameBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Discard Pile";
            // 
            // handDeckList
            // 
            this.handDeckList.FormattingEnabled = true;
            this.handDeckList.Location = new System.Drawing.Point(616, 134);
            this.handDeckList.Name = "handDeckList";
            this.handDeckList.Size = new System.Drawing.Size(170, 199);
            this.handDeckList.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(616, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hand";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Rummy.Properties.Resources.Gray_back;
            this.pictureBox1.Location = new System.Drawing.Point(340, 134);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // deckLbl
            // 
            this.deckLbl.AutoSize = true;
            this.deckLbl.Location = new System.Drawing.Point(339, 121);
            this.deckLbl.Name = "deckLbl";
            this.deckLbl.Size = new System.Drawing.Size(105, 13);
            this.deckLbl.TabIndex = 8;
            this.deckLbl.Text = "Cards Remaining: 52";
            // 
            // fullDeckList
            // 
            this.fullDeckList.FormattingEnabled = true;
            this.fullDeckList.Location = new System.Drawing.Point(17, 65);
            this.fullDeckList.Name = "fullDeckList";
            this.fullDeckList.Size = new System.Drawing.Size(190, 17);
            this.fullDeckList.TabIndex = 9;
            this.fullDeckList.Visible = false;
            // 
            // comDeckList
            // 
            this.comDeckList.FormattingEnabled = true;
            this.comDeckList.Location = new System.Drawing.Point(17, 91);
            this.comDeckList.Name = "comDeckList";
            this.comDeckList.Size = new System.Drawing.Size(190, 17);
            this.comDeckList.TabIndex = 10;
            this.comDeckList.Visible = false;
            // 
            // discardFromHandBtn
            // 
            this.discardFromHandBtn.Enabled = false;
            this.discardFromHandBtn.Location = new System.Drawing.Point(479, 134);
            this.discardFromHandBtn.Name = "discardFromHandBtn";
            this.discardFromHandBtn.Size = new System.Drawing.Size(131, 51);
            this.discardFromHandBtn.TabIndex = 11;
            this.discardFromHandBtn.Text = "Discard Selected";
            this.discardFromHandBtn.UseVisualStyleBackColor = true;
            this.discardFromHandBtn.Click += new System.EventHandler(this.discardFromHandBtn_Click);
            // 
            // turnLbl
            // 
            this.turnLbl.AutoSize = true;
            this.turnLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnLbl.Location = new System.Drawing.Point(337, 91);
            this.turnLbl.Name = "turnLbl";
            this.turnLbl.Size = new System.Drawing.Size(106, 20);
            this.turnLbl.TabIndex = 12;
            this.turnLbl.Text = "Current Turn: ";
            // 
            // winnerLbl
            // 
            this.winnerLbl.AutoSize = true;
            this.winnerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winnerLbl.ForeColor = System.Drawing.Color.Red;
            this.winnerLbl.Location = new System.Drawing.Point(536, 24);
            this.winnerLbl.Name = "winnerLbl";
            this.winnerLbl.Size = new System.Drawing.Size(0, 25);
            this.winnerLbl.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 25);
            this.label3.TabIndex = 14;
            this.label3.Text = "1 Handed Rummy";
            // 
            // sortValueBtn
            // 
            this.sortValueBtn.Enabled = false;
            this.sortValueBtn.Location = new System.Drawing.Point(479, 191);
            this.sortValueBtn.Name = "sortValueBtn";
            this.sortValueBtn.Size = new System.Drawing.Size(131, 51);
            this.sortValueBtn.TabIndex = 15;
            this.sortValueBtn.Text = "Sort by Value";
            this.sortValueBtn.UseVisualStyleBackColor = true;
            this.sortValueBtn.Click += new System.EventHandler(this.sortValueBtn_Click);
            // 
            // sortSuitBtn
            // 
            this.sortSuitBtn.Enabled = false;
            this.sortSuitBtn.Location = new System.Drawing.Point(479, 248);
            this.sortSuitBtn.Name = "sortSuitBtn";
            this.sortSuitBtn.Size = new System.Drawing.Size(131, 51);
            this.sortSuitBtn.TabIndex = 16;
            this.sortSuitBtn.Text = "Sort by Suit";
            this.sortSuitBtn.UseVisualStyleBackColor = true;
            this.sortSuitBtn.Click += new System.EventHandler(this.sortSuitBtn_Click);
            // 
            // AI2Check
            // 
            this.AI2Check.AutoSize = true;
            this.AI2Check.Location = new System.Drawing.Point(214, 65);
            this.AI2Check.Name = "AI2Check";
            this.AI2Check.Size = new System.Drawing.Size(97, 17);
            this.AI2Check.TabIndex = 17;
            this.AI2Check.Text = "Two AI Players";
            this.AI2Check.UseVisualStyleBackColor = true;
            this.AI2Check.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // oddsLbl
            // 
            this.oddsLbl.AutoSize = true;
            this.oddsLbl.Location = new System.Drawing.Point(207, 309);
            this.oddsLbl.Name = "oddsLbl";
            this.oddsLbl.Size = new System.Drawing.Size(0, 13);
            this.oddsLbl.TabIndex = 18;
            // 
            // comLvl
            // 
            this.comLvl.Location = new System.Drawing.Point(574, 65);
            this.comLvl.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.comLvl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.comLvl.Name = "comLvl";
            this.comLvl.Size = new System.Drawing.Size(36, 20);
            this.comLvl.TabIndex = 19;
            this.comLvl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // playLvl
            // 
            this.playLvl.Location = new System.Drawing.Point(574, 88);
            this.playLvl.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.playLvl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.playLvl.Name = "playLvl";
            this.playLvl.Size = new System.Drawing.Size(36, 20);
            this.playLvl.TabIndex = 20;
            this.playLvl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(616, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Computer Level";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(616, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Player Level";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(479, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 28);
            this.button1.TabIndex = 23;
            this.button1.Text = "Play Loop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 338);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.playLvl);
            this.Controls.Add(this.comLvl);
            this.Controls.Add(this.oddsLbl);
            this.Controls.Add(this.AI2Check);
            this.Controls.Add(this.sortSuitBtn);
            this.Controls.Add(this.sortValueBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.winnerLbl);
            this.Controls.Add(this.turnLbl);
            this.Controls.Add(this.discardFromHandBtn);
            this.Controls.Add(this.comDeckList);
            this.Controls.Add(this.fullDeckList);
            this.Controls.Add(this.deckLbl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.handDeckList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newGameBtn);
            this.Controls.Add(this.drawDeckBtn);
            this.Controls.Add(this.discardDeckList);
            this.Controls.Add(this.drawDiscardBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Play Rummy";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comLvl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playLvl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button drawDiscardBtn;
        private System.Windows.Forms.ListBox discardDeckList;
        private System.Windows.Forms.Button drawDeckBtn;
        private System.Windows.Forms.Button newGameBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox handDeckList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label deckLbl;
        private System.Windows.Forms.ListBox fullDeckList;
        private System.Windows.Forms.ListBox comDeckList;
        private System.Windows.Forms.Button discardFromHandBtn;
        private System.Windows.Forms.Label turnLbl;
        private System.Windows.Forms.Label winnerLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sortValueBtn;
        private System.Windows.Forms.Button sortSuitBtn;
        private System.Windows.Forms.CheckBox AI2Check;
        private System.Windows.Forms.Label oddsLbl;
        private System.Windows.Forms.NumericUpDown comLvl;
        private System.Windows.Forms.NumericUpDown playLvl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}

