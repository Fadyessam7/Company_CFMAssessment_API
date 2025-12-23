using System;
using System.Collections.Generic;

namespace Company_CFM.Models;

public partial class Employees
{
    public int ID { get; set; }

    public string? Name { get; set; }

    public decimal? Salary { get; set; }

    public int? Department_Id { get; set; }

    public virtual Departments? Department { get; set; }
}
