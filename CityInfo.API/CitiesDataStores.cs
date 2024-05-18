using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }
        public static CitiesDataStore current { get; } = new CitiesDataStore();
        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with big park.",
                    PointOfInterest=new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=1,
                            Name="Central Park",
                            Description="The most visited"
                        },
                        new PointOfInterestDto()
                        {
                            Id=2,
                            Name="Empire State building",
                            Description="A 102 story"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "New York City",
                    Description = "The one with the cathedral that was never really finshed.",
                    PointOfInterest=new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=3,
                            Name="Central Park",
                            Description="The most visited"
                        },
                        new PointOfInterestDto()
                        {
                            Id=4,
                            Name="Empire State building",
                            Description="A 102 story"
                        }
                    }
                },
                new CityDto()
                {
                    Id= 3,
                    Name="Paris",
                    Description="The one with that big tower.",
                    PointOfInterest=new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=5,
                            Name="Central Park",
                            Description="The most visited"
                        },
                        new PointOfInterestDto()
                        {
                            Id=6,
                            Name="Empire State building",
                            Description="A 102 story"
                        }
                    }
                }
            };
        }
    }
}
 