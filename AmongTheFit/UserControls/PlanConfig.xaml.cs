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
    public partial class PlanConfig : UserControl
    {
        public PlanConfig()
        {
            InitializeComponent();
        }

        Task<Exercise[]> task;
        Exercise[] exercises;

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            task = APIData.GetExercises();

            exercises = await task;

            foreach (Exercise ex in exercises)
                ExercisesCBox.Items.Add(ex.name);

            foreach(Muscles m in Enum.GetValues(typeof(Muscles)))
                MusclesCBox.Items.Add(m);


        }

        private void MusclesCBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ExercisesCBox.Items.Clear();

            foreach (Exercise ex in exercises)
                if(ex.muscles.Contains((int)Enum.Parse(typeof(Muscles), e.AddedItems[0].ToString())))
                    ExercisesCBox.Items.Add(ex.name);
        }

        private void AddExerciseButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Exercise ex in exercises)
            {
                if (ex.name == ExercisesCBox.Text)
                {
                    Exercise exercise = ex;
                    exercise.reps = Convert.ToInt32(RepsBox.Text);
                    exercise.sets = Convert.ToInt32(SetsBox.Text);

                    ExercisesGrid.Items.Add(exercise);
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ExercisesGrid.Items.RemoveAt(ExercisesGrid.SelectedIndex);
        }
    }
}
