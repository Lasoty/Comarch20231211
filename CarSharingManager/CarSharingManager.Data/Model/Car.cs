namespace CarSharingManager.Data.Model;

public class Car
{
    public int Id { get; set; }

    public string Make { get; set; }

    public string Model { get; set; }

    public string LicensePlate { get; set; }

    public int Year { get; set; }

    public CarStatuses CarStatus { get; set; }
}

public enum CarStatuses
{
    Available,
    Reserved
}