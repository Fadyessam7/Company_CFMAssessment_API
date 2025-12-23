using System;
using System.Collections.Generic;

namespace Company_CFM.Models;

public partial class Orders
{
    public string ID { get; set; } = null!;

    public string? Customer_Id { get; set; }

    public int? Product_Id { get; set; }

    public int? Amount { get; set; }

    public virtual Customers? Customer { get; set; }

    public virtual Products? Product { get; set; }
}
