using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class notification
{
    public long id { get; set; }

    public long? user_id { get; set; }

    public string notification_type { get; set; } = null!;

    public string? message { get; set; }

    public DateTime? notification_date { get; set; }

    public bool? is_read { get; set; }

    public virtual user? user { get; set; }
}
