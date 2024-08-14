using Avalonia.Controls;
using System.Reflection;

namespace AvaloniaAutoCompleteBoxInDataGrid.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_OnUnloadingRow(object? sender, DataGridRowEventArgs e)
        {
            if (KludgeCheckBox.IsChecked == false) return;

            // When another DataContext is binding to the AutoCompleteBox some of them properties updates properties of "old" data context.
            // The workaround is to prohibit rows reusing by DataGrid
            // To avoid rows recycling by DataGrid:
            if (sender is DataGrid dataGrid)
            {
                var currentSlotProperty = typeof(DataGrid).GetProperty("CurrentSlot", BindingFlags.Instance | BindingFlags.NonPublic);
                if (currentSlotProperty is not null)
                {
                    var currentSlot = currentSlotProperty.GetValue(dataGrid);
                    if (currentSlot is not null)
                    {
                        var indexProperty = typeof(DataGridRow).GetProperty("Index", BindingFlags.Instance | BindingFlags.NonPublic);
                        if (indexProperty is not null)
                        {
                            indexProperty.SetValue(e.Row, currentSlot);
                        }
                    }
                }
            }
        }
    }
}