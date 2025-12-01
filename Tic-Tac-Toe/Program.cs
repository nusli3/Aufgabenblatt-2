namespace Tic_Tac_Toe;

class Program
{
    static void Main()
    {
        //Create a 3x3 playing_field, with empty spaces
        char[,] playing_field = new char[3, 3];
        Init(playing_field);

        char currentPlayer = 'O'; //Player with O starts
        
        while (true)
        {   
            //Clear screen so the playing playing_field is good visible
            Console.Clear();
            //Playing_field is shown to the player
            PrintBoard(playing_field);

            //Tell the player whose turn it is rn
            Console.WriteLine("Player " + currentPlayer + ", it's your turn.");
            
            //Ask the player where tey want to place theire "x" or "O"
            int row = AskNumber("In which row do you want to place your symbol?(1-3): ") - 1;
            int col = AskNumber("In which column do you want to playe your symbol (1-3): ") - 1;

            //Check if th chosen spot is valid aka within the  playing_field
            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                Console.WriteLine("Position does not exist. Press ENTER.");
                Console.ReadLine();
                continue;
            }

            //check if the spot is already in use by a "x" or "0"
            if (playing_field[row, col] != ' ')
            {
                //Prompt the user to press ENTER to restart when their input is not valid
                Console.WriteLine("Position already taken. Press ENTER to restart.");
                Console.ReadLine();
                continue;   //ask again for an input
            }

            //place the symbol
            playing_field[row, col] = currentPlayer;

            //chec if the player won the game that just played a character
            if (CheckWin(playing_field, currentPlayer))
            {
                Console.Clear();
                PrintBoard(playing_field);
                Console.WriteLine("Player " + currentPlayer + " wins!");
                break;
            }

            //check if the playing_field is fll -> if it is full there is a draw
            if (IsFull(playing_field))
            {
                Console.Clear();
                PrintBoard(playing_field);
                Console.WriteLine("It's a draw!");  //-> draw
                break;  //game ends
            }

            //Switch player
            //if it was "0" then "x" plays now
            //if it was "x" then "0" plays now
            if (currentPlayer == 'O')
                currentPlayer = 'X';
            else
                currentPlayer = 'O';
        }
    }

    //Fills the playing_field with spaces, so all fields are empty
    static void Init(char[,] playing_field)
    {
        //Put spaces in all 9 positions
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                playing_field[r, c] = ' ';
            }
        }
    }

    //Print playing_field on the screen so the user knows what the state of the game is
    static void PrintBoard(char[,] playing_field)
    {
        Console.WriteLine("  1 2 3");
        for (int r = 0; r < 3; r++)
        {
            //Print row
            Console.Write((r + 1) + " ");
            for (int c = 0; c < 3; c++)
            {
                //Print each column in that row
                Console.Write(playing_field[r, c]);
                if (c < 2) Console.Write("|");
            }
            Console.WriteLine();
            if (r < 2) Console.WriteLine("  -----");    //Print line between rows
        }
    }
    //Ask the user what number the want o
    static int AskNumber(string text)
    {
        Console.Write(text);
        int num;

        //Try to convert user text to a number
        //If it fails, num will be 0, which will be treated as an invalid number above.
        int.TryParse(Console.ReadLine(), out num); 
        return num;
    }

    //Checks if the playing_field has no empty spaces left
    //If there is still at least one it is not full
    static bool IsFull(char[,] playing_field)
    {
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                if (playing_field[r, c] == ' ')
                    return false;   //Found an empty spot
            }
        }
        return true;    //No empty space found
    }

    //Checks all possible win conditions fot the player
    //if the player has three in a row/column/diagonal they win
    static bool CheckWin(char[,] b, char p)
    {
        //Check all rows
        for (int r = 0; r < 3; r++)
        {
            if (b[r, 0] == p && b[r, 1] == p && b[r, 2] == p)
                return true;
        }

        //Check all colums
        for (int c = 0; c < 3; c++)
        {
            if (b[0, c] == p && b[1, c] == p && b[2, c] == p)
                return true;
        }

        //Check diagonal one
        if (b[0, 0] == p && b[1, 1] == p && b[2, 2] == p)
            return true;

        //Check diagonal 2
        if (b[0, 2] == p && b[1, 1] == p && b[2, 0] == p)
            return true;

        return false;   //no possible win
    }
}