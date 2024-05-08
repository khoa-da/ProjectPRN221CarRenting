using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class Reservation
{
    public string ReservationId { get; set; } = null!;

    public decimal? Amount { get; set; }

    public DateOnly? PickupDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public string? PickupLocationId { get; set; }

    public string? ReturnLocationId { get; set; }

    public int? CustomerId { get; set; }

    public string? CarId { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual CrcOffice? PickupLocation { get; set; }
}
