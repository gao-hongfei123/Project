using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Todo3.Wpf.Service;
using Todo3.Wpf.Shared.Dtos;

namespace Todo3.Wpf.ViewModels
{
    public class TodoViewModel:NavigationViewModel
    {
        private ObservableCollection<TodoDto> todoDtos;
        public TodoViewModel(ITodoService todoService,IContainerProvider  provider):base(provider)
        {
            TodoDtos= new ObservableCollection<TodoDto>();
            AddCommand = new DelegateCommand(Add);
            
            SaveCommand = new DelegateCommand(Save);
            
            this.todoService = todoService;
            createTodoDtos();
            //选择
            SelectCommand = new DelegateCommand<TodoDto>(Selected);
            //筛选
            SearchCommand = new DelegateCommand(SearchQuery);

        }
        private bool isDrawerOpen=false;
        public readonly ITodoService todoService;
        

        public DelegateCommand<TodoDto> SelectCommand { get; set; }
        public bool IsDrawerOpen
        {
            get { return isDrawerOpen; }
            set { isDrawerOpen = value; RaisePropertyChanged(); }
        }
        
        public DelegateCommand SearchCommand { get; set; }

        public async void Selected(TodoDto dto)
        {
            IsDrawerOpen = true;
            var obj =await  todoService.GetSingleAsync(dto.Id);
            if (obj != null)
            {
                CurrentDto = obj.Result;
            }
        }

        private string search;
        public string Search
        {
            get { return search; }
            set { search = value; }
        }



        private TodoDto currentDto;
        public TodoDto CurrentDto
        {
            get { return currentDto; }
            set { currentDto = value; RaisePropertyChanged(); }
        }


        public DelegateCommand SaveCommand { get; set; }
        



        public DelegateCommand AddCommand { get; set; }
        public void Add()
        { 
            IsDrawerOpen= true;
            currentDto= new TodoDto();
        }

        


        public ObservableCollection<TodoDto> TodoDtos
        {
            get { return todoDtos; }
            set { todoDtos = value; }
        }

        public async void createTodoDtos()
        {
            UpdateLoading(true);
            var todos = await todoService.GetAllAsync(new Shared.QueryParameter()
            {
                PageIndex= 0,
                PageSize=100
            });
            if (todos.Status)
            {
                todoDtos.Clear();
                foreach (var item in todos.Result.Items)
                { 
                    todoDtos.Add(item);
                }
            }
            UpdateLoading(false);
           
        }


        //条件查询
        public async  void SearchQuery()
        {
             var result = await todoService.GetAllAsync(new Shared.QueryParameter()
            {
                PageIndex = 0,
                PageSize = 100,
                Search = Search
            }) ;

            if (result.Status)
            { 
                todoDtos.Clear();
                foreach (var item in result.Result.Items)
                {
                    todoDtos.Add(item);
                }
            }

        }

        //添加到代办功能
        public async void Save()
        {
                //若大于0说明是编辑功能，若等于0说明是新增功能
                if (CurrentDto.Id > 0)
                {
                    var dto = await todoService.UpdateAsync(CurrentDto);
                    if (dto.Status)
                    {
                        var obj = TodoDtos.FirstOrDefault(t => t.Id == CurrentDto.Id);
                        CurrentDto.Title = obj.Title;
                        CurrentDto.Content = obj.Content;
                        CurrentDto.Status = obj.Status;
                    }
                    IsDrawerOpen = false;

                }
                //新增
                else
                {
                    var addDto = await todoService.AddAsync(CurrentDto);
                    if (addDto.Status)
                    {
                        TodoDtos.Add(addDto.Result);
                        IsDrawerOpen = false;
                    }
                
                 }
        }
    }
}
