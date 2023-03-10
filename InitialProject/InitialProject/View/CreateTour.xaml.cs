using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for CreateTour.xaml
    /// </summary>
    public partial class CreateTour : Window
    {
        public User LoggedInUser { get; set; }
        private readonly TourRepository _tourRepository;
        private readonly LocationRepository _locationRepository;

        private string _name;
        private string _city;
        private string _country;
        private string _description;
        private string _language;
        private string _maxGuestNum;
        private string _startPoint;
        private string _additionalPoints;
        private string _endPoint;
        private string _startDate;
        private string _endDate;
        private string _duration;
        private string _imageUrl;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string TourName
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string City
        {
            get => _city;
            set
            {
                if (value != _city)
                {
                    _city = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Country
        {
            get => _country;
            set
            {
                if (value != _country)
                {
                    _country = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }
        public string TourLanguage
        {
            get => _language;
            set
            {
                if (value != _language)
                {
                    _language = value;
                    OnPropertyChanged();
                }
            }
        }
        public string MaxGuestNum
        {
            get => _maxGuestNum;
            set
            {
                if (value != _maxGuestNum)
                {
                    _maxGuestNum = value;
                    OnPropertyChanged();
                }
            }
        }
        public string StartPoint
        {
            get => _startPoint;
            set
            {
                if (value != _startPoint)
                {
                    _startPoint = value;
                    OnPropertyChanged();
                }
            }
        }
        public string AdditionalPoint
        {
            get => _additionalPoints;
            set
            {
                if (value != _additionalPoints)
                {
                    _additionalPoints = value;
                    OnPropertyChanged();
                }
            }
        }
        public string EndPoint
        {
            get => _endPoint;
            set
            {
                if (value != _endPoint)
                {
                    _endPoint = value;
                    OnPropertyChanged();
                }
            }
        }
        public string StartDate
        {
            get => _startDate;
            set
            {
                if (value != _startDate)
                {
                    _startDate = value;
                    OnPropertyChanged();
                }
            }
        }
        public string EndDate
        {
            get => _endDate;
            set
            {
                if (value != _endDate)
                {
                    _endDate = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Duration
        {
            get => _duration;
            set
            {
                if (value != _duration)
                {
                    _duration = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                if (value != _imageUrl)
                {
                    _imageUrl = value;
                    OnPropertyChanged();
                }
            }
        }

        public CreateTour(User user)
        {
            InitializeComponent();
            DataContext= this;
            LoggedInUser= user;
            _tourRepository= new TourRepository();
            _locationRepository= new LocationRepository();
        }

        private void ConfirmCreate_Click(object sender, RoutedEventArgs e)
        {
            Location newLocation = new Location(City, Country);
            Location savedLocation = _locationRepository.Save(newLocation);
            Tour newTour = new Tour(TourName, savedLocation.Id, TourLanguage, int.Parse(MaxGuestNum), DateTime.Parse(StartDate), DateTime.Parse(EndDate), int.Parse(Duration), int.Parse(MaxGuestNum), false, LoggedInUser.Id) ;
            Tour savedTour = _tourRepository.Save(newTour);
            GuideMainWindow.Tours.Add(savedTour);
            Close();
        }

        private void CancelCreate_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
