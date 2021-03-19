using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    // Dated Created: 02/15/2021
    // Last Modified: 03/02/2021
    //
    // **************************************************


    /// <summary>
    /// USER COMMANDS
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
        //NOTEON,
        //NOTEOFF,
        //CRAZYCOMBO,
        DONE
    }


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
                Console.WriteLine("\td) Light Alarm System");
                Console.WriteLine("\te) Temperature Alarm System");
                Console.WriteLine("\tf) User Programming");
                Console.WriteLine("\tg) Disconnect Finch Robot");
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
                        TempAlarmSystemDisplayMenuScreen(finchRobot);
                        break;

                    case "f":
                        UserProgrammingDisplayMenuScreen(finchRobot);

                        break;

                    case "g":
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
                case "l":
                    finchRobot.setMotors(0, 255);
                    finchRobot.wait(4000);
                    finchRobot.setMotors(0, 0);

                    break;


                case "r":
                    finchRobot.setMotors(255, 0);
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

        #region DATA RECORDER
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
                        Console.WriteLine("\tPlease enter a letter from the menu choices provided.");
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
               
                //change to farenhheit w method
            }

            Console.WriteLine($"\t The Average Temperature is:{temperatures.Average()} Celsius");

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
                //change to farenhheit w method
            }

            Console.WriteLine($"\t The Average Temperature is:{temperatures.Average():n2} Celsius"); //simplified
        }

        /// <summary>
        /// get temperature data 
        /// </summary>
        /// <param name="numberOfDataPoints"></param>
        /// <param name="dataPointFrequency"></param>
        /// <param name="finchRobot"></param>
        /// <returns>temperatures</returns>
        /// 
        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfDataPoints];

            DisplayScreenHeader("\tGet Data");

            Console.WriteLine($"\tNumber of Data points:  {numberOfDataPoints}");
            Console.WriteLine($"\tData point frequency: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("\tOk folks we are ready to start recording temperature data.");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = finchRobot.getTemperature();
                Console.WriteLine($"\tReading {index + 1}: {temperatures[index].ToString("n2")}");  //can be simplified
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                finchRobot.wait(waitInSeconds);


                Console.WriteLine($"\t Temperature in Farenheit :{ ConvertToFarenheit(temperatures[index])}");

                // set to seperate method TempConversion..
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
        /// convert celsius to farenheit
        /// </summary>
        /// <param name="celsiusTemp"></param>
        /// <returns>farenheit temperature</returns>
        static double ConvertToFarenheit(double celsiusTemp)
        {
            return ((celsiusTemp * 1.8) + 32);
        }

        /// <summary>
        /// get frequency of data points from user
        /// </summary>
        /// <returns>data point frequency</returns>

        static double DataRecorderDisplayGetDataPointFrequency()
        {

            string userResponse;
            bool validResponse = false;
            double dataPointFrequency;

            // validate...yess i did it
            DisplayScreenHeader("\t Data Point Frequency");

            do
            {
                Console.Write("\tFrequency of Data Points (how often in seconds): ");
                userResponse = Console.ReadLine();

                validResponse = double.TryParse(userResponse, out dataPointFrequency);

                if (!validResponse)
                {
                    Console.Write("\tPlease enter a proper number [1,2,3...]: ");
                }

            } while (!validResponse);

            DisplayContinuePrompt();

            return dataPointFrequency;

        }
        /// <summary>
        /// get number of data points 
        /// </summary>
        /// <returns>number of data points</returns>

        static int DataRecorderDisplayGetNumberOfDataPoints()
        {
            string useResponse;
            bool validResponse = false;
            int numberOfDataPoints;
                
            DisplayScreenHeader("\tNumber of Data Points");
            
            do
            {           

                Console.Write("\tPlease Enter the Number of Data Points you want to record: ");
                useResponse = Console.ReadLine();

                //validate...done

                validResponse = int.TryParse(useResponse, out numberOfDataPoints);

                if (!validResponse)
                {
                    Console.Write("\tPlease Enter a proper number [1,2,3..]: ");
                }    
                
            } while (!validResponse);

                DisplayContinuePrompt();

            return numberOfDataPoints;
        }

        #endregion

        #region ALARM SYSTEM

        //****************************************
        //*         Alarm System                 *
        //****************************************
        static void AlarmSystemDisplayMenuScreen(Finch finchRobot)
        {


            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxThresholdValue = 0;
            int timeToMonitor = 0;

            do
            {
                DisplayScreenHeader(" Light Alarm System Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Minimum/Maximum Threshold Value");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = LightAlarmDisplaySetSensorsToMonitors();

                        break;

                    case "b":
                        rangeType = LightAlarmDisplaySetRangeType();

                        break;

                    case "c":
                        minMaxThresholdValue = LightAlarmSetMinMaxThresholdValue(rangeType, finchRobot);

                        break;

                    case "d":
                        timeToMonitor = LightAlarmSetTimeToMonitor();

                        break;

                    case "e":
                        LightAlarmSetAlarm(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor);

                        break;

                   
                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter from the menu choices provided.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);


        }

        /// <summary>
        /// set alarm
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="sensorsToMonitor"></param>
        /// <param name="rangeType"></param>
        /// <param name="minMaxThresholdValue"></param>
        /// <param name="timeToMonitor"></param>
        static void LightAlarmSetAlarm(
            Finch finchRobot,
            string sensorsToMonitor,
            string rangeType,
            int minMaxThresholdValue,
            int timeToMonitor)
        
        {
            int secondsElapsed = 0;
            bool thresholdExceeded = false;
            int currentLightSensorValue = 0;

            DisplayScreenHeader("Set Alarm");

            Console.WriteLine($"\tSensors to Monitor {sensorsToMonitor}");
            Console.WriteLine("\tRange Type:{0}", rangeType);
            Console.WriteLine("\tMin/Max threshold Value:"  + minMaxThresholdValue);
            Console.WriteLine($"\tTime to monitor: {timeToMonitor}");
            Console.WriteLine();
            
            Console.WriteLine("\tPress any key to begin Monitoring");
            Console.ReadKey();
            Console.WriteLine();

            while ((secondsElapsed < timeToMonitor) && !thresholdExceeded )
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
                        currentLightSensorValue = finchRobot.getRightLightSensor() + finchRobot.getLeftLightSensor() / 2;
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
                Console.WriteLine($"\tThe {rangeType} threshold value of {minMaxThresholdValue} was exceeded by the current light sensor value of {currentLightSensorValue}");
            }
            else
            {
                Console.WriteLine($"\tThe {rangeType} threshold value of {minMaxThresholdValue} was not exceeded.");
        
            }
           

            DisplayMenuPrompt("Light Alarm");
        }


        /// <summary>
        /// set time to monitor
        /// </summary>
        /// <returns> time To Monitor</returns>
        static int LightAlarmSetTimeToMonitor()
        {
            bool validResponse = false;
            string userResponse;
            int timeToMonitor;  

            DisplayScreenHeader("Time to Monitor");
            //validate...help?

            do
            {
                Console.WriteLine("\tEnter length of time to monitor in seconds");
                userResponse = Console.ReadLine();

            
                validResponse = int.TryParse(userResponse, out  timeToMonitor);

                if (!validResponse)
                {
                    Console.WriteLine("\t We need a time in seconds please [1,5,20]");
                  
                }

            } while (!validResponse);


            Console.WriteLine();
            Console.WriteLine($"\t You entered: {timeToMonitor} seconds.");
                      
                       
            DisplayMenuPrompt("Light Alarm");

            return timeToMonitor;
        }

        /// <summary>
        ///  get min/max threshold value
        /// </summary>
        /// <param name="rangeType"></param>
        /// <param name="finchRobot"></param>
        /// <returns>min/max threshold value</returns>
        static int LightAlarmSetMinMaxThresholdValue(string rangeType, Finch finchRobot)
        {
            int minMaxThresholdValue;
            string userResponse;
            bool validResponse = false;

            DisplayScreenHeader("Minimum/Maximum Threshold Value");
                    
            //valid..done?

            do
            {
                     
            Console.WriteLine($"\tLeft light sensor ambient value: {finchRobot.getLeftLightSensor()}");
            Console.WriteLine($"\tRight light sensor ambient value: {finchRobot.getRightLightSensor()}");
            Console.WriteLine();
           

            Console.WriteLine($"\tEnter the {rangeType} light sensor value:");
            userResponse = Console.ReadLine();

            validResponse = int.TryParse(userResponse, out  minMaxThresholdValue);

                if (!validResponse)
                {
                    Console.WriteLine("\tEnter the the threshold value in numbers[1, 36, 88]");
                }
                       

            } while (!validResponse);

            Console.WriteLine();
            Console.WriteLine($"\tYou entered {minMaxThresholdValue}");

            DisplayMenuPrompt("Light Alarm");

            return minMaxThresholdValue;
        }


        /// <summary>
        /// select sensors to use
        /// </summary>
        /// <returns> sensors to monitor</returns>
        static string LightAlarmDisplaySetSensorsToMonitors()
        {
            string sensorsToMonitor;
            bool validInput = false;

           // validate..help
            
            DisplayScreenHeader("Sensors to Monitor");

            do
            {
                          
                Console.Write("\tSensors to Monitor [left, right, both]");
                sensorsToMonitor = Console.ReadLine().ToLower();

                validInput = sensorsToMonitor == "left" || sensorsToMonitor == "right" || sensorsToMonitor == "both";

                if (!validInput)
                {
                    Console.WriteLine("\tInvalid response. Please enter 'left' 'right' or 'both' ");
                }
           
            
            } while (!validInput);

            Console.WriteLine();
            Console.WriteLine($"\tYou chose : {sensorsToMonitor} ");

            DisplayMenuPrompt("Light Alarm");

            return sensorsToMonitor;
        }

        /// <summary>
        /// set Range min/max
        /// </summary>
        /// <returns>range type</returns>
        static string LightAlarmDisplaySetRangeType()
        {
            string rangeType ;
            bool validInput = false;
            
            DisplayScreenHeader("Range Type");

            //validate..done
            do
            {
   
        
                Console.Write("\tPlease enter range Type [minimum, maximum]:");
                rangeType = Console.ReadLine().ToLower();

                validInput = rangeType == "minimum" || rangeType == "maximum";

                if (!validInput)  
                {
                    Console.WriteLine("\tInvalid response. Enter 'minimum' or 'maximum'.");   
                }
           
                     
            } while (!validInput);

            Console.WriteLine();
            Console.WriteLine($"\tYou entered: {rangeType}.");
            Console.WriteLine();
            
            DisplayMenuPrompt("Light Alarm");

            return rangeType;
        }


        #endregion

        #region TEMPERATURE ALARM
        //********************************************************************
        //
        //                  Temperature Alarm System
        //
        //********************************************************************


        /// <summary>
        /// 
        /// </summary>
        /// <param name="finchRobot"></param>
        static void TempAlarmSystemDisplayMenuScreen(Finch finchRobot)
        {


            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;


            string rangeType = "";
            double minMaxThresholdValue = 0;
            double timeToMonitor = 0;

            do
            {
                DisplayScreenHeader(" Temperature Alarm System Menu");

                //
                // get user menu choice


                Console.WriteLine("\ta) Set Range Type");
                Console.WriteLine("\tb) Set Minimum/Maximum Threshold Value");
                Console.WriteLine("\tc) Set Time to Monitor");
                Console.WriteLine("\td) Set Alarm");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {




                    case "a":
                        rangeType = TempAlarmDisplaySetRangeType();

                        break;

                    case "b":
                        minMaxThresholdValue = TempAlarmSetMinMaxThresholdValue(rangeType, finchRobot);

                        break;

                    case "c":
                        timeToMonitor = TempAlarmSetTimeToMonitor();

                        break;

                    case "d":
                        TempAlarmSetAlarm(finchRobot, rangeType, minMaxThresholdValue, timeToMonitor);

                        break;


                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter from the menu choices provided.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);


        }

        /// <summary>
        /// set alarm
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="rangeType"></param>
        /// <param name="minMaxThresholdValue"></param>
        /// <param name="timeToMonitor"></param>
        static void TempAlarmSetAlarm(
            Finch finchRobot,

            string rangeType,
            double minMaxThresholdValue,
            double timeToMonitor)

        {
            double secondsElapsed = 0;
            bool thresholdExceeded = false;
            double currentTempSensorValue = 0;

            DisplayScreenHeader("Set Temperature Alarm");


            Console.WriteLine("\tRange Type:{0}", rangeType);
            Console.WriteLine("\tMin/Max threshold Value:" + minMaxThresholdValue);
            Console.WriteLine($"\tTime to monitor: {timeToMonitor}");
            Console.WriteLine();

            Console.WriteLine("\tPress any key to begin Monitoring");
            Console.ReadKey();
            Console.WriteLine();

            while ((secondsElapsed < timeToMonitor) && !thresholdExceeded)
            {
                
                currentTempSensorValue = finchRobot.getTemperature();
                

                switch (rangeType)
                {

                    case "minimum":
                        if (currentTempSensorValue < minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;

                    case "maximum":
                        if (currentTempSensorValue > minMaxThresholdValue)
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
                Console.WriteLine($"\tThe {rangeType} threshold value of {minMaxThresholdValue} was exceeded by the current Temp sensor value of {currentTempSensorValue}");
            }
            else
            {
                Console.WriteLine($"\tThe {rangeType} threshold value of {minMaxThresholdValue} was not exceeded.");

            }


            DisplayMenuPrompt("Temperature Alarm");
        }


        /// <summary>
        /// set time to monitor
        /// </summary>
        /// <returns> time To Monitor</returns>
        static int TempAlarmSetTimeToMonitor()
        {
            bool validResponse = false;
            string userResponse;
            int timeToMonitor;

            DisplayScreenHeader("Time to Monitor");
            
            do
            {
                Console.WriteLine("\tEnter length of time to monitor in seconds");
                userResponse = Console.ReadLine();


                validResponse = int.TryParse(userResponse, out timeToMonitor);

                if (!validResponse)
                {
                    Console.WriteLine("\t We need a time in seconds please [1,5,20]");

                }

            } while (!validResponse);


            Console.WriteLine();
            Console.WriteLine($"\t You entered: {timeToMonitor} seconds.");


            DisplayMenuPrompt("Temperature Alarm");

            return timeToMonitor;
        }

        /// <summary>
        ///  get min/max threshold value
        /// </summary>
        /// <param name="rangeType"></param>
        /// <param name="finchRobot"></param>
        /// <returns>min/max threshold value</returns>
        static double TempAlarmSetMinMaxThresholdValue(string rangeType, Finch finchRobot)
        {
            double minMaxThresholdValue;
            string userResponse;
            bool validResponse = false;

            DisplayScreenHeader("Minimum/Maximum Threshold Value");

            do
            {

                Console.WriteLine($"\tAmbient Temperature value: {finchRobot.getTemperature()}");
                Console.WriteLine();


                Console.WriteLine($"\tEnter the {rangeType} temp sensor value:");
                userResponse = Console.ReadLine();

                validResponse = double.TryParse(userResponse, out minMaxThresholdValue);

                if (!validResponse)
                {
                    Console.WriteLine("\tEnter the the threshold value in numbers[1, 36, 88]");
                }


            } while (!validResponse);

            Console.WriteLine();
            Console.WriteLine($"\tYou entered {minMaxThresholdValue}");

            DisplayMenuPrompt("Temperature Alarm");

            return minMaxThresholdValue;
        }


        

        /// <summary>
        /// set Range min/max
        /// </summary>
        /// <returns>range type</returns>
        static string TempAlarmDisplaySetRangeType()
        {
            string rangeType;
            bool validInput = false;

            DisplayScreenHeader("Range Type");
                        
            do
            {

                Console.Write("\tPlease enter range Type [minimum, maximum]:");
                rangeType = Console.ReadLine().ToLower();

                validInput = rangeType == "minimum" || rangeType == "maximum";

                if (!validInput)
                {
                    Console.WriteLine("\tInvalid response. Enter 'minimum' or 'maximum'.");
                }


            } while (!validInput);

            Console.WriteLine();
            Console.WriteLine($"\tYou entered: {rangeType}.");
            Console.WriteLine();

            DisplayMenuPrompt("Temperature Alarm");

            return rangeType;
        }




        #endregion



        #region User Programming

        //***********************************************
        //*          User Programming                    *
        //************************************************
        static void UserProgrammingDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = false;

            string menuChoice;
            bool quitMenu = false;

            (int motorSpeed, int ledBrightness, double waitSeconds) comandParameters;  //add note and combo
            comandParameters.motorSpeed = 0;
            comandParameters.ledBrightness = 0;
            comandParameters.waitSeconds = 0;

            List<Command> commands = new List<Command>(); 
            
            

            do
            {
                DisplayScreenHeader("User Programming Menu");

                Console.WriteLine("\ta) Set Command Parameters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Commands");
                Console.WriteLine("\td) Execute Commands");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();


                switch (menuChoice)
                {
                    case "a":
                        comandParameters = UserProgrammingDisplayGetCommandParameters();
                        break;
                    
                    case "b":
                        UserProgrammingDisplayGetFinchCommands(commands);
                        break;

                    case "c":
                        UserProgrammingDisplayFinchCommands(commands);
                        break;

                    case "d":
                        UserProgrammingDisplayExecuteFinchCommands(finchRobot, commands, comandParameters);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                                    
                    default:
                        Console.WriteLine();
                        Console.WriteLine("\t Please enter a letter from the menu options.");
                        DisplayContinuePrompt();
                        break;
                }



            } while (!quitMenu);


           DisplayScreenHeader("User Programming");
            

            DisplayContinuePrompt();
        }


        /// <summary>
        /// ********************************************************************************
        ///                       Execute Commands
        /// ********************************************************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="commands"></param>
        /// <param name="commandParameters"></param>
        private static void UserProgrammingDisplayExecuteFinchCommands(
            Finch finchRobot, 
            List<Command> commands, 
            (int motorSpeed, int ledBrightness, double waitSeconds) commandParameters)  //ADD NOTEON, NOTEOFF, COMBO

        {
            int motorSpeed = commandParameters.motorSpeed;
            int ledBrightness = commandParameters.ledBrightness;
            int waitMilliSeconds = (int)(commandParameters.waitSeconds * 1000);
            // int note = commandParameters.
            string commandFeedback = "";
            const int TURNING_MOTOR_SPEED = 100;

            DisplayScreenHeader("Execute Finch Commands");

            Console.WriteLine("\tThe Finch Robot will now execute your list of commands");
            DisplayContinuePrompt();

            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.NONE:
                        break;

                    case Command.MOVEFORWARD:
                        finchRobot.setMotors(motorSpeed, motorSpeed);
                        commandFeedback = Command.MOVEFORWARD.ToString();
                        break;

                    case Command.MOVEBACKWARD:
                        finchRobot.setMotors(-motorSpeed, -motorSpeed);
                        commandFeedback = Command.MOVEBACKWARD.ToString();
                        break;

                    case Command.STOPMOTORS:
                        finchRobot.setMotors(0, 0);
                        commandFeedback = Command.STOPMOTORS.ToString();
                        break;

                    case Command.WAIT:
                        finchRobot.wait(waitMilliSeconds);
                        commandFeedback = Command.WAIT.ToString();
                        break;

                    case Command.TURNRIGHT:
                        finchRobot.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                        commandFeedback = Command.TURNRIGHT.ToString();
                        break;

                    case Command.TURNLEFT:
                        finchRobot.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        commandFeedback = Command.TURNLEFT.ToString();
                        break;

                    case Command.LEDON:
                        finchRobot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        commandFeedback = Command.LEDON.ToString();
                        break;

                    case Command.LEDOFF:
                        finchRobot.setLED(0, 0, 0);
                        commandFeedback = Command.LEDOFF.ToString();
                        break;

                    case Command.GETTEMPERATURE:
                        commandFeedback = $"Temperature; {finchRobot.getTemperature().ToString("n2")}\n";
                        break;

                    //case Command.NOTEON:
                    //finchRobot.noteOn(100)+
                    //finchRobot.noteOn(200);
                    //commandFeedback = Command.NOTEON.ToString();

                    //case Command.NOTEOFF:
                    // finchRobot.noteOff(0);
                    //commandFeedback = Command.NOTEOFF.ToString();

                    //case Command.CRAZYCOMBO:
                    //finchRobot.noteOn(100), finchRobot.NOTEON, Command.setLED(ledBrightness, ledBrightness, ledBrightness), Command.setMotors(motorSpeed, motorSpeed);
                    //commandFeedback = Command.CRAZYCOMBO.ToString();

                    case Command.DONE:
                         commandFeedback = Command.DONE.ToString();
                        break;

                    

                    default:
                       
                        break;

                }
                     Console.WriteLine($"\t{commandFeedback}");
               
                                
            }
                    DisplayMenuPrompt("User Programming");

        }


        /// <summary>
        /// ***************************************************************
        ///                     Display Commands
        /// ***************************************************************
        /// </summary>
        /// <param name="commands"></param>
        static void UserProgrammingDisplayFinchCommands(List<Command> commands)
        {
            DisplayScreenHeader("Finch Robot Commands");

            foreach (Command command in commands)
            {
                Console.WriteLine($"\t{command}");
            }

            DisplayMenuPrompt("User Programming");
        }

        /// <summary>
        /// ********************************************************************
        ///                 Get Commands from User
        /// ********************************************************************
        /// </summary>
        /// <param name="commands"></param>
        private static void UserProgrammingDisplayGetFinchCommands(List<Command> commands)
        {
            Command command = Command.NONE;

            DisplayScreenHeader("Finch Robot Commands");

            //  OR type out commands

            int commandCount = 1;
            Console.WriteLine("\tList of Available Commands");
            Console.WriteLine();
            Console.Write("\t-");
            foreach (string commandName  in Enum.GetNames(typeof(Command)))
            {
                Console.Write($"- {commandName.ToLower()} -");
                if (commandCount % 5 == 0) Console.Write("-\n\t-");
                commandCount++;
            }
                //end of list of commands code block
                
            Console.WriteLine();

            while (command != Command.DONE)
            {
                Console.Write("\tEnter a Command:");

                if (Enum.TryParse(Console.ReadLine().ToUpper(), out command))
                {
                    commands.Add(command);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("\t\tYOU MUST ENTER A COMMAND FROM THE LIST ABOVE");
                }
            }
            
                Console.WriteLine();
                Console.WriteLine($"\tYou entered:");

            //ECHO BACK
            foreach (Command item in commands)
            {
                Console.WriteLine();
                Console.Write($"\t {item}, ");
            }

            DisplayMenuPrompt("User Programming");
        }  
         
             
        /// <summary>
        /// Get command parameters
        /// </summary>
        /// <returns> tuple of command parameters</returns>
        ///********************************************************************************
        ///                             Get Command Parameters From User
        //*************************************************************************************
        static (int motorSpeed, int ledBrightness, double waitSeconds) UserProgrammingDisplayGetCommandParameters()
        {

            DisplayScreenHeader("Command Parameters");

           
          
                 string userResponse;
                 bool validResponse = false;
           
                 (int motorSpeed, int ledBrightness, double waitSeconds ) commandParameters;
                    commandParameters.motorSpeed = 0;
                    commandParameters.ledBrightness = 0;
                    commandParameters.waitSeconds = 0;
                    //commandParameters.note = 0;
                    //commandParameters.combo = 0;
            do
            {   
                
                
                Console.Write("\tEnter Motor Speed [1-255]:");
                userResponse = Console.ReadLine();

                validResponse = int.TryParse(userResponse, out commandParameters.motorSpeed);

                if (!validResponse)
                {
                    Console.WriteLine("\t You MUST enter an number between 1-255 :");
                }
                //validate done
            
            } while (!validResponse);


            string userBrightness;
            bool validBrightness = false;


            do
            {

                Console.Write("\tEnter LED Brightness [1-255]:");
                userBrightness = Console.ReadLine();

                validBrightness = int.TryParse(userBrightness, out commandParameters.ledBrightness);

                if (!validBrightness)
                {
                    Console.WriteLine("\t You MUST enter an number between 1-255 :");
                }
                //validate done

            } while (!validBrightness);

            string userTime;
            bool validTime;
            
            do
            {
                Console.Write("\tPlease enter a Wait Time in seconds");
                userTime = Console.ReadLine();
                validTime = double.TryParse(userTime, out commandParameters.waitSeconds);

                if (!validTime)
                {
                    Console.WriteLine("\tYou MUST enter a time in seconds[1, 3, 4.5]");
                }

            } while (!validTime);
                //validate done

            // CHANGE TO NOTE AND COMBO

            //string userNote;
            //bool validNote;

            //do
            //{
            //    Console.WriteLine("\tPlease enter Note frequency [50-1000]");
            //    userTime = Console.ReadLine();
            //    validTime = int.TryParse(userTime, out commandParameters.note);

            //    if (!validNote)
            //    {
            //        Console.WriteLine("\tYou MUST enter a number between 50-1000.");
            //    }

            //} while (!validNote);

            //string userCombo;
            //bool validCombo;

            //do                dont think i need
            //{
            //    Console.WriteLine("\tPlease enter a Wait Time in seconds");
            //    userTime = Console.ReadLine();
            //    validTime = double.TryParse(userTime, out commandParameters.combo);

            //    if (!validTime)
            //    {
            //        Console.WriteLine("\tYou MUST enter a time in seconds[1, 3, 4.5]");
            //    }

            //} while (!validTime);

            Console.WriteLine();
            Console.WriteLine("\t\tYou Entered:");
            Console.WriteLine($"\tMotor speed: {commandParameters.motorSpeed}");
            Console.WriteLine($"\tLed brightness: {commandParameters.ledBrightness}");
            Console.WriteLine($"\tWait command duration: {commandParameters.waitSeconds}");
            //Console.WriteLine($"\tNote Fequency: {commandParameters.note}");

            DisplayMenuPrompt("User Programming");

            return commandParameters;
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

            Console.WriteLine("\tThe Finch robot is now disconnected.");
            Console.WriteLine("\t\tThanks for Playing with us today!");

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

            Console.WriteLine("\tAbout to connect to Finch robot.");
            Console.WriteLine("\t Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            Console.WriteLine("\tConnecting to the Finch now");
            finchRobot.noteOn(200);
            finchRobot.wait(600);
            finchRobot.noteOff();
            Console.WriteLine("\tLook at the pretty lights");
            finchRobot.setLED(255, 0, 0);
            finchRobot.wait(500);
            finchRobot.setLED(0, 255, 0);
            finchRobot.wait(500);
            finchRobot.setLED(0, 0, 255);
            finchRobot.setLED(0, 0, 0);
            Console.WriteLine("\t Finch Now Connected");


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
            Console.WriteLine("\tHello and welcome to the Super Finch Control App");
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
            Console.WriteLine("\t\tThank you for using the Super Finch Control App!");
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




