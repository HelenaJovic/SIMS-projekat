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
    /// Interaction logic for GuestNumber.xaml
    /// </summary>
    public partial class GuestNumber : Window
    {
        public Accommodation SelectedAccommodation;
        public AccommodationReservation accommodationReservation;


        private readonly AccommodationReservationRepository _accommodationReservationRepository;
        private readonly AccommodationRepository _accommodationRepository;
        public User LoggedInUser { get; set; }
        public GuestNumber(Accommodation selectedAccommodation, User user)
        {
            InitializeComponent();

            InitializeComponent();
            DataContext = this;
            SelectedAccommodation = selectedAccommodation;
            LoggedInUser = user;
            _accommodationReservationRepository = new AccommodationReservationRepository(LoggedInUser);
            accommodationReservation = new AccommodationReservation();
            _accommodationRepository = new AccommodationRepository();
        }

        private void CancelCreate_Click(object sender, RoutedEventArgs e)
        {
            Close(); 
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string _startDate { get; set; }
        public string _endDate { get; set; }

        private string _minDaysReservation { get; set; }

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

        public string DaysNum
        {
            get => _minDaysReservation;
            set
            {
                if (value != _minDaysReservation)
                {
                    _minDaysReservation = value;
                    OnPropertyChanged();
                }
            }
        }
        private MessageBoxResult ConfirmReservation()
        {

            string sMessageBoxText = $"Da li ste sigurni da zelite da rezervisete ovaj smestaj?";
            string sCaption = "Porvrda rezervacije!";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        private void Reserve_Click(object sender, RoutedEventArgs e)
        {
            int maxGuest = 0;
            MessageBoxResult result = ConfirmReservation();

          

            if (!(int.TryParse(TxtNumGuest.Text, out maxGuest) || (TxtNumGuest.Text.Equals(""))))
            {
                return;
            }
            if ((maxGuest - SelectedAccommodation.MaxGuestNum) <= 0)
            {
                if (result == MessageBoxResult.Yes)
                {
                    CreateReservation create = new CreateReservation(SelectedAccommodation, LoggedInUser);
                    string _accommodationName = _accommodationRepository.GetNameByAccId(SelectedAccommodation.Id);
                    AccommodationReservation newReservation = new(LoggedInUser.Id, DateOnly.Parse(StartDate), DateOnly.Parse(EndDate), int.Parse(DaysNum), SelectedAccommodation.Id, _accommodationName);
                    AccommodationReservation savedReservation = _accommodationReservationRepository.Save(newReservation);
                    Guest1MainWindow.AccommodationsReservationList.Add(savedReservation);
                    Close();
                }
                else
                {
                    MessageBox.Show("Mozda da izaberete neki drugi smestaj?");
                }
            }
            else
            {
                MessageBox.Show("Prekrsili ste maksimalan  broj gostiju.");
            }
        }
    }
}
