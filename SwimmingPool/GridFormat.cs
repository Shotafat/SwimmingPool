using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwimmingPool
{
    public class GridFormat
    {
        private static int _id;
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public DateTime Day { get; set; }
        public bool IsChecked { get; set; } = false;
        public GridFormat(int id)
        {
            this.Id = id++;
        }
    }
}
