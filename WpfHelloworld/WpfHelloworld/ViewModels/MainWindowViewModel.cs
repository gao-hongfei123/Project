using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfHelloworld.Command;

namespace WpfHelloworld.ViewModels
{
    //一个页面一般对应一个viewmodel，分别将属性和方法封装到里面，以传递到NotificationObject和DelegateCommand供前端进行调用。
    public class MainWindowViewModel:NotificationObject
    {	
		//属性操作，属性的多少参考前端（xaml）哪些数据会发生动态变化
		private int input1;

		public int Input1
		{
			get { return input1; }
			//将该属性传递给NotificationObject中定义的委托，绑定到委托上
			set { input1 = value; RaisePropertyChanged("Input1"); }
		}



		private int input2;

		public int Input2
		{
			get { return input2; }
			//同上
			set { input2 = value;RaisePropertyChanged("Input2"); }
		}

		private int rusult;

		public int Result
		{
			get { return rusult; }
			set { rusult = value;RaisePropertyChanged("Result"); }
		}

		//方法操作
		//引入delegatecommand类中创建的委托，只不过是将其提到外面，因为其他地方也可能用到该委托
		public DelegateCommand AddCommand { get; set; }
		//需要执行的逻辑方法
		public void Add(Object parameter)
		{
			Result = Input1 + Input2;
		}
		//在构造函数中进行方法绑定
		public MainWindowViewModel()
		{
			//创建委托对象
			AddCommand = new DelegateCommand();
			//将方法与委托中的事件成员进行订阅
			AddCommand.ExcuteAction = new Action<object>(Add);
			

		}



	}
}
