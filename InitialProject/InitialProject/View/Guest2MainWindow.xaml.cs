using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Metrics;
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
    /// Interaction logic for Guest2MainWindow.xaml
    /// </summary>
    public partial class Guest2MainWindow : Window
    {
        public static ObservableCollection<Tour> Tours { get; set; }
        public static ObservableCollection<Tour> ToursMainList { get; set; }
        public static ObservableCollection<Tour> ToursCopyList { get; set; }
        public static ObservableCollection<Location> Locations { get; set; }
        public Tour SelectedTour { get; set; }
        public User LoggedInUser { get; set; }
        private readonly TourRepository _tourRepository;
        public List<Tour> tours { get; set; }
        public Guest2MainWindow(User user)
        {
            InitializeComponent();
            DataContext= this;
            LoggedInUser= user;
            _tourRepository= new TourRepository();
            Tours = new ObservableCollection<Tour>(_tourRepository.GetByUser(user));
            ToursMainList = new ObservableCollection<Tour>();
            ToursCopyList = new ObservableCollection<Tour>();
            string[] lines = File.ReadAllLines("../../../Resources/Data/tours.csv");
            foreach (string line in lines)
            {
                Tour t = new Tour();
                string[] splitted = line.Split("|");
                t.FromCSV(splitted);
                ToursMainList.Add(t);
                ToursCopyList.Add(t);
            }
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            ToursMainList.Clear();
            foreach (Tour t in ToursCopyList)
            {
                ToursMainList.Add(t);
            }
            if (txtSearch.Text.Equals(""))
            {
                ToursMainList.Clear();
                foreach (Tour t in ToursCopyList)
                {
                    ToursMainList.Add(t);
                }
                return;
            }
            String[] splitted = txtSearch.Text.Split(",");
            foreach (String s in splitted)
            {
                s.Replace(" ", "");
            }
            List<int> indexesToDrop = new List<int>();
            if (splitted.Length==1)
            {
                foreach (Tour t in ToursCopyList)
                {
                    if (TourDuration.IsSelected)
                    {
                        if (t.Duration.ToString().CompareTo(splitted[0].ToLower()) != 0)
                        {
                            indexesToDrop.Add(ToursCopyList.IndexOf(t));
                        }
                    }
                    else if (TourLanguage.IsSelected)
                    {
                        if (!t.Language.ToLower().Contains(splitted[0].ToLower()))
                        {
                            {
                                indexesToDrop.Add(ToursCopyList.IndexOf(t));
                            }
                        }
                    }
                    else if (TourGuestNumber.IsSelected)
                    {
                        if (t.MaxGuestNum.ToString().CompareTo(splitted[0]) < 0)
                        {
                            indexesToDrop.Add(ToursCopyList.IndexOf(t));
                        }
                    }
                }
            }
            else if (splitted.Length==2)
            {
                foreach (Tour t in ToursCopyList)
                {
                    foreach (Location location in Locations)

                    {
                        if (t.Location.Id.Equals(location.Id))
                        {
                            if (!location.City.ToLower().Contains(splitted[0].ToLower()) && !location.Country.ToLower().Contains(splitted[1].ToLower()))
                            {
                                indexesToDrop.Add(ToursCopyList.IndexOf(t));
                            }
                        }
                    }
                }
            }
            for (int i = indexesToDrop.Count-1; i>=0; i--)
            {
                ToursMainList.RemoveAt(indexesToDrop[i]);
            }

        }

        private void Button_Click_Filters(object sender, RoutedEventArgs e)
        {
            AddFilters addFilters = new();
            addFilters.Show();
        }
    }
}
