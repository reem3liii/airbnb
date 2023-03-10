using airbnb.DTO;
using airbnb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace airbnb.Controllers
{
    public class MainFeaturesController : Controller
    {
        private readonly AirbnbDbContext _context;

        public MainFeaturesController(AirbnbDbContext context)
        {
            _context = context;
        }

        [HttpGet("getAll")]
        public ActionResult getAll()
        {
            List<Place> places = _context.Places.Include(p=> p.Reviews).ToList();

            if (places.Count == 0)
            {
                return NotFound();
            }
            else
            {
                List<PlaceDTO> placesDTO = new List<PlaceDTO>();
                foreach (Place p in places)
                {
                    double avgRate = p.Reviews.Average(p => p.Ratings);

                    List<string> imgUrls = _context.Place_Image.Where(x=> x.PlaceId == p.PlaceId).Select(x=> x.ImageName).ToList();
                    placesDTO.Add(new PlaceDTO()
                    {
                      Location=p.Location,
                      Type=p.Type,
                      DailyPrice=p.DailyPrice,
                      AvgRating=avgRate,
                      ImagesUrls= imgUrls

                    }
                    );
                }
                return Ok(placesDTO);
            }
        }

        [HttpGet("filter")]
        public ActionResult getByFilter(int maxPrice, int minPrice,int bedNum, int bedRoomNum, int bathRoomNum, string type)
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).
            Where(x=> x.DailyPrice>= minPrice && x.DailyPrice <= maxPrice && x.BedNumber == bedNum && x.BedroomNumber == bedRoomNum && x.BathroomNumber == bathRoomNum && x.Type == type).ToList();
            if (places.Count == 0)
            {
                return NotFound();
            }
            else
            {
                List<PlaceDTO> placesDTO = new List<PlaceDTO>();
                foreach (Place p in places)
                {
                    double avgRate = p.Reviews.Average(p => p.Ratings);
                    List<string> imgUrls = _context.Place_Image.Where(x => x.PlaceId == p.PlaceId).Select(x => x.ImageName).ToList();
                    placesDTO.Add(new PlaceDTO()
                    {
                        Location = p.Location,
                        Type = p.Type,
                        DailyPrice = p.DailyPrice,
                        AvgRating = avgRate,
                        ImagesUrls = imgUrls

                    }
                    );
                }
                return Ok(placesDTO);
            }
        }

        [HttpGet("search")]
        public ActionResult getBySearch(string location)
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).Where(x => x.Location.Contains(location)).ToList();
            if (places.Count == 0)
            {
                return NotFound();
            }
            else
            {
                List<PlaceDTO> placesDTO = new List<PlaceDTO>();
                foreach (Place p in places)
                {
                    double avgRate = p.Reviews.Average(p => p.Ratings);
                    List<string> imgUrls = _context.Place_Image.Where(x => x.PlaceId == p.PlaceId).Select(x => x.ImageName).ToList();
                    placesDTO.Add(new PlaceDTO()
                    {
                        Location = p.Location,
                        Type = p.Type,
                        DailyPrice = p.DailyPrice,
                        AvgRating = avgRate,
                        ImagesUrls = imgUrls

                    }
                    );
                }
                return Ok(placesDTO);
            }
        }

        [HttpGet("placeInDetail")]
        public ActionResult placeInDetail(int id)
        {
            Place place = _context.Places.Include(p => p.Reviews).Include(p=> p.Owner).FirstOrDefault(p=> p.PlaceId== id);

            if (place == null)
            {
                return NotFound();
            }
            else
            {        
                List<string> imgUrls = _context.Place_Image.Where(x => x.PlaceId == place.PlaceId).Select(x => x.ImageName).ToList();
                List<string> services = _context.Place_Service.Where(x => x.PlaceId == place.PlaceId).Select(x => x.Service).ToList();

                PlaceDetailsDTO placeDetailDTO = new PlaceDetailsDTO()
                {
                    Description = place.Description,
                    Location = place.Location,
                    AvgRating = place.Reviews.Average(p => p.Ratings),
                    ReviewsNumber = place.Reviews.Count(),
                    ImagesUrls = imgUrls,
                    Type = place.Type,
                    OwnerName = place.Owner.FirstName,
                    BedroomNumber= place.BedroomNumber,
                    BedNumber = place.BedNumber,
                    BathroomNumber=place.BathroomNumber,
                    Services = services,
                    Reviews = place.Reviews,
                   Owner = place.Owner,
                };
                return View(placeDetailDTO);
            }
        }

        [HttpGet("reserve")]
        public ActionResult reserve(int id, int duration = 5, int guestsNumber = 1)
        {
            Place place = _context.Places.FirstOrDefault(p => p.PlaceId == id);
            int servicePrice = _context.Place_Service.Where(x => x.PlaceId == place.PlaceId).Sum(x => x.Price);
            DateTime date= DateTime.Now;
            ReserveDTO reserveDTO = new ReserveDTO()
            {
                DailyPrice = place.DailyPrice,
                StartDate = date,
                EndDate = date.AddDays(duration),
                GuestsNumber = guestsNumber,
                ServicesPrice= servicePrice,
                Duration= duration,
            };
            return Ok(reserveDTO);
        }

    }
}