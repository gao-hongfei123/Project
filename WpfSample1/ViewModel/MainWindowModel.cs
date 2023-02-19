using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSample1.Entity;

namespace WpfSample1.ViewModel
{
     public class MainWindowModel:ObservableObject
    {
        public MainWindowModel()
        {
            InitUserModules();
            InitUserModules();
        }
        public ObservableCollection<UserModule> userModules { get; set; }
        public void InitUserModules()
        {
            userModules = new ObservableCollection<UserModule>();
            userModules.Add(new UserModule() { FilePath = "Images/1.jpeg", UserName = "张三", Content = "编程", SignTime ="32min" });
            userModules.Add(new UserModule() { FilePath = "Images/2.jpg", UserName = "李四", Content = "编程", SignTime = "32min"});
            userModules.Add(new UserModule() { FilePath = "Images/3.jpeg", UserName = "王五", Content = "编程", SignTime ="32min" });
            userModules.Add(new UserModule() { FilePath = "Images/4.jpg", UserName = "赵六", Content = "编程", SignTime = "32min"});
            userModules.Add(new UserModule() { FilePath = "Images/5.jpeg", UserName = "张三", Content = "编程", SignTime ="32min" });
            userModules.Add(new UserModule() { FilePath = "Images/6.jpg", UserName = "张三", Content = "编程", SignTime = "32min"});
            userModules.Add(new UserModule() { FilePath = "Images/7.jpeg", UserName = "张三", Content = "编程", SignTime ="32min" });
            userModules.Add(new UserModule() { FilePath = "Images/8.jpeg", UserName = "张三", Content = "编程", SignTime ="32min" });
        }
    }
}
