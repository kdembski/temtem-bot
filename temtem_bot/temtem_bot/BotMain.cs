using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace temtem_bot
{
    class BotMain : InputSimulations
    {
        // counters properties
        public static int EncountersCounter { get; set; } = 0;
        public static int FreetemCounter { get; set; } = 0;

        //property and thread for Move function
        public static bool KeepMoving { get; set; } = false;
        static Thread moveThread = new Thread(new ParameterizedThreadStart(Move));

        static Point outOfCombatPoint = new Point(1668, 214);
        static Color outOfCombatColor = Color.FromArgb(60, 232, 234);

        static Point inCombatPoint = new Point(809, 998);
        static Color inCombatColor = Color.FromArgb(28, 209, 211);

        static Point animationEndPoint = new Point(809, 998);
        static Color animationEndColor = Color.FromArgb(28, 209, 211);

        static Point leftOpponentPlatePoint = new Point(1310, 75);
        static Point rightOpponentPlatePoint = new Point(1710, 130);
        static Color plateColor = Color.FromArgb(31, 31, 31);

        public static bool LumaHunt(string terrain)
        {
            Point location1;
            Point location2;
            bool success1;
            bool success2;

            KeepMoving = true;
            Reconnect();
            if (!moveThread.IsAlive)
            {
                moveThread = new Thread(new ParameterizedThreadStart(Move));
                moveThread.Start(terrain);
            }
            //check if in encounter
            if (GetColorAt(inCombatPoint) == inCombatColor)
            {
                CountEncounters();
                //takes screenshot of screen
                Bitmap bmpScreenshot = Screenshot();
                //check if first tem is luma
                success1 = FindBitmap(Properties.Resources.needle2, bmpScreenshot, 1220, 23, 1409, 54, out location1);
                //check if second tem is luma
                success2 = FindBitmap(Properties.Resources.needle2, bmpScreenshot, 1619, 78, 1807, 109, out location2);
                //if luma is found
                if (success1 == true || success2 == true)
                {
                    //stop hunting
                    FormMain.HuntingTimerIsActive = false;
                    return false;
                }
                //if luma isn't found
                else if (success1 == false && success2 == false)
                {
                    //run from encounter
                    HoldKey((byte)Keys.D8, 100, 255, 200, 355);
                    HoldKey((byte)Keys.D8, 100, 255, 200, 355);
                    return true;
                }
                return true;
            }
            return true;
        }
        public static bool FreetemFarm(string terrain, bool catch1SV, bool healTemsAndBuyCards, string spot)
        {
            int holdKeysleepMin = 100;
            int holdKeySleepMax = 255;
            int sleepAfterPressMin = 355;
            int sleepAfterPressMax = 555;
            Point leftPlateFreezeCheckPoint = new Point(1423, 113);
            Point rightPlateFreezeCheckPoint = new Point(1821, 168);
            Color perfStatColor = Color.FromArgb(27, 209, 211);
            Color freezeStatusColor = Color.FromArgb(220, 252, 255);

            KeepMoving = true;
            Reconnect();
            SwapTemAfterFaint();
            if (!moveThread.IsAlive)
            {
                moveThread = new Thread(new ParameterizedThreadStart(Move));
                moveThread.Start(terrain);
            }
            //if encouter start
            if (GetColorAt(inCombatPoint) == inCombatColor)
            {
                //if theres no frozen enemy
                if (GetColorAt(animationEndPoint) == animationEndColor && !(GetColorAt(rightPlateFreezeCheckPoint) == freezeStatusColor) && !(GetColorAt(leftPlateFreezeCheckPoint) == freezeStatusColor))
                {
                    //atack
                    HoldKey((byte)Keys.D1, holdKeysleepMin, holdKeySleepMax, sleepAfterPressMin, sleepAfterPressMax);
                    HoldKey((byte)Keys.F, holdKeysleepMin, holdKeySleepMax, sleepAfterPressMin, sleepAfterPressMax);
                    HoldKey((byte)Keys.D1, holdKeysleepMin, holdKeySleepMax, sleepAfterPressMin, sleepAfterPressMax);
                    HoldKey((byte)Keys.F, holdKeysleepMin, holdKeySleepMax, sleepAfterPressMin, sleepAfterPressMax);
                }
                //if right enemy is frozen
                if (GetColorAt(rightPlateFreezeCheckPoint) == freezeStatusColor && GetColorAt(animationEndPoint) == animationEndColor)
                {
                    //throw temcards on right opp
                    HoldKey((byte)Keys.D7, holdKeysleepMin, holdKeySleepMax, sleepAfterPressMin, sleepAfterPressMax);
                    HoldKey((byte)Keys.E, holdKeysleepMin, holdKeySleepMax, sleepAfterPressMin, sleepAfterPressMax);
                    HoldKey((byte)Keys.F, holdKeysleepMin, holdKeySleepMax, sleepAfterPressMin, sleepAfterPressMax);
                    MouseLeftClick(rightOpponentPlatePoint.X, rightOpponentPlatePoint.Y, 100, 20);
                    HoldKey((byte)Keys.D6, holdKeysleepMin, holdKeySleepMax, sleepAfterPressMin, sleepAfterPressMax);
                }
                //if left enemy is frozen
                if (GetColorAt(leftPlateFreezeCheckPoint) == freezeStatusColor && GetColorAt(animationEndPoint) == animationEndColor)
                {
                    //throw temcards on left opp
                    HoldKey((byte)Keys.D7, holdKeysleepMin, holdKeySleepMax, sleepAfterPressMin, sleepAfterPressMax);
                    HoldKey((byte)Keys.E, holdKeysleepMin, holdKeySleepMax, sleepAfterPressMin, sleepAfterPressMax);
                    HoldKey((byte)Keys.F, holdKeysleepMin, holdKeySleepMax, sleepAfterPressMin, sleepAfterPressMax);
                    MouseLeftClick(leftOpponentPlatePoint.X, leftOpponentPlatePoint.Y, 100, 20);
                    HoldKey((byte)Keys.D6, holdKeysleepMin, holdKeySleepMax, sleepAfterPressMin, sleepAfterPressMax);
                }
            }
            //if temtem was catched
            if (GetColorAt(new Point(728, 428)) == Color.FromArgb(255, 175, 88))
            {
                //if catching 1 sv tems
                if (catch1SV)
                {
                    //check perfect sv stats
                    if (GetColorAt(new Point(1503, 390)) == perfStatColor ||
                        GetColorAt(new Point(1503, 425)) == perfStatColor ||
                        GetColorAt(new Point(1503, 465)) == perfStatColor ||
                        GetColorAt(new Point(1503, 505)) == perfStatColor ||
                        GetColorAt(new Point(1503, 544)) == perfStatColor ||
                        GetColorAt(new Point(1503, 583)) == perfStatColor ||
                        GetColorAt(new Point(1503, 622)) == perfStatColor)
                    {
                        //keep tem
                        MouseLeftClick(870, 940, 60, 20);
                        EncountersCounter++;
                    }
                    else
                    {
                        //release tem
                        MouseLeftClick(1020, 785, 50, 20);
                        MouseLeftClick(850, 650, 70, 20);
                        FreetemCounter++;
                        EncountersCounter++;
                    }
                    Thread.Sleep(2000);
                }
                //if not catching 1 sv tems
                else if (!catch1SV)
                {
                    int perfStatCounter = 0;
                    int[] coordsArray = new int[] { 390, 425, 465, 505, 544, 583, 622 };
                    for (int i = 0; i < 7; i++)
                    {
                        //check perfect stats and count them
                        if (GetColorAt(new Point(1503, coordsArray[i])) == perfStatColor)
                        {
                            perfStatCounter++;
                        }
                    }
                    //if 3 or more perfect stats(luma)
                    if (perfStatCounter >= 3)
                    {
                        //keep tem
                        MouseLeftClick(870, 940, 60, 20);
                        EncountersCounter++;
                    }
                    else
                    {
                        //release tem
                        MouseLeftClick(1020, 785, 50, 20);
                        MouseLeftClick(850, 650, 70, 20);
                        EncountersCounter++;
                        FreetemCounter++;
                    }
                    Thread.Sleep(2000);
                }
            }
            //if heal tems and buy cards is enabled
            if (healTemsAndBuyCards)
            {
                //if one of tems is fainted
                if (GetColorAt(new Point(1424, 1028)) == Color.FromArgb(82, 29, 35) ||
                    GetColorAt(new Point(1504, 1028)) == Color.FromArgb(82, 29, 35) ||
                    GetColorAt(new Point(1584, 1028)) == Color.FromArgb(82, 29, 35) ||
                    GetColorAt(new Point(1664, 1028)) == Color.FromArgb(82, 29, 35) ||
                    GetColorAt(new Point(1744, 1028)) == Color.FromArgb(82, 29, 35))
                {
                    KeepMoving = false;
                    if (InputSimulations.IsKeyDown(Keys.A))
                    {
                        InputSimulations.KeyUp((byte)Keys.A);
                    }
                    if (InputSimulations.IsKeyDown(Keys.D))
                    {
                        InputSimulations.KeyUp((byte)Keys.D);
                    }
                    //use smoke bomb
                    Thread.Sleep(1000);
                    HoldKey((byte)Keys.I, 125, 125, 400, 500);
                    HoldKey((byte)Keys.E, 125, 125, 400, 500);
                    int xmin = 275, ymin = 195, xmax = 405, ymax = 230;
                    //search for smoke bomb
                    for (int i = 0; i < 7; i++)
                    {
                        string recognizedString = TextRecognition.Recognize(xmin, ymin + (i * 112), xmax, ymax + (i * 112));
                        //if found, use it
                        if (String.Equals(recognizedString, "smoke"))
                        {
                            MouseLeftClick(xmin, ymin + (i * 112), 0, 0);
                            HoldKey((byte)Keys.F, 100, 155, 400, 500);
                            HoldKey((byte)Keys.F, 100, 155, 400, 500);
                            break;
                        }
                    }
                    Thread.Sleep(3000);
                    SpinWait.SpinUntil(() => GetColorAt(outOfCombatPoint) == outOfCombatColor);
                    if (spot == "Magmis")
                    {
                        //heal tems
                        HoldKey((byte)Keys.A, 280, 280, 10, 20);
                        HoldKey((byte)Keys.W, 100, 100, 10, 20);
                        HoldKey((byte)Keys.F, 100, 100, 10, 20);
                        Thread.Sleep(10000);
                        //buy cards
                        HoldKey((byte)Keys.S, 100, 100, 10, 20);
                        HoldKey((byte)Keys.D, 520, 540, 10, 20);
                        HoldKey((byte)Keys.W, 100, 100, 10, 20);
                        HoldKey((byte)Keys.F, 100, 100, 10, 20);
                        Thread.Sleep(1000);
                        HoldKey((byte)Keys.F, 100, 100, 200, 300);
                        HoldKey((byte)Keys.S, 100, 100, 200, 300);
                        HoldKey((byte)Keys.S, 100, 100, 200, 300);
                        HoldKey((byte)Keys.F, 100, 100, 200, 300);
                        for (int i = 0; i < 9; i++)
                        {
                            HoldKey((byte)Keys.D, 100, 100, 200, 300);
                        }
                        HoldKey((byte)Keys.F, 100, 100, 200, 300);
                        HoldKey((byte)Keys.Escape, 100, 100, 200, 300);
                        //back to spot
                        HoldKey((byte)Keys.S, 470, 470, 10, 20);
                        HoldKey((byte)Keys.A, 3620, 3620, 10, 20);
                        HoldKey((byte)Keys.S, 200, 200, 10, 20);
                        Thread.Sleep(2000);
                        HoldKey((byte)Keys.S, 900, 900, 10, 20);
                    }
                    else if (spot == "Grumvel")
                    {
                        HoldKey((byte)Keys.W, 300, 300, 10, 20);
                        HoldKey((byte)Keys.A, 500, 500, 10, 20);
                        HoldKey((byte)Keys.W, 800, 800, 10, 20);
                        HoldKey((byte)Keys.D, 300, 300, 10, 20);
                        HoldKey((byte)Keys.F, 300, 300, 10, 20);
                        Thread.Sleep(10000);

                        HoldKey((byte)Keys.A, 100, 100, 10, 20);
                        HoldKey((byte)Keys.S, 800, 800, 10, 20);
                        HoldKey((byte)Keys.D, 1300, 1300, 10, 20);
                        HoldKey((byte)Keys.W, 800, 800, 10, 20);

                        HoldKey((byte)Keys.F, 100, 100, 200, 300);
                        Thread.Sleep(1000);
                        HoldKey((byte)Keys.F, 100, 100, 200, 300);
                        for (int i = 0; i < 10; i++)
                        {
                            HoldKey((byte)Keys.S, 100, 100, 200, 300);
                        }
                        HoldKey((byte)Keys.F, 100, 100, 200, 300);
                        for (int i = 0; i < 9; i++)
                        {
                            HoldKey((byte)Keys.D, 100, 100, 200, 300);
                        }
                        HoldKey((byte)Keys.F, 100, 100, 200, 300);
                        HoldKey((byte)Keys.Escape, 100, 100, 200, 300);

                        HoldKey((byte)Keys.S, 500, 500, 10, 20);
                        HoldKey((byte)Keys.A, 700, 700, 10, 20);
                        HoldKey((byte)Keys.S, 500, 500, 10, 20);
                        Thread.Sleep(2000);
                        SpinWait.SpinUntil(() => GetColorAt(outOfCombatPoint) == outOfCombatColor && GetColorAt(new Point(1780, 35)) == outOfCombatColor);
                        HoldKey((byte)Keys.S, 500, 500, 10, 20);
                        HoldKey((byte)Keys.A, 1000, 1000, 10, 20);
                        HoldKey((byte)Keys.S, 600, 600, 10, 20);
                        HoldKey((byte)Keys.A, 1730, 1730, 10, 20);
                        HoldKey((byte)Keys.W, 1000, 1000, 10, 20);
                        Thread.Sleep(2000);
                        SpinWait.SpinUntil(() => GetColorAt(outOfCombatPoint) == outOfCombatColor && GetColorAt(new Point(1780, 35)) == outOfCombatColor);
                        HoldKey((byte)Keys.W, 1000, 3000, 10, 20);
                    }
                }
            }
            return true;
        }
        public static bool ExpTrain(string terrain)
        {
            Point location1;
            Point location2;
            bool success1;
            bool success2;

            KeepMoving = true;
            Reconnect();
            if (!moveThread.IsAlive)
            {
                moveThread = new Thread(new ParameterizedThreadStart(Move));
                moveThread.Start(terrain);
            }
            //check if encounter start
            if (GetColorAt(new Point(809, 998)) == Color.FromArgb(28, 209, 211))
            {
                int[] trainingValuesTemp = new int[7];
                CountEncounters();
                //takes screenshot of screen
                Bitmap bmpScreenshot = Screenshot();
                //check if first tem is luma
                success1 = FindBitmap(Properties.Resources.needle2, bmpScreenshot, 1220, 23, 1409, 54, out location1);
                //check if second tem is luma
                success2 = FindBitmap(Properties.Resources.needle2, bmpScreenshot, 1619, 78, 1807, 109, out location2);
                //if luma is found
                if (success1 == true || success2 == true)
                {
                    //stop hunting
                    FormMain.HuntingTimerIsActive = false;
                    return false;
                }
                //if luma isn't found
                else if (success1 == false && success2 == false)
                {
                Repeat:
                    SpinWait.SpinUntil(() => GetColorAt(new Point(809, 998)) == Color.FromArgb(28, 209, 211));
                    HoldKey((byte)Keys.F, 100, 255, 355, 555);
                    HoldKey((byte)Keys.F, 100, 255, 355, 555);
                    HoldKey((byte)Keys.F, 100, 255, 355, 555);
                    HoldKey((byte)Keys.F, 100, 255, 355, 555);

                    SpinWait.SpinUntil(() => GetColorAt(new Point(809, 998)) == Color.FromArgb(28, 209, 211) ||
                                             GetColorAt(new Point(880, 280)) == Color.FromArgb(28, 209, 211) ||
                                             GetColorAt(new Point(730, 280)) == Color.FromArgb(28, 209, 211) ||
                                             GetColorAt(new Point(580, 280)) == Color.FromArgb(28, 209, 211) ||
                                             GetColorAt(new Point(1668, 214)) == Color.FromArgb(60, 232, 234));
                    //pass trough gain exp screen
                    if (GetColorAt(new Point(880, 280)) == Color.FromArgb(28, 209, 211) || GetColorAt(new Point(730, 280)) == Color.FromArgb(28, 209, 211) || GetColorAt(new Point(580, 280)) == Color.FromArgb(28, 209, 211))
                    {
                        Thread.Sleep(500);
                        while (true)
                        {
                            if (GetColorAt(new Point(809, 998)) == Color.FromArgb(28, 209, 211) || (GetColorAt(new Point(660, 540)) == Color.FromArgb(0, 0, 0) && GetColorAt(new Point(1260, 540)) == Color.FromArgb(0, 0, 0) && GetColorAt(new Point(1860, 540)) == Color.FromArgb(0, 0, 0)))
                            {
                                break;
                            }
                            HoldKey((byte)Keys.Escape, 1, 2, 1, 1);
                            Thread.Sleep(1000);
                        }
                        SpinWait.SpinUntil(() => GetColorAt(new Point(809, 998)) == Color.FromArgb(28, 209, 211) || (GetColorAt(new Point(660, 540)) == Color.FromArgb(0, 0, 0) && GetColorAt(new Point(1260, 540)) == Color.FromArgb(0, 0, 0) && GetColorAt(new Point(1860, 540)) == Color.FromArgb(0, 0, 0)));
                    }
                    if (GetColorAt(new Point(1811, 108)) == Color.FromArgb(228, 125, 71) || GetColorAt(new Point(1413, 53)) == Color.FromArgb(228, 125, 71))
                    {
                        goto Repeat;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// simulates move of character
        /// </summary>
        public static void Move(object data)
        {
            //1754
            int rightMin = 1739;
            int rightMax = 1749;
            //1775
            int leftMin = 1780;
            int leftMax = 1790;
            int caveAdd = 10;
            string terrain = data.ToString();
            if (terrain == "Grass")
            {
                //if out of encounter
                while (GetColorAt(outOfCombatPoint) == outOfCombatColor && KeepMoving)
                {
                    //if grass on right from character on minimap, hold A key
                    if ((GetColorAt(new Point(new Random().Next(rightMin, rightMax), 154)) == Color.FromArgb(112, 171, 132) || GetColorAt(new Point(new Random().Next(rightMin, rightMax), 154)) == Color.FromArgb(112, 171, 133))
                        && !(InputSimulations.IsKeyDown(Keys.D)))
                    {
                        KeyDown((byte)Keys.A);
                    }

                    else if (InputSimulations.IsKeyDown(Keys.A))
                    {
                        KeyUp((byte)Keys.A);
                    }
                    //if grass on left from character on minimap, hold D key
                    if ((GetColorAt(new Point(new Random().Next(leftMin, leftMax), 154)) == Color.FromArgb(112, 171, 132) || GetColorAt(new Point(new Random().Next(leftMin, leftMax), 154)) == Color.FromArgb(112, 171, 133))
                        && !(InputSimulations.IsKeyDown(Keys.A)))
                    {
                        KeyDown((byte)Keys.D);
                    }
                    else if (InputSimulations.IsKeyDown(Keys.D))
                    {
                        KeyUp((byte)Keys.D);
                    }
                }
            }
            if (terrain == "Water")
            {
                //if out of encounter
                while (GetColorAt(outOfCombatPoint) == outOfCombatColor && KeepMoving)
                {
                    //if water on right from character on minimap, hold A key
                    if ((GetColorAt(new Point(new Random().Next(rightMin, rightMax), 154)) == Color.FromArgb(0, 127, 178) || GetColorAt(new Point(new Random().Next(rightMin, rightMax), 154)) == Color.FromArgb(0, 127, 178))
                        && !(InputSimulations.IsKeyDown(Keys.D)))
                    {
                        KeyDown((byte)Keys.A);
                    }
                    else if (InputSimulations.IsKeyDown(Keys.A))
                    {
                        KeyUp((byte)Keys.A);
                    }
                    //if water on left from character on minimap, hold D key
                    if ((GetColorAt(new Point(new Random().Next(leftMin, leftMax), 154)) == Color.FromArgb(0, 127, 178) || GetColorAt(new Point(new Random().Next(leftMin, leftMax), 154)) == Color.FromArgb(0, 127, 178))
                        && !(InputSimulations.IsKeyDown(Keys.A)))
                    {
                        KeyDown((byte)Keys.D);
                    }
                    else if (InputSimulations.IsKeyDown(Keys.D))
                    {
                        KeyUp((byte)Keys.D);
                    }
                }
            }
            if (terrain == "Cave")
            {
                //if out of encounter
                while (GetColorAt(outOfCombatPoint) == outOfCombatColor && KeepMoving)
                {
                    //if cave on right from character on minimap, hold A key
                    if ((GetColorAt(new Point(new Random().Next(rightMin - caveAdd, rightMax), 154)) == Color.FromArgb(52, 121, 132) || GetColorAt(new Point(new Random().Next(rightMin - caveAdd, rightMax), 154)) == Color.FromArgb(53, 120, 135))
                        && !(InputSimulations.IsKeyDown(Keys.D)))
                    {
                        KeyDown((byte)Keys.A);
                    }
                    else if (InputSimulations.IsKeyDown(Keys.A))
                    {
                        KeyUp((byte)Keys.A);
                    }
                    //if cave on left from character on minimap, hold D key
                    if ((GetColorAt(new Point(new Random().Next(leftMin, leftMax + caveAdd), 154)) == Color.FromArgb(52, 121, 132) || GetColorAt(new Point(new Random().Next(leftMin, leftMax + caveAdd), 154)) == Color.FromArgb(53, 120, 135))
                        && !(InputSimulations.IsKeyDown(Keys.A)))
                    {
                        KeyDown((byte)Keys.D);
                    }
                    else if (InputSimulations.IsKeyDown(Keys.D))
                    {
                        KeyUp((byte)Keys.D);
                    }
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
        /// <summary>
        /// reconnect after disconnectiing
        /// </summary>
        private static void Reconnect()
        {
            int x = 855, y = 655;
            Color exitButtonColor = Color.FromArgb(28, 209, 211);
            Point exitButtonPoint = new Point(1060, 680);
            //check if reconnect plate appears
            if (GetColorAt(exitButtonPoint) == exitButtonColor)
            {
                //click reconnect button
                MouseLeftClick(x, y, 30, 20);
            }
        }
        /// <summary>
        /// counting numbers of encounters
        /// </summary>
        private static void CountEncounters()
        {

            EncountersCounter++;
            //if second enemy plate is available
            if (GetColorAt(new Point(1413, 53)) == Color.FromArgb(228, 125, 71))
            {
                EncountersCounter++;
            }
        }
        /// <summary>
        /// after friendly tem if fainted send next one to battle
        /// </summary>
        private static void SwapTemAfterFaint()
        {
            //if friendly tem fainted
            if (GetColorAt(new Point(930, 239)) == Color.FromArgb(30, 30, 30))
            {
                //send next tem to battle
                HoldKey((byte)Keys.F, 100, 155, 200, 355);
                HoldKey((byte)Keys.A, 100, 155, 200, 355);
                HoldKey((byte)Keys.F, 100, 155, 200, 355);
            }
        }
        /// <summary>
        /// heal friendly tem if wounded enough
        /// </summary>
        private static void HealTems()
        {
            if (GetColorAt(new Point(1425, 1028)) == Color.FromArgb(219, 42, 56) ||
                GetColorAt(new Point(1505, 1028)) == Color.FromArgb(219, 42, 56) ||
                GetColorAt(new Point(1585, 1028)) == Color.FromArgb(219, 42, 56) ||
                GetColorAt(new Point(1665, 1028)) == Color.FromArgb(219, 42, 56) ||
                GetColorAt(new Point(1745, 1028)) == Color.FromArgb(219, 42, 56))
            {
                bool found = false;
                HoldKey((byte)Keys.I, 100, 155, 500, 655);
                HoldKey((byte)Keys.E, 100, 155, 500, 655);
                HoldKey((byte)Keys.E, 100, 155, 500, 655);
                HoldKey((byte)Keys.E, 100, 155, 500, 655);
                for (int i = 0; i < 25; i++)
                {
                    HoldKey((byte)Keys.S, 10, 15, 100, 155);
                }
                int xmin = 275, ymin = 195, xmax = 375, ymax = 230;
            //search for balm
            Repeat:
                for (int i = 0; i < 7; i++)
                {
                    string recognizedString = TextRecognition.Recognize(xmin, ymin + (i * 112), xmax, ymax + (i * 112));
                    //if found, use it
                    if (String.Equals(recognizedString, "balm"))
                    {
                        found = true;
                        MouseLeftClick(xmin, ymin + (i * 112), 0, 0);
                        HoldKey((byte)Keys.F, 100, 155, 500, 500);
                        HoldKey((byte)Keys.F, 100, 155, 500, 500);
                        HoldKey((byte)Keys.F, 100, 155, 500, 500);
                        break;
                    }
                }
                if (found == false)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        HoldKey((byte)Keys.S, 10, 15, 100, 155);
                    }
                    goto Repeat;
                }
                HoldKey((byte)Keys.Escape, 100, 155, 500, 655);
                HoldKey((byte)Keys.Escape, 100, 155, 500, 655);
            }
        }
    }
}
