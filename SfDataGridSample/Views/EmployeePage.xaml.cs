using Syncfusion.Maui.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SfDataGridSample.Views;

public partial class EmployeePage : ContentPage
{
    
    public EmployeePage(EmployeeViewModel employeeViewModel)
	{
		InitializeComponent();
        this.BindingContext = employeeViewModel;
        if (employeeViewModel.EmployeeSelectedRow != null)
        {
          dataGrid.SelectedRows = new ObservableCollection<object>(employeeViewModel.EmployeeSelectedRow);
        }
        dataGrid.SelectionChanged += dataGrid_SelectionChanged;
    }

    private void dataGrid_SelectionChanged(object sender, Syncfusion.Maui.DataGrid.DataGridSelectionChangedEventArgs e)
    {
        EmployeeViewModel employeeViewModel = this.BindingContext as EmployeeViewModel;
        employeeViewModel.EmployeeSelectedRow = new ObservableCollection<object>(dataGrid.SelectedRows);
    
    }
}