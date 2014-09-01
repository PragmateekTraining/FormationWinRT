using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SettingsFlyoutSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            SettingsPane.GetForCurrentView().CommandsRequested += MainPage_CommandsRequested;
        }

        private void MainPage_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            args.Request.ApplicationCommands.Add(new SettingsCommand("Position", "Position", _ =>
                {
                    PositionSettingsFlyout flyout = new PositionSettingsFlyout();
                    flyout.Show();
                }));

            args.Request.ApplicationCommands.Add(new SettingsCommand("Color", "Color", _ =>
            {
                ColorSettingsFlyout flyout = new ColorSettingsFlyout();
                flyout.Show();
            }));

            args.Request.ApplicationCommands.Add(new SettingsCommand("About", "About", _ =>
            {
                AboutSettingsFlyout flyout = new AboutSettingsFlyout();
                flyout.Show();
            }));
        }
    }
}
