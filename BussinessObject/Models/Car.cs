using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class Car
{
    public string CarId { get; set; } = null!;

    public string? CurrentLocationId { get; set; }

    public string? TypeId { get; set; }

    public string? Color { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public string? Description { get; set; }

    public DateOnly? PurchDate { get; set; }

    public virtual CrcOffice? CurrentLocation { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual CarType? Type { get; set; }
}
