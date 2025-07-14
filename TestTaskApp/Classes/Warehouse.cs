using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskApp.Classes
{
    public class Warehouse
    {
        public List<Pallet> Pallets { get; set; } = new List<Pallet>();
        public void AddPallet(Pallet pallet)
        {
            Pallets.Add(pallet);
        }
        public IEnumerable<IGrouping<DateTime?, Pallet>> GroupPalletsByExpiration()
        {
            return Pallets
                .GroupBy(p => p.ExpirationDate)
                .OrderBy(g => g.Key);
        }
        public IEnumerable<Pallet> GetTopPalletsWithLongestExpiration(int count)
        {
            return Pallets
                .Where(p => p.ExpirationDate.HasValue)
                .OrderByDescending(p => p.ExpirationDate)
                .Take(count)
                .OrderBy(p => p.Volume);
        }
    }
}
