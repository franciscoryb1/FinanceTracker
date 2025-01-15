using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class cash_wallet
{
    public long id { get; set; }

    public long? user_id { get; set; }

    public decimal amount { get; set; }

    public string currency { get; set; } = null!;

    public DateTime? updated_at { get; set; }

    public virtual user? user { get; set; }
}
