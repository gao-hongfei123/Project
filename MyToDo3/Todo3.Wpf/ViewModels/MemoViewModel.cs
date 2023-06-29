using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo3.Wpf.Service;
using Todo3.Wpf.Shared;
using Todo3.Wpf.Shared.Dtos;

namespace Todo3.Wpf.ViewModels
{
    public class MemoViewModel:BindableBase
    {
        private ObservableCollection<MemoDto> memoDtos;
        public MemoViewModel(IMemoService service)
        {

            MemoDtos = new ObservableCollection<MemoDto>();
            
            AddCommand = new DelegateCommand(Add);
            this.service = service;
            createMemoDtos();
            SelectCommand = new DelegateCommand<MemoDto>(Selected);
            

        }
        private bool isDrawerOpen = false;
        private readonly IMemoService service;

        
        public DelegateCommand<MemoDto> SelectCommand { get; set; }
        //点击项目打开右侧窗口
        public async void Selected(MemoDto obj)
        { 
            
            var dto =await  service.GetSingleAsync(obj.Id);
            if (dto != null)
            {
                if (dto.Status)
                {
                    CurrentDto = dto.Result;
                }

            }
            IsDrawerOpen = true;


        }
        private MemoDto currentDto;

        public MemoDto CurrentDto
        {
            get { return currentDto; }
            set { currentDto = value; RaisePropertyChanged(); }
        }

        public bool IsDrawerOpen
        {
            get { return isDrawerOpen; }
            set { isDrawerOpen = value; RaisePropertyChanged(); }
        }
        
        public DelegateCommand AddCommand { get; set; }
        
        //添加
        public void Add()
        {
            IsDrawerOpen = true;
        }

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; }
        }

        public async  void createMemoDtos()
        {
            var memos = await service.GetAllAsync(new QueryParameter()
            {
                PageIndex = 0,
                PageSize = 100
            });
            if (memos.Status)
            {
                memoDtos.Clear();
                foreach (var item in memos.Result.Items)
                {
                    memoDtos.Add(item);
                }
            }
        }
       

    }
}
