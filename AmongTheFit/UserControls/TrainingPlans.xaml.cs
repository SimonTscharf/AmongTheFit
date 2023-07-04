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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using AmongTheFit.Classes;

namespace AmongTheFit.UserControls
{
    /// <summary>
    /// Interaktionslogik für TrainingPlans.xaml
    /// </summary>
    public partial class TrainingPlans : UserControl
    {
        public TrainingPlans()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Exercise[] exercises = APIData.GetExercisesByMuscleGroup(Muscles.Chest);

            foreach (Exercise ex in exercises)
                ExercisesCBox.Items.Add(ex.name);

            foreach(Muscles m in Enum.GetValues(typeof(Muscles)))
            {
                MusclesCBox.Items.Add(m);
            }
        }

        private void MusclesCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
