using Microsoft.Practices.Unity;
using Prism.Unity;
using ToDoListApp.Abstractions;
using ToDoListApp.Data;
using ToDoListApp.Models;
using ToDoListApp.Views;
using Xamarin.Forms;

namespace ToDoListApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();


            NavigationService.NavigateAsync("MainPage");
              }

        private void RegisterTypesForNavigation()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();

        }

        private void RegisterInterfaces()
        {
            Container.RegisterType<IToDoItemRepository, ToDoItemsRepository>();
        }

        protected override void RegisterTypes()
        {
            RegisterTypesForNavigation();
            RegisterInterfaces();

            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<ItemAdd>();
        }
    }
}
