using CarSharingManager.Data.Model;

namespace CarSharingManager.Services;
public interface ICarServicesFacade
{
    bool AddCar(Car car);
    void EditCar(Car car);
    bool DeleteCar(int id);
    IEnumerable<Car> FindCar(string filterText);
    Reservation ReserveCar(Customer  customer, Car car);
    bool CancelReservation(Reservation reservation);
}

public class CarServicesFacade : ICarServicesFacade
{
    private readonly ICarService carService;
    private readonly IReservationService reservationService;

    public CarServicesFacade(ICarService carService, IReservationService reservationService)
    {
        this.carService = carService;
        this.reservationService = reservationService;
    }

    public bool AddCar(Car car) => carService.AddCar(car);

    public void EditCar(Car car) => carService.EditCar(car);

    public bool DeleteCar(int id) => carService.DeleteCar(id);

    public IEnumerable<Car> FindCar(string filterText) => carService.FindCar(filterText);

    public Reservation ReserveCar(Customer customer, Car car) => reservationService.ReserveCar(customer, car);

    public bool CancelReservation(Reservation reservation) => reservationService.CancelReservation(reservation);
}