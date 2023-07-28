using System;
using System.Collections.Generic;

namespace OrderingSystemAI.Repo.Models;

public partial class SubOrder
{
    public int Id { get; set; }

    public string? FoodName { get; set; }

    public decimal? FoodPrice { get; set; }

    public int? Quantity { get; set; }
}
