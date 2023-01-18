﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Appointment_Scheduler_Felix_Berinde.Database;


namespace Appointment_Scheduler_Felix_Berinde
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();

            //create temp customer list
            List<Customer> tempList = new List<Customer>();

            //assign the customer class database list to the temp customer list
            tempList = DBConnection.GetAllCustomers();

            //set the data source
            customersDGV.DataSource = tempList;

            //see a full row selection
            customersDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //make grid readonly
            customersDGV.ReadOnly = true;

            //make grid only able to select one row
            customersDGV.MultiSelect = false;

            //remove bottom column
            customersDGV.AllowUserToAddRows = false;

            //remove row header
            customersDGV.RowHeadersVisible = false;

            //remove vertical scrollbar
            customersDGV.ScrollBars = ScrollBars.Vertical;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCustomer customer = new AddCustomer();
            customer.ShowDialog();
        }

        private void modCustomerButton_Click(object sender, EventArgs e)
        {
            //check for no selection
            if (customersDGV.CurrentRow == null || !customersDGV.CurrentRow.Selected)
            {
                MessageBox.Show("Nothing Selected!", "Please make a selection.");
                return;
            }
            this.Hide();
            ModCustomer customer = new ModCustomer();
            customer.ShowDialog();
        }

        private void customersDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            customersDGV.ClearSelection();
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            //check for no selection
            if (customersDGV.CurrentRow == null || !customersDGV.CurrentRow.Selected)
            {
                MessageBox.Show("Nothing Selected!", "Please make a selection.");
                return;
            }
            //get the selected row
            Customer C = customersDGV.CurrentRow.DataBoundItem as Customer;

            //Confirm the delete with a MessageBox
            if (DialogResult.Yes == MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning))
            {
                //TODO: remove the selected customer from the list and database
                
            }
        }
    }
}
