using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class budget
{
    public long id { get; set; }

    public long? user_id { get; set; }

    public string category { get; set; } = null!;

    public decimal amount { get; set; }

    public string period { get; set; } = null!;

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual user? user { get; set; }
}
