using CarSharingManager.Data.Model;
using CarSharingManager.Data.Repositories;

namespace CarSharingManager.Services;

public interface ICarService
{
    bool AddCar(Car car);
    void EditCar(Car car);
    bool DeleteCar(int id);
    IEnumerable<Car> FindCar(string filterText);
}

public class CarService : ICarService
{
    private readonly ICarRepository carRepository;

    public CarService(ICarRepository carRepository)
    {
        this.carRepository = carRepository;
    }

    public bool AddCar(Car car)
    {
        if (!ValidateCar(car)) return false;

        carRepository.Add(car);
        return true;
    }

    private static bool ValidateCar(Car car)
    {
        if (car == null)
            return false;

        if (string.IsNullOrWhiteSpace(car.Make) || string.IsNullOrWhiteSpace(car.Model))
            return false;

        if (!(car.Year is >= 2000 and <= 2024)) return false;

        return true;
    }

    public void EditCar(Car car)
    {
        throw new NotImplementedException();
    }

    public bool DeleteCar(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Car> FindCar(string filterText)
    {
        throw new NotImplementedException();
    }
}