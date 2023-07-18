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
using AmongTheFit.Classes;

namespace AmongTheFit.UserControls
{
    /// <summary>
    /// Interaktionslogik für TrainingPlans.xaml
    /// </summary>
    public partial class TrainingPlans : UserControl
    {

        List<TrainingPlan> trainingPlans;

        public TrainingPlans()
        {
            InitializeComponent();

            trainingPlans = new List<TrainingPlan>();

            if (trainingPlans.Count == 0)
            {
                TrainingPlanGrid.Visibility = Visibility.Hidden;
                ZeroTraningPlansText.Visibility = Visibility.Visible;
            }
        }

        private void CreatePlanButton_Click(object sender, RoutedEventArgs e)
        {
            TrainingPlan trainingPlan = new TrainingPlan("test", trainingPlans.Count + 1);

            trainingPlans.Add(trainingPlan);

            TrainingPlanGrid.Items.Add(trainingPlan);

            if(trainingPlans.Count > 0)
            {
                TrainingPlanGrid.Visibility = Visibility.Visible;
                ZeroTraningPlansText.Visibility = Visibility.Hidden;
            }
            else
            {
                TrainingPlanGrid.Visibility = Visibility.Hidden;
                ZeroTraningPlansText.Visibility = Visibility.Visible;
            }

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var item = TrainingPlanGrid.SelectedItem;

            this.Content = new PlanConfig();
        }
    }
}
