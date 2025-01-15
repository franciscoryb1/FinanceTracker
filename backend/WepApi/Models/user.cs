using System;
using System.Collections.Generic;

namespace WepApi.Models;

public partial class user
{
    public long id { get; set; }

    public string username { get; set; } = null!;

    public string email { get; set; } = null!;

    public string password_hash { get; set; } = null!;

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual ICollection<bank_account> bank_accounts { get; set; } = new List<bank_account>();

    public virtual ICollection<budget> budgets { get; set; } = new List<budget>();

    public virtual ICollection<cash_wallet> cash_wallets { get; set; } = new List<cash_wallet>();

    public virtual ICollection<credit_card> credit_cards { get; set; } = new List<credit_card>();

    public virtual ICollection<debt> debts { get; set; } = new List<debt>();

    public virtual ICollection<expense_category> expense_categories { get; set; } = new List<expense_category>();

    public virtual ICollection<expense> expenses { get; set; } = new List<expense>();

    public virtual ICollection<income_category> income_categories { get; set; } = new List<income_category>();

    public virtual ICollection<income> incomes { get; set; } = new List<income>();

    public virtual ICollection<notification> notifications { get; set; } = new List<notification>();

    public virtual ICollection<recurring_payment> recurring_payments { get; set; } = new List<recurring_payment>();

    public virtual ICollection<report> reports { get; set; } = new List<report>();

    public virtual ICollection<savings_goal> savings_goals { get; set; } = new List<savings_goal>();

    public virtual ICollection<taxis> taxes { get; set; } = new List<taxis>();

    public virtual ICollection<virtual_wallet> virtual_wallets { get; set; } = new List<virtual_wallet>();
}
