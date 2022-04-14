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

namespace TXTToSQL.pages.dialogs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddGroupDialog : Page
    {
        public ExperimentalGroup chosenGroup = new ExperimentalGroup();

        public AddGroupDialog()
        {
            this.InitializeComponent();
        }

        public AddGroupDialog(ExperimentalGroup group)
        {
            this.InitializeComponent();
            this.chosenGroup = group;

            //Set components
            agdGroupName.Text = group.fullName;
            agdDescription.Text = group.description;
            agdColorPicker.Color = group.color;
            agdAbbreviation.Text = group.abbreviation;
            agdCurrentColor.Background = group.brush;
        }

        private void agdGroupName_TextChanged(object sender, TextChangedEventArgs e)
        {
            chosenGroup.fullName = agdGroupName.Text;
        }

        private void agdDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            chosenGroup.description = agdDescription.Text;
        }

        private void agdColorPicker_ColorChanged(ColorPicker sender, ColorChangedEventArgs args)
        {
            chosenGroup.color = agdColorPicker.Color;

            agdCurrentColor.Background = new SolidColorBrush(chosenGroup.color);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            chosenGroup.abbreviation = agdAbbreviation.Text;
        }
    }
}
