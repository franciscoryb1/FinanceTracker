using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class credit_card_transaction
{
    public long id { get; set; }

    public long? credit_card_id { get; set; }

    public decimal amount { get; set; }

    public DateTime transaction_date { get; set; }

    public string? description { get; set; }

    public string transaction_type { get; set; } = null!;

    public virtual credit_card? credit_card { get; set; }
}
