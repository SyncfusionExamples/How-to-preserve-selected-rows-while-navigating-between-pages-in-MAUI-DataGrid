using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using SfDataGridSample.Views;
using Syncfusion.Maui.DataGrid;


namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        EmployeeViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new EmployeeViewModel();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.ItemIndex == 0)
                Navigation.PushAsync(new EmployeePage(viewModel));
            else if(e.ItemIndex == 1)
                Navigation.PushAsync(new OrderInfoPage());
        }
    }

}