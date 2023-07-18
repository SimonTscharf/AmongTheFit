using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmongTheFit.Classes
{
    class TrainingPlan
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<TrainingPlanDay> days;

        public TrainingPlan(string _name, int _id)
        {
            days = new List<TrainingPlanDay>();

            Name = _name;
            Id = _id;
        }
    }
}
