using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.UI.Models
{
    public partial class TodoItem : ObservableObject
    {
        [ObservableProperty]
        private string _title;
        [ObservableProperty]
        private string _description;
        [ObservableProperty]
        private bool _isCompleted;
        [ObservableProperty]
        private DateTime _dueDate;

        //public string Title
        //{
        //    get => _title;
        //    set
        //    {
        //        _title = value;
        //        OnPropertyChanged(nameof(Title));
        //    }
        //}
        //public string Description { get => _description; set => _description = value; }
        //public bool IsCompleted { 
        //    get => _isCompleted;
        //    set
        //    {
        //        _isCompleted = value;
        //        OnPropertyChanged(nameof(IsCompleted));
        //    }
        //}
        //public DateTime DueDate { get => _dueDate; set => _dueDate = value; }

        //public event PropertyChangedEventHandler? PropertyChanged;

        //public void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
