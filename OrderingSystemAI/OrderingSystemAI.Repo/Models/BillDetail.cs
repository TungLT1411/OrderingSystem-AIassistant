using System;
using System.Collections.Generic;

namespace OrderingSystemAI.Repo.Models;

public partial class BillDetail
{
    public int Id { get; set; }

    public int? BillId { get; set; }

    public string? FoodName { get; set; }

    public decimal? FoodPrice { get; set; }

    public int? Quantity { get; set; }

    public virtual Bill? Bill { get; set; }
}
