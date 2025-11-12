using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.UI.Messages;
using Todo.UI.Models;
using Todo.UI.Pages;
using Todo.UI.Repositories;

namespace Todo.UI.ViewModels
{
    public partial class TodoDetailViewModel : ObservableObject
    {
        private readonly ITodoRepository _repository;
        private readonly IMessenger _messenger;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddTodoCommand))]
        private string _title = "";

        [ObservableProperty]
        private string _description = "";

        [ObservableProperty]
        private bool _isCompleted = false;

        [ObservableProperty]
        private DateTime _dueDate = DateTime.Today;

        public TodoDetailViewModel(ITodoRepository repository, IMessenger messenger)
        {
            _repository = repository;
            _messenger = messenger;
        }

        private bool CanAddTodo()
        {
            if(_title != null && _title.Length >= 10)
                return true;

            return false;
        }

        [RelayCommand(CanExecute = nameof(CanAddTodo))]
        private async Task AddTodo()
        {
            TodoItem newItem = new TodoItem()
            {
                Title = _title,
                Description = _description,
                IsCompleted = _isCompleted,
                DueDate = _dueDate,
            };

            _repository.AddTodo(newItem);

            _messenger.Send(new TodoItemAdded(newItem));

            await Shell.Current.GoToAsync("..");
        }
    }
}
