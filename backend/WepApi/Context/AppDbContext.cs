using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WepApi.Models;

namespace WepApi.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<bank_account> bank_accounts { get; set; }

    public virtual DbSet<bank_transaction> bank_transactions { get; set; }

    public virtual DbSet<budget> budgets { get; set; }

    public virtual DbSet<cash_wallet> cash_wallets { get; set; }

    public virtual DbSet<credit_card> credit_cards { get; set; }

    public virtual DbSet<credit_card_transaction> credit_card_transactions { get; set; }

    public virtual DbSet<debt> debts { get; set; }

    public virtual DbSet<exchange_rate> exchange_rates { get; set; }

    public virtual DbSet<expense> expenses { get; set; }

    public virtual DbSet<expense_category> expense_categories { get; set; }

    public virtual DbSet<income> incomes { get; set; }

    public virtual DbSet<income_category> income_categories { get; set; }

    public virtual DbSet<notification> notifications { get; set; }

    public virtual DbSet<recurring_payment> recurring_payments { get; set; }

    public virtual DbSet<report> reports { get; set; }

    public virtual DbSet<savings_goal> savings_goals { get; set; }

    public virtual DbSet<taxis> taxes { get; set; }

    public virtual DbSet<user> users { get; set; }

    public virtual DbSet<virtual_wallet> virtual_wallets { get; set; }

    public virtual DbSet<virtual_wallet_transaction> virtual_wallet_transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-26PNQDT;Database=FinanceTracker;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<bank_account>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__bank_acc__3213E83F87B09E25");

            entity.HasIndex(e => e.account_number, "UQ__bank_acc__AF91A6ADAE4F5886").IsUnique();

            entity.Property(e => e.account_number)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.balance).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.bank_name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.created_at).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.updated_at).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.user).WithMany(p => p.bank_accounts)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__bank_acco__user___3E52440B");
        });

        modelBuilder.Entity<bank_transaction>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__bank_tra__3213E83F9F69FCC4");

            entity.Property(e => e.amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.description).IsUnicode(false);
            entity.Property(e => e.transaction_date).HasColumnType("datetime");
            entity.Property(e => e.transaction_type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.bank_account).WithMany(p => p.bank_transactions)
                .HasForeignKey(d => d.bank_account_id)
                .HasConstraintName("FK__bank_tran__bank___4316F928");
        });

        modelBuilder.Entity<budget>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__budgets__3213E83FDDD143B0");

            entity.Property(e => e.amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.category)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.period)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.budgets)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__budgets__user_id__5EBF139D");
        });

        modelBuilder.Entity<cash_wallet>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__cash_wal__3213E83FC48FA207");

            entity.Property(e => e.amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.currency)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.cash_wallets)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__cash_wall__user___46E78A0C");
        });

        modelBuilder.Entity<credit_card>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__credit_c__3213E83F945B8E02");

            entity.HasIndex(e => e.card_number, "UQ__credit_c__1E6E0AF422F19A6F").IsUnique();

            entity.Property(e => e.balance).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.card_limit).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.card_number)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.credit_cards)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__credit_ca__user___4BAC3F29");
        });

        modelBuilder.Entity<credit_card_transaction>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__credit_c__3213E83F6C7E51C3");

            entity.Property(e => e.amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.description).IsUnicode(false);
            entity.Property(e => e.transaction_date).HasColumnType("datetime");
            entity.Property(e => e.transaction_type)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.credit_card).WithMany(p => p.credit_card_transactions)
                .HasForeignKey(d => d.credit_card_id)
                .HasConstraintName("FK__credit_ca__credi__5070F446");
        });

        modelBuilder.Entity<debt>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__debts__3213E83FAFE25D7F");

            entity.Property(e => e.amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.debt_type)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.interest_rate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.debts)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__debts__user_id__5441852A");
        });

        modelBuilder.Entity<exchange_rate>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__exchange__3213E83F6D28B32D");

            entity.Property(e => e.from_currency)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.rate).HasColumnType("decimal(15, 6)");
            entity.Property(e => e.rate_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.to_currency)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<expense>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__expenses__3213E83F5F95C908");

            entity.Property(e => e.amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.category)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.description).IsUnicode(false);
            entity.Property(e => e.expense_date).HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.expenses)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__expenses__user_i__59063A47");
        });

        modelBuilder.Entity<expense_category>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__expense___3213E83F272B4207");

            entity.Property(e => e.category_name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.expense_categories)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__expense_c__user___76969D2E");
        });

        modelBuilder.Entity<income>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__income__3213E83FEB72F7EF");

            entity.ToTable("income");

            entity.Property(e => e.amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.income_date).HasColumnType("datetime");
            entity.Property(e => e.source)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.user).WithMany(p => p.incomes)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__income__user_id__5BE2A6F2");
        });

        modelBuilder.Entity<income_category>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__income_c__3213E83FBB2FEE31");

            entity.Property(e => e.category_name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.income_categories)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__income_ca__user___7B5B524B");
        });

        modelBuilder.Entity<notification>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__notifica__3213E83FC1DB14A4");

            entity.Property(e => e.is_read).HasDefaultValue(false);
            entity.Property(e => e.message).IsUnicode(false);
            entity.Property(e => e.notification_date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.notification_type)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.user).WithMany(p => p.notifications)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__notificat__user___00200768");
        });

        modelBuilder.Entity<recurring_payment>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__recurrin__3213E83F7EB1972E");

            entity.Property(e => e.amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.frequency)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.payment_type)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.user).WithMany(p => p.recurring_payments)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__recurring__user___07C12930");
        });

        modelBuilder.Entity<report>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__reports__3213E83F8B555539");

            entity.Property(e => e.content).IsUnicode(false);
            entity.Property(e => e.generated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.report_type)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.user).WithMany(p => p.reports)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__reports__user_id__6A30C649");
        });

        modelBuilder.Entity<savings_goal>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__savings___3213E83F6137A32F");

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.current_amount)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(15, 2)");
            entity.Property(e => e.goal_name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.target_amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.user).WithMany(p => p.savings_goals)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__savings_g__user___6477ECF3");
        });

        modelBuilder.Entity<taxis>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__taxes__3213E83FB8FB8A67");

            entity.Property(e => e.amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.paid).HasDefaultValue(false);
            entity.Property(e => e.tax_type)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.user).WithMany(p => p.taxes)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__taxes__user_id__0C85DE4D");
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__users__3213E83F25BADF82");

            entity.HasIndex(e => e.email, "UQ__users__AB6E6164158ADC7D").IsUnique();

            entity.HasIndex(e => e.username, "UQ__users__F3DBC572C636285D").IsUnique();

            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.password_hash).IsUnicode(false);
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.username)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<virtual_wallet>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__virtual___3213E83FBA632425");

            entity.HasIndex(e => e.wallet_id, "UQ__virtual___0EE6F040BD8D282C").IsUnique();

            entity.Property(e => e.balance).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.created_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.currency)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.updated_at)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.wallet_id)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.wallet_name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.user).WithMany(p => p.virtual_wallets)
                .HasForeignKey(d => d.user_id)
                .HasConstraintName("FK__virtual_w__user___6EF57B66");
        });

        modelBuilder.Entity<virtual_wallet_transaction>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__virtual___3213E83FE660811C");

            entity.Property(e => e.amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.description).IsUnicode(false);
            entity.Property(e => e.transaction_date).HasColumnType("datetime");

            entity.HasOne(d => d.virtual_wallet).WithMany(p => p.virtual_wallet_transactions)
                .HasForeignKey(d => d.virtual_wallet_id)
                .HasConstraintName("FK__virtual_w__virtu__73BA3083");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
