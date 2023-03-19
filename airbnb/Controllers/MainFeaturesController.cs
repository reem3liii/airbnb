using airbnb.DTO;
using airbnb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace airbnb.Controllers
{
    public class MainFeaturesController : Controller
    {
        private readonly AirbnbDbContext _context;

        public MainFeaturesController(AirbnbDbContext context)
        {
            _context = context;
        }

        public ActionResult getAll()
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).ToList();

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
                        PlaceId = p.PlaceId,
                        Location = p.Location,
                        Type = p.Type,
                        DailyPrice = p.DailyPrice,
                        AvgRating = avgRate,
                        ImagesUrls = imgUrls

                    }
                    );
                }
                return View(placesDTO);
            }
        }

        public ActionResult trending()
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).ToList();
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
                    if (avgRate >= 4)
                    {
                        placesDTO.Add(new PlaceDTO()
                        {
                            PlaceId = p.PlaceId,
                            Location = p.Location,
                            Type = p.Type,
                            DailyPrice = p.DailyPrice,
                            AvgRating = avgRate,
                            ImagesUrls = imgUrls

                        });
                    }
                }
                return View(placesDTO);
            }
        }
        public ActionResult pool()
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).ToList();
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
                    List<string> services = _context.Place_Service.Where(x => x.PlaceId == p.PlaceId).Select(x => x.Service).ToList();

                    foreach (string service in services)
                    {
                        if (service.Contains("pool") || service.Contains("Pool"))
                        {
                            placesDTO.Add(new PlaceDTO()
                            {
                                PlaceId = p.PlaceId,
                                Location = p.Location,
                                Type = p.Type,
                                DailyPrice = p.DailyPrice,
                                AvgRating = avgRate,
                                ImagesUrls = imgUrls

                            });
                        }
                    }
                }
                return View(placesDTO);
            }
        }

        public ActionResult beachFront()
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).ToList();
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
                    List<string> services = _context.Place_Service.Where(x => x.PlaceId == p.PlaceId).Select(x => x.Service).ToList();

                    foreach (string service in services)
                    {
                        if (service.Contains("Beach") || service.Contains("Sea"))
                        {
                            placesDTO.Add(new PlaceDTO()
                            {
                                PlaceId = p.PlaceId,
                                Location = p.Location,
                                Type = p.Type,
                                DailyPrice = p.DailyPrice,
                                AvgRating = avgRate,
                                ImagesUrls = imgUrls

                            });
                        }
                    }
                }
                return View(placesDTO);
            }
        }

        public ActionResult desert()
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).ToList();
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
                    List<string> services = _context.Place_Service.Where(x => x.PlaceId == p.PlaceId).Select(x => x.Service).ToList();

                    foreach (string service in services)
                    {
                        if (service.Contains("Desert"))
                        {
                            placesDTO.Add(new PlaceDTO()
                            {
                                PlaceId = p.PlaceId,
                                Location = p.Location,
                                Type = p.Type,
                                DailyPrice = p.DailyPrice,
                                AvgRating = avgRate,
                                ImagesUrls = imgUrls

                            });
                        }
                    }
                }
                return View(placesDTO);
            }
        }
        public ActionResult garden()
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).ToList();
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
                    List<string> services = _context.Place_Service.Where(x => x.PlaceId == p.PlaceId).Select(x => x.Service).ToList();

                    foreach (string service in services)
                    {
                        if (service.Contains("Garden"))
                        {
                            placesDTO.Add(new PlaceDTO()
                            {
                                PlaceId = p.PlaceId,
                                Location = p.Location,
                                Type = p.Type,
                                DailyPrice = p.DailyPrice,
                                AvgRating = avgRate,
                                ImagesUrls = imgUrls

                            });
                        }
                    }
                }
                return View(placesDTO);
            }
        }

        public ActionResult lake()
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).ToList();
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
                    List<string> services = _context.Place_Service.Where(x => x.PlaceId == p.PlaceId).Select(x => x.Service).ToList();

                    foreach (string service in services)
                    {
                        if (service.Contains("Lake"))
                        {
                            placesDTO.Add(new PlaceDTO()
                            {
                                PlaceId = p.PlaceId,
                                Location = p.Location,
                                Type = p.Type,
                                DailyPrice = p.DailyPrice,
                                AvgRating = avgRate,
                                ImagesUrls = imgUrls

                            });
                        }
                    }
                }
                return View(placesDTO);
            }
        }

        public ActionResult mountain()
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).ToList();
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
                    List<string> services = _context.Place_Service.Where(x => x.PlaceId == p.PlaceId).Select(x => x.Service).ToList();

                    foreach (string service in services)
                    {
                        if (service.Contains("Mountain"))
                        {
                            placesDTO.Add(new PlaceDTO()
                            {
                                PlaceId = p.PlaceId,
                                Location = p.Location,
                                Type = p.Type,
                                DailyPrice = p.DailyPrice,
                                AvgRating = avgRate,
                                ImagesUrls = imgUrls

                            });
                        }
                    }
                }
                return View(placesDTO);
            }
        }
        [HttpPost("filter")]
        public ActionResult filter(int maxPrice, int minPrice, int bedNum, int bedRoomNum, int bathRoomNum, string type)
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).
            Where(x => x.DailyPrice >= minPrice && x.DailyPrice <= maxPrice && x.BedNumber == bedNum && x.BedroomNumber == bedRoomNum && x.BathroomNumber == bathRoomNum && x.Type == type).ToList();
            if (places.Count == 0)
            {
                //return Content("No data match the requirement");
                return View("notFound");
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
                        PlaceId = p.PlaceId,
                        Location = p.Location,
                        Type = p.Type,
                        DailyPrice = p.DailyPrice,
                        AvgRating = avgRate,
                        ImagesUrls = imgUrls

                    }
                    );
                }
                return View(placesDTO);
            }
        }

        [HttpPost("search")]
        public ActionResult search(string location)
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).Where(x => x.Location.Contains(location)).ToList();
            if (places.Count == 0)
            {
                //return Content("No data match the requirement");
                return View("notFound");
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
                        PlaceId = p.PlaceId,
                        Location = p.Location,
                        Type = p.Type,
                        DailyPrice = p.DailyPrice,
                        AvgRating = avgRate,
                        ImagesUrls = imgUrls

                    }
                    );
                }
                return View(placesDTO);
            }
        }

        [HttpGet("placeInDetail")]
        public ActionResult placeInDetail(int id)
        {
            Place place = _context.Places.Include(p => p.Reviews).Include(p => p.Owner).FirstOrDefault(p => p.PlaceId == id);

            if (place == null)
            {
                return NotFound();
            }
            else
            {
                List<string> imgUrls = _context.Place_Image.Where(x => x.PlaceId == place.PlaceId).Select(x => x.ImageName).ToList();
                List<string> services = _context.Place_Service.Where(x => x.PlaceId == place.PlaceId).Select(x => x.Service).ToList();
                List<string> phones = _context.Owner_Phone.Where(x => x.OwnerId == place.Owner.OwnerId).Select(x => x.PhoneNumber).ToList();

                PlaceDetailsDTO placeDetailDTO = new PlaceDetailsDTO()
                {
                    PlaceId = place.PlaceId,
                    Description = place.Description,
                    Location = place.Location,
                    Map = place.Map,
                    AvgRating = place.Reviews.Average(p => p.Ratings),
                    ReviewsNumber = place.Reviews.Count(),
                    ImagesUrls = imgUrls,
                    Type = place.Type,
                    OwnerName = place.Owner.FirstName,
                    BedroomNumber = place.BedroomNumber,
                    BedNumber = place.BedNumber,
                    BathroomNumber = place.BathroomNumber,
                    Services = services,
                    Reviews = place.Reviews,
                    Owner = place.Owner,
                    OwnerPhones = phones,
                    Reserve = new ReserveDTO()
                    {
                        PlaceId = place.PlaceId,
                        DailyPrice = place.DailyPrice,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(5),
                        GuestsNumber = 1,
                        ServicesPrice = _context.Place_Service.Where(x => x.PlaceId == place.PlaceId).Sum(x => x.Price),
                    }
                };
                return View(placeDetailDTO);
            }
        }

        [Authorize]
        public ActionResult reserve(int placeId, int dailyPrice, DateTime startDate, DateTime endDate, int guests, int services)
        {
            ReserveDTO reserveDTO = new ReserveDTO()
            {
                PlaceId = placeId,
                DailyPrice = dailyPrice,
                StartDate = startDate,
                EndDate = endDate,
                GuestsNumber = guests,
                ServicesPrice = services,
                Duration = (endDate - startDate).Days,
                DailypriceInDuration = dailyPrice * (endDate - startDate).Days,
                TotalPrice = dailyPrice * guests * (endDate - startDate).Days + services,
            };
            return View(reserveDTO);
        }

        [Authorize]
        public async Task<IActionResult> confirmReserve(int placeId, DateTime startDate, DateTime endDate, string paymentType, int guests)
        {
            var rented = _context.Rent.Where(x => x.PlaceId == placeId).Include(x=> x.Contract).ToList();
            

            if (rented.Count > 0)
            {
                foreach(var item in rented)
                {
                    var rentedStartDate = item.Contract.StartDate;
                    var rentedEndDate = item.Contract.EndDate;
                    var duration = (rentedEndDate - rentedStartDate).Days;
                    var date = rentedStartDate;

                    if (rentedStartDate.Year == rentedEndDate.Year)
                    {
                        if (rentedStartDate.Month == rentedEndDate.Month)
                        {
                            for (int i = 0; i < duration; i++)
                            {
                                if (date == startDate)
                                {
                                    return View("rented", rented);
                                }
                                date = date.AddDays(1);
                            }
                        }
                    }
                }
                
            }

            Models.Contract contract = new Models.Contract()
            {
                StartDate = startDate,
                EndDate = endDate,
                PaymentType = paymentType,
            };
            _context.Add(contract);
            await _context.SaveChangesAsync();

            Rent rent = new Rent()
            {
                CustomerId = int.Parse(User.Identity.Name),
                PlaceId = placeId,
                ContractId = contract.ContractId,
                GuestsNumber = guests,
                Customer = _context.Customers.FirstOrDefault(m => m.CustomerId == int.Parse(User.Identity.Name)),
                Place = _context.Places.FirstOrDefault(m => m.PlaceId == placeId),
                Contract = contract,
            };
            _context.Add(rent);
            await _context.SaveChangesAsync();

            return View(rent);

        }

    }
}