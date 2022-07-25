using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasker.DataModels;
using Task = Tasker.DataModels.Task;

namespace Tasker
{
    public class Core
    {
        public static void Add(Tuple<string?, string?, string?, string?> inputParameters)
        {
            using TaskerContext context = new();
            Task newTask = new() { Name = inputParameters.Item1, Description = inputParameters.Item2, Term = inputParameters.Item3, Status = inputParameters.Item4 };
            context.Tasks.Add(newTask);
            context.SaveChanges();
        }
        public static void Edit(string nameForEdit, string parameterForEdit, string newParameter)
        {
            TaskerContext context = new();
            var tasks = context.Tasks
               .Where(c => c.Name == nameForEdit)
               .FirstOrDefault();
            switch (parameterForEdit)
            {
                case "1":
                    tasks.Name = newParameter;
                    break;
                case "2":
                    tasks.Description = newParameter;
                    break;
                case "3":
                    tasks.Term = newParameter;
                    break;
                case "4":
                    tasks.Status = newParameter;
                    break;
                default:
                    throw new Exception();
            }
            context.Attach(tasks);
            context.Tasks.Update(tasks);
            context.SaveChanges();
        }
        public static void Delete(string nameForDelete)
        {
            TaskerContext context = new();
            Task task = new()
            {
                Name = nameForDelete
            };
            context.Tasks.Attach(task);
            context.Tasks.Remove(task);
            context.SaveChanges();
        }
    }
}
