
using System.ComponentModel;
using PropertyChanged;

namespace DailyList;

public class Category : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string Color { get; set; }
    public int PendingTasks { get; set; }
    public float Percentage { get; set; }
    public bool IsSelected { get; set; }
}