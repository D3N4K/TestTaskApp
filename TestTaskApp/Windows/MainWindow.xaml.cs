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
using TestTaskApp.Classes;

namespace TestTaskApp
{
    public partial class MainWindow : Window
    {
        Warehouse warehouse;
        DataFromDB dataFromDB = new DataFromDB();
        List<Pallet> palletView = new List<Pallet>();
        public MainWindow()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            warehouse = dataFromDB.LoadData();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private void btnShowByDate_Click(object sender, RoutedEventArgs e)
        {
            lbInformation.Items.Clear();
            var groupedPallets = warehouse.GroupPalletsByExpiration();
            lbInformation.Items.Add("Группировка паллет по сроку годности:");
            foreach (var group in groupedPallets)
            {
                lbInformation.Items.Add($"\nСрок годности: {group.Key?.ToShortDateString() ?? "Нет данных"}");
                foreach (var pallet in group.OrderBy(p => p.Weight))
                {
                    lbInformation.Items.Add($"  Паллета ID: {pallet.Id}, Вес: {pallet.Weight}, Объем: {pallet.Volume}");
                }
            }
        }
        private void btnShowTop3_Click(object sender, RoutedEventArgs e)
        {
            lbInformation.Items.Clear();
            var topPallets = warehouse.GetTopPalletsWithLongestExpiration(3);
            lbInformation.Items.Add("\nТоп 3 паллеты с наибольшим сроком годности:");
            foreach (var pallet in topPallets)
            {
                lbInformation.Items.Add($"Паллета ID: {pallet.Id}, Срок годности: {pallet.ExpirationDate?.ToShortDateString()}, Объем: {pallet.Volume}");
            }
        }
    }
}
