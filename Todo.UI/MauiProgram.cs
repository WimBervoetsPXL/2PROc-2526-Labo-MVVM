using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.Messaging;
using MauiIcons.Fluent.Filled;
using Microsoft.Extensions.Logging;
using Todo.UI.Repositories;
using Todo.UI.ViewModels;

namespace Todo.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseFluentFilledMauiIcons()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<TodoListViewModel>();
            builder.Services.AddTransient<TodoDetailViewModel>();
            builder.Services.AddSingleton<ITodoRepository, TodoRepository>();
            builder.Services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
