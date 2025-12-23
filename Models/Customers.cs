using System;
using System.Collections.Generic;

namespace Company_CFM.Models;

public partial class Customers
{
    public string ID { get; set; } = null!;

    public string? Name { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
