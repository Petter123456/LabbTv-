using System;
using System.Linq;


namespace LabbTvå
{
    class Program
    {

        public enum Character { troll, dragon, worm, hobbit, cow}
        public static string[] enumToArray = Enum.GetNames(typeof(Character));
        public static string[] userResponses = new string[5];
        public static string[] namesTeam = new string[5];
        public static int[] ageTeam = new int[5];
        public static double[] levelTeam = new double[5];
        public static string userInput;
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome, we heard that you are a team of 5 playing the Game: Bombarde");
            Console.WriteLine("Please enter some data that we ask you for about your team members to find out some interesting facts");

            DataInput(namesTeam);
            DataInput(ageTeam);
            DataInput(levelTeam);
            DataInput(enumToArray);

            Console.WriteLine("Thank you for participating");
            Console.ReadKey(); 
        }

      
        public static void DataInput(Array arr)
        {
            int selectCalc = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                while (i < arr.Length)
                {
                    var arrayOfStrings = typeof(string);
                    var arrayOfInt = typeof(int);
                    var arrayOfDouble = typeof(double);
                    bool exceptionThrown = false;

                    if (arr.GetType() == arrayOfStrings.MakeArrayType())
                    {
                        if (arr.GetValue(0) == null || !arr.GetValue(0).Equals("troll"))
                        {
                            Console.WriteLine("Please enter the names of the 5 players in your team");
                            userInput = Console.ReadLine();
                            try
                            {
                                if (userInput.Equals(""))
                                {
                                    throw new Exception();
                                }
                            }
                            catch (Exception)
                            {
                                exceptionThrown = true;
                                Console.WriteLine("Input cannot be empty");
                            }
                            namesTeam[i] = userInput;
                            selectCalc = 1; 
                        }
                        else 
                        {
                            Console.WriteLine("Which character does your team members use");
                            userInput = Console.ReadLine();
                            try
                            {
                                Enum.Parse(typeof(Character), userInput);
                            }
                            catch (Exception)
                            {
                                exceptionThrown = true;
                                Console.WriteLine($"{userInput} is not a valid character in the game, please enter Troll, Hobit, Dragon, Cow or Worm");
                            }
                            userResponses[i] = userInput;
                            selectCalc = 2; 
                        }
                    }
                    else if (arr.GetType() == arrayOfInt.MakeArrayType())
                    {
                        Console.WriteLine("Please enter the age of the 5 players in your team");
                        userInput = Console.ReadLine();

                        try
                        {
                            int isNum = Int32.Parse(userInput);
                        }
                        catch (FormatException)
                        {
                            exceptionThrown = true;
                            Console.WriteLine($"Age cannot be {userInput} please enter a number");
                        }
                        if (!exceptionThrown)
                        {
                            ageTeam[i] = Int32.Parse(userInput);

                        }
                        selectCalc = 3;
                    }
                    else if (arr.GetType() == arrayOfDouble.MakeArrayType())
                    {
                        Console.WriteLine("Please enter the level of the 5 players in your team");
                        userInput = Console.ReadLine();

                        try
                        {
                            double isDouble = double.Parse(userInput);
                        }
                        catch (FormatException)
                        {
                            exceptionThrown = true;
                            Console.WriteLine($"Level cannot be {userInput} please enter a number with a maximum of one decimal (,)");
                        }
                        if (!exceptionThrown)
                        {
                            levelTeam[i] = double.Parse(userInput);
                        }
                        selectCalc = 4;
                    }
                    if (!exceptionThrown)
                    {
                        i++;
                    }
                }
            }
            if (selectCalc == 1)
            {
                calcNames(); 
            }
            else if (selectCalc == 2)
            {
                CalcEnum(); 
            }
            else if( selectCalc == 3)
            {
                calcAge(); 
            }
            else if(selectCalc == 4)
            {
                calcLevel(); 
            } 
        }

        public static void calcLevel()
        {
            double sum = 0;
            double average = 0;
            for (int i = 0; i < levelTeam.Length; i++)
            {
                sum += levelTeam[i];
                average = sum / levelTeam.Length;
            }

            Console.WriteLine($"The average level of your team is: {average}");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

        }


        public static void calcAge()
        {
            int sum = 0;

            for (int i = 0; i < ageTeam.Length; i++)
            {
                sum += ageTeam[i];
            }
            Console.WriteLine($"The total age of your team is: {sum}");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }


        public static void calcNames()
        {

            for (int j = 0; j < namesTeam.Length; j++)
            {
                int i, l;
                string str1 = "";
                string str = namesTeam[j];

                l = str.Length - 1;

                for (i = l; i >= 0; i--)
                {
                    str1 = str1 + str[i];
                }
                str = str1;
                Console.WriteLine($"Your teams names in reverse are: {str}");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static void CalcEnum()
        {
            int counter = 0;
            int longestOccurance = 0;
            string mostFrequent = "";

            for (int i = 0; i < userResponses.Length; i++)
            {
                counter = 0;
                for (int j = 0; j < userResponses.Length; j++)
                {
                    if (userResponses[j].Equals(userResponses[i]))
                    {
                        counter++;
                    }
                }
                if (counter > longestOccurance)
                {
                    longestOccurance = counter;
                    mostFrequent = userResponses[i];
                }
            }

            Console.WriteLine($"The character most used by your team is: {mostFrequent}");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
