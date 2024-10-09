using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Points_Of_Interest.Api.Dtos
{
    public class ClosestsPOIsDto
    {
        public string Name { get; set; } = "";
        public int X { get; set; }
        public int Y { get; set; }
        public double Distance { get; set; }
    }
}