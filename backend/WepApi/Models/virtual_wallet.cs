using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class virtual_wallet
{
    public long id { get; set; }

    public long? user_id { get; set; }

    public string wallet_name { get; set; } = null!;

    public string wallet_id { get; set; } = null!;

    public decimal balance { get; set; }

    public string currency { get; set; } = null!;

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual user? user { get; set; }

    public virtual ICollection<virtual_wallet_transaction> virtual_wallet_transactions { get; set; } = new List<virtual_wallet_transaction>();
}
