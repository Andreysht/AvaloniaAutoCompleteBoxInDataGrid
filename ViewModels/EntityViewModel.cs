using AvaloniaAutoCompleteBoxInDataGrid.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaAutoCompleteBoxInDataGrid.ViewModels;

public class EntityViewModel(Entity entity) : ObservableObject
{
    public string OriginalValue { get; } = entity.Value;

    public string Value
    {
        get => entity.Value;

        set
        {
            entity.Value = value;
            OnPropertyChanged(nameof(Value));
        }
    }
}