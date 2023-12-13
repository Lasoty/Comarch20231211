using CarSharingManager.Data.Model;

namespace CarSharingManager.Services;

public interface IReservationService
{
    Reservation ReserveCar(Customer customer, Car car);
    bool CancelReservation(Reservation reservation);
}

public class ReservationService : IReservationService
{
    public Reservation ReserveCar(Customer customer, Car car)
    {
        throw new NotImplementedException();
    }

    public bool CancelReservation(Reservation reservation)
    {
        throw new NotImplementedException();
    }
}