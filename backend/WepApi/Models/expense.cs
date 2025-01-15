using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class expense
{
    public long id { get; set; }

    public long? user_id { get; set; }

    public string category { get; set; } = null!;

    public decimal amount { get; set; }

    public DateTime expense_date { get; set; }

    public string? description { get; set; }

    public virtual user? user { get; set; }
}
