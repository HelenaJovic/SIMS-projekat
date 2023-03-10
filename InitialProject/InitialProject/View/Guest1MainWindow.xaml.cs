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

        



        public Guest1MainWindow(User user)
        {
            InitializeComponent();
            //accommodations = new List<Accommodation>();
            DataContext = this;
            LoggedInUser = user;
            _accommodationRepository = new AccommodationRepository();
            AccommodationsMainList = new ObservableCollection<Accommodation>();
            AccommodationsCopyList = new ObservableCollection<Accommodation>();
            Accommodations = new ObservableCollection<Accommodation>(_accommodationRepository.GetByUser(user));
            string[] lines = File.ReadAllLines("../../../Resources/Data/accommodations.csv");
            foreach(string line in lines)
            {
                Accommodation a = new Accommodation();
                string[] splited=line.Split("|");
                a.FromCSV(splited);
                AccommodationsMainList.Add(a);
                AccommodationsCopyList.Add(a);
            }

        }

        private void Button_Click_Search(object sender, RoutedEventArgs e)
        {
            //AccommodationsCopyList=new ObservableCollection<Accommodation>(_accommodationRepository.GetAll());
            AccommodationsMainList.Clear();

            foreach(Accommodation a in AccommodationsCopyList)
            {
                AccommodationsMainList.Add(a);
            }

            if(TxtSearch.Text.Equals(""))
            {
                AccommodationsMainList.Clear();
                foreach (Accommodation a in AccommodationsCopyList)
                {
                    AccommodationsMainList.Add(a);
                }
                return;
            }

            String [] splitted=TxtSearch.Text.Split(" ");
            List<int> indexesToDrop= new List<int>();

            if(splitted.Length==1)
            {
                foreach(Accommodation a in AccommodationsCopyList)
                {
                    if (AccommodationName.IsSelected)
                    {
                        if (!a.Name.ToLower().Contains(splitted[0].ToLower()))
                        {
                            indexesToDrop.Add(AccommodationsCopyList.IndexOf(a));
                        }
                    }
                    else if (GuestNumber.IsSelected)
                    {
                        if(a.MaxGuestNum.ToString().CompareTo(splitted[0].ToLower()) < 0 && a.MaxGuestNum.ToString().Equals(splitted[0]))
                        {
                            indexesToDrop.Add(AccommodationsCopyList.IndexOf(a));
                        }
                    }
                    else if(ReservationNumDays.IsSelected)
                    {
                        if (a.MinReservationDays.ToString().CompareTo(splitted[0].ToLower()) > 0 && !a.MinReservationDays.ToString().Equals(splitted[0]))
                        {
                            indexesToDrop.Add(AccommodationsCopyList.IndexOf(a));
                        }
                    }
                    else if(AccommodationType.IsSelected)
                    {
                        if(!a.Type.ToString().ToLower().Contains(splitted[0].ToLower()))
                            {
                            indexesToDrop.Add(AccommodationsCopyList.IndexOf(a));
                        }
                    }

                }
                for(int i=indexesToDrop.Count-1; i>=0; i--)
                {
                    AccommodationsMainList.RemoveAt(indexesToDrop[i]);
                }
            }


        }

        private void ViewGallery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Reserve_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
