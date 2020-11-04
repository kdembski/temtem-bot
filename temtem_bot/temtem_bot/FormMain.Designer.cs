namespace temtem_bot
{
    partial class FormMain
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
            this.backgroundWorkerBotMain = new System.ComponentModel.BackgroundWorker();
            this.checkedListBoxTerrain = new System.Windows.Forms.CheckedListBox();
            this.labelHuntingTime = new System.Windows.Forms.Label();
            this.labelMinutes = new System.Windows.Forms.Label();
            this.labelHours = new System.Windows.Forms.Label();
            this.labelColon2 = new System.Windows.Forms.Label();
            this.labelColon1 = new System.Windows.Forms.Label();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.timerHuntingTime = new System.Windows.Forms.Timer(this.components);
            this.labelEncounters = new System.Windows.Forms.Label();
            this.labelEncountersCounter = new System.Windows.Forms.Label();
            this.comboBoxChooseSpot = new System.Windows.Forms.ComboBox();
            this.checkBoxHealNBuy = new System.Windows.Forms.CheckBox();
            this.buttonFreetemCounterReset = new System.Windows.Forms.Button();
            this.labelFreetemCounter = new System.Windows.Forms.Label();
            this.labelFreetemName = new System.Windows.Forms.Label();
            this.checkBoxCatch1SV = new System.Windows.Forms.CheckBox();
            this.labelFreetem = new System.Windows.Forms.Label();
            this.labelTerrain = new System.Windows.Forms.Label();
            this.labelInstructions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backgroundWorkerBotMain
            // 
            this.backgroundWorkerBotMain.WorkerReportsProgress = true;
            this.backgroundWorkerBotMain.WorkerSupportsCancellation = true;
            this.backgroundWorkerBotMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerBotMain_DoWork);
            // 
            // checkedListBoxTerrain
            // 
            this.checkedListBoxTerrain.CheckOnClick = true;
            this.checkedListBoxTerrain.FormattingEnabled = true;
            this.checkedListBoxTerrain.Items.AddRange(new object[] {
            "Grass",
            "Water",
            "Cave"});
            this.checkedListBoxTerrain.Location = new System.Drawing.Point(227, 26);
            this.checkedListBoxTerrain.Name = "checkedListBoxTerrain";
            this.checkedListBoxTerrain.Size = new System.Drawing.Size(114, 49);
            this.checkedListBoxTerrain.TabIndex = 0;
            this.checkedListBoxTerrain.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxTerrain_ItemCheck);
            // 
            // labelHuntingTime
            // 
            this.labelHuntingTime.AutoSize = true;
            this.labelHuntingTime.BackColor = System.Drawing.Color.Transparent;
            this.labelHuntingTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelHuntingTime.ForeColor = System.Drawing.Color.Black;
            this.labelHuntingTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHuntingTime.Location = new System.Drawing.Point(6, 8);
            this.labelHuntingTime.Name = "labelHuntingTime";
            this.labelHuntingTime.Size = new System.Drawing.Size(108, 16);
            this.labelHuntingTime.TabIndex = 12;
            this.labelHuntingTime.Text = "HUNTING TIME:";
            this.labelHuntingTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMinutes
            // 
            this.labelMinutes.AutoSize = true;
            this.labelMinutes.BackColor = System.Drawing.Color.Transparent;
            this.labelMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelMinutes.ForeColor = System.Drawing.Color.Black;
            this.labelMinutes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelMinutes.Location = new System.Drawing.Point(144, 8);
            this.labelMinutes.Name = "labelMinutes";
            this.labelMinutes.Size = new System.Drawing.Size(22, 16);
            this.labelMinutes.TabIndex = 9;
            this.labelMinutes.Text = "00";
            this.labelMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHours
            // 
            this.labelHours.AutoSize = true;
            this.labelHours.BackColor = System.Drawing.Color.Transparent;
            this.labelHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelHours.ForeColor = System.Drawing.Color.Black;
            this.labelHours.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelHours.Location = new System.Drawing.Point(120, 8);
            this.labelHours.Name = "labelHours";
            this.labelHours.Size = new System.Drawing.Size(22, 16);
            this.labelHours.TabIndex = 7;
            this.labelHours.Text = "00";
            this.labelHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelColon2
            // 
            this.labelColon2.AutoSize = true;
            this.labelColon2.BackColor = System.Drawing.Color.Transparent;
            this.labelColon2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelColon2.ForeColor = System.Drawing.Color.Black;
            this.labelColon2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelColon2.Location = new System.Drawing.Point(162, 8);
            this.labelColon2.Name = "labelColon2";
            this.labelColon2.Size = new System.Drawing.Size(11, 16);
            this.labelColon2.TabIndex = 11;
            this.labelColon2.Text = ":";
            this.labelColon2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelColon1
            // 
            this.labelColon1.AutoSize = true;
            this.labelColon1.BackColor = System.Drawing.Color.Transparent;
            this.labelColon1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelColon1.ForeColor = System.Drawing.Color.Black;
            this.labelColon1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelColon1.Location = new System.Drawing.Point(138, 8);
            this.labelColon1.Name = "labelColon1";
            this.labelColon1.Size = new System.Drawing.Size(11, 16);
            this.labelColon1.TabIndex = 8;
            this.labelColon1.Text = ":";
            this.labelColon1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.BackColor = System.Drawing.Color.Transparent;
            this.labelSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelSeconds.ForeColor = System.Drawing.Color.Black;
            this.labelSeconds.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelSeconds.Location = new System.Drawing.Point(168, 8);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(22, 16);
            this.labelSeconds.TabIndex = 10;
            this.labelSeconds.Text = "00";
            this.labelSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerHuntingTime
            // 
            this.timerHuntingTime.Enabled = true;
            this.timerHuntingTime.Interval = 1000;
            this.timerHuntingTime.Tick += new System.EventHandler(this.timerHuntingTime_Tick);
            // 
            // labelEncounters
            // 
            this.labelEncounters.AutoSize = true;
            this.labelEncounters.BackColor = System.Drawing.Color.Transparent;
            this.labelEncounters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelEncounters.ForeColor = System.Drawing.Color.Black;
            this.labelEncounters.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelEncounters.Location = new System.Drawing.Point(6, 26);
            this.labelEncounters.Name = "labelEncounters";
            this.labelEncounters.Size = new System.Drawing.Size(106, 16);
            this.labelEncounters.TabIndex = 17;
            this.labelEncounters.Text = "ENCOUNTERS:";
            this.labelEncounters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEncountersCounter
            // 
            this.labelEncountersCounter.AutoSize = true;
            this.labelEncountersCounter.BackColor = System.Drawing.Color.Transparent;
            this.labelEncountersCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelEncountersCounter.ForeColor = System.Drawing.Color.Black;
            this.labelEncountersCounter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelEncountersCounter.Location = new System.Drawing.Point(118, 26);
            this.labelEncountersCounter.Name = "labelEncountersCounter";
            this.labelEncountersCounter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelEncountersCounter.Size = new System.Drawing.Size(15, 16);
            this.labelEncountersCounter.TabIndex = 18;
            this.labelEncountersCounter.Text = "0";
            this.labelEncountersCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxChooseSpot
            // 
            this.comboBoxChooseSpot.Enabled = false;
            this.comboBoxChooseSpot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.comboBoxChooseSpot.ForeColor = System.Drawing.Color.Black;
            this.comboBoxChooseSpot.FormattingEnabled = true;
            this.comboBoxChooseSpot.Items.AddRange(new object[] {
            "Magmis",
            "Grumvel"});
            this.comboBoxChooseSpot.Location = new System.Drawing.Point(227, 149);
            this.comboBoxChooseSpot.Name = "comboBoxChooseSpot";
            this.comboBoxChooseSpot.Size = new System.Drawing.Size(118, 21);
            this.comboBoxChooseSpot.TabIndex = 34;
            this.comboBoxChooseSpot.Text = "Choose spot...";
            // 
            // checkBoxHealNBuy
            // 
            this.checkBoxHealNBuy.AutoSize = true;
            this.checkBoxHealNBuy.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxHealNBuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.checkBoxHealNBuy.ForeColor = System.Drawing.Color.Black;
            this.checkBoxHealNBuy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxHealNBuy.Location = new System.Drawing.Point(227, 123);
            this.checkBoxHealNBuy.Name = "checkBoxHealNBuy";
            this.checkBoxHealNBuy.Size = new System.Drawing.Size(163, 20);
            this.checkBoxHealNBuy.TabIndex = 33;
            this.checkBoxHealNBuy.Text = "Heal tems && Buy cards";
            this.checkBoxHealNBuy.UseVisualStyleBackColor = false;
            this.checkBoxHealNBuy.CheckedChanged += new System.EventHandler(this.checkBoxHealNBuy_CheckedChanged);
            // 
            // buttonFreetemCounterReset
            // 
            this.buttonFreetemCounterReset.BackColor = System.Drawing.Color.White;
            this.buttonFreetemCounterReset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonFreetemCounterReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSeaGreen;
            this.buttonFreetemCounterReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonFreetemCounterReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFreetemCounterReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonFreetemCounterReset.ForeColor = System.Drawing.Color.Black;
            this.buttonFreetemCounterReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonFreetemCounterReset.Location = new System.Drawing.Point(227, 201);
            this.buttonFreetemCounterReset.Name = "buttonFreetemCounterReset";
            this.buttonFreetemCounterReset.Size = new System.Drawing.Size(118, 23);
            this.buttonFreetemCounterReset.TabIndex = 29;
            this.buttonFreetemCounterReset.Text = "Counter reset";
            this.buttonFreetemCounterReset.UseVisualStyleBackColor = false;
            this.buttonFreetemCounterReset.Click += new System.EventHandler(this.buttonFreetemCounterReset_Click);
            // 
            // labelFreetemCounter
            // 
            this.labelFreetemCounter.AutoSize = true;
            this.labelFreetemCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelFreetemCounter.ForeColor = System.Drawing.Color.Black;
            this.labelFreetemCounter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFreetemCounter.Location = new System.Drawing.Point(326, 182);
            this.labelFreetemCounter.Name = "labelFreetemCounter";
            this.labelFreetemCounter.Size = new System.Drawing.Size(15, 16);
            this.labelFreetemCounter.TabIndex = 30;
            this.labelFreetemCounter.Text = "0";
            // 
            // labelFreetemName
            // 
            this.labelFreetemName.AutoSize = true;
            this.labelFreetemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.labelFreetemName.ForeColor = System.Drawing.Color.Black;
            this.labelFreetemName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelFreetemName.Location = new System.Drawing.Point(224, 182);
            this.labelFreetemName.Name = "labelFreetemName";
            this.labelFreetemName.Size = new System.Drawing.Size(108, 16);
            this.labelFreetemName.TabIndex = 31;
            this.labelFreetemName.Text = "Freetem counter:";
            // 
            // checkBoxCatch1SV
            // 
            this.checkBoxCatch1SV.AutoSize = true;
            this.checkBoxCatch1SV.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxCatch1SV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.checkBoxCatch1SV.ForeColor = System.Drawing.Color.Black;
            this.checkBoxCatch1SV.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBoxCatch1SV.Location = new System.Drawing.Point(227, 97);
            this.checkBoxCatch1SV.Name = "checkBoxCatch1SV";
            this.checkBoxCatch1SV.Size = new System.Drawing.Size(88, 20);
            this.checkBoxCatch1SV.TabIndex = 28;
            this.checkBoxCatch1SV.Text = "Catch 1 sv";
            this.checkBoxCatch1SV.UseVisualStyleBackColor = false;
            // 
            // labelFreetem
            // 
            this.labelFreetem.AutoSize = true;
            this.labelFreetem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelFreetem.Location = new System.Drawing.Point(224, 78);
            this.labelFreetem.Name = "labelFreetem";
            this.labelFreetem.Size = new System.Drawing.Size(124, 16);
            this.labelFreetem.TabIndex = 35;
            this.labelFreetem.Text = "Freetem options:";
            // 
            // labelTerrain
            // 
            this.labelTerrain.AutoSize = true;
            this.labelTerrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelTerrain.Location = new System.Drawing.Point(224, 7);
            this.labelTerrain.Name = "labelTerrain";
            this.labelTerrain.Size = new System.Drawing.Size(113, 16);
            this.labelTerrain.TabIndex = 36;
            this.labelTerrain.Text = "Choose terrain:";
            // 
            // labelInstructions
            // 
            this.labelInstructions.AutoSize = true;
            this.labelInstructions.Location = new System.Drawing.Point(6, 56);
            this.labelInstructions.Name = "labelInstructions";
            this.labelInstructions.Size = new System.Drawing.Size(205, 39);
            this.labelInstructions.TabIndex = 37;
            this.labelInstructions.Text = "Press F9 to start and stop Freetem farming\r\nPress F10 to start and stop Luma hunt" +
    "ing\r\nPress F11 to start and stop Exp training";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 231);
            this.Controls.Add(this.labelInstructions);
            this.Controls.Add(this.labelTerrain);
            this.Controls.Add(this.labelFreetem);
            this.Controls.Add(this.comboBoxChooseSpot);
            this.Controls.Add(this.checkBoxHealNBuy);
            this.Controls.Add(this.buttonFreetemCounterReset);
            this.Controls.Add(this.labelFreetemCounter);
            this.Controls.Add(this.labelFreetemName);
            this.Controls.Add(this.checkBoxCatch1SV);
            this.Controls.Add(this.labelEncounters);
            this.Controls.Add(this.labelEncountersCounter);
            this.Controls.Add(this.labelHuntingTime);
            this.Controls.Add(this.labelMinutes);
            this.Controls.Add(this.labelHours);
            this.Controls.Add(this.labelColon1);
            this.Controls.Add(this.labelSeconds);
            this.Controls.Add(this.checkedListBoxTerrain);
            this.Controls.Add(this.labelColon2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TemtemBot";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorkerBotMain;
        private System.Windows.Forms.CheckedListBox checkedListBoxTerrain;
        private System.Windows.Forms.Label labelHuntingTime;
        private System.Windows.Forms.Label labelMinutes;
        private System.Windows.Forms.Label labelHours;
        private System.Windows.Forms.Label labelColon2;
        private System.Windows.Forms.Label labelColon1;
        private System.Windows.Forms.Label labelSeconds;
        private System.Windows.Forms.Timer timerHuntingTime;
        private System.Windows.Forms.Label labelEncounters;
        private System.Windows.Forms.Label labelEncountersCounter;
        private System.Windows.Forms.ComboBox comboBoxChooseSpot;
        private System.Windows.Forms.CheckBox checkBoxHealNBuy;
        private System.Windows.Forms.Button buttonFreetemCounterReset;
        private System.Windows.Forms.Label labelFreetemCounter;
        private System.Windows.Forms.Label labelFreetemName;
        private System.Windows.Forms.CheckBox checkBoxCatch1SV;
        private System.Windows.Forms.Label labelFreetem;
        private System.Windows.Forms.Label labelTerrain;
        private System.Windows.Forms.Label labelInstructions;
    }
}

