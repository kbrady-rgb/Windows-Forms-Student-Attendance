using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/***************************************************************
* Name        : Attendance - Final Project
* Author      : Kabrina Brady
* Created     : 11/26/2019
* Course      : CIS 169 - C#
* Version     : 1.0
* OS          : Windows 10
* Copyright   : This is my own original work
* Description : User clicks the new button, enters data in text boxes, then clicks the save button. They can view it in the DataGrid View.
*               Input:  Name, class, date, present, button clicks
*               Output: Saved data
* Academic Honesty: I attest that this is my original work.
* I have not used unauthorized source code, either modified or unmodified. I have not given other fellow student(s) access to my program.         
***************************************************************/

namespace Final_Project_Brady
{
    public partial class FinalProjectForm : Form
    {
        public bool invalidName = false; //global variable that test uses for ValidateName()
        public bool invalidID = false; //global variable that test uses for ValidateID()

        public FinalProjectForm()
        {
            InitializeComponent();
        }

        private void studentTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.studentTableBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.studentDataSet);
            }
            catch //Ensures exception isn't thrown if null value
            {
                MessageBox.Show("Pick a date.");
            }

            string id = studentIDTextBox.Text;
            ValidateID(id); //call to method to validate ID
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDataSet.StudentTable' table. You can move, or remove it, as needed.
            this.studentTableTableAdapter.Fill(this.studentDataSet.StudentTable);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); //closes the form
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            //Uses query that shows today's data
            this.studentTableTableAdapter.TodaysAttendance(this.studentDataSet.StudentTable);
        }

        //Validates name
        public void ValidateName(string name)
        {
            //Ensures name doesn't contain invalid characters
            if (name.Contains("!") || name.Contains("`") || name.Contains("~") || name.Contains("@") || name.Contains("#") || name.Contains("$") || name.Contains("%") || name.Contains("^") || name.Contains("&") || name.Contains("*") || name.Contains("(") || name.Contains(")") || name.Contains("_") || name.Contains("=") || name.Contains("+") || name.Contains("[") || name.Contains("]") || name.Contains("{") || name.Contains("}") || name.Contains(":")  || name.Contains("<") || name.Contains(">") || name.Contains("?") || name.Contains(",") || name.Contains(".") || name.Contains("/") || name.Contains("1") || name.Contains("2") || name.Contains("3") || name.Contains("4") || name.Contains("5") || name.Contains("6") || name.Contains("7") || name.Contains("8") || name.Contains("9") || name.Contains("0")
                )
            {
                invalidName = true; //necessary for test
                MessageBox.Show("Name contains invalid character(s).");
                throw new ArgumentException(); //throws exception
            }
        }
        
        //Validates ID
        public void ValidateID(string ID)
        {
            //Ensures ID is 9 digits long
            if (ID.Length != 9)
            {
                invalidID = true; //necessary for test
                MessageBox.Show("Student ID must contain 9 digits. Please edit the record and save again.");
                throw new ArgumentException();
            }

            //Ensures ID only contains integers
            try
            {
                int.Parse(ID);
            }
            catch
            {
                invalidID = true; //necessary for test
                MessageBox.Show("ID must only contain integers.");
            }
        }

        //While the user is typing, program checks to make sure name is valid
        private void firstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            ValidateName(firstName);
        }

        //While the user is typing, program checks to make sure name is valid
        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            string lastName = lastNameTextBox.Text;
            ValidateName(lastName);
        }
    }
}
