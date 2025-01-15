using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class credit_card
{
    public long id { get; set; }

    public long? user_id { get; set; }

    public string card_number { get; set; } = null!;

    public decimal card_limit { get; set; }

    public decimal balance { get; set; }

    public DateOnly due_date { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual ICollection<credit_card_transaction> credit_card_transactions { get; set; } = new List<credit_card_transaction>();

    public virtual user? user { get; set; }
}
