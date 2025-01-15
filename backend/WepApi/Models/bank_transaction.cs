using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class bank_transaction
{
    public long id { get; set; }

    public long? bank_account_id { get; set; }

    public decimal amount { get; set; }

    public DateTime transaction_date { get; set; }

    public string? description { get; set; }

    public string transaction_type { get; set; } = null!;

    public virtual bank_account? bank_account { get; set; }
}
