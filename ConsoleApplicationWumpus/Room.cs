/* Room.cs
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

namespace ConsoleApplicationWumpus
{
    class Room
    {
        string idRoom;
        string adjacentRoom1;
        string adjacentRoom2;
        string adjacentRoom3;
        string roomDescription;
        char optionMS;
      public  int numberOfArrows = 3;


        public string RoomId
        {
            set { idRoom = value; }
            get { return idRoom; }
        }
        public string RoomDescription
        {
            set { roomDescription = value; }
            get { return roomDescription; }
        }
       
        public string AdjacentRoom1
        {
            set { adjacentRoom1 = value; }
            get { return adjacentRoom1; }
        }
        public string AdjacentRoom2
        {
            set { adjacentRoom2 = value; }
            get { return adjacentRoom2; }
        }
        public string AdjacentRoom3
        {
            set { adjacentRoom3 = value; }
            get { return adjacentRoom3; }
        }
        public char OptionForChoice
        {
            set { optionMS = value; }
            get { return optionMS; }
        }
        }



    }

