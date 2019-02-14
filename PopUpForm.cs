using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

/// <summary>
/// Author: Travis Aubrey
/// Redid: 814041534
/// 
/// Summary:
/// 
/// Ideas:
///     -Took me a long time to figure out how to operate timers. Basically, they act as a loop. I have written them with global index variables and operate them just like i would loops.
///     
/// Complaints:
///     -Polymorphism is difficult with the Timers having to actively be my looping mechanisms.
/// 
/// Credits:
///     -Using Thread Sleep as a "timer" to control the speed that my loops iterate:
///     https://stackoverflow.com/questions/3486672/c-sharp-timer-slowing-down-a-loop
///     -Dynamic Window Naming:
///     https://stackoverflow.com/questions/22062219/dynamically-change-a-windows-form-window-title-during-runtime
/// </summary>
namespace SortOMatic
{
    /// <summary>
    /// Supplementary Class that handles the animation and sorting of the arrays.
    /// </summary>
    public partial class PopUpForm : Form
    {
        //Global Variables
        int integerArrayPresent;
        int doubleArrayPresent;
        int[] globalIntArray;
        double[] globalDoubleArray;

        //Window name intilization variable
        string sortingAlgorithm = "";

        //Index for first timer variable
        int startUpIterator = 0;

        //Index variables used for all other timers (loops)
        int loopIterator1 = 0;
        int loopIterator2 = 0;
        int loopIterator3 = 0;
        int loopIterator4 = 0;

        //Selection Sort Global Varibables
        int selectionSortSmallest;

        //Insertion Sort Global Variables
        int insert;
        int moveItem;
        double insertDouble;
        

        List<Label> labels = new List<Label>();

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PopUpForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Custom Constructor that enables interclass communication (with dynamic window title based on sorting algorithm selection in previous window)
        /// </summary>
        /// <param name="integerArrayPresent"></param>
        /// <param name="globalIntArray"></param>
        /// <param name="doubleArrayPresent"></param>
        /// <param name="globalDoubleArray"></param>
        public PopUpForm(int integerArrayPresent,int[] globalIntArray, int doubleArrayPresent, double[] globalDoubleArray, string windowName)
        {
            this.integerArrayPresent = integerArrayPresent;
            this.doubleArrayPresent = doubleArrayPresent;
            this.globalIntArray = globalIntArray;
            this.globalDoubleArray = globalDoubleArray;
            this.sortingAlgorithm = windowName;
            
            InitializeComponent();

            this.Text = $"Sorting Via {windowName} Algorithm...";
            this.Update();

            AssignNumbersToForm(); //<- Important that this is called here, so the user doesn't see the form populate after the form is shown.
        }

        /// <summary>
        /// Once the second window (PopUpForm) is shown, begin the chain of timers that will display the selected algorithm.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PopUpForm_Shown(object sender, EventArgs e)
        {
            FormOpenTimer.Start(); //Start the timer chain
        }

        /// <summary>
        /// Preliminary function that fills the form before the form is shown to the user
        /// </summary>
        private void AssignNumbersToForm()
        {
            //Grab all the labels on the form by using LINQ -75 total Labels
            labels = this.tableLayoutPanel1.Controls.OfType<Label>().Where(c => c.Name.StartsWith("label")).ToList();
            //Need to reverse the list because LINQ put them in reverse order which messed up several things.
            labels.Reverse();

            //MessageBox.Show($"There are {labels.Count} labels on this page.");

            //check global flags that were passed to this program
            if(integerArrayPresent == 1)
            {
                //populate the table with the int values
              for(int i = 25; i < 50; i++)
              {
                    labels[i].Text = globalIntArray[i-25].ToString();
              }
            }
            else if(doubleArrayPresent == 1)
            {
                for(int i = 25; i < 50; i++)
                {
                    labels[i].Text = globalDoubleArray[i-25].ToString();
                }
                
            }
        }

        /// <summary>
        /// Array display refreshing function. Essentially the same as the above method, which is the startup method except this one refreshes without assigning values to the labels.
        /// </summary>
        private void UpdateNumbers()
        {
            if (integerArrayPresent == 1)
            {
                //populate the table with the int values
                for (int i = 25; i < 50; i++)
                {
                    labels[i].Text = globalIntArray[i - 25].ToString();
                }
            }
            else if (doubleArrayPresent == 1)
            {
                for (int i = 25; i < 50; i++)
                {
                    labels[i].Text = globalDoubleArray[i - 25].ToString();
                }

            }
        }

        /// <summary>
        /// Initial Timer to wait a quarter second before displaying flashy "animation"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormOpenTimer_Tick(object sender, EventArgs e)
        {
            FormOpenTimer.Stop();
            StartUpTimer.Start();
        }

        /// <summary>
        /// Flashy method to display overall table on initial window popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartUpTimer_Tick(object sender, EventArgs e)
        {
            StartUpTimer.Stop();

            if(startUpIterator < 75)
            {
                labels[startUpIterator].BackColor = Color.Pink;
            } 
            if(startUpIterator > 37)
            {
                labels[startUpIterator - 38].BackColor = Color.White;
            }

            startUpIterator++;
            if(startUpIterator < 113)
            {
                StartUpTimer.Start();
            }
            else
            {
                SortSelector();
            }
        }

        /// <summary>
        /// Method that acts as a selection multiplexer and sends the correct information to those timers
        /// </summary>
        private void SortSelector()
        {
            if(sortingAlgorithm == "Insertion")
            {
                //MessageBox.Show($"{sortingAlgorithm} will now be shown"); //Testing point, remove when done.
                loopIterator1 = 1;
                loopIterator2 = 0;
                InsertionSort.Start();
            }
            else if(sortingAlgorithm == "Selection")
            {
                //MessageBox.Show($"{sortingAlgorithm} will now be shown"); //Testing point, remove when done.
                loopIterator1 = 0;
                loopIterator2 = loopIterator1 + 1;
                SelectionSort.Start();
            }
            else if(sortingAlgorithm == "Quick")
            {
                MessageBox.Show($"{sortingAlgorithm} will now be shown");
            }
            else if(sortingAlgorithm == "Merge")
            {
                MessageBox.Show($"{sortingAlgorithm} will now be shown");
            }
            else //5th was selected
            {
                MessageBox.Show($"{sortingAlgorithm} will now be shown");
            }
        }

        /// <summary>
        /// "Generic" (but not really) method that executes the selection sort algorithm and displays all steps to the user.
        /// Utilizes timers as for loops. Algorithm found in book: Chapter 18.3.
        /// 
        /// This Timer is the first "for loop" in the algorithm found above ^.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionSort_Tick(object sender, EventArgs e) //ticks every 100ms
        {
            SelectionSort.Stop(); //Stop the delay at this point
                
                if (loopIterator1 < 25) //Index value for first for loop
                {
                    selectionSortSmallest = loopIterator1; //initially assign the smallest number

                    labels[loopIterator1 + 25].BackColor = Color.AliceBlue; 
                    labels[loopIterator1 + 49].BackColor = Color.White;
                    loopIterator2 = loopIterator1++ + 1; //Knock out two statements with variable incrememnting power in one line
                    SelectionSortSecondIterator.Start(); //<- replace with second iterator
                }
            //If loopIterator is 25, then we have reached the exit condition for this "loop" and the timer will cease to operate.
        }

        /// <summary>
        /// This method is the second "for" loop in the Selection Sort Algorithm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionSortSecondIterator_Tick(object sender, EventArgs e)
        {
            SelectionSortSecondIterator.Stop();

            //Current value in focus we are comparing to will be shown in green and with an awesome windings upward arrow!
            labels[loopIterator1 + 24].BackColor = Color.Green;
            labels[loopIterator1 + 49].Text = "X";

            //Once we are done iterating through the second timer's loop, clear all the searched boxes and reset them back to white.
            if(loopIterator2 == 25)
            {
                for (int i = 0; i <= 24; i++)
                {
                    labels[i + 50].BackColor = Color.White;
                    labels[i + 50].Text = "";
                }

            }

            //For Loop index is within bounds, execute for loop code here. In this case, we are comparing values.
            if(loopIterator2 <= 24)
            {
                //"Generically" check which array we are working with
                if(doubleArrayPresent == 1) 
                {
                    if (globalDoubleArray[loopIterator2] < globalDoubleArray[selectionSortSmallest])
                    {
                        labels[selectionSortSmallest + 50].Text = ""; //remove the previous upward arrow since that one is no longer the lowest value
                        selectionSortSmallest = loopIterator2;
                        labels[selectionSortSmallest + 50].Text = "X";//make current focus the number we are going to switch as of now
                    }
                }
                else //Int array was passed
                {
                    if (globalIntArray[loopIterator2] < globalIntArray[selectionSortSmallest])
                    {
                        labels[selectionSortSmallest + 50].Text = ""; //remove the previous upward arrow since that one is no longer the lowest value
                        selectionSortSmallest = loopIterator2;
                        labels[selectionSortSmallest + 50].Text = "X";//make current focus the number we are going to switch as of now
                    }
                }

                //Increment this loops index
                loopIterator2++;

                //Change color to signal that we have checked this index against the current focused index
                labels[loopIterator2 + 49].BackColor = Color.OrangeRed;

                //Call this timer again, basically, since the index was valid in this for loop, we need to loop again until its not.
                SelectionSortSecondIterator.Start();
            }
            else //index is out of bounds, thus the loop breaks
            {
                labels[loopIterator1 + 24].BackColor = Color.AliceBlue; //Cement the value we already processed in the first loop
                labels[loopIterator1 + 49].Text = ""; //Remove the arrow as well

                //Check which array we are working with and swap the appropriate index values
                if(doubleArrayPresent == 1)
                {
                    SwapLabels(ref globalDoubleArray[loopIterator1 - 1], ref globalDoubleArray[selectionSortSmallest]);
                }
                else
                {
                    SwapLabels(ref globalIntArray[loopIterator1 - 1], ref globalIntArray[selectionSortSmallest]);
                }

                //call the display helper function so the user sees the update!
                UpdateNumbers();

                //Second for loop is complete, now continue the next loop in the first for loop!
                SelectionSort.Start();
            }
        }

        /// <summary>
        /// From the book, Chapter 18.3 page 755
        /// </summary>
        /// <param name="firstIndex"></param>
        /// <param name="secondIndex"></param>
        private void SwapLabels(ref int firstIndex, ref int secondIndex)
        {
            var temporary = firstIndex;
            firstIndex = secondIndex;
            secondIndex = temporary;
        }

        /// <summary>
        /// Copy of the above, except this is a second function that will be called when double arrays are passed in
        /// </summary>
        /// <param name="firstIndex"></param>
        /// <param name="secondIndex"></param>
        private void SwapLabels(ref double firstIndex, ref double secondIndex)
        {
            var temporary = firstIndex;
            firstIndex = secondIndex;
            secondIndex = temporary;
        }

        /// <summary>
        /// Initial For Loop for the Insertion Sort functionality.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertionSort_Tick(object sender, EventArgs e)
        {
            InsertionSort.Stop(); //Stop the delay at this point

            if (loopIterator1 < 25) //Index value for first for loop
            {
                if(integerArrayPresent == 1)
                {
                    insert = globalIntArray[loopIterator1]; //"Store value in current element"
                }
                else //double array is present
                {
                    insertDouble = globalDoubleArray[loopIterator1];
                }
                moveItem = loopIterator1; //initialize location to place element


                //Update display for this loop and alter needed colors
                UpdateNumbers();
                labels[loopIterator1 + 24].BackColor = Color.AliceBlue;
                labels[loopIterator1 + 25].BackColor = Color.Green; //Item we are checking is shown in green
                labels[loopIterator1 + 50].Text = "X";
                labels[loopIterator1 + 48].BackColor = Color.White;

                //Second while loop is dynamic in that it's counter resets everytime it's needed
                loopIterator2 = 0;

                InsertionSortSecondIterator.Start();
            }
            else //we have reached the exit condition for this "loop" and the timer will cease to operate.
            {
                labels[loopIterator1 + 25].BackColor = Color.AliceBlue; //Since we don't iterate to this one, manually change its color to standard
            }
            
        }

        /// <summary>
        /// Acts as the while loop in the algorithm as depicted by the book in chapter 18.3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InsertionSortSecondIterator_Tick(object sender, EventArgs e)
        {
            InsertionSortSecondIterator.Stop();
            if (integerArrayPresent == 1)
            {
                //This will be the while condition
                if (moveItem > 0 && globalIntArray[moveItem - 1] > insert)
                {
                    //Color the appropriate areas for this portion
                    labels[moveItem + 24].BackColor = Color.Green;
                    labels[moveItem + 49].BackColor = Color.OrangeRed;
                    labels[moveItem + 25].BackColor = Color.AliceBlue;

                    //switch array items.
                    globalIntArray[moveItem] = globalIntArray[moveItem - 1];

                    //Update the display
                    UpdateNumbers();

                    //Increment/Decrement counters
                    moveItem--;
                    loopIterator2++;

                    //Continue the while loop
                    InsertionSortSecondIterator.Start();
                }
                else //While loop is complete
                {
                    //Once the while loop completes, refresh the colors
                    for (int i = 0; i <= loopIterator1; i++)
                    {
                        labels[i + 25].BackColor = Color.AliceBlue;
                        labels[i + 50].BackColor = Color.White;
                        labels[i + 50].Text = "";
                    }

                    //assign the value
                    globalIntArray[moveItem] = insert;

                    //Final display update
                    UpdateNumbers();

                    //increment the intial for loop
                    loopIterator1++;

                    //Return to original for loop
                    InsertionSort.Start();
                }
            }
            else //Double array is present so small changes take affect
            {
                //This will be the while condition
                if (moveItem > 0 && globalDoubleArray[moveItem - 1] > insertDouble)
                {
                    //Color the appropriate areas for this portion
                    labels[moveItem + 24].BackColor = Color.Green;
                    labels[moveItem + 49].BackColor = Color.OrangeRed;
                    labels[moveItem + 25].BackColor = Color.AliceBlue;

                    //switch array items.
                    globalDoubleArray[moveItem] = globalDoubleArray[moveItem - 1];

                    //Update the display
                    UpdateNumbers();

                    //Increment/Decrement counters
                    moveItem--;
                    loopIterator2++;

                    //Continue the while loop
                    InsertionSortSecondIterator.Start();
                }
                else //While loop is complete
                {
                    //Once the while loop completes, refresh the colors
                    for (int i = 0; i <= loopIterator1; i++)
                    {
                        labels[i + 25].BackColor = Color.AliceBlue;
                        labels[i + 50].BackColor = Color.White;
                        labels[i + 50].Text = "";
                    }

                    //assign the value
                    globalDoubleArray[moveItem] = insertDouble;

                    //Final display update
                    UpdateNumbers();

                    //increment the intial for loop
                    loopIterator1++;

                    //Return to original for loop
                    InsertionSort.Start();
                }
            }
        }
    }
}
