using MvvmHelpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ToDoListApp.Abstractions;
using ToDoListApp.Models;

namespace ToDoListApp.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        INavigationService _navigationService;
        IToDoItemRepository _toDoItemsRepository;
        

        private ObservableRangeCollection<ToDoItem> _toDoItems;
        public DelegateCommand AddToDoItemCommand => new DelegateCommand(NextPage);
        private bool _isListViewRefreshing;
        public ICommand RefreshListViewCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService, IToDoItemRepository toDoItemsRepository)

        {


            _navigationService = navigationService;
            _toDoItemsRepository = toDoItemsRepository;

            RefreshListViewCommand = new DelegateCommand(OnListViewRefreshing);

            
        }

        public async void NextPage()
        {
            await _navigationService.NavigateAsync("ItemAdd");


        }
        public ObservableRangeCollection<ToDoItem> ToDoItems
        {
            get { return _toDoItems; }
            set { SetProperty(ref _toDoItems, value); }
        }

        public bool IsListViewRefreshing
        {
            get { return _isListViewRefreshing; }
            set { SetProperty(ref _isListViewRefreshing, value); }
        }

        private async void OnListViewRefreshing()
        {
            ToDoItems = new ObservableRangeCollection<ToDoItem>(await _toDoItemsRepository.GetAllAsync());
            IsListViewRefreshing = false;
        }
        public async void OnNavigatingTo(NavigationParameters parameters)
        {
            ToDoItems = new ObservableRangeCollection<ToDoItem>(await _toDoItemsRepository.GetAllAsync());
        }
    }
}
