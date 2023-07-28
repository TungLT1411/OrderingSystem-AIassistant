using System;
using System.Collections.Generic;

namespace OrderingSystemAI.Repo.Models;

public partial class Bill
{
    public int Id { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? CreateTime { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();
}
