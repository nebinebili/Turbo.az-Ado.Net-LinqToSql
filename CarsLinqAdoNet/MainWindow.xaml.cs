using CarsLinqAdoNet.DataAccesss.Abstract;
using CarsLinqAdoNet.DataAccesss.Context;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarsLinqAdoNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClasses1DataContext dtx;
        public MainWindow()
        {
            InitializeComponent();
            dtx = new DataClasses1DataContext();
            ReadData();
        }
        void ReadData()
        {
            cmb_brand.ItemsSource = from b in dtx.Makes select b.Name;
            cmb_typeban.ItemsSource = from tb in dtx.BanTypes select tb.Name;
            cmb_color.ItemsSource = from c in dtx.Colors select c.Name;
            cmb_typefuel.ItemsSource = from f in dtx.FuelTypes select f.Name;
            cmb_country.ItemsSource = from c in dtx.Regions select c.Name;
            cmb_gears.ItemsSource = from g in dtx.Gears select g.Name;
            cmb_transmission.ItemsSource = from t in dtx.Transmissions select t.Name;
            cmb_maxvolume.ItemsSource = from e in dtx.EngineVolumes select e.Volume;
            cmb_minvolume.ItemsSource = from e in dtx.EngineVolumes select e.Volume;
            cmb_minvolume.SelectedIndex = 0;
        }

        private void cmb_brand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_brand.SelectedItem != null)
            {
                var result = from b in dtx.Makes
                             where b.Name == cmb_brand.SelectedItem.ToString()
                             select b.Id;

                cmb_model.ItemsSource = from m in dtx.Models
                                        where m.MakeId == result.First()
                                        select m.Name;
            }
            
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            
            IQueryable<Car> carsResult = dtx.Cars;
            if (cmb_color.SelectedItem != null)
            {
                carsResult = dtx.Cars.Where(c => c.Color.Name.Equals(cmb_color.SelectedItem));
            }
            if (cmb_brand.SelectedItem != null)
            {
                carsResult = carsResult.Where(c => c.Make.Name.Equals(cmb_brand.SelectedItem));
            }
            if (cmb_typeban.SelectedItem != null)
            {
                carsResult = carsResult.Where(c => c.BanType.Name.Equals(cmb_typeban.SelectedItem));
            }
            if (cmb_country.SelectedItem != null)
            {
                carsResult = carsResult.Where(c => c.Region.Name.Equals(cmb_country.SelectedItem));
            }
            if (cmb_model.SelectedItem != null)
            {
                carsResult = carsResult.Where(c => c.Model.Name.Equals(cmb_model.SelectedItem));
            }
            if (cmb_gears.SelectedItem != null)
            {
                carsResult = carsResult.Where(c => c.Gear.Name.Equals(cmb_gears.SelectedItem));
            }
            if (cmb_typefuel.SelectedItem != null)
            {
                carsResult = carsResult.Where(c => c.FuelType.Name.Equals(cmb_typefuel.SelectedItem));
            }
            if (cmb_transmission.SelectedItem != null)
            {
                carsResult = carsResult.Where(c => c.Transmission.Name.Equals(cmb_transmission.SelectedItem));
            }
            if (cmb_maxvolume.SelectedItem != null)
            {
                carsResult = carsResult.Where(c => c.EngineVolume.Volume <= int.Parse(cmb_maxvolume.SelectedItem.ToString()));
            }
            if (cmb_minvolume.SelectedItem != null)
            {
                carsResult = carsResult.Where(c => c.EngineVolume.Volume >= int.Parse(cmb_minvolume.SelectedItem.ToString()));
            }
            if (!string.IsNullOrEmpty(txb_maxPrice.Text))
            {
                carsResult = carsResult.Where(c => c.Price <= decimal.Parse(txb_maxPrice.Text));
            }
            if (!string.IsNullOrEmpty(txb_minPrice.Text))
            {
                carsResult = carsResult.Where(c => c.Price >= decimal.Parse(txb_minPrice.Text));
            }
            if (!string.IsNullOrEmpty(txb_maxMileage.Text))
            {
                carsResult = carsResult.Where(c => c.Mileage <= int.Parse(txb_maxMileage.Text));
            }
            if (!string.IsNullOrEmpty(txb_minMileage.Text))
            {
                carsResult = carsResult.Where(c => c.Mileage >= int.Parse(txb_minMileage.Text));
            }
            if (!string.IsNullOrEmpty(txb_maxYear.Text))
            {
                carsResult = carsResult.Where(c => c.RegYear <= int.Parse(txb_maxYear.Text));
            }
            if (!string.IsNullOrEmpty(txb_minYear.Text))
            {
                carsResult = carsResult.Where(c => c.RegYear >= int.Parse(txb_minYear.Text));
            }



            IQueryable cars = from car in carsResult
                       select new
                       {
                           City = car.Region.Name,
                           Make = car.Make.Name,
                           Model = car.Model.Name,
                           Price = car.Price,
                           RegistrationYear = car.RegYear,
                           BanType = car.BanType.Name,
                           Mileage = car.Mileage,
                           Color = car.Color.Name,
                           EngineVolume = car.EngineVolume.Volume,
                           FuelType = car.FuelType.Name,
                           Gear = car.Gear.Name,
                           Transmission = car.Transmission.Name
                       };
            SearchResult searchResult = new SearchResult(cars);
            searchResult.ShowDialog();

        }

        private void btn_Refresh_Click(object sender, RoutedEventArgs e)
        {
            cmb_color.SelectedItem = null;
            cmb_brand.SelectedItem = null;
            cmb_model.SelectedItem = null;
            cmb_country.SelectedItem = null;
            cmb_gears.SelectedItem = null;
            cmb_maxvolume.SelectedItem = null;
            cmb_minvolume.SelectedIndex = 0;
            cmb_transmission.SelectedItem = null;
            cmb_typeban.SelectedItem = null;
            cmb_typefuel.SelectedItem = null;
        }
    }
}
