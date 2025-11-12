using Todo.UI.Repositories;
using Todo.UI.ViewModels;

namespace Todo.UI.Pages;

public partial class TodoDetailPage : ContentPage
{
	public TodoDetailPage(TodoDetailViewModel vm)
	{
		InitializeComponent();

		this.BindingContext = vm;
	}
}