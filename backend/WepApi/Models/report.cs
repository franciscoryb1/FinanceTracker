using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class report
{
    public long id { get; set; }

    public long? user_id { get; set; }

    public string report_type { get; set; } = null!;

    public DateTime? generated_at { get; set; }

    public string? content { get; set; }

    public virtual user? user { get; set; }
}
