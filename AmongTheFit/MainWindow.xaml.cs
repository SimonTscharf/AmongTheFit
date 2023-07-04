using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AmongTheFit
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<ToggleButton> views = new List<ToggleButton>();
        public List<UserControl> userControls = new List<UserControl>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            views.Add(BurgerMenu);
            views.Add(TrainingsplanButton);
            views.Add(SettingsButton);

            userControls.Add(LoadingScreen);
            userControls.Add(TrainingPlans);
            userControls.Add(Settings);
        }
        private void SelectUserControl(UserControl currentControl, ToggleButton currentButton)
        {
            if (currentControl.Visibility == Visibility.Hidden)
                currentControl.Visibility = Visibility.Visible;

            foreach (ToggleButton t in views)
            {
                if (t.Name != currentButton.Name)
                    t.IsChecked = false;
            }

            foreach (UserControl uc in userControls)
            {
                if (uc.Name != currentControl.Name)
                    uc.Visibility = Visibility.Hidden;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TrainingsplanButton_Checked(object sender, RoutedEventArgs e)
        {
            SelectUserControl(TrainingPlans, TrainingsplanButton);
        }

        private void SettingsButton_Checked(object sender, RoutedEventArgs e)
        {
            SelectUserControl(Settings, SettingsButton);
        }
    }
}
