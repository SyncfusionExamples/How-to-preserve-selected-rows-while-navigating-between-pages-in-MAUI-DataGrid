# How-to-preserve-selected-rows-while-navigating-between-pages-in-MAUI-DataGrid

When navigating between pages, the DataGrid gets disposed, resulting in the loss of selection. This article demonstrates a workaround to maintain the selected rows while navigating between pages in a [.NET MAUI DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid).

**Step 1:** Initialize the [SfDataGrid](https://help.syncfusion.com/maui/datagrid/getting-started) with the necessary properties. Set up an ObservableCollection in the ViewModel class to manage the selected rows.
 
**Step 2:** Implement the ObservableCollection in the ViewModel class to handle selected rows. Utilize the [SfDataGrid.SelectionChanged](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.DataGrid.SfDataGrid.html#Syncfusion_Maui_DataGrid_SfDataGrid_SortColumnsChanged) event in the corresponding DataGrid page class to capture selected rows. Upon the event triggering, load the selected rows into the local ObservableCollection collection.

**Step 3:** Use the [SfDataGrid.SelectedRows](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.DataGrid.SfDataGrid.html#Syncfusion_Maui_DataGrid_SfDataGrid_SelectedRows) property to programmatically select rows by assigning the locally stored selected rows when opening the DataGrid Page.

  
 ```C#
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
 ```


