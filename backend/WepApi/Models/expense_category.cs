using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class expense_category
{
    public long id { get; set; }

    public long? user_id { get; set; }

    public string category_name { get; set; } = null!;

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual user? user { get; set; }
}
