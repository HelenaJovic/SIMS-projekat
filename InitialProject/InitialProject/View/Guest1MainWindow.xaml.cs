
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
    /// Interaction logic for Guest1MainWindow.xaml
    /// </summary>
    public partial class Guest1MainWindow : Window
    {
        public static ObservableCollection<Accommodation> Accommodations { get; set; }
        public static ObservableCollection<Accommodation> AccommodationsMainList { get; set; }
        public static ObservableCollection<Accommodation> AccommodationsCopyList { get; set; }

        public static ObservableCollection<Location> Locations { get; set; }
        public Accommodation SelectedAccommodation{ get; set; }
        public User LoggedInUser { get; set; }
        private readonly AccommodationRepository _accommodationRepository;
        private readonly LocationRepository _locationRepository;

        



        public Guest1MainWindow(User user)
        {
            InitializeComponent();
            //accommodations = new List<Accommodation>();
            DataContext = this;
            LoggedInUser = user;
            _accommodationRepository = new AccommodationRepository();
            _locationRepository = new LocationRepository();
            AccommodationsMainList = new ObservableCollection<Accommodation>();
            AccommodationsCopyList = new ObservableCollection<Accommodation>();
            Locations = new ObservableCollection<Location>(_locationRepository.GetAll());
            Accommodations = new ObservableCollection<Accommodation>(_accommodationRepository.GetByUser(user));
            string[] linesAccommodation = File.ReadAllLines("../../../Resources/Data/accommodations.csv");
            string[] linesLocation = File.ReadAllLines("../../../Resources/Data/locations.csv");
            foreach (string line in linesAccommodation)
            {   //Location location = new Location();
                Accommodation a = new Accommodation();
                /*foreach(string lineLocation in linesLocation)
                {
                   
                    string[] splited_loc = line.Split("|");
                    location.FromCSV(splited_loc);
                    Locations.Add(location);
                }*/
                /*if(a.IdLocation==location.Id)
                {
                    string[] splited = line.Split("|");
                    a.FromCSV(splited);

                    AccommodationsMainList.Add(a);
                    AccommodationsCopyList.Add(a);
                }*/
                string[] splited = line.Split("|");
                a.FromCSV(splited);

                AccommodationsMainList.Add(a);
                AccommodationsCopyList.Add(a);

                // l.FromCSV()


            }

        }


        

        

        private void Reserve_Click(object sender, RoutedEventArgs e)
        {
            CreateReservation createReservation = new CreateReservation();
            createReservation.Show();
        }

        private void Filter_Click(object sender, RoutedEventArgs e)
        {
            FilteringAccommodation filteringAccommodation1 = new FilteringAccommodation();
            filteringAccommodation1.Show();
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            AccommodationsMainList.Clear();
            foreach (Accommodation a in AccommodationsCopyList)
            {
                AccommodationsMainList.Add(a);
            }
        }
    }
}
