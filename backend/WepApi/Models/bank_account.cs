using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class bank_account
{
    public long id { get; set; }

    public long? user_id { get; set; }

    public string account_number { get; set; } = null!;

    public string bank_name { get; set; } = null!;

    public decimal balance { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual ICollection<bank_transaction> bank_transactions { get; set; } = new List<bank_transaction>();

    public virtual user? user { get; set; }
}
