using Todo.UI.Pages;

namespace Todo.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(TodoDetailPage), typeof(TodoDetailPage));
        }
    }
}
