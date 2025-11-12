using Bogus;
using Todo.UI.Models;

namespace Todo.UI.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        // Create fake data using Bogus data generator:
        // https://github.com/bchavez/Bogus
        private Faker<TodoItem> fake = new Faker<TodoItem>()
            .RuleFor(todo => todo.Title, (f, todo) => f.Lorem.Word())
            .RuleFor(todo => todo.Description, (f, todo) => f.Lorem.Sentence())
            .RuleFor(todo => todo.IsCompleted, (f, todo) => f.Random.Bool())
            .RuleFor(todo => todo.DueDate, (f, todo) => f.Date.Soon(7));

        List<TodoItem> items = new List<TodoItem>();
        
        public async Task<List<TodoItem>> GetTodoItems(int numberOfItems)
        {

            for (int i = 0; i < numberOfItems; i++)
            {
                items.Add(fake.Generate());
                await Task.Delay(10);
            }

            return items;
        }

        public void AddTodo(TodoItem item)
        {
            items.Add(item);
        }

    }
}
