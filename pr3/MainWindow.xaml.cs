using System.Windows;
using System.Windows.Controls;

namespace pr3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public List<Order> Orders { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        Orders = new List<Order>();
        OrdersDataGrid.ItemsSource = Orders;
    }

    private void AddOrderButton_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(OrderNumberTextBox.Text) ||
            ProductComboBox.SelectedItem == null ||
            OrderStatusComboBox.SelectedItem == null)
        {
            MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        Order newOrder = new Order
        {
            OrderNumber = OrderNumberTextBox.Text,
            Product = (ProductComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
            Status = (OrderStatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString()
        };
        Orders.Add(newOrder);
        
        OrdersDataGrid.Items.Refresh();
        OrderNumberTextBox.Clear();
        ProductComboBox.SelectedIndex = -1;
        OrderStatusComboBox.SelectedIndex = -1;
    }

    public class Order
    {
        public string OrderNumber { get; set; }
        public string? Product { get; set; }
        public string? Status { get; set; }
    }
}