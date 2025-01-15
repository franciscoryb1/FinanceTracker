using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class debt
{
    public long id { get; set; }

    public long? user_id { get; set; }

    public string debt_type { get; set; } = null!;

    public decimal amount { get; set; }

    public decimal? interest_rate { get; set; }

    public DateOnly due_date { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual user? user { get; set; }
}
