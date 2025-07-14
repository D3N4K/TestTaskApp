using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskApp.Classes
{
    public abstract class StorageItem
    {
        public int Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Deep { get; set; }
        public double Weight { get; set; }
        public abstract double Volume { get; }
    }
}
