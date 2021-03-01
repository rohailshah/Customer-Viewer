// Last Modified By:    Rohail Shah
// Original Date:       March 1, 2021
// Last Modified Date:  March 1, 2021
// Project Name:        CustomerViewer
// Description:
//  Using the existing Customer class, this is a simple form designed to toggle
// through a list of customers, strictly to view their info.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerViewer
{
    public partial class formCustomerViewer : Form
    {
        // Declare a collection of all customers as a List.
        private List<Customer> customerList = new List<Customer>();
        // An index representing the current selected customer.
        private int currentIndex = 4;

        // Minimum and maximum indexes; should match the number of records set up below.
        private const int MinimumIndex = 0;
        private const int MaximumIndex = 5;

        public formCustomerViewer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the form loads, instantiate some customers and add them to a list so they can be viewed later.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLoad(object sender, EventArgs e)
        {
            // Declare and instantiate five new customer objects.
            // You are going to be asked to change some of these values.
            Customer kyle = new Customer("Mr.", "Kyle", "Chapman", true);
            Customer yourNameHere = new Customer("", "Rohail", "Shah", true);
            Customer someoneElse = new Customer("Sir", "Kamrin", "Aubin", true);
            Customer fourthPerson = new Customer("", "Mark Oliver", "Everett", true);
            Customer everyoneIsImportant = new Customer("Lady", "Scape", "Goat", false);
            Customer sixthCustomer = new Customer("Lucky", "Number", "Six", true);

            // Add all of the new customer objects from above to the list.
            customerList.Add(kyle);
            customerList.Add(yourNameHere);
            customerList.Add(someoneElse);
            customerList.Add(fourthPerson);
            customerList.Add(everyoneIsImportant);
            customerList.Add(sixthCustomer);

            // Call ViewCustomer and display the first customer object.
            ViewCustomer(currentIndex);
        }

        /// <summary>
        /// Shows the previous customer in the list, populating all fields with information related to the previous customer; 
        /// displays an error message if there are no prior customers in the list.
        /// </summary>
        private void PreviousButton(object sender, EventArgs e)
        {
            // Once user moves to previous index, enable both first and last buttons.
            buttonFirst.Enabled = true;
            buttonLast.Enabled = true;

            // Go to the previous customer in the list.
            currentIndex -= 1;

            // If we can view their info, that's great.
            // Check if we are at the start of the list.
            if (!ViewCustomer(currentIndex) || currentIndex <= MinimumIndex)
            {
                // Since we're at the start of the list, don't go back further
                // and disable the Previous button.
                currentIndex = MinimumIndex;
                buttonPrevious.Enabled = false;
                buttonFirst.Enabled = false;
            }

            // We know we're not at the end of the list, so allow the Next button.
            buttonNext.Enabled = true;
        }
        /// <summary>
        /// Shows the next customer in the list, populating all fields with information related to the next customer; 
        /// displays an error message if there are no next customers in the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton(object sender, EventArgs e)
        {
            // Once user moves to next index, enable both first and last buttons.
            buttonFirst.Enabled = true;
            buttonLast.Enabled = true;
            
            // Go to the next customer in the list.
            currentIndex += 1;

            // If we can view their info, that's great.
            // Check if we are at the start of the list.
            if (!ViewCustomer(currentIndex) || currentIndex >= MaximumIndex)
            {
                // Since we're at the end of the list, don't go forward further
                // and disable the Next button.
                currentIndex = MaximumIndex;
                buttonNext.Enabled = false;
                buttonLast.Enabled = false;
            }

            // We know we're not at the beginnning of the list, so allow the Previous button.
            buttonPrevious.Enabled = true;
        }

        private void FirstButton(object sender, EventArgs e)
        {
            // Once user moves to first index, enable last button.
            buttonLast.Enabled = true;

            // Go to the first customer in the list.
            currentIndex = MinimumIndex;

            // If we can view their info, that's great.
            ViewCustomer(currentIndex);

            // We know we're at the beginning of the list, so allow the Next button and disable the Previous button.
            buttonNext.Enabled = true;
            buttonPrevious.Enabled = false;
        }
        /// <summary>
        /// Shows the final customer in the list, populating all fields with information related to this customer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastButton(object sender, EventArgs e)
        {
            // Once user moves to last index, enable first button.
            buttonFirst.Enabled = true;

            // Go to the last customer in the list.
            currentIndex = MaximumIndex;

            // If we can view their info, that's great.
            ViewCustomer(currentIndex);

            // We know we're at the end of the list, so allow the Previous button and disable the Next button.
            buttonPrevious.Enabled = true;
            buttonNext.Enabled = false;
        }

        /// <summary>
        /// Me close form.
        /// </summary>
        private void ExitButton(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Attempt to display a customer from the customerList with a key value matching the argument passed in.
        /// </summary>
        /// <param name="listIndex">An integer value representing the index of the customer object</param>
        /// <returns>true if successful, false if not</returns>
        private bool ViewCustomer(int listIndex)
        {
            // If the current listIndex is in range...
            if (listIndex >= MinimumIndex && listIndex <= MaximumIndex)
            {
                // Populate the various fields with the relevant customer info.
                textBoxIdentificationNumber.Text = customerList[listIndex].Id.ToString();
                comboBoxTitle.Text = customerList[listIndex].Title;
                textBoxFirstName.Text = customerList[listIndex].FirstName;
                textBoxLastName.Text = customerList[listIndex].LastName;
                checkBoxVip.Checked = customerList[listIndex].VipStatus;

                // This was successful!
                return true;
            }
            else
            {
                // We went out of bounds; this was not successful.
                return false;
            }
        }
    }
}
