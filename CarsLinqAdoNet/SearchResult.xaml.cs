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
using System.Windows.Shapes;

namespace CarsLinqAdoNet
{
    /// <summary>
    /// Interaction logic for SearchResult.xaml
    /// </summary>
    public partial class SearchResult : Window
    {
        public SearchResult(IQueryable cars)
        {
            InitializeComponent();
            datagrid.ItemsSource = cars;
        }
    }
}
