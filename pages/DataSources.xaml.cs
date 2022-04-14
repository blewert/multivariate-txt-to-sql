using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TXTToSQL
{
    public record ExperimentalGroup
    {
        public string fullName;
        public string abbreviation;
        public string description;
        public Color color;

        public Brush brush
        {
            get { return new SolidColorBrush(color); }
        }
    }
}

namespace TXTToSQL.pages
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataSources : Page
    {
        public ObservableCollection<ExperimentalGroup> groups = new ObservableCollection<ExperimentalGroup>();

        public DataSources()
        {
            this.InitializeComponent();
            DebugAddGroups();
        }

        private void DebugAddGroups()
        {
            groups.Add(new ExperimentalGroup
            {
                fullName = "Group A",
                abbreviation = "A",
                description = "The first experimental group, exposed to condition A.",
                color = Color.FromArgb(255, 255, 255, 0)
            });

            groups.Add(new ExperimentalGroup
            {
                fullName = "Group B",
                abbreviation = "B",
                description = "The second experimental group, exposed to condition B.",
                color = Color.FromArgb(255, 255, 0, 255)
            });

            groups.Add(new ExperimentalGroup
            {
                fullName = "Group C",
                abbreviation = "C",
                description = "The third experimental group, exposed to condition C.",
                color = Color.FromArgb(255, 0, 255, 255)
            });
        }

        private async void dsAddGroupButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ContentDialog();

            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Add group";
            dialog.PrimaryButtonText = "Add";
            dialog.CloseButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Primary;

            var dialogContent = new TXTToSQL.pages.dialogs.AddGroupDialog();
            dialog.Content = dialogContent;

            var result = await dialog.ShowAsync();

            if (result != ContentDialogResult.Primary)
                return;

            groups.Add(dialogContent.chosenGroup);
        }

        private void dsDeleteGroupButton_Click(object sender, RoutedEventArgs e)
        {
            if (dsListViewGroups.SelectedItems.Count <= 0)
                return;

            var selectedItems = dsListViewGroups.SelectedItems;

            foreach(var item in selectedItems)
            {
                var castedItem = item as ExperimentalGroup;
                groups.Remove(castedItem);
            }
        }

        private async void dsEditGroupButton_Click(object sender, RoutedEventArgs e)
        {
            if (dsListViewGroups.SelectedItems.Count <= 0)
                return;

            var selectedIndex = dsListViewGroups.SelectedIndex;
            var selectedItem = dsListViewGroups.SelectedItems[0] as ExperimentalGroup;

            var dialog = new ContentDialog();

            dialog.XamlRoot = this.XamlRoot;
            dialog.Title = "Edit group";
            dialog.PrimaryButtonText = "Edit";
            dialog.CloseButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Primary;

            var dialogContent = new TXTToSQL.pages.dialogs.AddGroupDialog(selectedItem);
            dialog.Content = dialogContent;

            var result = await dialog.ShowAsync();

            if (result != ContentDialogResult.Primary)
                return;

            groups[selectedIndex] = dialogContent.chosenGroup;
        }
    }
}
