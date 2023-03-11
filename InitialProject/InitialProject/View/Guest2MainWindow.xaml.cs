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
        public static ObservableCollection<Tour> CopyTours { get; set; }
        public static ObservableCollection<Location> Locations { get; set; }
        public Tour SelectedTour { get; set; }
        public User LoggedInUser { get; set; }
        private readonly TourRepository _tourRepository;
        public List<Tour> tours { get; set; }
        public Guest2MainWindow(User user)
        {
            InitializeComponent();
            tours = new List<Tour>();
            DataContext= this;
            LoggedInUser= user;
            _tourRepository= new TourRepository();
            Tours = new ObservableCollection<Tour>(_tourRepository.GetByUser(user));
            string[] lines = File.ReadAllLines("../../../Resources/Data/tours.csv");
            foreach(string line in lines)
            {
                Tour t = new Tour();
                string[] splitted = line.Split("|");
                t.FromCSV(splitted);
                tours.Add(t);
            }
        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            /*CopyTours = new ObservableCollection<Tour>(_tourRepository.GetAll());
            Tours.Clear();
            foreach (Tour tour in CopyTours)
            {
                Tours.Add(tour);
            }
            if (txtSearch.Text.Equals(""))
            {
                Tours.Clear();
                foreach (Tour s in CopyTours)
                {
                    Tours.Add(s);
                }
                return;
            }
            String[] splitted = txtSearch.Text.Split(",");
            foreach (String s in splitted)
            {
                s.Replace(" ", "");
            }
            List<int> indexesToDrop = new List<int>();
            if (splitted.Length == 1)
            {
                foreach (Tour s in CopyTours)
                {
                    if (s.MaxGuestNum.ToString().CompareTo(splitted[0])==-1)
                    {
                        indexesToDrop.Add(CopyTours.IndexOf(s));
                    }
                    else if (!s.Duration.Equals(splitted[0]))
                    {
                        indexesToDrop.Add(CopyTours.IndexOf(s));
                    }
                    else if(!s.Language.ToLower().Contains(splitted[0].ToLower()))
                    {
                        indexesToDrop.Add(CopyTours.IndexOf(s));
                    }
                }
                for (int i = indexesToDrop.Count - 1; i >= 0; i--)
                {
                    Tours.RemoveAt(indexesToDrop[i]);
                }
            }
            else
            {
                foreach (Tour s in CopyTours)
                {
                    foreach(Location location in Locations)

                    {
                        if(s.IdLocation.Equals(location.Id))
                        {
                            if(!location.City.ToLower().Contains(splitted[0].ToLower()) && !location.Country.ToLower().Contains(splitted[1].ToLower()))
                            {
                                indexesToDrop.Add(CopyTours.IndexOf(s));
                            }
                        }
                    }
                }
                for (int i = indexesToDrop.Count - 1; i >= 0; i--)
                {
                    Tours.RemoveAt(indexesToDrop[i]);
                }
            }*/
        }
    }
}
