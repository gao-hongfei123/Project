using DryIoc;
using Prism.DryIoc;
using Prism.Ioc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Todo3.Wpf.Service;
using Todo3.Wpf.ViewModels;
using Todo3.Wpf.Views;
using Todo3.Wpf.Views.Dialogs;

namespace Todo3.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册HttpRestSharp类
            containerRegistry.GetContainer().Register<HttpRestSharp>(made: Parameters.Of.Type<string>(serviceKey: "webUrl"));
            containerRegistry.GetContainer().RegisterInstance(@"https://localhost:7010/", serviceKey: "webUrl");
            //注册仓储类和仓储接口
            containerRegistry.Register<ITodoService, TodoService>();
            containerRegistry.Register<IMemoService, MemoService>();
            //注册弹框
            containerRegistry.RegisterDialog<AddTodoView,AddTodoViewModel>();
            containerRegistry.RegisterDialog<AddMemoView,AddMemoViewModel>();

            //注册导航
            containerRegistry.RegisterForNavigation<IndexView, IndexViewModel>();
            containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();
            containerRegistry.RegisterForNavigation<TodoView, TodoViewModel>();
            containerRegistry.RegisterForNavigation<SettingView, SettingViewModel>();
        }
    }
}
