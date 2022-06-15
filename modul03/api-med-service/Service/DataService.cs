using System.Text.Json;

using Model;

namespace Service;

public class DataService
{
    private List<TodoTask> data { get; }

    private int NextId { get; set; }

    public DataService() {
        NextId = 1;
        this.data = new List<TodoTask>();
        this.data.Add(new TodoTask(NextId++, "Husk at læse teksten", false));
        this.data.Add(new TodoTask(NextId++, "Teste API'en", false));
        this.data.Add(new TodoTask(NextId++, "Skriv nogle noter", false));   
    }

    public TodoTask[] GetTasks() {
        return data.ToArray();
    }

    public TodoTask GetTaskById(int id) {
        return data.Find(task => task.TodoTaskId == id);
    }

    public string CreateTask(string text, bool done) {
        var task = new TodoTask(NextId++, text, done);
        data.Add(task);
        return JsonSerializer.Serialize(new { msg = "New task created", newTask = task });
    }

    public string DeleteTaskById(int id) {
        var task = GetTaskById(id);
        if (task is null)
            return "Task not found";
        data.Remove(task);
            return "Task deleted";
            

    }
     public TodoTask GetTaskByDone(bool done) {
        return data.Find(task => task.Done == done);
    }

    //public List<bool> GetTaskByDone(bool Done)
   // {
     //   List<bool> result = new ();
     //   foreach (TodoTask task in data) 
      //  {
        //    if (task.Done == Done)
       // result.Add(task.Done);
       // }
       // return result;
    //}
}
