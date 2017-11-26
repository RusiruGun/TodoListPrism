using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoListApp.Abstractions;
using ToDoListApp.Models;
namespace ToDoListApp.ViewModels
{
    public class ItemAddViewModel : BindableBase
    {
        public ICommand SaveItemCommand { get; set; }

        public string PageTitle
        {
            get { return _pageTitle; }
            set { SetProperty(ref _pageTitle, value); }
        }

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
        public ItemAddViewModel(INavigationService navigationService, IToDoItemRepository toDoItemsRepository)
        {
            _navigationService = navigationService;
            _toDoItemsRepository = toDoItemsRepository;

            SaveItemCommand = new DelegateCommand(OnSaveItem);

        }

        private async void OnSaveItem()
        {
            var toDoItem = new ToDoItem()
            {
                ID = _itemId,
                Title = _title,
                Date = _date,

            };


            await _toDoItemsRepository.SaveItemAsync(toDoItem);

            await _navigationService.GoBackAsync();
        }
        private readonly IToDoItemRepository _toDoItemsRepository;
        private string _pageTitle;
        private int _itemId = 0;
        private string _title;
        private string _date;
        INavigationService _navigationService;
    }
}
