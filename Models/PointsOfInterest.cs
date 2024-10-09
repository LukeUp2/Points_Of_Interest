using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Points_Of_Interest.Api.Models
{
    public class PointsOfInterest
    {
        public int Id { get; set; }
        public string POI_Name { get; set; } = string.Empty;
        public int X_Coord { get; set; }
        public int Y_Coord { get; set; }

    }
}