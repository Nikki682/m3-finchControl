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
    //              to control the Finch robot 
    // Application Type: Console
    // Author: Fink, Nikki and starter from Velis, John
    // Dated Created: 2/15/2021
    // Last Modified: 2/25/2021
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
                Console.WriteLine("\tb) Dance..well Kinda ");
                Console.WriteLine("\tc) Mixing It Up");
                Console.WriteLine("\td) Random");
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
                        UnderConstruction();

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
            finchRobot.wait(800);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(880);
            finchRobot.wait(500);
            finchRobot.noteOff();
            finchRobot.noteOn(784);
            finchRobot.wait(1000);
            finchRobot.noteOff();
            finchRobot.noteOn(988);
            finchRobot.wait(800);
            finchRobot.noteOff();
            finchRobot.noteOn(1047);
            finchRobot.setLED(255, 0, 255);
            finchRobot.wait(800);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);


            Console.WriteLine("\tWas that awesome or what? y/n");
            lightAnswer = Console.ReadLine().ToLower();
            //    while (lightAnswer != "y" || lightAnswer != "n")
            //    {
            //        Console.WriteLine(" Please pick y or n");
            //        Console.WriteLine();
            //        lightAnswer = Console.ReadLine();


            if (lightAnswer == "y")
            {
                Console.WriteLine(" \tThanks I thought so too");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();

            }


            else
            {
                Console.WriteLine("\tOh I'm sorry you did't like it. Lets do something else.");
                Console.WriteLine("Press an key to continue");
                Console.ReadKey();
            }

            Console.WriteLine("\tDo you want to turn on my lights? y/n");
            morePlay = Console.ReadLine().ToLower();
            //  while (morePlay != "y" || morePlay != "n")



            if (morePlay == "y")

            {
                finchRobot.setLED(255, 255, 255);
                finchRobot.wait(2000);
                finchRobot.setLED(0, 0, 0);
                finchRobot.setLED(255, 0, 0);
                finchRobot.wait(2000);
                finchRobot.setLED(0, 0, 0);
                Console.WriteLine("\tok ok I know not too impressive.");
                Console.WriteLine("press an key to continue");
                Console.ReadKey();
            }


            else
            {
                Console.WriteLine("\tOk no problem, lets move on shall we.");
                Console.WriteLine("Press an key to continue");
                Console.ReadKey();
            }



            DisplayContinuePrompt();


            DisplayMenuPrompt("Talent Show Menu");


        }


        ///*******************************************************************
        ///*                 Talent Show > Dance                             *
        ///*******************************************************************


        static void TalentShowDisplayDance(Finch finchRobot)
        {
            string userMove;
            // bool quit = false;


            Console.CursorVisible = false;

            DisplayScreenHeader("Let's Move");

            Console.WriteLine("\tThis Finch robot is about to move! Look out!");
            DisplayContinuePrompt();

            // move
            finchRobot.setMotors(255, 255);
            finchRobot.wait(10);
            finchRobot.setMotors(255, 0);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 255);
            finchRobot.wait(1000);
            finchRobot.setMotors(0, 0);


            Console.WriteLine("\tWell that wasn't anything special was it?");
            Console.WriteLine();
            Console.WriteLine("\tOk how about you move the robot a little.");
            Console.WriteLine("\tPress L to move left or R to move right");
            userMove = Console.ReadLine().ToLower();


            //  do
            //  {
            switch (userMove)
            {
                case "l": finchRobot.setMotors(0, 255);
                    finchRobot.wait(4000);
                    finchRobot.setMotors(0, 0);

                    break;


                case "r": finchRobot.setMotors(255, 0);
                    finchRobot.wait(4000);
                    finchRobot.setMotors(0, 0);


                    break;


                default:
                    Console.WriteLine("Enter L or R");
                    DisplayContinuePrompt();
                    break;



            }


            // } while(!quit);


            Console.WriteLine("\tAAAnd thats's enough of that lol");

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

            for (int mixValue = 0; mixValue < 100; mixValue++)
            {
                finchRobot.setLED(mixValue, mixValue, mixValue);
                finchRobot.wait(25);
            }
            //hbday song
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(587);
            finchRobot.wait(500);
            finchRobot.noteOn(659);
            finchRobot.wait(500);
            finchRobot.noteOn(587);
            finchRobot.wait(1000);
            finchRobot.noteOn(740);
            finchRobot.wait(1000);
            finchRobot.noteOn(880);
            finchRobot.wait(1000);

            finchRobot.setLED(255, 0, 0);
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

            finchRobot.setLED(0, 255, 0);
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

            finchRobot.setLED(0, 0, 255);
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
            finchRobot.wait(2000);
            finchRobot.noteOff();
            finchRobot.setLED(0, 0, 0);

            finchRobot.setMotors(255, 255);
            finchRobot.wait(2000);
            finchRobot.setMotors(-255, -255);
            finchRobot.wait(1000);
            finchRobot.setMotors(255, 255);
            finchRobot.wait(2000);
            finchRobot.setMotors(0, 0);

            Console.WriteLine();
            Console.WriteLine("\tNo more mixing it up, for now");

            DisplayMenuPrompt("Talent Show Menu");
        }
        #endregion

        #region Data Recorder
        //*******************************
        //*        Data Recorder        *
        //*******************************

        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;

            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points ");
                Console.WriteLine("\tb) Frequency of Data Points ");
                Console.WriteLine("\tc) Get Data ");
                Console.WriteLine("\td) Show Data");
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
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();

                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, finchRobot);

                        break;

                    case "d":
                        DataRecorderDisplayData(temperatures);

                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choices provided.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);


        }

        static void DataRecorderDisplayData(double[] temperatures)
        {
            DisplayScreenHeader("Display Data");

            //
            //table headers
            //
            Console.WriteLine(
               "Recording #".PadLeft(15) +
               "Temperature".PadLeft(15)
                );
            Console.WriteLine(
                "----------".PadLeft(15) +
                "----------".PadLeft(15)
                );
            //
            //display table data
            //

            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                (index + 1).ToString().PadLeft(15) +
                temperatures[index].ToString("n2").PadLeft(15)
                );
                //change to farenhhiet
            }


            DisplayContinuePrompt();
        }

        static void DataRecorderDisplayTable(double[] temperatures)
        {
            // 
            //table headers
            //
            Console.WriteLine(
               "Recording #".PadLeft(15) +
               "Temperature".PadLeft(15)
                );
            Console.WriteLine(
                "----------".PadLeft(15) +
                "----------".PadLeft(15)
                );
            //
            //display table data
            //

            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                (index + 1).ToString().PadLeft(15) +
                temperatures[index].ToString("n2").PadLeft(15)
                );
                //change to farenhhiet
            }
        }

        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfDataPoints];
            double[] conversion = new double[numberOfDataPoints];

            DisplayScreenHeader("\tGet Data");

            Console.WriteLine($"\tNumber of Data points:  {numberOfDataPoints}");
            Console.WriteLine($"\tData point frequency: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("\tOk folks we are ready to start recording temperature data.");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = finchRobot.getTemperature();
                Console.WriteLine($"\tReading {index + 1}: {temperatures[index].ToString("n2")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                finchRobot.wait(waitInSeconds);

                conversion[index] = (int)((temperatures[index] * 1.8) + 32);
                Console.WriteLine($"\t Temperature in Farenheit :{ conversion[index] + 1}");

            }


            DisplayContinuePrompt();
            DisplayScreenHeader("Get Data");

            Console.WriteLine();
            Console.WriteLine("\tTable of Temperatures");
            Console.WriteLine();
            DataRecorderDisplayTable(temperatures);

            DisplayContinuePrompt();

            return temperatures;
        }




        /// <summary>
        /// get frequency of data points from user
        /// </summary>
        /// <returns>frequency of data points</returns>

        static double DataRecorderDisplayGetDataPointFrequency()
        {
            
            string userResponse;
            bool validResponse;
            do
            {



                DisplayScreenHeader("\t Data Point Frequency");

                Console.Write("\tFrequency of Data Points (how often in seconds): ");
                userResponse = Console.ReadLine();
                //validate

                validResponse = double.TryParse(userResponse, out double dataPointFrequency);
                
                if (!validResponse)
                {
                    Console.WriteLine("enter number");
                    Console.WriteLine();
                }
                else
                {
                 
                 DisplayContinuePrompt();
                 
                }
                
                return dataPointFrequency;
                
                
            } while (!validResponse);

            
               
                
            
           
        }
        /// <summary>
        /// get number of data points 
        /// </summary>
        /// <returns>number of data points</returns>

        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            bool validResponse ;
            do
            {


                int numberOfDataPoints;
                string useResponse;
                validResponse = false;

                DisplayScreenHeader("\tNumber of Data Points");

                Console.Write("\tPlease Enter the Number of Data Points you want to record: ");
                useResponse = Console.ReadLine();
                //validate

                int.TryParse(useResponse, out numberOfDataPoints);
                if (!validResponse )
                {
                    



                }
                DisplayContinuePrompt();

                return numberOfDataPoints;
                
            } while (!validResponse);










                DisplayContinuePrompt();

               // return numberOfDataPoints;
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

            Console.WriteLine("\tConnecting to our Finch now");
            finchRobot.noteOn(200);
            finchRobot.wait(400);
            finchRobot.noteOff();
            Console.WriteLine("\t OOOHH Pretty Lights");
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(500);
            finchRobot.setLED(0, 0, 255);
            finchRobot.setLED(0, 0, 0);
            Console.WriteLine("\t Finch Connected");


            DisplayMenuPrompt("Main Menu");

            

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
            Console.WriteLine("\tHello and welcome to my Finch control App");
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
            Console.ReadLine();

        }

        #endregion
    }
}
