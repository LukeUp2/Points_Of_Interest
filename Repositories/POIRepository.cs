using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Points_Of_Interest.Api.Data;
using Points_Of_Interest.Api.Dtos;
using Points_Of_Interest.Api.Models;

namespace Points_Of_Interest.Api.Repositories
{
    public class POIRepository
    {
        private readonly AppDbContext _context;

        public POIRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<PointsOfInterest>> All()
        {
            return await _context.Points_Of_Interests.ToListAsync();
        }

        public async Task Add(PointsOfInterest pointsOfInterest)
        {
            await _context.Points_Of_Interests.AddAsync(pointsOfInterest);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ClosestsPOIsDto>> GetClosests(GetCloserPOIDto location)
        {
            return await _context.Points_Of_Interests
                    .Select(p => new ClosestsPOIsDto()
                    {
                        Name = p.POI_Name,
                        X = p.X_Coord,
                        Y = p.Y_Coord,
                        Distance = Math.Round(Math.Sqrt(Math.Pow(location.X_Coord - p.X_Coord, 2) + Math.Pow(location.Y_Coord - p.Y_Coord, 2)), 2)
                    })
                    .Where(x => x.Distance <= location.D_Max)
                    .OrderBy(x => x.Distance)
                    .ToListAsync();

        }
    }
}