using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class recurring_payment
{
    public long id { get; set; }

    public long? user_id { get; set; }

    public string payment_type { get; set; } = null!;

    public decimal amount { get; set; }

    public DateOnly due_date { get; set; }

    public string frequency { get; set; } = null!;

    public DateOnly next_payment_date { get; set; }

    public DateTime? created_at { get; set; }

    public virtual user? user { get; set; }
}
