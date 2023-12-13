using CarSharingManager.Data.Model;
using CarSharingManager.Data.Repositories;
using FluentAssertions;
using Moq;

namespace CarSharingManager.Services.Tests;

[TestFixture]
public class CarServiceTests
{
    ICarService carService;
    Mock<ICarRepository> carRepositoryMock;

    [SetUp]
    public void Setup()
    {
        carRepositoryMock = new Mock<ICarRepository>();

        carService = new CarService(carRepositoryMock.Object);
    }

    [Test]
    public void AddCar_Should_Accept_When_Maker_And_Model_Exists()
    {
        //Arange 
        Car car = new()
        {
            Id = 1,
            Make = "Audi",
            Model = "A6",
            LicensePlate = null,
            CarStatus = CarStatuses.Available,
            Year = 2018
        };
        bool expect = true;

        // Act
        bool actual = carService.AddCar(car);

        // Assert
        actual.Should().BeTrue();
    }

    [Test]
    public void AddCar_Should_Reject_When_Maker_And_Model_NotExists()
    {
        //Arange 
        Car car = new()
        {
            Id = 1,
            Make = "",
            Model = null,
            LicensePlate = null,
            CarStatus = CarStatuses.Available,
            Year = 2018
        };
        bool expect = false;

        // Act
        bool actual = carService.AddCar(car);

        // Assert
        actual.Should().BeFalse();
    }

    [TestCase(1999, false)]
    [TestCase(2000, true)]
    [TestCase(2001, true)]
    [TestCase(2023, true)]
    [TestCase(2030, false)]
    public void AddCar_Should_Accept_Cars_InRange2000_ToCurrentYear(int year, bool result)
    {
        //Arange 
        Car car = new()
        {
            Id = 1,
            Make = "Audi",
            Model = "A6",
            LicensePlate = null,
            CarStatus = CarStatuses.Available,
            Year = year
        };
        bool expect = true;

        // Act
        bool actual = carService.AddCar(car);

        // Assert
        actual.Should().Be(result);
    }

    [Test]
    public void AddCar_Should_Save_Entity_InRepository()
    {
        //Arange 
        Car car = new()
        {
            Id = 1,
            Make = "Audi",
            Model = "A6",
            LicensePlate = null,
            CarStatus = CarStatuses.Available,
            Year = 2018
        };

        carRepositoryMock.Setup(c => c.Add(It.IsAny<Car>())).Verifiable();

        // Act
        carService.AddCar(car);

        // Assert
        carRepositoryMock.Verify(c => c.Add(It.IsAny<Car>()), Times.Once());

    }
}