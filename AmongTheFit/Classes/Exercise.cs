using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmongTheFit.Classes
{
    class Exercise
    {
        public string name { get; set; }
        public int[] muscles { get; set; }
        public int sets { get; set; }
        public int reps { get; set; }
        public string tag { get; set; }

        public Exercise() { }

        public Exercise(string _name, int[] _muscles, int _sets, int _reps)
        {
            name = _name;
            muscles = _muscles;
            sets = _sets;
            reps = _reps;
        }
    }

    enum Muscles
    {
        Biceps = 1,
        Shoulders,
        Chest = 4,
        Triceps,
        Abs,
        Calves,
        Glutes,
        Traps,
        Quads,
        Hamstrings,
        Lats,
        Brachialis,
        Obliques
    }
}
