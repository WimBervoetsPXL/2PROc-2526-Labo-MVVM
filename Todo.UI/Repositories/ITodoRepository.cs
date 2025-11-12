using Todo.UI.Models;

namespace Todo.UI.Repositories
{
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetTodoItems(int numberOfItems);

        void AddTodo(TodoItem item);
    }
}