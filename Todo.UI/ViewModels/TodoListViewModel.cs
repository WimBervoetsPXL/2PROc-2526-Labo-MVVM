using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Todo.UI.Models;

namespace Todo.UI.ViewModels
{
    public partial class TodoListViewModel : ObservableObject // : INotifyPropertyChanged
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddTodoCommand))]
        private string _newTodoTitle = "";

        private ObservableCollection<TodoItem> _todoItems;

        //public void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //public event PropertyChangedEventHandler? PropertyChanged;

        //public ICommand AddTodoCommand { get; private set; }
        //public ICommand LoadDataCommand { get; private set; }

        //public string NewTodoTitle
        //{
        //    get
        //    {
        //        return _newTodoTitle;
        //    }
        //    set
        //    {
        //        _newTodoTitle = value;
        //        OnPropertyChanged(nameof(NewTodoTitle));
        //    }
        //}

        public ObservableCollection<TodoItem> TodoItems
        {
            get => _todoItems;
            set
            {
                _todoItems = value;
            }
        }

        public TodoListViewModel()
        {
            this.TodoItems = new ObservableCollection<TodoItem>();

            //TODO: Initialise commands:
            //AddTodoCommand = new Command(AddTodo);
            //LoadDataCommand = new Command(LoadData);
        }

        private bool CanAddTodo()
        {
            if(this.NewTodoTitle.Length >= 10)
                return true;

            return false;
        }

        [RelayCommand(CanExecute = nameof(CanAddTodo))]
        private void AddTodo()
        {
            //TODO: add item to TodoItems, use NewTodoTitle as Title for the new item
            //TODO: clear the NewTodoTitle

            TodoItem newItem = new TodoItem();
            newItem.Title = this.NewTodoTitle;

            this.TodoItems.Add(newItem);

            this.NewTodoTitle = string.Empty;
        }

        [RelayCommand]
        private void DeleteTodo(TodoItem item)
        {
            //TODO: remove item from TodoItems
            this.TodoItems.Remove(item);
        }

        [RelayCommand]
        private void LoadData()
        {
            foreach (TodoItem item in Data.TodoDb.GetTodoItems(10))
            {
                TodoItems.Add(item);
            }
        }

        

    }
}
