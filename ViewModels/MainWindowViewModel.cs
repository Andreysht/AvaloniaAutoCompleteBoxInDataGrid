using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AvaloniaAutoCompleteBoxInDataGrid.Models;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaAutoCompleteBoxInDataGrid.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public ObservableCollection<EntityViewModel> Entities { get; } = new ObservableCollection<EntityViewModel>();

        public MainWindowViewModel()
        {
            Reset();
        }

        [RelayCommand]
        private void Reset()
        {
            Entities.Clear();
            var entities = new List<Entity>
            {
                new Entity("1"),
                new Entity("2"),
                new Entity("3"),
                new Entity("4"),
                new Entity("5"),
                new Entity("6"),
                new Entity("7"),
                new Entity("8"),
                new Entity("9"),
            };

            foreach (var entity in entities)
            {
                Entities.Add(new EntityViewModel(entity));
            }
        }
    }
}
