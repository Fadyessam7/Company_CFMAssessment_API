using System;
using System.Collections.Generic;

namespace Company_CFM.Models;

public partial class Departments
{
    public int ID { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Employees> Employees { get; set; } = new List<Employees>();
}
