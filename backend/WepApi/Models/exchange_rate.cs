using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class exchange_rate
{
    public long id { get; set; }

    public string from_currency { get; set; } = null!;

    public string to_currency { get; set; } = null!;

    public decimal rate { get; set; }

    public DateTime? rate_date { get; set; }
}
