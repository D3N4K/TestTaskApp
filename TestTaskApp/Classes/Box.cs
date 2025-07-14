using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskApp.Classes
{
    public class Box : StorageItem
    {
        public DateTime? ProductionDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Box()
        {
        }
        public override double Volume => Width * Height * Deep;
    }
}
