/* Program.cs
 * Assignment 4
 *
 * Revision History
 * Pranay Sheth, 2015.03.06: Created
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplicationWumpus
{
    class Program
    {
        static void Main(string[] args)
        {
            string folder = @"";
            string file = @"WumpusGame.txt";

            string[] lineByLineFile = File.ReadAllLines(Path.Combine(folder, file));
            int numberOfRooms = Convert.ToInt32(lineByLineFile[0]);
            Room[] cave = new Room[numberOfRooms]; //array of objects of type class Room
            int intializationCounter = 0;
            string[] delimitors = { " " };
            char askToPlayAgain = ' ';
            string wumpusLocation = " ";
            string bottomlesspitLocation = " ";
            string bottomlesspitLocation2 = " ";
            string spiderLocation = " ";
            string spiderLocation2 = " ";
            string currentRoom = " ";
            bool flagCheckString = false;

            string[] splitRoomID = new string[20];

            for (int i = 1; i < lineByLineFile.Length; i++) //creates loop for the number of rooms entered in the first line of the text hence loops starts from 1 uptill the 2 times the length there are 10 numbers and 10 description
            {
                Room caves = new Room();
                string temporaryRoomAssignment = lineByLineFile[i];
                splitRoomID = temporaryRoomAssignment.Split(delimitors, StringSplitOptions.RemoveEmptyEntries);
                // Console.WriteLine(d[intializationCounter]);
                caves.RoomId = splitRoomID[0];
                caves.AdjacentRoom1 = splitRoomID[1];
                caves.AdjacentRoom2 = splitRoomID[2];
                caves.AdjacentRoom3 = splitRoomID[3];
                caves.RoomDescription = lineByLineFile[++i]; ; // pre increment before execution
                cave[intializationCounter] = caves;//assigning object to array of objects
                //Console.WriteLine(cave[intializationCounter].RoomId+cave[intializationCounter].AdjacentRoom1 +cave[intializationCounter].AdjacentRoom2+cave[intializationCounterr].AdjacentRoom3+"\n"+cave[intializationCounter].RoomDescription);
                intializationCounter++;
            }

            Console.WriteLine(" Ready to Play !");
            Random randomobj = new Random();
            do
            {
                wumpusLocation = Convert.ToString(randomobj.Next(2, numberOfRooms+1)); // location of wumpus 
                bottomlesspitLocation = Convert.ToString(randomobj.Next(2, numberOfRooms+1)); // location of pit
                bottomlesspitLocation2 = Convert.ToString(randomobj.Next(2, numberOfRooms+1)); // location of pit
                spiderLocation = Convert.ToString(randomobj.Next(2, numberOfRooms+1));// location of spider
                spiderLocation2 = Convert.ToString(randomobj.Next(2, numberOfRooms+1));// location of 2nd spider

                if (bottomlesspitLocation2 == spiderLocation2||spiderLocation == bottomlesspitLocation2 || wumpusLocation == bottomlesspitLocation || spiderLocation2 == wumpusLocation || wumpusLocation == spiderLocation || wumpusLocation == bottomlesspitLocation2 || spiderLocation == spiderLocation2 || spiderLocation2 == bottomlesspitLocation || spiderLocation == bottomlesspitLocation || bottomlesspitLocation2 == bottomlesspitLocation)
                {
                    flagCheckString = false;
                }
                else
                {
                    flagCheckString = true;
                   // Console.WriteLine(" Wumpus is in{0}", wumpusLocation);
                   // Console.WriteLine(" Pit 1 is in{0}", bottomlesspitLocation);
                   // Console.WriteLine(" Pit 2 is in{0}", bottomlesspitLocation2);
                   // Console.WriteLine(" Spider 1 is in{0}", spiderLocation);
                   // Console.WriteLine(" Spider 2 is in{0}", spiderLocation2);
                }
            }
            while (flagCheckString == false);



           

            int currentIndex = 0;
            bool gameOver = false;
            Console.WriteLine("Welcome to **Hunt The Wumpus!**");
            do                    //implementation of game 
            {
                Console.WriteLine("You are in room {0}", cave[currentIndex].RoomId);
                
                if(cave[currentIndex].numberOfArrows<0)
                { cave[currentIndex].numberOfArrows = 3;
                 }
                Console.WriteLine("You have {0} arrows left", cave[currentIndex].numberOfArrows);
                Console.WriteLine(cave[currentIndex].RoomDescription);
                Console.WriteLine("There are tunnels to rooms {0}, {1}, and {2}", cave[currentIndex].AdjacentRoom1, cave[currentIndex].AdjacentRoom2, cave[currentIndex].AdjacentRoom3);
           containerBlock:     {
               
                    Console.WriteLine("(M) Move or (S) Shoot");
                    char optionSelected = Convert.ToChar(Console.ReadLine());
                    optionSelected = Char.ToUpper(optionSelected);
              

                    switch (optionSelected)
                    {
                        default:
                            Console.WriteLine("Use M/m or S/s only");
                            break;
                        case 'M':
                            {
                                if (cave[currentIndex].numberOfArrows == 0)
                                {
                                    Console.WriteLine("Oops !You are out of arrows");
                                    Console.WriteLine(" --D E A D --\n");
                                    gameOver = true;
                                }
                                else
                                {
                                    Console.WriteLine(" Which room?");
                                    string choiceOfRoom = Console.ReadLine();

                                    // to check if entereed room is right
                                    if (choiceOfRoom == cave[currentIndex].AdjacentRoom1 || choiceOfRoom == cave[currentIndex].AdjacentRoom2 || choiceOfRoom == cave[currentIndex].AdjacentRoom3)
                                    {
                                        currentRoom = choiceOfRoom;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Dimwit! You cant get to there from here");
                                        Console.WriteLine("There are tunnels to rooms {0}, {1}, and {2}", cave[currentIndex].AdjacentRoom1, cave[currentIndex].AdjacentRoom2, cave[currentIndex].AdjacentRoom3);
                                        goto containerBlock;
                                    }

                                    if (choiceOfRoom == wumpusLocation || choiceOfRoom == spiderLocation || choiceOfRoom == spiderLocation2 || choiceOfRoom == bottomlesspitLocation || choiceOfRoom == bottomlesspitLocation2)
                                    {
                                        Console.WriteLine(" --D E A D --\n");
                                        Console.WriteLine("Try again!");
                                        gameOver = true;
                                    }
                                    else
                                    {
                                        // to check if entereed room matches the room ID
                                        while (currentRoom != cave[currentIndex].RoomId)
                                        {
                                            currentIndex = (++currentIndex) % numberOfRooms;
                                        };

                                        Console.WriteLine("You are in room {0}", cave[currentIndex].RoomId);
                                        Console.WriteLine("You have {0} arrows left", cave[currentIndex].numberOfArrows);
                                        Console.WriteLine(cave[currentIndex].RoomDescription);
                                        Console.WriteLine("There are tunnels to rooms {0}, {1}, and {2}", cave[currentIndex].AdjacentRoom1, cave[currentIndex].AdjacentRoom2, cave[currentIndex].AdjacentRoom3);
                                        if (currentRoom == bottomlesspitLocation || currentRoom == bottomlesspitLocation2)
                                        {
                                            Console.WriteLine("You smell a dank odor"); // there is a pit in one of the adjacent rooms
                                        }
                                        else if (currentRoom == wumpusLocation)
                                        {
                                            Console.WriteLine("You smell some nasty Wumpus!"); // Wumpus is adjacent rooms
                                        }
                                        else if (currentRoom == spiderLocation || currentRoom == spiderLocation2)
                                        {
                                            Console.WriteLine("You hear a faint clicking noise"); // spider in adjacent room
                                        }
                                        else
                                        {
                                            goto containerBlock;

                                        }

                                    }
                                }
                                break;

                            }
                        case 'S':
                            {
                                Console.WriteLine(" Which room?");
                                string choiceOfRoom = Console.ReadLine();
                                if (choiceOfRoom == wumpusLocation && cave[currentIndex].numberOfArrows>=1)
                                {
                                    Console.WriteLine("Your arrow goes down the tunnel and finds its mark");
                                    Console.WriteLine("You shot the Wumpus!** You Win!**");
                                    Console.WriteLine("Enjoy your fame!");
                                    gameOver = true;
                                }
                                else
                                {

                                    if (choiceOfRoom == cave[currentIndex].AdjacentRoom1 || choiceOfRoom == cave[currentIndex].AdjacentRoom2 || choiceOfRoom == cave[currentIndex].AdjacentRoom3 )
                                    {
                                       
                                        if (cave[currentIndex].numberOfArrows == 0)
                                        {
                                            Console.WriteLine("Oops !You are out of arrows");
                                            Console.WriteLine(" --D E A D --\n");
                                            gameOver = true; 
                                        }
                                         --cave[currentIndex].numberOfArrows;
                                    //    Console.WriteLine("You have {0} arrows left", cave[currentIndex].numberOfArrows);
                                     //   Console.WriteLine(cave[currentIndex].RoomDescription);
                                     //   Console.WriteLine("There are tunnels to rooms {0}, {1}, and {2}", cave[currentIndex].AdjacentRoom1, cave[currentIndex].AdjacentRoom2, cave[currentIndex].AdjacentRoom3);
                                        if (gameOver==false)
                                        {
                                            if (cave[currentIndex].AdjacentRoom1 == bottomlesspitLocation || cave[currentIndex].AdjacentRoom1 == bottomlesspitLocation2 || cave[currentIndex].AdjacentRoom2 == bottomlesspitLocation || cave[currentIndex].AdjacentRoom2 == bottomlesspitLocation2 || cave[currentIndex].AdjacentRoom3 == bottomlesspitLocation || cave[currentIndex].AdjacentRoom3 == bottomlesspitLocation2)
                                            {
                                                Console.WriteLine("You smell a dank odor"); // there is a pit in one of the adjacent rooms
                                            }
                                            else if (cave[currentIndex].AdjacentRoom1 == spiderLocation || cave[currentIndex].AdjacentRoom1 == spiderLocation2 || cave[currentIndex].AdjacentRoom2 == spiderLocation || cave[currentIndex].AdjacentRoom2 == spiderLocation2 || cave[currentIndex].AdjacentRoom3 == spiderLocation || cave[currentIndex].AdjacentRoom3 == spiderLocation2)
                                            {
                                                Console.WriteLine("You hear a faint clicking noise");// spider in adjacent room
                                            }
                                            else if (cave[currentIndex].AdjacentRoom1 == wumpusLocation || cave[currentIndex].AdjacentRoom2 == wumpusLocation || cave[currentIndex].AdjacentRoom3 == wumpusLocation)
                                            {
                                                Console.WriteLine("You smell some nasty Wumpus!"); // Wumpus is adjacent rooms
                                            }
                                        }

                                    }
                                    else
                                    {
                                       Console.WriteLine("Your arrow goes down the tunnel and is lost.You missed.");
                                       // Console.WriteLine("You are in room {0}", cave[currentIndex].RoomId);
                                       // Console.WriteLine("You have {0} arrows left", cave[currentIndex].numberOfArrows);
                                      ///  Console.WriteLine(cave[currentIndex].RoomDescription);
                                      //  Console.WriteLine("There are tunnels to rooms {0}, {1}, and {2}", cave[currentIndex].AdjacentRoom1, cave[currentIndex].AdjacentRoom2, cave[currentIndex].AdjacentRoom3);
                                        Console.WriteLine("Dimwit! You cant SHOOT there from here");
                                        goto containerBlock;
                                    }
                                }

                                break;
                            }
                    } // END OF SWITCH CASE
                }

                if (gameOver)
                {
                    Console.WriteLine("Play Again Y/N");
                    askToPlayAgain = Char.ToUpper(Convert.ToChar(Console.ReadLine()));

                    if (askToPlayAgain == 'Y')
                    {
                        gameOver = false;
                        currentIndex = 0;
                    }

                }
            }// END OF DO
            while (!gameOver);

            Console.ReadLine();
            
        }// end of main
        
    }// end of program
}// end of mainspace
