using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Todo.UI.Messages;
using Todo.UI.Models;
using Todo.UI.Pages;
using Todo.UI.Repositories;

namespace Todo.UI.ViewModels
{
    public partial class TodoListViewModel : ObservableObject, IRecipient<TodoItemAdded> // : INotifyPropertyChanged
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

        private readonly ITodoRepository _repository;

        public TodoListViewModel(ITodoRepository repository, IMessenger messenger)
        {
            this.TodoItems = new ObservableCollection<TodoItem>();
            _repository = repository;

            messenger.Register<TodoItemAdded>(this);

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

        //[RelayCommand(CanExecute = nameof(CanAddTodo))]
        [RelayCommand]
        private async Task AddTodo()
        {
            //TODO: add item to TodoItems, use NewTodoTitle as Title for the new item
            //TODO: clear the NewTodoTitle

            //TodoItem newItem = new TodoItem();
            //newItem.Title = this.NewTodoTitle;

            //this.TodoItems.Add(newItem);

            //this.NewTodoTitle = string.Empty;

            await Shell.Current.GoToAsync(nameof(TodoDetailPage));
        }

        [RelayCommand]
        private void DeleteTodo(TodoItem item)
        {
            //TODO: remove item from TodoItems
            this.TodoItems.Remove(item);
        }

        [RelayCommand]
        private async Task LoadData()
        {
            if(!TodoItems.Any())
            {
                List<TodoItem> items = await _repository.GetTodoItems(10);
                foreach (TodoItem item in items)
                {
                    TodoItems.Add(item);
                }
            }
        }

        public void Receive(TodoItemAdded message)
        {
            TodoItems.Add(message.Value);
        }
    }
}
