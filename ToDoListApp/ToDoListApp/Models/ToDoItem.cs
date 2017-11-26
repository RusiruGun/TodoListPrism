using Prism.Mvvm;
using SQLite;

namespace ToDoListApp.Models
{
    public class ToDoItem : BindableBase
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }



        public ToDoItem()
        {

        }


        private string _title;
        private string _date;
    }
}
