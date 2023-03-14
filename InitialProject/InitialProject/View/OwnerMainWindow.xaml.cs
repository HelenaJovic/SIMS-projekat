using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace InitialProject.View
{
	/// <summary>
	/// Interaction logic for OwnerMainWindow.xaml
	/// </summary>
	public partial class OwnerMainWindow : Window
	{
		public static ObservableCollection<Accommodation> Accommodations { get; set; }

		public static Accommodation SelectedAccommodation { get; set; }

		public static User LoggedInUser { get; set; }

		private readonly AccommodationRepository _accommodationRepository;

		public static ObservableCollection<AccommodationReservation> Reservations { get; set; }

		public static ObservableCollection<AccommodationReservation> AllReservations { get; set; }

		public static ObservableCollection<AccommodationReservation> FilteredReservations { get; set; }

		public static AccommodationReservation SelectedReservation { get; set; }

		private readonly AccommodationReservationRepository _reservationsRepository;

		private readonly UserRepository _userRepository;
		public OwnerMainWindow(User user)
		{
			InitializeComponent();
			DataContext = this;
			LoggedInUser = user;
			_accommodationRepository = new AccommodationRepository();
			_reservationsRepository = new AccommodationReservationRepository();
			_userRepository = new UserRepository();
			Accommodations = new ObservableCollection<Accommodation>(_accommodationRepository.GetByUser(LoggedInUser));
			AllReservations = new ObservableCollection<AccommodationReservation>(_reservationsRepository.GetAll());
			FilteredReservations = new ObservableCollection<AccommodationReservation>();

			foreach (AccommodationReservation res in AllReservations)
			{
				res.Guest = _userRepository.GetById(res.IdGuest);
				res.Accommodation = _accommodationRepository.GetById(res.IdAccommodation);
			}


			Reservations = new ObservableCollection<AccommodationReservation>((AllReservations.ToList().FindAll(c => c.Accommodation.IdUser == LoggedInUser.Id)));


			DateOnly today = DateOnly.FromDateTime(DateTime.Now);


			foreach (AccommodationReservation res in Reservations)
			{
				if (res.EndDate < today && today.DayNumber - res.EndDate.DayNumber <= 5)
				{
					FilteredReservations.Add(res);
				}
			}

			Loaded += Window_Loaded;

		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			if(FilteredReservations.Count > 0)
			{
				MessageBox.Show("Neki gosti nisu ocenjeni. Ukoliko zelite da ih ocenite otidjite na tab Guests for evaluation");
			}
		}
		private void AddAccommodation_Click(object sender, RoutedEventArgs e)
		{
			CreateAccommodation createAccommodation = new CreateAccommodation(LoggedInUser);
			createAccommodation.Show();

		}

		private void RateGuests_Click(object sender, RoutedEventArgs e)
		{
			if (SelectedReservation == null)
			{
				MessageBox.Show("Potrebno je izbrati gosta kog zelite da ocenite!");
			}
			else
			{
				RateGuests rateGuests = new RateGuests(LoggedInUser, SelectedReservation);
				rateGuests.Show();
			}
		}


	}
}
