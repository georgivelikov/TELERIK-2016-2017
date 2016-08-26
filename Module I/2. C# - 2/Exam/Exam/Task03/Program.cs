using System;
using System.Collections.Generic;

namespace Reusable3p1
{
    class Program
    {
        public static int[] cube = new int[4];
        public static List<char> basilisksHit = new List<char>();
        public static List<Basilisk> unitsList;
        public static Basilisk harryPotter;
        public static int HarryMoves = 0;
        public static bool HarryBusted = false;
        public static string FinalText;
        static void Main()
        {

            string[] cubeSize = Console.ReadLine().Split(' ');
            cube[0] = int.Parse(cubeSize[0]); cube[1] = int.Parse(cubeSize[1]); cube[2] = int.Parse(cubeSize[2]); cube[3] = int.Parse(cubeSize[3]);

            harryPotter = new Basilisk();
            string[] potterPos = Console.ReadLine().Split(' ');
            harryPotter.Name = '@';
            harryPotter.Cords[0] = int.Parse(potterPos[0]); harryPotter.Cords[1] = int.Parse(potterPos[1]); harryPotter.Cords[2] = int.Parse(potterPos[2]); harryPotter.Cords[3] = int.Parse(potterPos[3]);

            unitsList = new List<Basilisk>();

            int numActualBasilisks = int.Parse(Console.ReadLine());
            for (int i = 0; i < numActualBasilisks; i++)
            {
                unitsList.Add(new Basilisk(Console.ReadLine()));
            }

            //Moves being gathered//
            List<AMove> theMoves = new List<AMove>();
            string currentLine = Console.ReadLine();
            while (currentLine != "END")
            {
                theMoves.Add(new AMove(currentLine));
                currentLine = Console.ReadLine();
            }

            //Moves Being Performed//
            int harryMoves = 0;
            int basiliskMoves = 0;

            for (int i = 0; i < theMoves.Count; i++)
            {
                if (theMoves[i].Name == '@') //Harry Moves//
                {
                    if (MoveHarry(theMoves[i]) < 0)
                    {
                        Console.WriteLine("Harry Has gone into basilisk" + basilisksHit[0] + " during his " + harryMoves + " turn.");
                        break;
                    }
                    harryMoves++;
                }
                else //A basilisk moves//
                {
                    if (MoveBasilisk(theMoves[i], FindBasiliskByName(theMoves[i].Name)) < 0)
                    {
                        Console.WriteLine("A basilisc has ran into Harry durring its' " + basiliskMoves);
                        break;
                    }
                    basiliskMoves++;
                }
            }

        }
        public static int MoveHarry(AMove theMove)
        {
            if (theMove.Weight > 0)
            {
                while (theMove.Weight > 0 && harryPotter.Cords[theMove.Dimension] < cube[theMove.Dimension] - 1)
                {
                    harryPotter.Cords[theMove.Dimension]++;
                    if (HarryCheck()) return -1;
                    theMove.Weight--;
                }
            }
            else
            {
                while (theMove.Weight < 0 && harryPotter.Cords[theMove.Dimension] > 0)
                {
                    harryPotter.Cords[theMove.Dimension]--;
                    if (HarryCheck()) return -1;
                    theMove.Weight++;
                }
            }

            return 0;
        }
        public static bool HarryCheck()
        {
            bool doesHit = false;
            for (int i = 0; i < unitsList.Count; i++)
            {
                if (harryPotter == unitsList[i])
                {
                    doesHit = true;
                    basilisksHit.Add(unitsList[i].Name);
                }
            }
            return doesHit;
        }

        public static int MoveBasilisk(AMove theMove, int basiliskIndex)
        {
            if (theMove.Weight > 0)
            {
                while (theMove.Weight > 0 && unitsList[basiliskIndex].Cords[theMove.Dimension] < cube[theMove.Dimension] - 1)
                {
                    unitsList[basiliskIndex].Cords[theMove.Dimension]++;
                    if (BasiliskCheck(basiliskIndex)) return -1;
                    theMove.Weight--;
                }
            }
            else
            {
                while (theMove.Weight < 0 && unitsList[basiliskIndex].Cords[theMove.Dimension] > 0)
                {
                    unitsList[basiliskIndex].Cords[theMove.Dimension]--;
                    if (BasiliskCheck(basiliskIndex)) return -1;
                    theMove.Weight++;
                }
            }
            return 0;
        }

        public static bool BasiliskCheck(int basiliskIndex)
        {
            if (unitsList[basiliskIndex] == harryPotter)
            {
                basilisksHit.Add(unitsList[basiliskIndex].Name);
                return true;
            }
            return false;
        }

        public static int GetDimension(char theDim)
        {
            switch (theDim)
            {
                case 'A': return 0;
                case 'B': return 1;
                case 'C': return 2;
                default: return 3;
            }
        }

        public static int FindBasiliskByName(char theName)
        {
            for (int i = 0; i < unitsList.Count; i++)
            {
                if (unitsList[i].Name == theName) return i;
            }
            return -1;
        }
    }

    public class Basilisk
    {
        public int[] Cords = new int[4];

        public char Name { get; set; }

        public Basilisk()
        {

        }

        public Basilisk(string setData)
        {
            Name = setData[0];
            string[] seperated = setData.Split(' ');
            Cords[0] = int.Parse(seperated[1]);
            Cords[1] = int.Parse(seperated[2]);
            Cords[2] = int.Parse(seperated[3]);
            Cords[3] = int.Parse(seperated[4]);
        }


        public static bool operator ==(Basilisk unit1, Basilisk unit2)
        {
            if (unit1.Cords[0] == unit2.Cords[0] && unit1.Cords[1] == unit2.Cords[1] && unit1.Cords[2] == unit2.Cords[2] && unit1.Cords[3] == unit2.Cords[3]) return true;
            return false;
        }
        public static bool operator !=(Basilisk unit1, Basilisk unit2)
        {
            if (unit1.Cords[0] != unit2.Cords[0] || unit1.Cords[1] != unit2.Cords[1] || unit1.Cords[2] != unit2.Cords[2] || unit1.Cords[3] != unit2.Cords[3]) return true;
            return false;
        }

    }


    public class AMove
    {
        public char Name { get; set; }
        public int Dimension { get; set; }
        public int Weight { get; set; }

        public AMove(string setString)
        {
            string[] decompose = setString.Split(' ');
            this.Name = setString[0];
            this.Dimension = Program.GetDimension(setString[2]);
            this.Weight = int.Parse(decompose[2]);
        }
    }


}
