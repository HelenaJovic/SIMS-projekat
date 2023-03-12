using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for TourFiltering.xaml
    /// </summary>
    public partial class TourFiltering : Window
    {
        public TourFiltering()
        {
            InitializeComponent();
            DataContext = this;

        }

        private void Button_Click_Filter(object sender, RoutedEventArgs e)
        {
            Guest2MainWindow.ToursMainList.Clear();


            int max = 0;
            if (!(int.TryParse(txtGuestNum.Text, out max) || (txtGuestNum.Text.Equals(""))))
            {
                return;
            }
            foreach (Tour t in Guest2MainWindow.ToursCopyList)
            {
                if (t.Language.ToLower().Contains(txtLanguage.Text.ToLower()) && t.Location.Country.ToLower().Contains(txtLocationCountry.Text.ToLower()) && t.Location.City.ToLower().Contains(txtLocationCity.Text.ToLower()) && t.Duration.ToString().ToLower().Contains(txtDuration.Text.ToLower()) &&
                    (t.MaxGuestNum - max >= 0 || txtGuestNum.Text.Equals("")))
                {
                    Guest2MainWindow.ToursMainList.Add(t);
                }

            }

            Close();

        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
