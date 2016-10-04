//Morgan Boon
//CIS237
//Assignment 2
//Due 10/04/2016




using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;
        bool mazeSolved = false;

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        {}


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;

           //Calls mazeTraversal method and passes start variables
           mazeTraversal(xStart, yStart);
           Console.WriteLine("Congratulations you have solved the maze");
           mazeSolved = false;
            
        }


        /// <summary>
        /// mazeTraversal method is a recursive method.
        /// Each part checks if the location is open in the maze and then moves
        /// to the array location. It then calls the mothod again
        /// x's are placed along the correct path and o's
        /// are placed along the paths that have been traveled but are dead ends.
        /// </summary>
        private void mazeTraversal(int x, int y)
        {

            maze[x, y] = 'x';
            PrintMaze();
            //If x and y are in the array it continues running the recursive method
            if (x < 11 && y < 11 && x > 0 && y > 0)
            {
                //Checks to see if right is open if so it moves right and continues recursive call
                if (maze[x, y + 1] == '.' && mazeSolved == false)
                {
                    mazeTraversal(x, y + 1);
                }
                //Checks to see if down is open if so it moves right and continues recursive call
                if (maze[x + 1, y] == '.' && mazeSolved == false)
                {
                    mazeTraversal(x + 1, y);

                }
                //Checks to see if left is open if so it moves right and continues recursive call
                if (maze[x, y - 1] == '.' && mazeSolved == false)
                {
                    mazeTraversal(x, y - 1);

                }
                //Checks to see if up is open if so it moves right and continues recursive call
                if (maze[x - 1, y] == '.' && mazeSolved == false)
                {
                    mazeTraversal(x - 1, y);

                }

                //If there is no open moves it goes back and places o's along the dead end path
                if (mazeSolved == false)
                {
                    maze[x, y] = 'o';
                }

                
            }

            //If it has reached the edge of the array the mazeSolved varable is set to true 
            else
            {
                mazeSolved = true;
            }
            
        }

        //Prints maze
        public void PrintMaze()
        {
            //loops through each column location
            for (int column = 0; column < maze.GetLength(0); column++)
            {
                //loops through each row location
                for (int row = 0; row < maze.GetLength(1); row++)
                {
                    Console.Write(maze[column, row]);
                }

                //after every item in the row is printed it goes to the next row
                Console.WriteLine();
            }

            //Added for space between each array print
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
