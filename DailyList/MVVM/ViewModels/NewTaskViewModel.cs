using System.Collections.ObjectModel;

namespace DailyList;

public class NewTaskViewModel
{
    public string Task { get; set; }
    public ObservableCollection<MyTask> Tasks { get; set; }
    public ObservableCollection<Category> Categories { get; set; }
}
