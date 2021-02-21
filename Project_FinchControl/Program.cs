using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: M3 Finch Control
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Fink, Nikki
    // Dated Created: 2/15/2021
    // Last Modified: 2/21/2021
    //
    // **************************************************

    class Program
    {
        // first method run when the app starts up


        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
            //UnderConstruction();
        }

        /// setup the console theme

        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
        }


        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************

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
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);

                        break;

                    case "d":
                           AlarmSystemDisplayMenuScreen(finchRobot);

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

        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************

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
                Console.WriteLine("\tb) Dance ");
                Console.WriteLine("\tc) Mixing It Up");
                Console.WriteLine("\td) ");
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
                        TalentShowDisplayDance(finchRobot);

                        break;

                    case "c":
                        TalentShowMixingItUp(finchRobot);

                        break;

                    case "d":
                        Console.WriteLine("Under construction. Come back later");

                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choices provided.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }


        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************

        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {
            string lightAnswer;
            string morePlay;

            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThis robot will now light up and make noise!");
            DisplayContinuePrompt();

            //    for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            //    {
            //        finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
            //        finchRobot.noteOn(lightSoundLevel * 100);
            //        finchRobot.wait(250);
            //        finchRobot.noteOff();
            //        finchRobot.setLED(0, 0, 0);
            //    }

            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(500);
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.setLED(0, 0, 255);
            finchRobot.wait(500);
            finchRobot.setLED(0, 0, 0);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(2000);
            finchRobot.setLED(0, 0, 0);

            //song
            finchRobot.noteOn(1047);
            finchRobot.wait(800);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(880);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(1500);
            finchRobot.noteOff();
            finchRobot.noteOn(988);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(1047);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(2000);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            Console.WriteLine("\tWas that awesome or what? y/n");
            lightAnswer = Console.ReadLine();

            if (lightAnswer == "y")
            {
                Console.WriteLine("Yeah I thought so too");

            }
            else
            {
                Console.WriteLine("Oh I'm sorry you did't like it. Lets do something else.");
                Console.WriteLine("Do you want to turn on my lights? y/n");
                morePlay = Console.ReadLine();


                if (morePlay == "y")

                {
                    finchRobot.setLED(255, 255, 255);
                    finchRobot.wait(2000);
                    finchRobot.setLED(0, 0, 0);
                    finchRobot.setLED(0, 255, 0);
                    finchRobot.wait(3000);
                    finchRobot.setLED(0, 0, 0);
                }
                else
                {
                    Console.WriteLine("ok no problem, lets move on.");
                }
            }





            DisplayMenuPrompt("Talent Show Menu");
        }


        ///*******************************************************************
        ///*                 Talent Show > Dance                             *
        ///*******************************************************************


        static void TalentShowDisplayDance(Finch finchRobot)
        {
            string userMove;
            bool quitDance = false;

            Console.CursorVisible = false;

            DisplayScreenHeader("Let's Move");

            Console.WriteLine("\tThe Finch robot is about to move!");
            DisplayContinuePrompt();

            // move
            finchRobot.setMotors(255, 255);
            finchRobot.wait(10);
            finchRobot.setMotors(255, 0);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 255);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);


            Console.WriteLine("Well that wasn't anything special was it?");
            Console.WriteLine("Ok how about you move the robot a little.");
            Console.WriteLine("Press 1 to move left or 2 to move right");
            userMove = Console.ReadLine();
            Console.WriteLine("I see you want to move" + userMove);


            if (userMove == "1")
            {
                finchRobot.setMotors(0, 255);
                finchRobot.wait(1000);
                finchRobot.setMotors(0, 0);
            }
            else if (userMove == "2") 
            {
                finchRobot.setMotors(255,0);
                finchRobot.wait(1000);
                finchRobot.setMotors(0, 0);
            }
            else
            {
                Console.WriteLine("Enter valid number");
            }
            
            
            
            //maybe an or/else instead of a do? or remove do/while nope need if

            //do
            //{
            //    switch (userMove)
            //    {
            //        case "1": finchRobot.setMotors(0, 255);
            //            finchRobot.wait(4000);
            //            finchRobot.setMotors(0, 0);
            //            break;
            //        case "2": finchRobot.setMotors(255, 0);
            //            finchRobot.wait(4000);
            //            finchRobot.setMotors(0, 0);

            //            break;
            //        case "": Console.WriteLine("Pick 1 or 2");
            //            break;
            //        default: quitDance = true;
            //            break;


            //    }

            //} while (!quitDance);




            DisplayMenuPrompt("Talent Show Menu");
        }

        ///**********************************************************************
        ///*            Talent Show > Mixing It Up                              *
        ///**********************************************************************

        static void TalentShowMixingItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing It Up");

            Console.WriteLine("\tThe Finch robot is gonna shake rattle and roll, with pretty colors and sounds too!");
            DisplayContinuePrompt();

            // more for loops and commands for sing/dance

            for (int mixValue = 0; mixValue < 200; mixValue++)
            {
                finchRobot.setLED(mixValue, mixValue, mixValue);
                finchRobot.wait(25);
            }
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(659);
            finchRobot.wait(1000);
            finchRobot.noteOn(587);
            finchRobot.wait(1000);
            finchRobot.noteOn(740);
            finchRobot.wait(1200);

            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(659);
            finchRobot.wait(1000);
            finchRobot.noteOn(587);
            finchRobot.wait(1000);
            finchRobot.noteOn(880);
            finchRobot.wait(1000);
            finchRobot.noteOn(784);

            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(988);
            finchRobot.wait(500);
            finchRobot.noteOn(784);
            finchRobot.wait(1000);
            finchRobot.noteOn(740);
            finchRobot.wait(500);
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOn(659);
            finchRobot.wait(1000);

            finchRobot.noteOn(523);
            finchRobot.wait(500);
            finchRobot.noteOn(523);
            finchRobot.wait(500);
            finchRobot.noteOn(988);
            finchRobot.wait(500);
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOn(880);
            finchRobot.wait(500);
            finchRobot.noteOn(784);
            finchRobot.wait(3000);
            finchRobot.noteOff();

            Console.WriteLine("That was fun");


            DisplayMenuPrompt("Talent Show Menu");
        }
        #endregion

        #region Data Recorder
        //*******************************
        //*        Data Recorder        *
        //*******************************

        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Data Recorder");
            Console.WriteLine("\tThis area is still under construction");
            DisplayContinuePrompt();
        }


        #endregion




        #region Alarm system

        //****************************************
        //*         Alarm System                 *
        //****************************************
        static void AlarmSystemDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Alarm System");
            Console.WriteLine("\tThis area is still under construction");
            DisplayContinuePrompt();
        }

        #endregion



        #region User Programming

       //***********************************************
       //*          User Programming                    *
       //************************************************
        static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("User Programming");
            Console.WriteLine("\tThis area is still under construction");
            DisplayContinuePrompt();
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

            // TODO test connection and provide user feedback - text, lights, sounds

            Console.WriteLine("Connecting to our Finch");
            finchRobot.noteOn(200);
            finchRobot.wait(400);
            finchRobot.noteOff();
            Console.WriteLine("Pretty Lights");
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(500);
            finchRobot.setLED(0, 0, 255);


            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
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

        // area for methods

        static void UnderConstruction()
        {
            Console.WriteLine();
            Console.WriteLine("Sorry this section is still under construction.");
            Console.WriteLine("Come back soon!");
            DisplayContinuePrompt();

        }

        #endregion
    }
}
