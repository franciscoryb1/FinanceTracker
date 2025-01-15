using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class taxis
{
    public long id { get; set; }

    public long? user_id { get; set; }

    public string tax_type { get; set; } = null!;

    public decimal amount { get; set; }

    public DateOnly due_date { get; set; }

    public bool? paid { get; set; }

    public virtual user? user { get; set; }
}
