using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskApp.Classes
{
    public class Pallet : StorageItem
    {
        public List<Box> Boxes { get; set; } = new List<Box>();
        public DateTime? ExpirationDate
        {
            get
            {
                if (Boxes.Count == 0) return null;
                return Boxes.Min(b => b.ExpirationDate);
            }
        }
        public override double Volume
        {
            get
            {
                double boxesVolume = Boxes.Sum(b => b.Volume);
                double palletVolume = Width * Height * Deep;
                return boxesVolume + palletVolume;
            }
        }
        public new double Weight
        {
            get
            {
                double boxesWeight = Boxes.Sum(b => b.Weight);
                return boxesWeight + 30;
            }
        }
        public void AddBox(Box box)
        {
            if (box.Width > Width || box.Deep > Deep)
            {
                throw new Exception("Размер коробки превышает размер паллеты!");
            }
            Boxes.Add(box);
        }
    }
}
