using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Utx.FoodOrder.Enums;
using Utx.FoodOrder.Models;

namespace Utx.FoodOrder
{
    /// <summary>
    /// Interaction logic for FoodMenu.xaml
    /// </summary>
    public partial class FoodMenu : UserControl
    {
        private List<FoodModel> MenuItems { get; } = new List<FoodModel>();
        public ObservableCollection<FoodModel> DisplayItems { get; } = new ObservableCollection<FoodModel>();
        public ListView ExposedList { get; private set; }

        public FoodMenu()
        {
            InitializeComponent();
            ExposedList = foodMenuView;
        }

        public void AddMenuItem(FoodModel item)
        {
            if (MenuItems.Contains(item)) return; // Most practically throw an exception
            MenuItems.Add(item);
        }

        public void ShowVendor(FoodProviders provider, IEnumerable<FoodModel> except = null)
        {
            DisplayItems.Clear();
            var resultList = MenuItems.Where(x => x.Provider.Equals(provider));
            if (except != null)
            {
                resultList = resultList.Except(except);
            }
            foreach (var item in resultList)
            {
                DisplayItems.Add(item);
            }
            DataContext = this;
        }        
    }
}
