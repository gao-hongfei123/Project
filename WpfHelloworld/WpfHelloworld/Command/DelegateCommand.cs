using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfHelloworld.Command
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;


        //定义两个委托告诉前端函数是否可执行
        public Func<Object, bool> CanExcuteFunc { get; set; }
        //告诉前端执行什么函数
        public Action<Object> ExcuteAction { get; set; }
        //所绑定的控件是否可以执行函数，true才可以执行execute函数
        public bool CanExecute(object? parameter)
        {
            //默认情况下直接为true
            if (CanExcuteFunc == null)
            {
                return true;
            }
            return true;
            CanExcuteFunc(parameter);//参数就是方法名
        }
        //命令执行时所调用的方法
        public void Execute(object? parameter)
        {
            if (ExcuteAction != null)
            {
                return;
            }
            ExcuteAction(parameter);//参数就是方法名，执行对应的方法
        }

    }
}
