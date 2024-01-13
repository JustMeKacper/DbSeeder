using Microsoft.AspNetCore.Mvc;
using DbSeederMachine.Data;
using Bogus;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DbSeederMachine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeederController : ControllerBase
    {
        private readonly RestContext _context;
        private readonly ILogger<SeederController> _logger;

        public SeederController(RestContext context, ILogger<SeederController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpPost("GenerateMultiple")]
        public IActionResult SeedMultiData([FromQuery]int amount)
        {
            if (amount <= 0) { return BadRequest(); }
            for (int i = 0; i < amount; i++)
            {
                SeedData();
            }
            return Ok();
        }

        [HttpPost("GenerateSingle")]
        public IActionResult SeedData()
        {
            var employee = new Faker<Employee>()
                .RuleFor(e => e.Name, f => f.Name.FirstName())
                .RuleFor(e => e.LastName, f => f.Name.LastName())
                .RuleFor(e => e.WorkPosition, f => f.Name.JobTitle())
                .RuleFor(e => e.hSalary, f => f.Random.Decimal(2000, 5000))
                .Generate();
            _context.Employees.Add(employee);
            _context.SaveChanges();

            var car = new Faker<Car>()
                .RuleFor(c => c.CarModel, f => f.Vehicle.Model())
                .RuleFor(c => c.CarBrand, f => f.Vehicle.Manufacturer())
                .RuleFor(c => c.Vin, f => f.Random.Int(0))
                .RuleFor(c => c.CarState, f => f.Lorem.Word())
                .Generate();
            _context.Cars.Add(car);
            _context.SaveChanges();

            var loyaltyCard = new Faker<LoyaltyCard>()
                .RuleFor(l => l.NameOfUser, f => f.Name.FirstName())
                .RuleFor(l => l.LastNameOfUser, f => f.Name.LastName())
                .RuleFor(l => l.NIP, f => f.Finance.Account())
                .RuleFor(l => l.Discount, f => f.Random.Float(0, 50))
                .Generate();
            _context.LoyaltyCards.Add(loyaltyCard);
            _context.SaveChanges();

            var reservation = new Faker<Reservation>()
                .RuleFor(r => r.ClientId, f => f.Random.Int(1))
                .RuleFor(r => r.AmountOfPersons, f => f.Random.Int(1, 10))
                .RuleFor(r => r.DateOfReservation, f => f.Date.Soon())
                .RuleFor(r => r.Confirmed, f => f.Random.Bool())
                .Generate();
            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            var deliveryOrder = new Faker<DeliveryOrder>()
                .RuleFor(d => d.OrderContent, f => f.Lorem.Sentence())
                .RuleFor(d => d.SuggestedDeliveryTime, f => f.Date.Soon())
                .RuleFor(d => d.OrderState, f => f.Lorem.Word())
                .RuleFor(d => d.ClientsRate, f => f.Random.Int(1, 5))
                .RuleFor(d => d.CarId, car.CarId)
                .RuleFor(d => d.DeliveryManId, employee.Id)
                .Generate();
            _context.DeliveryOrders.Add(deliveryOrder);
            _context.SaveChanges();

            var order = new Faker<Order>()
                .RuleFor(o => o.OrderDetails, f => f.Lorem.Sentence())
                .RuleFor(o => o.OrderPrice, f => f.Finance.Amount(100, 1000))
                .RuleFor(o => o.IdLoyaltyCard, loyaltyCard.CardId)
                .Generate();
            _context.Orders.Add(order);
            _context.SaveChanges();

            var guestManagement = new Faker<GuestManagement>()
                .RuleFor(g => g.ReservationID, reservation.ReservationId)
                .RuleFor(g => g.LoyaltyCardID, loyaltyCard.CardId)
                .RuleFor(g => g.OrderID, order.OrderId)
                .RuleFor(g => g.DeliveryOrderID, deliveryOrder.Id)
                .Generate();
            _context.GuestManagements.Add(guestManagement);
            _context.SaveChanges();

            var rentedCar = new Faker<RentedCar>()
                .RuleFor(rc => rc.CarId, car.CarId)
                .RuleFor(rc => rc.DriverId, employee.Id)
                .RuleFor(rc => rc.StartOfRent, f => f.Date.Recent())
                .RuleFor(rc => rc.EndOfRent, f => f.Date.Soon())
                .RuleFor(rc => rc.CarState, f => f.Lorem.Word())
                .Generate();
            _context.RentedCars.Add(rentedCar);
            _context.SaveChanges();

            var restaurantTable = new Faker<RestaurantsTable>()
                .RuleFor(rt => rt.ReservationId, reservation.ReservationId)
                .RuleFor(rt => rt.IsNotBroken, f => f.Random.Bool())
                .RuleFor(rt => rt.Location, f => f.Address.City())
                .RuleFor(rt => rt.MainEmployee, employee.Id)
                .Generate();
            _context.RestaurantsTables.Add(restaurantTable);
            _context.SaveChanges();

            var employeeTask = new Faker<EmployeeTask>()
                .RuleFor(et => et.Duties, f => f.Lorem.Sentence())
                .RuleFor(et => et.Privileges, f => f.Lorem.Sentence())
                .RuleFor(et => et.Employees_id, employee.Id)
                .Generate();
            _context.EmployeeTasks.Add(employeeTask);
            _context.SaveChanges();

            return Ok("Dane zosta³y dodane.");

        }
        [HttpPost("Clear")]
        public IActionResult ClearAllData()
        {
            try
            {
                // Usuñ dane z tabeli GuestManagements
                _context.Database.ExecuteSqlRaw("DELETE FROM GuestManagements");

                // Usuñ dane z tabeli DeliveryOrders
                _context.Database.ExecuteSqlRaw("DELETE FROM DeliveryOrders");

                // Usuñ dane z pozosta³ych tabel
                _context.Database.ExecuteSqlRaw("DELETE FROM Employees");
                _context.Database.ExecuteSqlRaw("DELETE FROM Cars");
                _context.Database.ExecuteSqlRaw("DELETE FROM Orders");
                _context.Database.ExecuteSqlRaw("DELETE FROM LoyaltyCards");
                _context.Database.ExecuteSqlRaw("DELETE FROM RentedCars");
                _context.Database.ExecuteSqlRaw("DELETE FROM RestaurantsTables");
                _context.Database.ExecuteSqlRaw("DELETE FROM Reservations");
                _context.Database.ExecuteSqlRaw("DELETE FROM EmployeeTasks");

                return Ok("Wszystkie dane zosta³y wyczyszczone.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Wyst¹pi³ b³¹d podczas usuwania danych: {ex.Message}");
            }
        }
    }
    }
