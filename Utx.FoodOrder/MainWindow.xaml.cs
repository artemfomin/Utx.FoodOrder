using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Utx.FoodOrder.Models;
using McDonaldsProvider = Utx.FoodOrder.Clients.McDonalds;
using KfcProvider = Utx.FoodOrder.Clients.Kfc;
using PizzaHutProvider = Utx.FoodOrder.Clients.PizzaHut;
using BurgerKingProvider = Utx.FoodOrder.Clients.BurgerKing;
using Utx.FoodOrder.Enums;
using System.Collections.ObjectModel;

namespace Utx.FoodOrder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _employeeName = string.Empty;
        private FoodProviders _selectedProvider;

        // All 4 should be better injected, I prefer Autofac. Out of time for it
        private McDonaldsProvider.Provider McDonalds { get; set; }
        private KfcProvider.Provider Kfc { get; set; }
        private PizzaHutProvider.Provider PizzaHut { get; set; }
        private BurgerKingProvider.Provider BurgerKing { get; set; }


        public ObservableCollection<FoodModel> OrderedItems { get; } = new ObservableCollection<FoodModel>();


        public MainWindow()
        {
            InitializeComponent();

            foodMenuTable.ExposedList.MouseDoubleClick += menuItem_OnMouseDoubleClick;

            McDonalds = new McDonaldsProvider.Provider();
            Kfc = new KfcProvider.Provider();
            PizzaHut = new PizzaHutProvider.Provider();
            BurgerKing = new BurgerKingProvider.Provider();

            // Better FoodMenu should have another "AddRange" method
            foreach(var product in GetProducts())
            {                
                foodMenuTable.AddMenuItem(product);
            }
        }

        private IList<FoodModel> GetProducts()
        {
            List<FoodModel> products = new List<FoodModel>();

            products.AddRange(GetMcDonaldsProducts());
            products.AddRange(GetKfcProducts());
            products.AddRange(GetPizzaHutProducts());
            products.AddRange(GetBurgerKingProducts());

            return products;
        }

        private IList<FoodModel> GetMcDonaldsProducts()
        {
            List<FoodModel> products = new List<FoodModel>();
            products = McDonalds.GetAvailableProducts()
                .Select(x => new FoodModel { Name = x.Name, Price = x.Price, Provider = Enums.FoodProviders.McDonalds })
                .ToList();
            return products;
        }

        private IList<FoodModel> GetKfcProducts()
        {
            List<FoodModel> products = new List<FoodModel>();
            products = Kfc.GetAvailableProducts()
                .Select(x => new FoodModel { Name = x.Name, Price = x.Price, Provider = Enums.FoodProviders.Kfc })
                .ToList();
            return products;
        }

        private IList<FoodModel> GetPizzaHutProducts()
        {
            List<FoodModel> products = new List<FoodModel>();
            products = PizzaHut.GetAvailableProducts()
                .Select(x => new FoodModel { Name = x.Name, Price = x.Price, Provider = Enums.FoodProviders.PizzaHut })
                .ToList();
            return products;
        }

        private IList<FoodModel> GetBurgerKingProducts()
        {
            List<FoodModel> products = new List<FoodModel>();
            products = BurgerKing.GetAvailableProducts()
                .Select(x => new FoodModel { Name = x.Name, Price = x.Price, Provider = Enums.FoodProviders.BurgerKing })
                .ToList();
            return products;
        }

        private void employeeName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(employeeName.Text))
            {
                providerLabel.IsEnabled = false;
                providerSelect.IsEnabled = false;
            }
            else
            {
                providerLabel.IsEnabled = true;
                providerSelect.IsEnabled = true;
            }
        }

        private void providerSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString();

            switch (item)
            {
                case "McDonalds":
                    _selectedProvider = FoodProviders.McDonalds;                    
                    break;
                case "KFC":
                    _selectedProvider = FoodProviders.Kfc;
                    break;
                case "Pizza Hut":
                    _selectedProvider = FoodProviders.PizzaHut;
                    break;
                case "Burger King":
                    _selectedProvider = FoodProviders.BurgerKing;
                    break;
            }
            foodMenuTable.ShowVendor(_selectedProvider, OrderedItems);
        }

        private void menuItem_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = (sender as ListView).SelectedValue as FoodModel;
            if (selectedItem != null && !OrderedItems.Any(x => x.Equals(selectedItem)))
            {
                OrderedItems.Add(selectedItem);
                foodMenuTable.ShowVendor(_selectedProvider, OrderedItems);
                total.Content = OrderedItems.Select(x => x.Price).Sum();
                DataContext = this;
            }            
        }
    }
}
