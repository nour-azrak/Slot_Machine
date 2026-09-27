namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int FIRST_ARRAY_POSITION = 0;
            // define 2D array for our slot machine
            const int ROWSNUMBER = 3, COLUMNSNUMBER = 3;
            int[,] slotMachineArray = new int[ROWSNUMBER, COLUMNSNUMBER];

            // declare arrays to track winning row, column or diagonal
            int[] trackWinningRow = new int[ROWSNUMBER];
            int[] trackWinningColumn = new int[COLUMNSNUMBER]; // it does not make a difference to use ROWSNUMBER or ROWSNUMBER
            int[] trackWinningDiagonalOne = new int[ROWSNUMBER];  // it does not make a difference to use ROWSNUMBER or ROWSNUMBER

            // bool to check equality of arrays trackWinning...
            bool rowIsEqual = true;
            bool colIsEqual = true;
            bool diagOneIsEqual = true;

            // fill with random numbers. Narrow window of max min is used
            // to increase the probability of winning row, column or diagonal.
            const int MAX_RANDOM_NUMBER = 5, MIN_RANDOM_NUMBER = 1;
            Random random = new Random();

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


            // check if any row has equal numbers
            for(int row = 0; row < ROWSNUMBER; row++)
            {
                rowIsEqual = true;
                for (int col = 0; col < COLUMNSNUMBER; col++)
                {
                    trackWinningRow[col] = slotMachineArray[row, col];
                    if(trackWinningRow[col] != trackWinningRow[FIRST_ARRAY_POSITION])
                    {
                        rowIsEqual = false;
                    }
                Console.Write($"{trackWinningRow[col]} ");
                }
                Console.WriteLine();
                if (rowIsEqual) break;
            }
            Console.WriteLine();

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
                    Console.Write($"{trackWinningColumn[col]} ");
                }
                Console.WriteLine();
                if (colIsEqual) break;
            }
            Console.WriteLine();

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
            if (rowIsEqual || colIsEqual || diagOneIsEqual)
            {
                Console.WriteLine("You Won");
            }
            else
            {
                Console.WriteLine("You Lost");
            }
        }
    }
}
