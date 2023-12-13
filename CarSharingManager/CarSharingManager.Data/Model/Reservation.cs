using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingManager.Data.Model;

public class Reservation
{
    public long Id { get; set; }

    public long CarId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public long CustomerId { get; set; }

    public ReservationStatuses Status { get; set; }
}

public enum ReservationStatuses
{
    Active,
    Completed,
    Cancelled
}