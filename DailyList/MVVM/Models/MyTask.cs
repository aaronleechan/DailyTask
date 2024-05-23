using System.ComponentModel;

namespace DailyList;

public class MyTask : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public string TaskName { get; set; }
    public bool Completed {get; set; }
    public int CategoryId { get; set; }
    public string TaskColor { get; set; }
}
