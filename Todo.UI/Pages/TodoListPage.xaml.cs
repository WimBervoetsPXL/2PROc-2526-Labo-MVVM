using MauiIcons.Core;
using Todo.UI.ViewModels;

namespace Todo.UI.Pages;

public partial class TodoListPage : ContentPage
{
	public TodoListPage()
	{
		InitializeComponent();
        this.BindingContext = new TodoListViewModel();

        _ = new MauiIcon();
    }
}