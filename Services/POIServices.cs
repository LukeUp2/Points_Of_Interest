using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Points_Of_Interest.Api.Dtos;
using Points_Of_Interest.Api.Models;
using Points_Of_Interest.Api.Repositories;

namespace Points_Of_Interest.Api.Services
{
    public class POIServices
    {
        private readonly POIRepository _poiRepository;

        public POIServices(POIRepository repository)
        {
            _poiRepository = repository;
        }

        public async Task<List<PointsOfInterest>> ListAll()
        {
            return await _poiRepository.All();
        }

        public async Task CreatePOI(CreatePOIDto createPOIDto)
        {
            bool valid = Validate(createPOIDto);
            if (!valid)
            {
                throw new BadHttpRequestException("Dados inválidos");
            }

            PointsOfInterest pointsOfInterest = new PointsOfInterest()
            {
                POI_Name = createPOIDto.Name,
                X_Coord = createPOIDto.X_Coord,
                Y_Coord = createPOIDto.Y_Coord,
            };

            await _poiRepository.Add(pointsOfInterest);

        }

        public async Task<List<ClosestsPOIsDto>> GetClosests(GetCloserPOIDto closerPOIDto)
        {
            if (closerPOIDto.X_Coord < 0 || closerPOIDto.Y_Coord < 0 || closerPOIDto.D_Max < 0)
            {
                throw new BadHttpRequestException("Dados inválidos");
            }

            var closestsPoints = await _poiRepository.GetClosests(closerPOIDto);
            return closestsPoints;
        }
        private bool Validate(CreatePOIDto createPOIDto)
        {

            if (createPOIDto.Name == string.Empty)
            {
                return false;
            }

            if (createPOIDto.X_Coord < 0 || createPOIDto.Y_Coord < 0)
            {
                return false;
            }

            return true;
        }

    }
}