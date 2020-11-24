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
    //              and added talent show options
    // Application Type: Console
    // Author: Jandreski, Elise
    // Dated Created: 11/11/2020
    // Last Modified: 11/24/2020
    //
    // **************************************************

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

                        break;

                    case "d":

                        break;

                    case "e":

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

        //methods for talent show options displayed in the talent show menu
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
                finchRobot.wait(300);
                finchRobot.setMotors(75, 150);
                finchRobot.wait(300);
                finchRobot.setMotors(75, 150);
                finchRobot.wait(300);
                finchRobot.setMotors(150, 75);
                finchRobot.wait(300);
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
            for (int i = 0; i < 8; i++)
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

            // TODO test connection and provide user feedback - text, lights, sounds

            //DisplayMenuPrompt("Main Menu");

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
