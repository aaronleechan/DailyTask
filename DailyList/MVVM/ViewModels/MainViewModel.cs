using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace DailyList.MVVM.ViewModels
{
    public class MainViewModel 
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks {get; set; }

        public MainViewModel()
        {
            FillData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        private void Tasks_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void FillData()
        {
            var r = new Random();

            Categories = new ObservableCollection<Category>
            {
                new Category
                {
                    Id = 1,
                    CategoryName = "Chest",
                    Color = Color.FromRgb(r.Next(0,255), r.Next(0,255), r.Next(0,255)).ToHex()
                },
                new Category
                {
                    Id = 2,
                    CategoryName = "Back",
                    Color = Color.FromRgb(r.Next(0,255), r.Next(0,255), r.Next(0,255)).ToHex()
                },
                new Category
                {
                    Id = 3,
                    CategoryName = "Leg",
                    Color = Color.FromRgb(r.Next(0,255), r.Next(0,255), r.Next(0,255)).ToHex()
                },
                new Category
                {
                    Id = 4,
                    CategoryName = "Shoulder",
                    Color = Color.FromRgb(r.Next(0,255), r.Next(0,255), r.Next(0,255)).ToHex()
                },
                new Category
                {
                    Id = 5,
                    CategoryName = "Triceps",
                    Color = Color.FromRgb(r.Next(0,255), r.Next(0,255), r.Next(0,255)).ToHex()
                },
                new Category
                {
                    Id = 6,
                    CategoryName = "Biceps",
                    Color = Color.FromRgb(r.Next(0,255), r.Next(0,255), r.Next(0,255)).ToHex()
                },
                new Category
                {
                    Id = 7,
                    CategoryName = "Core",
                    Color = "#14df80"
                }
            };

            Tasks = new ObservableCollection<MyTask>
            {
                new MyTask
                {
                    TaskName = "Knee Push Up",
                    Completed = false,
                    CategoryId = 1
                },
                new MyTask
                {
                    TaskName = "Dumbbell Fly",
                    Completed = false,
                    CategoryId = 1
                },
                new MyTask
                {
                    TaskName = "Standing Dumbbell Fly",
                    Completed = false,
                    CategoryId = 1
                },
                new MyTask
                {
                    TaskName = "Dumbbell Row",
                    Completed = false,
                    CategoryId = 2
                },
                new MyTask
                {
                    TaskName = "Lat Pulldown",
                    Completed = false,
                    CategoryId = 2
                },
                new MyTask
                {
                    TaskName = "Squat",
                    Completed = false,
                    CategoryId = 3
                },
                new MyTask
                {
                    TaskName = "Leg Curl",
                    Completed = false,
                    CategoryId = 3
                },
                new MyTask
                {
                    TaskName = "Leg Press",
                    Completed = false,
                    CategoryId = 3
                },
                new MyTask
                {
                    TaskName = "Shoulder Press",
                    Completed = false,
                    CategoryId = 4
                },
                new MyTask
                {
                    TaskName = "Dumbbell Tricep Extension",
                    Completed = false,
                    CategoryId = 5
                },
                new MyTask
                {
                    TaskName = "Dumbbell Hammer Curl",
                    Completed = false,
                    CategoryId = 6
                },
                new MyTask
                {
                    TaskName = "Plank",
                    Completed = false,
                    CategoryId = 7
                }
                
            };

            UpdateData();
        }

        public void UpdateData()
        {
            foreach(var c in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;

                var completed = from t in tasks
                                where t.Completed == true
                                select t;
                
                var notCompleted = from t in tasks
                                    where t.Completed == false
                                    select t;
                
                c.PendingTasks = notCompleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }
            foreach(var t in Tasks)
            {
                var catColor = 
                    (from c in Categories
                     where c.Id == t.CategoryId
                     select c.Color).FirstOrDefault();
                t.TaskColor = catColor;
            }
        }
    
        public string TaskName { get; set; }
        public Color TaskColor { get; set; }

    }

}
