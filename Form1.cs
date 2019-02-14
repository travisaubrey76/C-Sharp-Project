using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary>
/// Author: Travis Aubrey
/// Redid: 814041534
/// 
/// Summary:
/// 
/// Changelog:
/// 
/// Ideas:
///     -Thinking about utilizing a 25 sized array for both integers and doubles.
///     
/// 
/// Credits:
///     -Needed help with converting a filtered array back into an int[] array, utilized this resource:
///         https://stackoverflow.com/questions/5430016/better-way-to-sort-array-in-descending-order
///     -Upon keypress on my combo box's, an annoying "ding" sound would appear. I found the fix here:
///         https://stackoverflow.com/questions/6290967/stop-the-ding-when-pressing-enter
///     -Checking to see if a windows form is already open and if so close it before creating a new form.
///         https://stackoverflow.com/questions/3861602/how-to-check-if-a-windows-form-is-already-open-and-close-it-if-it-is
/// </summary>
namespace SortOMatic
{
    public partial class Form_Menu : Form
    {
        //Global Variables {If I needed to process more datatypes, I could include more flags}
        int integerArrayPresent = 0; //flag to determine if an integer array is present
        int doubleArrayPresent = 0;  //flag to determine if a double array is present

        int[] globalIntArray; //These two arrays are global because we need to interact with them between methods. I could set to static with properties, but this was more simple
        double[] globalDoubleArray; //and it doesn't seem like the exercise requires it. If I have more time i'll go ahead and do this.

        public Form_Menu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clicking the Integer Generation Button will generate an array of X integers in a specific order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateIntegers_Click(object sender, EventArgs e)
        {
            //variables
            int[] intArray = new int[25]; //creates an array with a user inputted size
            Random randomNumber = new Random();
            string numbersToDisplay = ""; //Initializing the string to empty so we can manipulate it later.

            //Fill the array with random int values
            for (int index = 0; index < 25; index++)
            {
                intArray[index] = randomNumber.Next(101);

            }

            //This part of the code is crude, but basically create a new global array of the correct size everytime we need to and let the compiler take care of the array that is no longer being used.
            if (integerArrayPresent == 1)
            {
                globalIntArray = new int[25];
            }

            //Set flags
            doubleArrayPresent = 0;
            integerArrayPresent = 1;

            //work ordering conditions
            if(OrderingComboBox.Text == "Ascending")
            {
                //Filter the array
                var filteredArray =
                    from value in intArray
                    orderby value ascending
                    select value;

                //Revert the list back to our original array
                intArray = filteredArray.ToArray();

                //Organize the array into a presentable string
                for (int indexTwo = 0; indexTwo < 25; indexTwo++)
                {
                    if (indexTwo == 24) //if we have reached the last element in the array
                    {
                        numbersToDisplay += $"{intArray[indexTwo]}";
                    }
                    else //Otherwise keep including the comma and space
                    {
                        numbersToDisplay += $"{intArray[indexTwo]}, ";
                    }
                }

                //Display the text in a message box
                MessageBox.Show($"25 Integers ranging from 0-100 in {OrderingComboBox.Text} order are shown: \n{numbersToDisplay}");
            }
            else if (OrderingComboBox.Text == "Descending")
            {
                //Filter the array
                var filteredArray =
                    from value in intArray
                    orderby value descending
                    select value;

                //Revert the list back to our original array
                intArray = filteredArray.ToArray();

                //Organize the array into a presentable string
                for (int indexTwo = 0; indexTwo < 25; indexTwo++)
                {
                    if (indexTwo == 24) //if we have reached the last element in the array
                    {
                        numbersToDisplay += $"{intArray[indexTwo]}";
                    }
                    else //Otherwise keep including the comma and space
                    {
                        numbersToDisplay += $"{intArray[indexTwo]}, ";
                    }
                }

                //Display the text in a message box
                MessageBox.Show($"25 Integers ranging from 0-100 in {OrderingComboBox.Text} order are shown: \n{numbersToDisplay}");
            }
            else
            {
                //Organize the array into a presentable string
                for (int indexTwo = 0; indexTwo < 25; indexTwo++)
                {
                    if (indexTwo == 24) //if we have reached the last element in the array
                    {
                        numbersToDisplay += $"{intArray[indexTwo]}";
                    }
                    else //Otherwise keep including the comma and space
                    {
                        numbersToDisplay += $"{intArray[indexTwo]}, ";
                    }
                }

                //Display the text in a message box
                MessageBox.Show($"25 Integers ranging from 0-100 in {OrderingComboBox.Text} order are shown: \n{numbersToDisplay}");
            }
                
           

            //Assign the global array values
            globalIntArray = intArray;
        }

        /// <summary>
        /// Clicking the Doubles Generation Button will generate an array of X doubles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateDoubles_Click(object sender, EventArgs e)
        {
            //variables
            double[] doubleArray = new double[25]; //creates an array with a user inputted size
            Random randomNumber = new Random();
            string numbersToDisplay = ""; //initializing the array so we can manipulate it later.

            //Fill the array with random double values
            for (int index = 0; index < 25; index++)
            {
                doubleArray[index] = Math.Round((randomNumber.NextDouble() * 100), 2); //Generate random double value between 2 integers 0-100
            }

            //Check to see if a double array is already present in the global scope and if so, create a new instance to work with
            if (doubleArrayPresent == 1)
            {
                globalDoubleArray = new double[25];
            }

            //Set flags
            integerArrayPresent = 0;
            doubleArrayPresent = 1;

            //Work the ordering conditions
            if (OrderingComboBox.Text == "Ascending")
            {
                //Filter the array
                var filteredArray =
                    from value in doubleArray
                    orderby value ascending
                    select value;

                //Revert the list back to our original array
                doubleArray = filteredArray.ToArray();

                //Organize the array into a presentable string
                for (int indexTwo = 0; indexTwo < 25; indexTwo++)
                {
                    if (indexTwo == 24) //if we have reached the last element in the array
                    {
                        numbersToDisplay += $"{doubleArray[indexTwo]}";
                    }
                    else //Otherwise keep including the comma and space
                    {
                        numbersToDisplay += $"{doubleArray[indexTwo]}, ";
                    }
                }

                //Display the text in a message box
                MessageBox.Show($"25 Doubles ranging from 0-100 in {OrderingComboBox.Text} order are shown: \n{numbersToDisplay}");
            }
            else if (OrderingComboBox.Text == "Descending")
            {
                //Filter the array
                var filteredArray =
                    from value in doubleArray
                    orderby value descending
                    select value;

                //Revert the list back to our original array
                doubleArray = filteredArray.ToArray();

                //Organize the array into a presentable string
                for (int indexTwo = 0; indexTwo < 25; indexTwo++)
                {
                    if (indexTwo == 24) //if we have reached the last element in the array
                    {
                        numbersToDisplay += $"{doubleArray[indexTwo]}";
                    }
                    else //Otherwise keep including the comma and space
                    {
                        numbersToDisplay += $"{doubleArray[indexTwo]}, ";
                    }
                }

                //Display the text in a message box
                MessageBox.Show($"25 Doubles ranging from 0-100 in {OrderingComboBox.Text} order are shown: \n{numbersToDisplay}");
            }
            else
            {
                //Organize the array into a presentable string
                for (int indexTwo = 0; indexTwo < 25; indexTwo++)
                {
                    if (indexTwo == 24) //if we have reached the last element in the array
                    {
                        numbersToDisplay += $"{doubleArray[indexTwo]}";
                    }
                    else //Otherwise keep including the comma and space
                    {
                        numbersToDisplay += $"{doubleArray[indexTwo]}, ";
                    }
                }

                //Display the text in a message box
                MessageBox.Show($"25 Doubles ranging from 0-100 in {OrderingComboBox.Text} order are shown: \n{numbersToDisplay}");
            }

            //Assign the values randomly generated to the global double array
            globalDoubleArray = doubleArray;
        }

        /// <summary>
        /// Clicking the Sort button begins the user selected algorithm on the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeginSortingButton_Click(object sender, EventArgs e)
        {
            //check to see if we already have the form opened!
            if (Application.OpenForms["PopUpForm"] != null)
            {
                Application.OpenForms["PopUpForm"].Close();
            }
            PopUpForm sortForm = new PopUpForm(integerArrayPresent, globalIntArray, doubleArrayPresent, globalDoubleArray, AlgorithmSelectComboBox.Text);
            sortForm.Show();
            
        }

        /// <summary>
        /// Basic redirect function that checks if enter was pressed. Also, doesn't cause the annoying "ding" after doing so.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderingComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                GenerateIntegers_Click(this, new EventArgs());
                e.Handled = true;
            }
        }

        /// <summary>
        /// Basic redirect function that checks if enter was pressed. Also, like the previous method, doesn't cause the annoying "ding".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AlgorithmSelectComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                BeginSortingButton_Click(this, new EventArgs());
                e.Handled = true;
            }
        }
    }
}
