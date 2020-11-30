using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, the menu,
    //              and added talent show, data recorder, 
    //              alarm system, and user programming options.
    // Application Type: Console
    // Author: Jandreski, Elise
    // Dated Created: 11/11/2020
    // Last Modified: 11/29/2020
    //
    // **************************************************

    /// <summary>
    /// User commands
    /// </summary>
    public enum Command
    {
        NONE,
        MOVEFORWARD,
        MOVEBACKWARD,
        STOPMOTORS,
        WAIT,
        TURNRIGHT,
        TURNLEFT,
        LEDON,
        LEDOFF,
        GETTEMPERATURE,
        DONE
    }
    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        bool robotConnected = DisplayConnectFinchRobot(finchRobot);
                        DisplayFinchRobotConnectionStatus(robotConnected, finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":
                        LightAlarmDisplayMenuScreen(finchRobot);
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }


        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) light and song");
                Console.WriteLine("\tc) dance");
                Console.WriteLine("\td) Mixing it up");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplaySongAndLight(finchRobot);
                        break;

                    case "c":
                        TalentShowDisplayDance(finchRobot);
                        break;

                    case "d":
                        TalentShowDisplayMixingItUp(finchRobot);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }


        //methods for talents being shown
        /// <summary>
        /// ****************************************************************
        /// *               Talent Show > Song and light                   *
        /// ****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplaySongAndLight(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Song and light");
            Console.WriteLine("\tThe finch will now sing and light up!");
            DisplayContinuePrompt();

            #region assign frequencies to notes
            // first octave frequencies in Hz
            int c1 = 33, cSharp1 = 35, d1 = 37, dSharp1 = 39, e = 41, f1 = 44, fSharp1 = 46, g1 = 49, gSharp1 = 52, a1 = 55, aSharp1 = 58, b1 = 62;

            // second octave frequencies in Hz
            int c2 = 65, cSharp2 = 69, d2 = 73, dSharp2 = 78, e2 = 82, f2 = 87, fSharp2 = 92, g2 = 98, gSharp2 = 104, a2 = 110, aSharp2 = 117, b2 = 123;

            // third octave frequencies in Hz
            int c3 = 131, cSharp3 = 139, d3 = 147, dSharp3 = 156, e3 = 165, f3 = 175, fSharp3 = 185, g3 = 196, gSharp3 = 208, a3 = 220, aSharp3 = 233, b3 = 247;

            // fourth octave frequencies in Hz
            int c4 = 262, cSharp4 = 277, d4 = 294, dSharp4 = 311, e4 = 330, f4 = 349, fSharp4 = 370, g4 = 392, gSharp4 = 415, a4 = 440, aSharp4 = 466, b4 = 494;
            #endregion

            #region assign time values to beats

            int quarter = 522;
            int eighth = 260;
            int dottedQuarter = 781;
            int dottedEighth = 391;
            int sixteenth = 130;
            int dottedSixteenth = 195;
            int half = 1043;
            int dottedHalf = 1565;
            int whole = 2087;
            int dottedWhole = 3130;

            #endregion

            for (int i = 0; i <= 2; i++)
            {
                //first and third measure 
                finchRobot.setLED(255, 0, 0);
                SingleMusicNote(a2, dottedEighth, finchRobot);
                finchRobot.setLED(255, 155, 0);
                SingleMusicNote(e3, sixteenth, finchRobot);
                finchRobot.setLED(155, 155, 0);
                SingleMusicNote(cSharp4, dottedEighth, finchRobot);
                finchRobot.setLED(155, 255, 0);
                SingleMusicNote(e3, sixteenth, finchRobot);
                finchRobot.setLED(0, 255, 0);
                SingleMusicNote(cSharp4, dottedEighth, finchRobot);
                finchRobot.setLED(0, 255, 155);
                SingleMusicNote(e3, sixteenth, finchRobot);

                //second and fourth measure
                finchRobot.setLED(0, 155, 155);
                SingleMusicNote(a2, dottedEighth, finchRobot);
                finchRobot.setLED(0, 155, 255);
                SingleMusicNote(fSharp3, sixteenth, finchRobot);
                finchRobot.setLED(0, 0, 255);
                SingleMusicNote(d4, half, finchRobot);
            }

            //fifth measure 
            finchRobot.setLED(155, 0, 255);
            Console.Write("\t\nwhy ");
            SingleMusicNote(cSharp3, quarter, finchRobot);

            finchRobot.setLED(155, 0, 155);
            Console.Write("are ");
            SingleMusicNote(e3, quarter, finchRobot);

            finchRobot.setLED(255, 0, 155);
            Console.Write("there ");
            SingleMusicNote(a3, quarter, finchRobot);

            //sixth measure
            finchRobot.setLED(255, 0, 0);
            Console.Write("so ");
            SingleMusicNote(b3, dottedEighth, finchRobot);

            finchRobot.setLED(255, 155, 0);
            Console.Write("man- ");
            SingleMusicNote(cSharp4, sixteenth, finchRobot);

            finchRobot.setLED(255, 255, 0);
            Console.WriteLine("y ");
            SingleMusicNote(cSharp4, half, finchRobot);

            //seventh measure
            finchRobot.setLED(155, 255, 0);
            Console.Write("songs ");
            SingleMusicNote(fSharp3, quarter, finchRobot);

            finchRobot.setLED(0, 255, 0);
            Console.Write("a- ");
            SingleMusicNote(e3, quarter, finchRobot);

            finchRobot.setLED(0, 255, 155);
            Console.Write("bout ");
            SingleMusicNote(a3, quarter, finchRobot);

            //eighth measure
            finchRobot.setLED(0, 255, 255);
            Console.Write("rain- ");
            SingleMusicNote(a3, quarter, finchRobot);

            finchRobot.setLED(0, 155, 255);
            Console.WriteLine("bows ");
            SingleMusicNote(b3, dottedQuarter, finchRobot);

            finchRobot.setLED(0, 0, 255);
            Console.Write("and ");
            SingleMusicNote(b2, eighth, finchRobot);

            //ninth measure
            finchRobot.setLED(155, 0, 255);
            Console.Write("what's ");
            SingleMusicNote(cSharp3, quarter, finchRobot);

            finchRobot.setLED(255, 0, 255);
            Console.Write("on ");
            SingleMusicNote(e3, quarter, finchRobot);

            finchRobot.setLED(255, 0, 155);
            Console.Write("the ");
            SingleMusicNote(gSharp3, quarter, finchRobot);

            //tenth measure
            finchRobot.setLED(255, 0, 0);
            Console.Write("oth- ");
            SingleMusicNote(a3, half, finchRobot);

            finchRobot.setLED(255, 255, 0);
            Console.Write("er ");
            SingleMusicNote(e3, quarter, finchRobot);

            //eleventh measure
            finchRobot.setLED(255, 255, 255);
            Console.Write("side? ");
            SingleMusicNote(fSharp3, dottedHalf, finchRobot);

            //turn off buzzer and light
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            Console.WriteLine("");
            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// **************************************************************
        /// *               Talent Show > Mixing it up                   *
        /// **************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        public static void TalentShowDisplayMixingItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing it up");

            Console.WriteLine("\tThe finch will now sing, light up, and dance. Make sure that your finch has enough room to move around before continuing!");
            DisplayContinuePrompt();

            #region assign frequencies to notes
            // first octave frequencies in Hz
            int c1 = 33, cSharp1 = 35, d1 = 37, dSharp1 = 39, e = 41, f1 = 44, fSharp1 = 46, g1 = 49, gSharp1 = 52, a1 = 55, aSharp1 = 58, b1 = 62;

            // second octave frequencies in Hz
            int c2 = 65, cSharp2 = 69, d2 = 73, dSharp2 = 78, e2 = 82, f2 = 87, fSharp2 = 92, g2 = 98, gSharp2 = 104, a2 = 110, aSharp2 = 117, b2 = 123;

            // third octave frequencies in Hz
            int c3 = 131, cSharp3 = 139, d3 = 147, dSharp3 = 156, e3 = 165, f3 = 175, fSharp3 = 185, g3 = 196, gSharp3 = 208, a3 = 220, aSharp3 = 233, b3 = 247;

            // fourth octave frequencies in Hz
            int c4 = 262, cSharp4 = 277, d4 = 294, dSharp4 = 311, e4 = 330, f4 = 349, fSharp4 = 370, g4 = 392, gSharp4 = 415, a4 = 440, aSharp4 = 466, b4 = 494;
            #endregion

            #region assign time values to beats

            int quarter = 522;
            int eighth = 260;
            int dottedQuarter = 781;
            int dottedEighth = 391;
            int sixteenth = 130;
            int dottedSixteenth = 195;
            int half = 1043;
            int dottedHalf = 1565;
            int whole = 2087;
            int dottedWhole = 3130;

            #endregion

            //first measure
            finchRobot.setLED(255, 255, 255);
            SingleMusicNote(d3, sixteenth, finchRobot);
            SingleMusicNote(d3, sixteenth, finchRobot);
            finchRobot.setLED(255, 255, 155);
            finchRobot.setMotors(75, 75);
            SingleMusicNote(d4, sixteenth, finchRobot);
            finchRobot.setMotors(0, 0);
            SingleMusicNote(0, sixteenth, finchRobot);
            finchRobot.setLED(255, 155, 155);
            SingleMusicNote(a3, eighth, finchRobot);
            SingleMusicNote(0, sixteenth, finchRobot);
            finchRobot.setLED(255, 155, 255);
            SingleMusicNote(gSharp3, eighth, finchRobot);
            finchRobot.setLED(155, 255, 255);
            SingleMusicNote(g3, eighth, finchRobot);
            finchRobot.setLED(155, 155, 155);
            SingleMusicNote(f3, eighth, finchRobot);
            finchRobot.setLED(255, 0, 0);
            SingleMusicNote(d3, sixteenth, finchRobot);
            finchRobot.setLED(0, 255, 0);
            SingleMusicNote(f3, sixteenth, finchRobot);
            finchRobot.setLED(0, 0, 255);
            SingleMusicNote(g3, sixteenth, finchRobot);

            //second measure
            finchRobot.setLED(255, 100, 100);
            SingleMusicNote(c3, sixteenth, finchRobot);
            SingleMusicNote(c3, sixteenth, finchRobot);
            finchRobot.setLED(100, 255, 100);
            finchRobot.setMotors(-75, -75);
            SingleMusicNote(d4, sixteenth, finchRobot);
            finchRobot.setMotors(0, 0);
            SingleMusicNote(0, sixteenth, finchRobot);
            finchRobot.setLED(100, 100, 255);
            SingleMusicNote(a3, eighth, finchRobot);
            SingleMusicNote(0, sixteenth, finchRobot);
            finchRobot.setLED(0, 255, 155);
            SingleMusicNote(gSharp3, eighth, finchRobot);
            finchRobot.setLED(155, 0, 255);
            SingleMusicNote(g3, eighth, finchRobot);
            finchRobot.setLED(50, 155, 255);
            SingleMusicNote(f3, eighth, finchRobot);
            finchRobot.setLED(255, 0, 0);
            SingleMusicNote(d3, sixteenth, finchRobot);
            finchRobot.setLED(0, 255, 0);
            SingleMusicNote(f3, sixteenth, finchRobot);
            finchRobot.setLED(0, 0, 255);
            SingleMusicNote(g3, sixteenth, finchRobot);

            //third measure
            finchRobot.setLED(255, 100, 100);
            SingleMusicNote(aSharp2, sixteenth, finchRobot);
            SingleMusicNote(aSharp2, sixteenth, finchRobot);
            finchRobot.setLED(100, 255, 100);
            finchRobot.setMotors(75, 75);
            SingleMusicNote(d4, sixteenth, finchRobot);
            finchRobot.setMotors(0, 0);
            SingleMusicNote(0, sixteenth, finchRobot);
            finchRobot.setLED(100, 100, 255);
            SingleMusicNote(a3, eighth, finchRobot);
            SingleMusicNote(0, sixteenth, finchRobot);
            finchRobot.setLED(0, 255, 155);
            SingleMusicNote(gSharp3, eighth, finchRobot);
            finchRobot.setLED(155, 0, 255);
            SingleMusicNote(g3, eighth, finchRobot);
            finchRobot.setLED(50, 155, 255);
            SingleMusicNote(f3, eighth, finchRobot);
            finchRobot.setLED(255, 0, 0);
            SingleMusicNote(d3, sixteenth, finchRobot);
            finchRobot.setLED(0, 255, 0);
            SingleMusicNote(f3, sixteenth, finchRobot);
            finchRobot.setLED(0, 0, 255);
            SingleMusicNote(g3, sixteenth, finchRobot);

            //fourth measure
            finchRobot.setLED(255, 100, 100);
            SingleMusicNote(c3, sixteenth, finchRobot);
            SingleMusicNote(c3, sixteenth, finchRobot);
            finchRobot.setLED(100, 255, 100);
            finchRobot.setMotors(-75, -75);
            SingleMusicNote(d4, sixteenth, finchRobot);
            finchRobot.setMotors(0, 0);
            SingleMusicNote(0, sixteenth, finchRobot);
            finchRobot.setLED(100, 100, 255);
            SingleMusicNote(a3, eighth, finchRobot);
            SingleMusicNote(0, sixteenth, finchRobot);
            finchRobot.setLED(0, 255, 155);
            SingleMusicNote(gSharp3, eighth, finchRobot);
            finchRobot.setLED(155, 0, 255);
            SingleMusicNote(g3, eighth, finchRobot);
            finchRobot.setLED(50, 155, 255);
            SingleMusicNote(f3, eighth, finchRobot);
            finchRobot.setLED(255, 0, 0);
            SingleMusicNote(d3, sixteenth, finchRobot);
            finchRobot.setLED(0, 255, 0);
            SingleMusicNote(f3, sixteenth, finchRobot);
            finchRobot.setLED(0, 0, 255);
            SingleMusicNote(g3, sixteenth, finchRobot);

            //fifth measure
            finchRobot.setMotors(80, 0);
            DoubleMusicNote(d3, d1, sixteenth, finchRobot);
            DoubleMusicNote(d3, d1, sixteenth, finchRobot);
            finchRobot.setMotors(-40, -80);
            DoubleMusicNote(d4, d1, sixteenth, finchRobot);
            DoubleMusicNote(d1, d1, sixteenth, finchRobot);
            finchRobot.setMotors(0, 75);
            DoubleMusicNote(a3, d1, eighth, finchRobot);
            finchRobot.setMotors(75, 0);
            DoubleMusicNote(d1, d1, sixteenth, finchRobot);
            finchRobot.setMotors(-75, 0);
            DoubleMusicNote(gSharp3, d1, eighth, finchRobot);
            finchRobot.setMotors(0, -75);
            DoubleMusicNote(g3, d1, eighth, finchRobot);
            DoubleMusicNote(f3, d1, eighth, finchRobot);
            DoubleMusicNote(d3, d1, sixteenth, finchRobot);
            DoubleMusicNote(f3, d1, sixteenth, finchRobot);
            DoubleMusicNote(g3, d1, sixteenth, finchRobot);

            //sixth measure
            finchRobot.setMotors(0, 80);
            DoubleMusicNote(c3, c1, sixteenth, finchRobot);
            DoubleMusicNote(c3, c1, sixteenth, finchRobot);
            finchRobot.setMotors(-80, -40);
            DoubleMusicNote(d4, c1, sixteenth, finchRobot);
            DoubleMusicNote(c1, c1, sixteenth, finchRobot);
            finchRobot.setMotors(75, 0);
            DoubleMusicNote(a3, c1, eighth, finchRobot);
            finchRobot.setMotors(0, 75);
            DoubleMusicNote(c1, c1, sixteenth, finchRobot);
            finchRobot.setMotors(0, -75);
            DoubleMusicNote(gSharp3, c1, eighth, finchRobot);
            finchRobot.setMotors(-75, 0);
            DoubleMusicNote(g3, c1, eighth, finchRobot);
            DoubleMusicNote(f3, c1, eighth, finchRobot);
            DoubleMusicNote(d3, c1, sixteenth, finchRobot);
            DoubleMusicNote(f3, c1, sixteenth, finchRobot);
            DoubleMusicNote(g3, c1, sixteenth, finchRobot);

            //seventh measure
            finchRobot.setMotors(25, 50);
            DoubleMusicNote(b2, b1, sixteenth, finchRobot);
            DoubleMusicNote(b2, b1, sixteenth, finchRobot);
            finchRobot.setMotors(50, 25);
            DoubleMusicNote(d4, b1, sixteenth, finchRobot);
            DoubleMusicNote(b1, b1, sixteenth, finchRobot);
            finchRobot.setMotors(0, 0);
            DoubleMusicNote(a3, b1, eighth, finchRobot);
            DoubleMusicNote(b1, b1, sixteenth, finchRobot);
            DoubleMusicNote(gSharp3, b1, eighth, finchRobot);
            DoubleMusicNote(g3, b1, eighth, finchRobot);
            DoubleMusicNote(f3, b1, eighth, finchRobot);
            DoubleMusicNote(d3, b1, sixteenth, finchRobot);
            DoubleMusicNote(f3, b1, sixteenth, finchRobot);
            DoubleMusicNote(g3, b1, sixteenth, finchRobot);

            //eighth measure
            finchRobot.setMotors(-25, -50);
            DoubleMusicNote(aSharp2, aSharp1, sixteenth, finchRobot);
            DoubleMusicNote(aSharp2, aSharp1, sixteenth, finchRobot);
            finchRobot.setMotors(-50, -25);
            DoubleMusicNote(d4, aSharp1, sixteenth, finchRobot);
            DoubleMusicNote(aSharp1, aSharp1, sixteenth, finchRobot);
            finchRobot.setMotors(0, 0);
            DoubleMusicNote(a3, aSharp1, eighth, finchRobot);
            DoubleMusicNote(aSharp1, aSharp1, sixteenth, finchRobot);
            DoubleMusicNote(gSharp3, c1, eighth, finchRobot);
            DoubleMusicNote(g3, c1, eighth, finchRobot);
            DoubleMusicNote(f3, c1, eighth, finchRobot);
            DoubleMusicNote(d3, c1, sixteenth, finchRobot);
            DoubleMusicNote(f3, c1, sixteenth, finchRobot);
            DoubleMusicNote(g3, c1, sixteenth, finchRobot);

            // reset finch robot
            finchRobot.noteOff();
            finchRobot.setMotors(0, 0);
            finchRobot.setLED(0, 0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
            }

            finchRobot.noteOff();

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Dance                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayDance(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Dance");

            Console.WriteLine("The finch will now dance. Make sure that your finch has room to move around before continuing!");
            DisplayContinuePrompt();

            //make finch wiggle forward
            for (int i = 0; i <= 2; i++)
            {
                finchRobot.setMotors(150, 75);
                finchRobot.wait(400);
                finchRobot.setMotors(75, 150);
                finchRobot.wait(400);
                finchRobot.setMotors(75, 150);
                finchRobot.wait(400);
                finchRobot.setMotors(150, 75);
                finchRobot.wait(400);
            }

            //make finch wiggle backward
            for (int i = 0; i <= 2; i++)
            {
                finchRobot.setMotors(-150, -75);
                finchRobot.wait(300);
                finchRobot.setMotors(-75, -150);
                finchRobot.wait(300);
                finchRobot.setMotors(-75, -150);
                finchRobot.wait(300);
                finchRobot.setMotors(-150, -75);
                finchRobot.wait(300);
            }


            //make finch shake it!
            for (int i = 0; i <= 8; i++)
            {
                finchRobot.setMotors(80, -80);
                finchRobot.wait(150);
                finchRobot.setMotors(-80, 80);
                finchRobot.wait(150);
            }

            //stop moving
            finchRobot.setMotors(0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }


        //Methods for playing music notes of specified time and frequency 
        #region methods for playing music notes
        public static void SingleMusicNote(int note, int beat, Finch finchRobot)
        {
            finchRobot.noteOn(note);
            finchRobot.wait(beat);
            //finchRobot.noteOff();
        }
        public static void RestMusicNote(int beat, Finch finchRobot)
        {
            finchRobot.noteOff();
            finchRobot.wait(beat);
        }

        public static void DoubleMusicNote(int note1, int note2, int beat, Finch finchRobot)
        {
            for (int i = 0; i <= beat / 260; i++)
            {
                finchRobot.setLED(155, 155, 20);
                SingleMusicNote(note1, 75, finchRobot);
                finchRobot.setLED(20, 155, 155);
                SingleMusicNote(note2, 75, finchRobot);
                //finchRobot.noteOff();



            }

        }
        #endregion

        #endregion

        #region DATA RECORDER

        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitDataRecorderMenu = false;
            string menuChoice;

            //
            // declare variables
            //
            int numberOfDataPoints = 0;
            double frequencyOfDataPoints = 0;
            double[] temperatures = null;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Enter number of data points");
                Console.WriteLine("\tb) Enter frequency of data point collection");
                Console.WriteLine("\tc) Get data");
                Console.WriteLine("\td) Show data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        frequencyOfDataPoints = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, frequencyOfDataPoints, finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayData(numberOfDataPoints, frequencyOfDataPoints, temperatures, finchRobot);
                        break;

                    case "q":
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitDataRecorderMenu);
        }

        /// <summary>
        /// Get number of data points
        /// </summary>
        /// <param name="FinchRobot"></param>
        /// <returns>numberOfDataPoints</returns>
        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;

            DisplayScreenHeader("Number of Data Points");

            //
            // prompt user for number of points, convert to int, and validate
            //
            bool validResponse = false;
            do
            {
                Console.Write("\t\nEnter the number of data points you would like to collect:");

                if (int.TryParse(Console.ReadLine(), out numberOfDataPoints) && numberOfDataPoints > 0)
                {
                    validResponse = true;
                    //
                    // echo the value to the user
                    //
                    Console.WriteLine($"\t\nNumber of Data Points entered: {numberOfDataPoints}");
                }
                else
                {
                    Console.WriteLine("\t\nPlease enter a positive integer for the number of data points you would like to collect.");
                }

            } while (!validResponse);

            DisplayContinuePrompt();

            return numberOfDataPoints;
        }

        /// <summary>
        /// Get data point frequency
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <returns>frequencyOfDataPoints</returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            double frequencyOfDataPoints;

            DisplayScreenHeader("Data Point Collection Frequency");

            //
            // prompt user for frequency, convert to double, and validate
            //
            bool validResponse = false;
            do
            {
                Console.Write("\t\nEnter the Frequency of data point collection in seconds:");

                if (double.TryParse(Console.ReadLine(), out frequencyOfDataPoints) && frequencyOfDataPoints > 0)
                {
                    validResponse = true;
                    //
                    // echo the value to the user
                    //
                    Console.WriteLine($"\t\nFrequency Of Data Points entered: {frequencyOfDataPoints}s");
                }
                else
                {
                    Console.WriteLine("\t\nPlease enter a positive number for the frequency of data point collection");
                }

            } while (!validResponse);

            DisplayContinuePrompt();

            //
            // return the value
            //
            return frequencyOfDataPoints;
        }

        /// <summary>
        /// /get data
        /// </summary>
        /// <param name="numberOfDataPoints"></param>
        /// <param name="frequencyOfDataPoints"></param>
        /// <param name="finchRobot"></param>
        /// <returns>temperatures</returns>
        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double frequencyOfDataPoints, Finch finchRobot)
        {
            DisplayScreenHeader("Record Data");

            //
            // Declare an array of double using number of data points input by user as the size
            //
            double[] temperatures = new double[numberOfDataPoints];

            //
            // display the number and frequency of data readings
            //
            Console.WriteLine($"\tnumber of data points: {numberOfDataPoints}");
            Console.WriteLine($"\tfrequency of data points: {frequencyOfDataPoints}");

            //
            // prompt the user to begin recording data
            //
            Console.WriteLine("\t\n The application is ready to begin recording data. Continue to proceed with data collection");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                //
                // get a temperature reading from the finch robot
                //
                temperatures[index] = finchRobot.getTemperature();

                //
                // display readings to user in degrees farenheit along with number of seconds passed (starting at t=0s)
                //
                double farenheitTemp = ConvertCelsiusToFarenheit(temperatures[index]);

                double numberOfSecondsElapsed = index * frequencyOfDataPoints;
                Console.WriteLine($"\n\ttemperature at t={numberOfSecondsElapsed}s: {farenheitTemp.ToString("n2")}");

                //
                // convert frequency of data points in seconds to milliseconds and cast to int so it can be used for finchRobot.wait();
                //
                int waitInSeconds = (int)(frequencyOfDataPoints * 1000);

                //
                // wait the number of seconds specified by the user
                //
                finchRobot.wait(waitInSeconds);
            }

            Console.WriteLine("\n\tThe application has completed collecting data");
            DisplayContinuePrompt();

            return temperatures;
        }

        /// <summary>
        /// display data table
        /// </summary>
        /// <param name="numberOfDataPoints"></param>
        /// <param name="frequencyOfDataPoints"></param>
        /// <param name="temperatures"></param>
        /// <param name="finchRobot"></param>
        static void DataRecorderDisplayDataTable(int numberOfDataPoints, double frequencyOfDataPoints, double[] temperatures,  Finch finchRobot)
        {
            DisplayScreenHeader("time vs. temperature");

            Console.WriteLine($"\n\t1 data point was recorded every {frequencyOfDataPoints} seconds for a total of {numberOfDataPoints} data points.");

            //
            // display table headers (and underscore)
            //
            Console.WriteLine("");
            Console.WriteLine(
                "time in seconds".PadLeft(20) +
                "Temperature".PadLeft(20)
                );

            Console.WriteLine(
                "_______________".PadLeft(20) +
                "_______________".PadLeft(20)
                );

            //
            // display table of data
            //
            for (int index = 0; index < temperatures.Length; index++)
            {
                double numberOfSecondsElapsed = index * frequencyOfDataPoints;
                double farenheitTemp = ConvertCelsiusToFarenheit(temperatures[index]);

                Console.WriteLine(
                    numberOfSecondsElapsed.ToString("n2").PadLeft(20) +
                    farenheitTemp.ToString("n2").PadLeft(20)
                    );
            }
        }

        /// <summary>
        /// display data
        /// </summary>
        /// <param name="numberOfDataPoints"></param>
        /// <param name="frequencyOfDataPoints"></param>
        /// <param name="temperatures"></param>
        /// <param name="finchRobot"></param>
        static void DataRecorderDisplayData(int numberOfDataPoints, double frequencyOfDataPoints, double[] temperatures, Finch finchRobot)
        {
            DisplayScreenHeader("Results");

            DataRecorderDisplayDataTable(numberOfDataPoints, frequencyOfDataPoints, temperatures, finchRobot);

            DisplayContinuePrompt();
        }
        
        /// <summary>
        /// Convert temperature in celsius to temperature in farenheit
        /// </summary>
        /// <param name="celsiusTemp"></param>
        /// <returns>farenheit temperature</returns>
        static double ConvertCelsiusToFarenheit(double celsiusTemp)
        {
            double farenheitTemp;

            farenheitTemp = celsiusTemp * 1.8 + 32;

            return farenheitTemp;
        }


        #endregion

        #region ALARM SYSTEM

        static void LightAlarmDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitLightAlarmMenu = false;
            string menuChoice;

            //
            // declare variablea
            //
            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxThresholdValue = 0;
            int timeToMonitor = 0;

            do
            {
                DisplayScreenHeader("Light Alarm Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set sensors to monitor");
                Console.WriteLine("\tb) Set range type");
                Console.WriteLine("\tc) Set maximum/minimum threshold value");
                Console.WriteLine("\td) Set time to monitor");
                Console.WriteLine("\te) Set alarm");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = LightAlarmDisplaySetSensorsToMonitor(finchRobot);
                        break;

                    case "b":
                        rangeType = LightAlarmDisplaySetRangeType();
                        break;

                    case "c":
                        minMaxThresholdValue = LightAlarmDisplaySetMinMaxThresholdValue(rangeType, finchRobot);
                        break;

                    case "d":
                        timeToMonitor = LightAlarmDisplaySetMaximumTimeToMonitor();
                        break;

                    case "e":
                        LightAlarmSetAlarm(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor);
                        break;

                    case "q":
                        quitLightAlarmMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitLightAlarmMenu);
        }

        static string LightAlarmDisplaySetSensorsToMonitor(Finch finchRobot)
        {
            string sensorsToMonitor;

            DisplayScreenHeader("Set sensors to monitor");

            //
            // Display ambient light values
            //
            Console.WriteLine($"\t\nLeft light sensor ambient value: {finchRobot.getLeftLightSensor()}");
            Console.WriteLine($"\t\nright light sensor ambient value: {finchRobot.getRightLightSensor()}");
           
            //
            // prompt user for input, validate, and echo
            //
            bool validResponse = false;
            do
            {
                Console.Write("\t\nWhich sensors would you like to monitor? [left, right, both]: ");
                sensorsToMonitor = Console.ReadLine().ToLower();

                if (sensorsToMonitor == "left" || sensorsToMonitor == "right" || sensorsToMonitor == "both")
                {
                    validResponse = true;
                    //
                    // echo the value to the user
                    //
                    Console.WriteLine($"\t\nSensor(s) being monitored: {sensorsToMonitor}");
                }
                else
                {
                    validResponse = false;
                    Console.WriteLine("\t\nOops! Looks like you didn't enter an appropriate response. Please try again.");
                }

            } while (!validResponse);

            DisplayMenuPrompt("Light Alarm");

            return sensorsToMonitor;
        }

        static string LightAlarmDisplaySetRangeType()
        {
            string rangeType;

            DisplayScreenHeader("Set Range Type");

            //
            // prompt user for input, validate, and echo
            //
            bool validResponse = false;
            do
            {
                Console.Write("\t\nWould you like the alarm to go off when it reaches a minimum value or when it reaches a maximum value? [minimum, maximum]: ");
                rangeType = Console.ReadLine().ToLower();

                if (rangeType == "minimum" || rangeType == "maximum")
                {
                    validResponse = true;
                    //
                    // echo the value to the user
                    //
                    Console.WriteLine($"\t\nRange type: {rangeType}");
                }
                else
                {
                    validResponse = false;
                    Console.WriteLine("\t\nOops! Looks like you didn't enter an appropriate response. Please try again.");
                }

            } while (!validResponse);

            DisplayMenuPrompt("Light Alarm");

            return rangeType;
        }

        static int LightAlarmDisplaySetMinMaxThresholdValue(string rangeType, Finch finchRobot)
        {
            int minMaxThresholdValue;

            DisplayScreenHeader("set minimum/maximum threshold value");

            Console.WriteLine($"\t\nLeft light sensor ambient value: {finchRobot.getLeftLightSensor()}");
            Console.WriteLine($"\t\nright light sensor ambient value: {finchRobot.getRightLightSensor()}");

            //
            // prompt user for input, validate, and echo
            //
            bool validResponse = false;
            do
            {
                Console.WriteLine($"\t\nEnter the {rangeType} light value the the alarm must reach before going off: ");


                if (int.TryParse(Console.ReadLine(), out minMaxThresholdValue) && minMaxThresholdValue > 0)
                {
                    validResponse = true;
                    //
                    // echo the value to the user
                    //
                    Console.WriteLine($"\t\n{rangeType} light value: {minMaxThresholdValue}");
                }
                else
                {
                    validResponse = false;
                    Console.WriteLine("\t\nOops! Looks like you didn't enter an appropriate response. Input must be a positive integer. Please try again.");
                }

            } while (!validResponse);

            DisplayMenuPrompt("Light Alarm");

            return minMaxThresholdValue;
        }

        static int LightAlarmDisplaySetMaximumTimeToMonitor()
        {
            int timeToMonitor;

            DisplayScreenHeader("Set length of time to monitor");

            //
            // prompt user for input, validate, and echo
            //
            bool validResponse = false;
            do
            {
                Console.WriteLine($"\t\nEnter the length of time you would like the finch to monitor for: ");

                if (int.TryParse(Console.ReadLine(), out timeToMonitor) && timeToMonitor > 0)
                {
                    validResponse = true;
                    //
                    // echo the value to the user
                    //
                    Console.WriteLine($"\t\nMaximum time to moniter: {timeToMonitor}");
                }
                else
                {
                    validResponse = false;
                    Console.WriteLine("\t\nOops! Looks like you didn't enter an appropriate response. Input must be a positive integer. Please try again.");
                }

            } while (!validResponse);

            DisplayMenuPrompt("Light Alarm");

            return timeToMonitor;
        }

        static void LightAlarmSetAlarm(
            Finch finchRobot, 
            string sensorsToMonitor, 
            string rangeType, 
            int minMaxThresholdValue, 
            int timeToMonitor)
        {
            DisplayScreenHeader("Set Alarm");

            //
            // display alarm parameters
            //
            string aboveOrBelow;
            if (rangeType == "minimum")
            {
                aboveOrBelow = "below";
            }
            else
            {
                aboveOrBelow = "above";
            }

            Console.WriteLine($"\t\nSensors being monitored: {sensorsToMonitor}");
            Console.WriteLine($"\t\nalarm will go off if light value is {aboveOrBelow} {minMaxThresholdValue} within {timeToMonitor}s after monitoring begins.");

            //
            // prompt user to begin monitoring
            //
            Console.WriteLine("\t\napplication will begin monitoring when you continue");
            DisplayContinuePrompt();

            //
            // monitor the correct light sensors and send warning if light exceeds the set threshold
            //
            int secondsElapsed = 0;
            bool thresholdExceeded = false;
            int currentLightSensorValue = 0;

            while ((secondsElapsed < timeToMonitor) && !thresholdExceeded)
            {
                

                switch (sensorsToMonitor)
                {
                    case "left":
                        currentLightSensorValue = finchRobot.getLeftLightSensor();
                        break;

                    case "right":
                        currentLightSensorValue = finchRobot.getRightLightSensor();
                        break;

                    case "both":
                        currentLightSensorValue = (finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor()) / 2;
                        break;
                }

                switch (rangeType)
                {
                    case "minimum":
                        if (currentLightSensorValue < minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;

                    case "maximum":
                        if (currentLightSensorValue > minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;

                }

                finchRobot.wait(1000);
                secondsElapsed++;
            }

            if (thresholdExceeded)
            {
                Console.WriteLine($"The current light sensor value ({currentLightSensorValue}) has gone {aboveOrBelow} the light value of {minMaxThresholdValue}");
            }
            else
            {
                Console.WriteLine($"The current light sensor value ({currentLightSensorValue}) has not gone {aboveOrBelow} the light value of {minMaxThresholdValue}");
            }

            DisplayMenuPrompt("Light Alarm");

        }

        #endregion

        #region USER PROGRAMMING
        static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitUserProgrammingMenu = false;
            string menuChoice;

            //
            // declare tuple to store command parameters
            //
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            //
            // declare a list of the enum command
            //
            List<Command> commands = new List<Command>();
            

            do
            {
                DisplayScreenHeader("User Programming Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set command parameters");
                Console.WriteLine("\tb) Add commands");
                Console.WriteLine("\tc) View commands");
                Console.WriteLine("\td) Execute commands");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        commandParameters = UserProgrammingDisplayGetCommandParameters();
                        break;

                    case "b":
                        UserProgrammingDisplayGetFinchCommands(commands);
                        break;

                    case "c":
                        UserProgrammingDisplayFinchCommands(commands);
                        break;

                    case "d":
                        UserProgrammingDisplayExecuteFinchCommands(finchRobot, commands, commandParameters);
                        break;

                    case "q":
                        quitUserProgrammingMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitUserProgrammingMenu);
        }

        static (int motorSpeed, int ledBrightness, double waitSeconds) UserProgrammingDisplayGetCommandParameters()
        {
            DisplayScreenHeader("Set commands parameters");

            //
            // declare tuple to store command parameters
            //
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters;
            commandParameters.motorSpeed = 0;
            commandParameters.ledBrightness = 0;
            commandParameters.waitSeconds = 0;

            //
            //  get command parameter values and validate
            //
            GetValidInteger("\tEnter motor speed [1 - 255]:", 1, 255, out commandParameters.motorSpeed);
            GetValidInteger("\tEnter LED brightness [1-255]", 1, 255, out commandParameters.ledBrightness);
            GetValidDouble("\tEnter wait in seconds [0-10]", 0, 10, out commandParameters.waitSeconds);

            //
            // echo command parameter values to user
            //
            Console.WriteLine($"\n\t\tMotor Speed: {commandParameters.motorSpeed}");
            Console.WriteLine($"\n\t\tLED Brightness: {commandParameters.ledBrightness}");
            Console.WriteLine($"\n\t\tWait command duration: {commandParameters.waitSeconds}s");

            DisplayMenuPrompt("User Programming");

            return commandParameters;
        }

        #region get and validate user input of numbers
        static void GetValidInteger(string GetDataPrompt, int minimumIntegerValue, int maximumIntegerValue, out int commandParameter)
        {
            bool validInteger = false;
            int integer;
            do
            {
                commandParameter = 0;

                Console.WriteLine(GetDataPrompt);

                if (int.TryParse(Console.ReadLine(), out integer) && integer > minimumIntegerValue && integer < maximumIntegerValue)
                {
                    validInteger = true;
                    commandParameter = integer;
                }
                else
                {
                    validInteger = false;
                    Console.WriteLine($"Error: Invalid response. Please enter an integer between the values of {minimumIntegerValue} and {maximumIntegerValue}");
                }
            } while (!validInteger);
        }

        static void GetValidDouble(string GetDataPrompt, int minimumDoubleValue, int maximumDoubleValue, out double commandParameter)
        {
            bool validDouble = false;
            double userResponseDouble;
            do
            {
                commandParameter = 0;

                Console.WriteLine(GetDataPrompt);

                if (double.TryParse(Console.ReadLine(), out userResponseDouble) && userResponseDouble > minimumDoubleValue && userResponseDouble < maximumDoubleValue)
                {
                    validDouble = true;
                    commandParameter = userResponseDouble;
                }
                else
                {
                    validDouble = false;
                    Console.WriteLine($"Error: Invalid response. Please enter a double between the values of {minimumDoubleValue} and {maximumDoubleValue}");
                }
            } while (!validDouble);
        }
        #endregion

        static void UserProgrammingDisplayGetFinchCommands(List<Command> commands)
        {
            Command command = Command.NONE;

            DisplayScreenHeader("Finch Robot Commands");

            //
            // list commands
            //
            Console.WriteLine("\t\nList of available commands: ");
            Console.WriteLine("\t\n--MOVEFORWARD, \t\n--MOVEBACKWARD, \t\n--STOPMOTORS, \t\n--WAIT, \t\n--TURNRIGHT, \t\n--TURNLEFT, \t\n--LEDON, \t\n--LEDOFF, \t\n--GETTEMPERATURE, \t\n--DONE");

            //
            // get user input for commands as long as DONE is not entered
            //
            while (command != Command.DONE)
            {
                Console.Write("\t\nEnter command:");

                if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    //
                    // add command to list
                    //
                    commands.Add(command);
                }
                else
                {
                    Console.WriteLine("Error: a command from the list was not entered. Please enter a command from the list");
                }
            }

            DisplayMenuPrompt("User Programming");
        }

        static void UserProgrammingDisplayFinchCommands(List<Command> commands)
        {
            foreach (Command command in commands)
            {
                Console.WriteLine($"\t{command}");
            }

            DisplayMenuPrompt("User Programming");
        }

        static void UserProgrammingDisplayExecuteFinchCommands(
            Finch finchRobot,
            List<Command> commands,
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)
        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            double waitSeconds = commandParameters.waitSeconds;
            int waitMilliSeconds = (int)(commandParameters.waitSeconds * 1000);
            string displayCommandPerformed = "";
            const int TURNING_MOTOR_SPEED = 100;

            DisplayScreenHeader("Execute finch commands");

            //
            // prompt user to begin the finche's execution of commands
            //
            Console.WriteLine("The finch is ready to perform the list of commands. Continue to begin execution");
            DisplayContinuePrompt();

            //
            // execute command and turn command enum to string to display to console
            //
            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;

                    case Command.MOVEFORWARD:
                        finchRobot.setMotors(motorSpeed, motorSpeed);
                    displayCommandPerformed = Command.MOVEFORWARD.ToString();
                        break;

                    case Command.MOVEBACKWARD:
                        finchRobot.setMotors(-motorSpeed, -motorSpeed);
                        displayCommandPerformed = Command.MOVEBACKWARD.ToString();
                        break;

                    case Command.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        displayCommandPerformed = Command.MOVEFORWARD.ToString();
                        break;

                    case Command.WAIT:
                        finchRobot.wait(waitMilliSeconds);
                        displayCommandPerformed = Command.WAIT.ToString();
                        break;

                    case Command.TURNRIGHT:
                        finchRobot.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                        displayCommandPerformed = Command.TURNRIGHT.ToString();
                        break;

                    case Command.TURNLEFT:
                        finchRobot.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        displayCommandPerformed = Command.TURNLEFT.ToString();
                        break;

                    case Command.LEDON:
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        displayCommandPerformed = Command.LEDON.ToString();
                        break;

                    case Command.LEDOFF:
                        finchRobot.setLED(0, 0, 0);
                        displayCommandPerformed = Command.LEDOFF.ToString();
                        break;

                    case Command.GETTEMPERATURE:
                        displayCommandPerformed = Command.GETTEMPERATURE.ToString() + $" Temperature reading: {finchRobot.getTemperature().ToString("n2")}";
                        break;

                    case Command.DONE:
                        displayCommandPerformed = Command.DONE.ToString();
                        break;

                    default:

                        break;
                }

                Console.WriteLine($"\n\t{displayCommandPerformed}");
            }

            DisplayMenuPrompt("User Programming");
        }
        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        /// <summary>
        /// Provides feedback to user about the connection status of the robot (whether robot is successfully connected or not)
        /// </summary>
        /// <param name="robotConnected"></param>
        /// <param name="finchRobot"></param>
        static void DisplayFinchRobotConnectionStatus(bool robotConnected, Finch finchRobot)
        {

            if (robotConnected)
            {
                #region assign frequencies to notes
                // first octave frequencies in Hz
                int c1 = 33, cSharp1 = 35, d1 = 37, dSharp1 = 39, e = 41, f1 = 44, fSharp1 = 46, g1 = 49, gSharp1 = 52, a1 = 55, aSharp1 = 58, b1 = 62;

                // second octave frequencies in Hz
                int c2 = 65, cSharp2 = 69, d2 = 73, dSharp2 = 78, e2 = 82, f2 = 87, fSharp2 = 92, g2 = 98, gSharp2 = 104, a2 = 110, aSharp2 = 117, b2 = 123;

                // third octave frequencies in Hz
                int c3 = 131, cSharp3 = 139, d3 = 147, dSharp3 = 156, e3 = 165, f3 = 175, fSharp3 = 185, g3 = 196, gSharp3 = 208, a3 = 220, aSharp3 = 233, b3 = 247;

                // fourth octave frequencies in Hz
                int c4 = 262, cSharp4 = 277, d4 = 294, dSharp4 = 311, e4 = 330, f4 = 349, fSharp4 = 370, g4 = 392, gSharp4 = 415, a4 = 440, aSharp4 = 466, b4 = 494;
                #endregion

                #region assign time values to beats

                int quarter = 522;
                int eighth = 260;
                int dottedQuarter = 781;
                int dottedEighth = 391;
                int sixteenth = 130;
                int dottedSixteenth = 195;
                int half = 1043;
                int dottedHalf = 1565;
                int whole = 2087;
                int dottedWhole = 3130;

                #endregion

                //turn lights and buzzer on then off to confirm that finch has succesfully connected
                finchRobot.setLED(0, 155, 155);
                SingleMusicNote(a2, dottedEighth, finchRobot);
                finchRobot.setLED(0, 155, 255);
                SingleMusicNote(fSharp3, sixteenth, finchRobot);
                finchRobot.setLED(0, 0, 255);
                SingleMusicNote(d4, half, finchRobot);
                finchRobot.noteOff();
                finchRobot.setLED(0, 0, 0);

                //display connection successful message
                Console.WriteLine("Finch has been succesfully connected");

            }
            else
            {
                //display connection unsuccessful message
                Console.WriteLine("Error: Connection was unsuccessful. Please try again");

                //reset connection for user's next attempt
                finchRobot.disConnect();
            }

            DisplayMenuPrompt("Main Menu");

        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
