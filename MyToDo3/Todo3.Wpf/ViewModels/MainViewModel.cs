using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using Todo3.Wpf.Common;
using Todo3.Wpf.Common.Models;

namespace Todo3.Wpf.ViewModels
{
    class MainViewModel:BindableBase
    {
        public DelegateCommand<MenuBar> NavigateCommand { get; set; }
        private ObservableCollection<MenuBar> menuBars;
        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal journal;
        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value;RaisePropertyChanged(); }
        }

        public MainViewModel(IRegionManager regionManager)
        {
            menuBars = new ObservableCollection<MenuBar>();
            CreateMenuBars();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            this.regionManager = regionManager;
            GoBackCommand = new DelegateCommand(GoBack);
            GoFowardCommand = new DelegateCommand(GoForward);
            
        }


        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoFowardCommand { get; set; }


        /// <summary>
        /// 后退
        /// </summary>
        public void GoBack()
        {
            if (journal!=null &&journal.CanGoBack)
                journal.GoBack();

        }
        /// <summary>
        /// 前进
        /// </summary>
        public void GoForward()
        { 
            if(journal!=null &&journal.CanGoForward)
                journal.GoForward();
        }
        /// <summary>
        /// 导航
        /// </summary>
        /// <param name="menuBar"></param>
        public void Navigate(MenuBar menuBar)
        {
            if(menuBar != null && !String.IsNullOrWhiteSpace(menuBar.NameSpace)) { 
            regionManager.Regions[PrismManager.RegionName].RequestNavigate(menuBar.NameSpace, back => {
               journal= back.Context.NavigationService.Journal;
            });
            }
        }
        /// <summary>
        /// 创建菜单栏
        /// </summary>
        public void CreateMenuBars()
        {
            menuBars.Add(new MenuBar { Icon = "Home", Title = "首页", NameSpace = "IndexView" });
            menuBars.Add(new MenuBar { Icon = "NotebookOutline", Title = "代办", NameSpace = "TodoView" });
            menuBars.Add(new MenuBar { Icon = "NotebookPlus", Title = "备忘录", NameSpace = "MemoView" });
            menuBars.Add(new MenuBar { Icon = "Cog", Title = "设置", NameSpace = "SettingView" });
        }

    }
}
