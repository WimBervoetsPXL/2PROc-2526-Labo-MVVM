using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.UI.Models;

namespace Todo.UI.Messages
{
    public class TodoItemAdded : ValueChangedMessage<TodoItem>
    {
        public TodoItemAdded(TodoItem value) : base(value)
        {

        }
    }
}
