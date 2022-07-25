using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasker.DataModels;
using Task = Tasker.DataModels.Task;
//165156165156165156
namespace Tasker
{
    public class UI
    {
        public static void ChoiceOperation()
        {
            while (true)
            {
                Console.WriteLine("Выберите действие из списка:\n1. Добавить задачу\n2. Показать список задач\n3. Редактировать задачу\n4. Удалить задачу\n5. Закрыть программу");
                string operations = Console.ReadLine();
                if (operations == "5")
                    break;
                switch (operations)
                {
                    case "1":
                        var inputParameters = UI.InputAdd();
                        Core.Add(inputParameters);
                        break;
                    case "2":
                        UI.Output();
                        break;
                    case "3":
                        var inputEdit = UI.InputEdit();
                        Core.Edit(inputEdit.Item1, inputEdit.Item2, inputEdit.Item3);
                        break;
                    case "4":
                        var nameForDelete = UI.InputDelete();
                        Core.Delete(nameForDelete);
                        break;
                    default:
                        throw new Exception();
                }
            }
        }
        public static Tuple<string, string, string, string> InputAdd()
        {
            Console.WriteLine("Введите имя задачи:");
            string name = Console.ReadLine();
            Console.WriteLine("Введите описание задачи:");
            string description = Console.ReadLine();
            Console.WriteLine("Введите время исполнения задачи:");
            string term = Console.ReadLine();
            Console.WriteLine("Выберите статус задачи:\n1-Новая, 2-В работе, 3-Приостановлено, 4-Выполнено\n");
            string status = Console.ReadLine();
            status = status switch
            {
                "1" => "Новая",
                "2" => "В работе",
                "3" => "Приостановлено",
                "4" => "Выполнено",
                _ => throw new Exception(),
            };
            return Tuple.Create(name, description, term, status);
        }
        public static void Output()
        {
            using TaskerContext context = new();
            Console.WriteLine("\nСписок задач:");
            List<Task> tasks = context.Tasks.ToList();
            foreach (Task u in tasks)
            {
                Console.WriteLine($"{u.Name}:\n{u.Description}\n{u.Term}\n{u.Status}\n");
            }
        }
        public static Tuple<string, string, string> InputEdit()
        {
            Console.WriteLine("Выберите имя задачи:");
            string nameForEdit = Console.ReadLine();
            Console.WriteLine("Выберите параметр для изменения:\n1-Имя, 2-Описание, 3-Дата, 4-Статус\n");
            string parameterForEdit = Console.ReadLine();
            string newParameter;
            if (parameterForEdit == "4")
            {
                Console.WriteLine("Выберите статус задачи:\n1-Новая, 2-В работе, 3-Приостановлено, 4-Выполнено\n");
                string parameterForStatus = Console.ReadLine();
                newParameter = parameterForStatus switch
                {
                    "1" => "Новая",
                    "2" => "В работе",
                    "3" => "Приостановлено",
                    "4" => "Выполнено",
                    _ => throw new Exception(),
                };
            }
            else
            {
                Console.WriteLine("Введите новый параметр:");
                newParameter = Console.ReadLine();
            }
            return Tuple.Create(nameForEdit, parameterForEdit, newParameter);
        }
        public static string InputDelete()
        {
            Console.WriteLine("Выберите имя задачи:");
            string nameForDelete = Console.ReadLine();
            return nameForDelete;
        }
    }
}
