using System;
using System.Collections.Generic;

namespace Company_CFM.Models;

public partial class Products
{
    public int ID { get; set; }

    public string? Name { get; set; }

    public decimal? Cost { get; set; }

    public virtual ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
