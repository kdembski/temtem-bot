using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;

namespace temtem_bot
{
    public partial class FormMain : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String sClassName, String sAppName);

        //pointer to form window
        IntPtr thisWindow;
        //hotkeys class object
        Hotkeys hotkeys;
        //bools use for handle main bot functions
        bool huntingLuma = false, expTraining = false, freetemFarming = false;
        //variable store terrain set by check boxes
        string terrain;
        bool catch1SV;
        bool healAndBuy;
        string spot;

        // properties for handling hunting timer
        public static bool HuntingTimerIsActive { get; set; } = false;
        public static int TimeSeconds { get; set; }
        public static int TimeMinutes { get; set; }
        public static int TimeHours { get; set; }

        string freetemCounterSaveFile = "C:/Users/dzojstik90/workspace/temtem_bot/temtem_bot/temtem_bot/Resources/freetemCounterSave.txt";

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            thisWindow = this.Handle;

            //register hotkeys
            hotkeys = new Hotkeys(thisWindow);
            hotkeys.RegisterAllHotkeys();

            //set default value of terrain list box
            checkedListBoxTerrain.SetItemChecked(0, true);

            //read saved freetem counter from file
            // create reader & open file
            TextReader tr = new StreamReader(freetemCounterSaveFile);
            // read lines of text
            string freetemCounter = tr.ReadLine();
            //Convert the strings to int
            BotMain.FreetemCounter = Convert.ToInt32(freetemCounter);
            // close the stream
            tr.Close();
            //update freetem counter
            labelFreetemCounter.Text = BotMain.FreetemCounter.ToString();
        }

        private void checkedListBoxTerrain_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < checkedListBoxTerrain.Items.Count; ++ix)
                if (ix != e.Index) checkedListBoxTerrain.SetItemChecked(ix, false);
        }

        private void timerHuntingTime_Tick(object sender, EventArgs e)
        {
            if (HuntingTimerIsActive)
            {
                TimeSeconds++;
                if (TimeSeconds >= 60)
                {
                    TimeMinutes++;
                    TimeSeconds = 0;
                    if (TimeMinutes >= 60)
                    {
                        TimeHours++;
                        TimeMinutes = 0;
                    }
                }
                labelSeconds.Text = String.Format("{0:00}", TimeSeconds);
                labelMinutes.Text = String.Format("{0:00}", TimeMinutes);
                labelHours.Text = String.Format("{0:00}", TimeHours);
                labelEncountersCounter.Text = BotMain.EncountersCounter.ToString();
                labelFreetemCounter.Text = BotMain.FreetemCounter.ToString();
            }
        }

        private void buttonFreetemCounterReset_Click(object sender, EventArgs e)
        {
            BotMain.FreetemCounter = 0;
            //update freetem counter
            labelFreetemCounter.Text = BotMain.FreetemCounter.ToString();
        }

        private void checkBoxHealNBuy_CheckedChanged(object sender, EventArgs e)
        {
            //enable spot combobox
            if (checkBoxHealNBuy.Checked)
            {
                comboBoxChooseSpot.Enabled = true;
            }
            else
            {
                comboBoxChooseSpot.Enabled = false;
            }
        }

        protected override void WndProc(ref Message keyPressed)
        {
            //check if catch 1 sv checkbox is checked
            if (checkBoxCatch1SV.Checked == true)
            {
                catch1SV = true;
            }
            else
            {
                catch1SV = false;
            }
            //check if heal and buy checkbox is checked
            if (checkBoxHealNBuy.Checked == true)
            {
                healAndBuy = true;
            }
            else
            {
                healAndBuy = false;
            }
            //get selected item for spot combobox to string
            if (comboBoxChooseSpot.SelectedItem != null)
            {
                spot = comboBoxChooseSpot.SelectedItem.ToString();
            }

            if (keyPressed.Msg == 0x0312)
            {
                //put chosen terrain name into string
                terrain = checkedListBoxTerrain.CheckedItems[0].ToString();
                //run lumahunting function on background worker after pressing f10 hotkey  
                if (keyPressed.WParam.ToInt32() == 1 && huntingLuma == false)
                {

                    if (!backgroundWorkerBotMain.IsBusy)
                    {
                        huntingLuma = true;
                        backgroundWorkerBotMain.RunWorkerAsync();
                        HuntingTimerIsActive = true;
                        TimeSeconds = 0; TimeMinutes = 0; TimeHours = 0;
                        BotMain.EncountersCounter = 0;
                        this.Size = new Size(230, 140);
                    }

                }
                //send cancellation request to background worker after pressing f10 hotkey
                else if (keyPressed.WParam.ToInt32() == 1 && huntingLuma == true)
                {

                    if (backgroundWorkerBotMain.WorkerSupportsCancellation == true)
                    {
                        huntingLuma = false;
                        backgroundWorkerBotMain.CancelAsync();
                        HuntingTimerIsActive = false;
                        BotMain.KeepMoving = false;
                        this.Size = new Size(400, 270);
                    }

                }
                //run tv training function on background worker after pressing f11 hotkey  
                if (keyPressed.WParam.ToInt32() == 2 && expTraining == false)
                {

                    if (!backgroundWorkerBotMain.IsBusy)
                    {
                        expTraining = true;
                        backgroundWorkerBotMain.RunWorkerAsync();
                        HuntingTimerIsActive = true;
                        TimeSeconds = 0; TimeMinutes = 0; TimeHours = 0;
                        BotMain.EncountersCounter = 0;
                        this.Size = new Size(230, 140);
                    }

                }
                //send cancellation request to background worker after pressing f11 hotkey
                else if (keyPressed.WParam.ToInt32() == 2 && expTraining == true)
                {

                    if (backgroundWorkerBotMain.WorkerSupportsCancellation == true)
                    {
                        expTraining = false;
                        backgroundWorkerBotMain.CancelAsync();
                        HuntingTimerIsActive = false;
                        BotMain.KeepMoving = false;
                        this.Size = new Size(400, 270);
                    }

                }
                //run freetem farming function on background worker after press f9 hotkey  
                if (keyPressed.WParam.ToInt32() == 3 && freetemFarming == false)
                {

                    if (!backgroundWorkerBotMain.IsBusy)
                    {
                        freetemFarming = true;
                        backgroundWorkerBotMain.RunWorkerAsync();
                        HuntingTimerIsActive = true;
                        TimeSeconds = 0; TimeMinutes = 0; TimeHours = 0;
                        BotMain.EncountersCounter = 0;
                        this.Size = new Size(230, 140);
                    }

                }
                //send cancellation request to background worker after pressing f9 hotkey
                else if (keyPressed.WParam.ToInt32() == 3 && freetemFarming == true)
                {

                    if (backgroundWorkerBotMain.WorkerSupportsCancellation == true)
                    {
                        freetemFarming = false;
                        backgroundWorkerBotMain.CancelAsync();
                        HuntingTimerIsActive = false;
                        BotMain.KeepMoving = false;
                        this.Size = new Size(400, 270);
                    }

                }

            }
            base.WndProc(ref keyPressed);
        }

        private void backgroundWorkerBotMain_DoWork(object sender, DoWorkEventArgs e)
        {
            while (huntingLuma)
            {
                //listen if cancellation request was send
                if (backgroundWorkerBotMain.CancellationPending == true)
                {
                    e.Cancel = true;//cancel background worker
                    huntingLuma = false;
                }
                else
                {
                    huntingLuma = BotMain.LumaHunt(terrain);//run luma hunt function
                    if (huntingLuma == false)
                    {
                    }
                }
            }
            while (expTraining)
            {
                //listen if cancellation request was send
                if (backgroundWorkerBotMain.CancellationPending == true)
                {
                    e.Cancel = true;//cancel background worker
                    expTraining = false;
                }
                else
                {
                    expTraining = BotMain.ExpTrain(terrain);//run tv train function
                }
            }
            
            while (freetemFarming)
            {
                //listen if cancellation request was send
                if (backgroundWorkerBotMain.CancellationPending == true)
                {
                    e.Cancel = true;//cancel background worker
                    freetemFarming = false;
                }
                else
                {
                    freetemFarming = BotMain.FreetemFarm(terrain, catch1SV, healAndBuy, spot);//run freetem farm function
                }
            }
            if (InputSimulations.IsKeyDown(Keys.A))
            {
                InputSimulations.KeyUp((byte)Keys.A);
            }
            if (InputSimulations.IsKeyDown(Keys.D))
            {
                InputSimulations.KeyUp((byte)Keys.D);
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            hotkeys.UnregisterAllHotkeys();
            //save freetem counter to file
            TextWriter tw = new StreamWriter(freetemCounterSaveFile);
            // write lines of text to the file
            tw.WriteLine(BotMain.FreetemCounter);
            // close the stream     
            tw.Close();
        }
    }
}
