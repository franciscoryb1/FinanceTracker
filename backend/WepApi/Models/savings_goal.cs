using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class savings_goal
{
    public long id { get; set; }

    public long? user_id { get; set; }

    public string goal_name { get; set; } = null!;

    public decimal target_amount { get; set; }

    public decimal? current_amount { get; set; }

    public DateOnly? due_date { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual user? user { get; set; }
}
