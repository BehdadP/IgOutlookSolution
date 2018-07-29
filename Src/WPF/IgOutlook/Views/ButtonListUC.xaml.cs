using IgOutlook.ViewModels;
using Infragistics.Windows.Ribbon;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IgOutlook.Views
{
    /// <summary>
    /// Interaction logic for ButtonListUC.xaml
    /// </summary>
    public partial class ButtonListUC : RibbonGroupPanel
    {
        public ButtonListUC()
        {
            InitializeComponent();
            DataContext = new ButtonListUCViewModel();
        }
    }
}
