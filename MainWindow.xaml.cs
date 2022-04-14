using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace txt_to_sql_converter
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private Dictionary<string, Type> pagesMap = new Dictionary<string, Type>();

        public MainWindow()
        {
            this.InitializeComponent();
            this.InitializeDictionary();

            nvMainContentFrame.Navigate(pagesMap["data-sources"]);
        }

        private void InitializeDictionary()
        {
            pagesMap["data-sources"] = typeof(TXTToSQL.pages.DataSources);
            pagesMap["data-model"]   = typeof(TXTToSQL.pages.DataModel);
            pagesMap["actions"]      = typeof(TXTToSQL.pages.Actions);
            pagesMap["settings"]     = typeof(TXTToSQL.pages.Settings);
        }

        private void nvMainNavigation_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var item = args.InvokedItemContainer as NavigationViewItem;

            if (args.IsSettingsInvoked)
            {
                nvMainContentFrame.Navigate(pagesMap["settings"]);
                return;
            }

            if (item == null)
                return;

            nvMainContentFrame.Navigate(pagesMap[item.Tag as string]);
        }
    }
}
