using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo3.Wpf.Common.Events;

namespace Todo3.Wpf.Common
{
    //类名无用，因为是拓展方法
    public static class DialogExtensions
    {
        //实际上是将publish进行了封装
        public static void UpdateLoading(this IEventAggregator aggregator, UpdateModel model)
        { 
            //所以updatemodel类是需要被传送的消息
            aggregator.GetEvent<UpdateLoadingEvent>().Publish(model);
        }
        //将subscribe进行了封装
        public static void Register(this IEventAggregator aggregator, Action<UpdateModel> action)
        { 
        aggregator.GetEvent<UpdateLoadingEvent>().Subscribe(action);
        }
    }
}
