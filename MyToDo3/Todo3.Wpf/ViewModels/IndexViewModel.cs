using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo3.Wpf.Common.Models;
using Todo3.Wpf.Shared;
using Todo3.Wpf.Shared.Dtos;
using Todo3.Wpf.Views.Dialogs;

namespace Todo3.Wpf.ViewModels
{
    public class IndexViewModel:BindableBase
    {
        private ObservableCollection<MemoDto> memoDtos;
        private ObservableCollection<TodoDto> todoDtos;
        private ObservableCollection<TaskBar> taskbars;
        private readonly IDialogService dialog;

        public IndexViewModel(IDialogService dialog)
        {
            TaskBars = new ObservableCollection<TaskBar>();
            TodoDtos = new ObservableCollection<TodoDto>();
            MemoDtos = new ObservableCollection<MemoDto>();
            createTaskBars();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            this.dialog = dialog;
        }

        
        /// <summary>
        /// 工具栏
        /// </summary>
        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskbars; }
            set { taskbars = value;RaisePropertyChanged(); }
        }
        /// <summary>
        /// 代办事项列表
        /// </summary>
        public ObservableCollection<TodoDto> TodoDtos
        {
            get { return todoDtos; }
            set { todoDtos = value; }
        }
        /// <summary>
        /// 备忘录列表
        /// </summary>
        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; }
        }

        public DelegateCommand<string> ExecuteCommand { get; set; }
        /// <summary>
        /// 工具栏
        /// </summary>
        public void createTaskBars()
        {
            TaskBars.Add(new TaskBar {  Icon="ClockFast" , Color= "#FF0CA0FF", Title = "汇总", Content="9", Target=""});
            TaskBars.Add(new TaskBar {  Icon="ClockCheckOutline" , Color= "#FF1ECA3A", Title = "已完成", Content = "9", Target=""});
            TaskBars.Add(new TaskBar {  Icon="ChartLineVariant" , Color= "#FF02C6DC", Title = "完成率", Content = "9", Target=""});
            TaskBars.Add(new TaskBar {  Icon="PlayListStar" , Color= "#FFFFA000", Title = "备忘录", Content = "9", Target=""});
        }

        public void Execute(string param)
        {
            switch (param)
            {
                case "新增代办": AddTodo(); break;
                case "新增备忘": AddMemo();break;
            }
        }

        public void AddTodo()
        {
            dialog.ShowDialog("AddTodoView");
        }

        public void AddMemo()
        { 
            dialog.ShowDialog("AddMemoView");

        }



    }
}
