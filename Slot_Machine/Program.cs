namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int STARTING_AMOUNT = 3, WINNING_COMBINATION_AMOUNT = 4, COST_PER_ROUND = 1, MULTIPLE_ALL_ROWS = 3;

            // welcome statement
            Console.WriteLine("Welcome to the slot machine");
            Console.WriteLine($"You have a 3x3 grid. If you hit a winning combination you win {WINNING_COMBINATION_AMOUNT} $\n");
            Console.WriteLine($"To start playing you need to enter {STARTING_AMOUNT} $. Each round costs at least {COST_PER_ROUND} $\n");
            // money
            int currentMoney = 0, moneyUserInput = 0;


            const int FIRST_ARRAY_POSITION = 0, MIDDLE_ROW_POSITION = 1;
            // define 2D array for our slot machine
            const int ROWSNUMBER = 3, COLUMNSNUMBER = 3;
            int[,] slotMachineArray = new int[ROWSNUMBER, COLUMNSNUMBER];

            // declare arrays to track winning row, column or diagonal
            int[] trackWinningRow = new int[ROWSNUMBER];
            int[] trackWinningColumn = new int[COLUMNSNUMBER]; // it does not make a difference to use ROWSNUMBER or ROWSNUMBER
            int[] trackWinningDiagonalOne = new int[ROWSNUMBER];  // it does not make a difference to use ROWSNUMBER or ROWSNUMBER

            // bool to check equality of arrays trackWinning...
            bool middleRowIsEqual = true;
            bool rowIsEqual = true;
            bool colIsEqual = true;
            bool diagOneIsEqual = true;

            //Narrow window of max min is used
            // to increase the probability of winning row, column or diagonal.
            const int MAX_RANDOM_NUMBER = 3, MIN_RANDOM_NUMBER = 1;
            Random random = new Random();


            // variable decleration for user combination selection
            char userSelection;
            // variable decleration for checking user input validity
            bool validUserInput;
            while (true)
            {
                Console.Write("Please enter $ amount: ");
                validUserInput = int.TryParse(Console.ReadLine(), out moneyUserInput) && moneyUserInput >= 0;

                currentMoney += moneyUserInput;
                if (!validUserInput)
                {
                    Console.WriteLine("Please enter a valid positive whole number. Zero is a valid input");
                    continue;
                }
                if (currentMoney < STARTING_AMOUNT)
                {
                    Console.WriteLine($"Your current balance is {currentMoney} which is less than {STARTING_AMOUNT}. Please enter more $");
                    continue;
                }

                Console.WriteLine("You can aim for the following combinations:");
                Console.WriteLine($"a. The middle row (costs {COST_PER_ROUND} $)");
                Console.WriteLine($"b. All rows (costs {COST_PER_ROUND * MULTIPLE_ALL_ROWS} $)");
                Console.WriteLine($"c. All column (costs {COST_PER_ROUND * MULTIPLE_ALL_ROWS} $)");
                Console.WriteLine($"d. Diagonal up left to down right (costs {COST_PER_ROUND} $)");
                Console.WriteLine("q. Quit the game");
                Console.Write("Please enter a, b, c or d in small letter form: ");
                validUserInput = char.TryParse(Console.ReadLine(), out userSelection);
                if (!validUserInput || (userSelection != 'a' && userSelection != 'b' && userSelection != 'c' && userSelection != 'd' && userSelection != 'q'))
                {
                    Console.WriteLine("Please enter a, b, c or d in small letter form");
                    continue;
                }
                if (userSelection == 'q') break;

                // fill with random numbers
                for (int rows = 0; rows < ROWSNUMBER; rows++)
                {
                    for (int cols = 0; cols < COLUMNSNUMBER; cols++)
                    {
                        slotMachineArray[rows, cols] = random.Next(MIN_RANDOM_NUMBER, MAX_RANDOM_NUMBER);
                        Console.Write($"{slotMachineArray[rows, cols]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                switch (userSelection)
                {
                    case 'a':
                        currentMoney -= COST_PER_ROUND;
                        // check if middle row has equal numbers
                        middleRowIsEqual = true;
                        for (int col = 0; col < COLUMNSNUMBER; col++)
                        {
                            trackWinningRow[col] = slotMachineArray[MIDDLE_ROW_POSITION, col];
                            if (trackWinningRow[col] != trackWinningRow[FIRST_ARRAY_POSITION])
                            {
                                middleRowIsEqual = false;
                            }
                        }
                        if (middleRowIsEqual)
                        {
                            Console.WriteLine("You Won!!") ;
                            currentMoney += WINNING_COMBINATION_AMOUNT;
                        }
                        else
                        {
                            Console.WriteLine("You Lost") ;
                        }
                        break;

                    case 'b':
                        currentMoney -= COST_PER_ROUND * MULTIPLE_ALL_ROWS;
                        // check if any row has equal numbers
                        for (int row = 0; row < ROWSNUMBER; row++)
                        {
                            rowIsEqual = true;
                            for (int col = 0; col < COLUMNSNUMBER; col++)
                            {
                                trackWinningRow[col] = slotMachineArray[row, col];
                                if (trackWinningRow[col] != trackWinningRow[FIRST_ARRAY_POSITION])
                                {
                                    rowIsEqual = false;
                                }
                            }
                            if (rowIsEqual) break;
                        }
                            if (rowIsEqual)
                            {
                                Console.WriteLine("You Won!!");
                                currentMoney += WINNING_COMBINATION_AMOUNT;
                            }
                            else
                            {
                                Console.WriteLine("You Lost");
                            }
                        Console.WriteLine();
                        break;

                    case 'c':
                        currentMoney -= COST_PER_ROUND * MULTIPLE_ALL_ROWS;
                        // check if any column has equal numbers
                        for (int row = 0; row < ROWSNUMBER; row++)
                        {
                            colIsEqual = true;
                            for (int col = 0; col < COLUMNSNUMBER; col++)
                            {
                                trackWinningColumn[col] = slotMachineArray[col, row];
                                if (trackWinningColumn[col] != trackWinningColumn[FIRST_ARRAY_POSITION])
                                {
                                    colIsEqual = false;
                                }
                            }
                            if (!colIsEqual) break;
                        }
                            if (colIsEqual)
                            {
                                Console.WriteLine("You Won!!");
                                currentMoney += WINNING_COMBINATION_AMOUNT;
                            }
                            else
                            {
                                Console.WriteLine("You Lost");
                            }
                        Console.WriteLine();
                        break;

                    case 'd':
                        currentMoney -= COST_PER_ROUND;
                        // check if any diagonal hast equal number
                        for (int row = 0; row < ROWSNUMBER; row++)
                        {
                            diagOneIsEqual = true;
                            for (int col = 0; col < COLUMNSNUMBER; col++)
                            {
                                if (col == row)
                                {
                                    trackWinningDiagonalOne[col] = slotMachineArray[col, row];
                                    Console.Write($"{trackWinningDiagonalOne[col]} ");
                                }
                                if (trackWinningDiagonalOne[col] != trackWinningDiagonalOne[FIRST_ARRAY_POSITION])
                                {
                                    diagOneIsEqual = false;
                                }

                            }
                            if (diagOneIsEqual) break;
                        }
                            if (diagOneIsEqual)
                            {
                                Console.WriteLine("You Won!!");
                                currentMoney += WINNING_COMBINATION_AMOUNT;
                            }
                            else
                            {
                                Console.WriteLine("You Lost");
                            }
                        break;
                }
                Console.WriteLine($"Your current balance is {currentMoney} $\n");
                Thread.Sleep(5000);
                Console.Clear();
            }

        }
    }
}
