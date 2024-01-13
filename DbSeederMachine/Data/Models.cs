using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DbSeederMachine.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string WorkPosition { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal hSalary { get; set; }

        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }
        public virtual ICollection<GuestManagement> GuestManagements { get; set; }
    }

    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public string CarBrand { get; set; }
        public int Vin { get; set; }
        public string CarState { get; set; }

        public virtual ICollection<DeliveryOrder> DeliveryOrders { get; set; }
        public virtual ICollection<RentedCar> RentedCars { get; set; }
    }

    public class DeliveryOrder
    {
        [Key]
        public int Id { get; set; }
        public string OrderContent { get; set; }
        public DateTime SuggestedDeliveryTime { get; set; }
        public int DeliveryManId { get; set; }
        public string OrderState { get; set; }
        public int ClientsRate { get; set; }

        public int? CarId { get; set; } // Zmienione na nullowalne

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        [ForeignKey("DeliveryManId")]
        public virtual Employee Employee { get; set; }
    }

    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int? IdLoyaltyCard { get; set; } // Nullowalne

        public string OrderDetails { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal OrderPrice { get; set; }

        [ForeignKey("IdLoyaltyCard")]
        public virtual LoyaltyCard LoyaltyCard { get; set; }
    }

    public class LoyaltyCard
    {
        [Key]
        public int CardId { get; set; }
        public string NameOfUser { get; set; }
        public string LastNameOfUser { get; set; }
        public string NIP { get; set; }
        public float Discount { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }

    public class RentedCar
    {
        [Key]
        public int idOfRent { get; set; }
        public int DriverId { get; set; }
        public int CarId { get; set; }
        public DateTime StartOfRent { get; set; }
        public DateTime EndOfRent { get; set; }
        public string CarState { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }

        [ForeignKey("DriverId")]
        public virtual Employee Employee { get; set; }
    }

    public class RestaurantsTable
    {
        [Key]
        public int TableId { get; set; }
        public int ReservationId { get; set; }
        public bool IsNotBroken { get; set; }
        public string Location { get; set; }
        public int MainEmployee { get; set; }

        [ForeignKey("MainEmployee")]
        public virtual Employee Employee { get; set; }
    }

    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public int ClientId { get; set; }
        public int AmountOfPersons { get; set; }
        public DateTime DateOfReservation { get; set; }
        public bool Confirmed { get; set; }
    }

    public class EmployeeTask
    {
        [Key]
        public int TaskId { get; set; }
        public string Duties { get; set; }
        public string Privileges { get; set; }
        public int Employees_id { get; set; }

        [ForeignKey("Employees_id")]
        public virtual Employee Employee { get; set; }
    }
    public class GuestManagement
    {
        [Key]
        public int GuestID { get; set; }
        public int? ReservationID { get; set; }
        public int? LoyaltyCardID { get; set; }
        public int? OrderID { get; set; }
        public int? DeliveryOrderID { get; set; }

        [ForeignKey("ReservationID")]
        public virtual Reservation Reservation { get; set; }

        [ForeignKey("LoyaltyCardID")]
        public virtual LoyaltyCard LoyaltyCard { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        [ForeignKey("DeliveryOrderID")]
        public virtual DeliveryOrder DeliveryOrder { get; set; }
    }
}
