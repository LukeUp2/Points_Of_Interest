using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Points_Of_Interest.Api.Dtos
{
    public class CreatePOIDto
    {
        public string Name { get; set; } = string.Empty;
        public int X_Coord { get; set; }
        public int Y_Coord { get; set; }
    }
}