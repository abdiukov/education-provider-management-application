﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for LocationInformation.xaml
    /// </summary>
    public partial class LocationInformation : Window
    {
        public LocationInformation()
        {
            InitializeComponent();
        }

        //logic
        private void SearchTextbox_MouseClick(object sender, MouseButtonEventArgs e)
        {
            if (SearchTextbox.Text == "Enter the location you wish to search")
            {
                SearchTextbox.Text = "";
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //logic to update the datagrid for a specific teacher
            SearchDataGrid(SearchTextbox.Text);

            //below is placeholder code for testing
            //StudentProfile pageobj = new StudentProfile();
            //pageobj.Show();
            //Close();
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            //logic to go to teacher's page
            //StudentProfile pageobj = new StudentProfile();
            //pageobj.Show();
            //Close();
        }


        private void SearchDataGrid(string searchInput)
        {
            if (SearchTextbox.Text == "EEnter the location you wish to search")
            {
                MessageBox.Show("Please enter something into the search bar");
            }
            else
            {
                MessageBox.Show(searchInput);
            }
        }

        //back button
        private void goBack_navigation_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pageobj = new MainWindow();
            pageobj.Show();
            Close();
        }

    }
}