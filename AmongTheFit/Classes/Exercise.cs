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
        public Muscles[] muscles { get; set; }
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
