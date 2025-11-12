using MauiIcons.Core;
using Todo.UI.Data;
using Todo.UI.ViewModels;

namespace Todo.UI.Pages;

public partial class TodoListPage : ContentPage
{
	public TodoListPage(TodoListViewModel vm)
	{
		InitializeComponent();
        this.BindingContext = vm;

        _ = new MauiIcon();
    }
}