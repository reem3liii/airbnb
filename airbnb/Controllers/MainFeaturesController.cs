using airbnb.Models;
using Microsoft.AspNetCore.Authorization;
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

        public ActionResult getAll()
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).ToList();

            if (places.Count == 0)
            {
                return NotFound();
            }
            else
            {
                List<PlaceViewModel> placesModel = new List<PlaceViewModel>();
                foreach (Place p in places)
                {
                    double avgRate = p.Reviews.Average(p => p.Ratings);

                    List<string> imgUrls = _context.Place_Image.Where(x => x.PlaceId == p.PlaceId).Select(x => x.ImageName).ToList();
                    placesModel.Add(new PlaceViewModel()
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
                return View(placesModel);
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
                List<PlaceViewModel> placesModel = new List<PlaceViewModel>();
                foreach (Place p in places)
                {
                    double avgRate = p.Reviews.Average(p => p.Ratings);
                    List<string> imgUrls = _context.Place_Image.Where(x => x.PlaceId == p.PlaceId).Select(x => x.ImageName).ToList();
                    if (avgRate >= 4)
                    {
                        placesModel.Add(new PlaceViewModel()
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
                return View(placesModel);
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
                List<PlaceViewModel> placesModel = new List<PlaceViewModel>();
                foreach (Place p in places)
                {
                    double avgRate = p.Reviews.Average(p => p.Ratings);
                    List<string> imgUrls = _context.Place_Image.Where(x => x.PlaceId == p.PlaceId).Select(x => x.ImageName).ToList();
                    List<string> services = _context.Place_Service.Where(x => x.PlaceId == p.PlaceId).Select(x => x.Service).ToList();

                    foreach (string service in services)
                    {
                        if (service.Contains("pool") || service.Contains("Pool"))
                        {
                            placesModel.Add(new PlaceViewModel()
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
                return View(placesModel);
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
                List<PlaceViewModel> placesModel = new List<PlaceViewModel>();
                foreach (Place p in places)
                {
                    double avgRate = p.Reviews.Average(p => p.Ratings);
                    List<string> imgUrls = _context.Place_Image.Where(x => x.PlaceId == p.PlaceId).Select(x => x.ImageName).ToList();
                    List<string> services = _context.Place_Service.Where(x => x.PlaceId == p.PlaceId).Select(x => x.Service).ToList();

                    foreach (string service in services)
                    {
                        if (service.Contains("Beach") || service.Contains("Sea"))
                        {
                            placesModel.Add(new PlaceViewModel()
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
                return View(placesModel);
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
                List<PlaceViewModel> placesModel = new List<PlaceViewModel>();
                foreach (Place p in places)
                {
                    double avgRate = p.Reviews.Average(p => p.Ratings);
                    List<string> imgUrls = _context.Place_Image.Where(x => x.PlaceId == p.PlaceId).Select(x => x.ImageName).ToList();
                    List<string> services = _context.Place_Service.Where(x => x.PlaceId == p.PlaceId).Select(x => x.Service).ToList();

                    foreach (string service in services)
                    {
                        if (service.Contains("Desert"))
                        {
                            placesModel.Add(new PlaceViewModel()
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
                return View(placesModel);
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
                List<PlaceViewModel> placesModel = new List<PlaceViewModel>();
                foreach (Place p in places)
                {
                    double avgRate = p.Reviews.Average(p => p.Ratings);
                    List<string> imgUrls = _context.Place_Image.Where(x => x.PlaceId == p.PlaceId).Select(x => x.ImageName).ToList();
                    List<string> services = _context.Place_Service.Where(x => x.PlaceId == p.PlaceId).Select(x => x.Service).ToList();

                    foreach (string service in services)
                    {
                        if (service.Contains("Garden"))
                        {
                            placesModel.Add(new PlaceViewModel()
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
                return View(placesModel);
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
                List<PlaceViewModel> placesModel = new List<PlaceViewModel>();
                foreach (Place p in places)
                {
                    double avgRate = p.Reviews.Average(p => p.Ratings);
                    List<string> imgUrls = _context.Place_Image.Where(x => x.PlaceId == p.PlaceId).Select(x => x.ImageName).ToList();
                    List<string> services = _context.Place_Service.Where(x => x.PlaceId == p.PlaceId).Select(x => x.Service).ToList();

                    foreach (string service in services)
                    {
                        if (service.Contains("Lake"))
                        {
                            placesModel.Add(new PlaceViewModel()
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
                return View(placesModel);
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
                List<PlaceViewModel> placesModel = new List<PlaceViewModel>();
                foreach (Place p in places)
                {
                    double avgRate = p.Reviews.Average(p => p.Ratings);
                    List<string> imgUrls = _context.Place_Image.Where(x => x.PlaceId == p.PlaceId).Select(x => x.ImageName).ToList();
                    List<string> services = _context.Place_Service.Where(x => x.PlaceId == p.PlaceId).Select(x => x.Service).ToList();

                    foreach (string service in services)
                    {
                        if (service.Contains("Mountain"))
                        {
                            placesModel.Add(new PlaceViewModel()
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
                return View(placesModel);
            }
        }

        [HttpPost]
        public ActionResult filter(int maxPrice, int minPrice, int bedNum, int bedRoomNum, int bathRoomNum, string type)
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).
            Where(x => x.DailyPrice >= minPrice && x.DailyPrice <= maxPrice && x.BedNumber == bedNum && x.BedroomNumber == bedRoomNum && x.BathroomNumber == bathRoomNum && x.Type == type).ToList();
            if (places.Count == 0)
            {
                return View("notFound");
            }
            else
            {
                List<PlaceViewModel> placesModel = new List<PlaceViewModel>();
                foreach (Place p in places)
                {
                    double avgRate = p.Reviews.Average(p => p.Ratings);
                    List<string> imgUrls = _context.Place_Image.Where(x => x.PlaceId == p.PlaceId).Select(x => x.ImageName).ToList();
                    placesModel.Add(new PlaceViewModel()
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
                return View(placesModel);
            }
        }

        [HttpPost]
        public ActionResult search(string location)
        {
            List<Place> places = _context.Places.Include(p => p.Reviews).Where(x => x.Location.Contains(location)).ToList();
            if (places.Count == 0)
            {
                return View("notFound");
            }
            else
            {
                List<PlaceViewModel> placesModel = new List<PlaceViewModel>();
                foreach (Place p in places)
                {
                    double avgRate = p.Reviews.Average(p => p.Ratings);
                    List<string> imgUrls = _context.Place_Image.Where(x => x.PlaceId == p.PlaceId).Select(x => x.ImageName).ToList();
                    placesModel.Add(new PlaceViewModel()
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
                return View(placesModel);
            }
        }

        [HttpGet]
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

                PlaceDetailsViewModel placeDetailModel = new PlaceDetailsViewModel()
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
                    Reserve = new ReserveViewModel()
                    {
                        PlaceId = place.PlaceId,
                        DailyPrice = place.DailyPrice,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(5),
                        GuestsNumber = 1,
                        ServicesPrice = _context.Place_Service.Where(x => x.PlaceId == place.PlaceId).Sum(x => x.Price),
                    }
                };
                return View(placeDetailModel);
            }
        }

        [Authorize]
        public ActionResult reserve(int placeId, int dailyPrice, DateTime startDate, DateTime endDate, int guests, int services)
        {
            ReserveViewModel reserveModel = new ReserveViewModel()
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
            return View(reserveModel);
        }

        [Authorize]
        public async Task<IActionResult> confirmReserve(int placeId, DateTime startDate, DateTime endDate, string paymentType, int guests)
        {
            var rented = _context.Rent.Where(x => x.PlaceId == placeId).Include(x => x.Contract).ToList();

            if (rented.Count > 0)
            {
                foreach (var item in rented)
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

        [Authorize]    
        public  IActionResult myBookings()
        {
            var rents = _context.Rent.Where(x => x.CustomerId == int.Parse(User.Identity.Name)).Include(x=> x.Place).Include(x=> x.Contract).ToList();

            if (rents.Count > 0)
            {
                var bookings = new List<BookingViewModel>();

                foreach (var rent in rents)
                {
                    List<string> imgs = _context.Place_Image.Where(x => x.PlaceId == rent.PlaceId).Select(x => x.ImageName).ToList();

                    var book = new BookingViewModel()
                    {
                        PlaceId=rent.PlaceId,
                        Description= rent.Place.Description,
                        Location= rent.Place.Location,
                        Type= rent.Place.Type,
                        Map= rent.Place.Map,
                        Images=imgs,
                        DailyPrice= rent.Place.DailyPrice,
                        BedNumber= rent.Place.BedNumber,
                        BedroomNumber= rent.Place.BedroomNumber,
                        BathroomNumber= rent.Place.BathroomNumber,
                        StartDate= rent.Contract.StartDate,
                        EndDate= rent.Contract.EndDate,
                        GuestsNumber=rent.GuestsNumber,
                    };

                    bookings.Add(book);
                }

                return View(bookings);

            }
            else
            {
                return View("noBooking");
            }

        }
    }
}