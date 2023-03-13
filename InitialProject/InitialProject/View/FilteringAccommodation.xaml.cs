using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for FilteringAccommodation.xaml
    /// </summary>
    public partial class FilteringAccommodation : Window
    {
       
        public Accommodation SelectedAccommodation { get; set; }
        public User LoggedInUser { get; set; }
       // private readonly AccommodationRepository _accommodationRepository;
       // private readonly LocationRepository _locationRepository;



        public FilteringAccommodation()
        {
            InitializeComponent();
            //accommodations = new List<Accommodation>();
            DataContext = this;

           

            }
        

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            Guest1MainWindow.AccommodationsMainList.Clear();
            /* foreach (Accommodation a in Guest1MainWindow.AccommodationsCopyList)
             {
                 Guest1MainWindow.AccommodationsMainList.Add(a);
             }*/

            /* String Name = txtName.Text
             String[] splittedLocation= txtLocation.Text.Split(",");
             String[] splittedType = txtType.Text.Split(",");
             String[] splittedGuestNum = txtGuestNum.Text.Split(",");
             String[] splittedReservationNum = txtReservationNum.Text.Split(",");*/

            /*List<int> indexesToDrop = new List<int>();
            List<Accommodation> filteredAccommodations = new List<Accommodation>();*/


            int max=0;
            int min=0;
            if (!(int.TryParse(txtGuestNum.Text, out max) || (txtGuestNum.Text.Equals(""))) || !(int.TryParse(txtReservationNum.Text, out min) || (txtReservationNum.Text.Equals(""))))
            {
                return;
            }
            foreach (Accommodation a in Guest1MainWindow.AccommodationsCopyList)
            {
                if (a.Name.ToLower().Contains(txtName.Text.ToLower()) && a.Location.Country.ToLower().Contains(txtLocationCountry.Text.ToLower()) && a.Location.City.ToLower().Contains(txtLocationCity.Text.ToLower()) && a.Type.ToString().ToLower().Contains(txtType.Text.ToLower()) && 
                    (a.MaxGuestNum - max >= 0 || txtGuestNum.Text.Equals("")) && (a.MinReservationDays -min <=0 || txtReservationNum.Text.Equals("")))
                {
                    Guest1MainWindow.AccommodationsMainList.Add(a);
                }

            }


        }
    }
}
