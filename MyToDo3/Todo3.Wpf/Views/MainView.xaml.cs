using MaterialDesignThemes.Wpf;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Todo3.Wpf.Common;

namespace Todo3.Wpf.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(IEventAggregator aggregator)
        {
            InitializeComponent();
            aggregator.Register(arg =>
            {
                this.DialoggHost.IsOpen = arg.IsOpen;
                if (DialoggHost.IsOpen)
                {
                    DialoggHost.DialogContent = new ProgressbarView();
                }
            });
            btn_Min.Click += (s, e) => this.WindowState = WindowState.Minimized;
            btn_Close.Click += (s, e) => this.Close();
            btn_Max.Click += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                    this.WindowState = WindowState.Normal;
                else
                { this.WindowState = WindowState.Maximized; }

            };
            colorZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };

            colorZone.MouseDoubleClick += (s, e) => {
                if (this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            };

            menuBar.SelectionChanged += (s, e) =>
            {
                drawerHost.IsLeftDrawerOpen = false;

            };
        }
    }
}
