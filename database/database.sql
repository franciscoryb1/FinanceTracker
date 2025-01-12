-- Creación de la base de datos
CREATE DATABASE FinanceTracker;
GO

-- Selección de la base de datos
USE FinanceTracker;
GO

-- Tabla de usuarios
CREATE TABLE users (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(255) UNIQUE NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    password_hash VARCHAR(MAX) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Tabla de cuentas bancarias
CREATE TABLE bank_accounts (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    account_number VARCHAR(255) UNIQUE NOT NULL,
    bank_name VARCHAR(255) NOT NULL,
    balance DECIMAL(15, 2) NOT NULL,
    created_at DATETIME2 DEFAULT GETDATE(),
    updated_at DATETIME2 DEFAULT GETDATE()
);
GO

-- Tabla de transacciones bancarias
CREATE TABLE bank_transactions (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    bank_account_id BIGINT FOREIGN KEY REFERENCES bank_accounts(id),
    amount DECIMAL(15, 2) NOT NULL,
    transaction_date DATETIME NOT NULL,
    description VARCHAR(MAX),
    transaction_type VARCHAR(50) CHECK (transaction_type IN ('credit', 'debit')) NOT NULL
);
GO

-- Tabla de carteras de efectivo
CREATE TABLE cash_wallets (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    amount DECIMAL(15, 2) NOT NULL,
    currency VARCHAR(50) NOT NULL,
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Tabla de tarjetas de crédito
CREATE TABLE credit_cards (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    card_number VARCHAR(255) UNIQUE NOT NULL,
    card_limit DECIMAL(15, 2) NOT NULL,
    balance DECIMAL(15, 2) NOT NULL,
    due_date DATE NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Tabla de transacciones de tarjetas de crédito
CREATE TABLE credit_card_transactions (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    credit_card_id BIGINT FOREIGN KEY REFERENCES credit_cards(id),
    amount DECIMAL(15, 2) NOT NULL,
    transaction_date DATETIME NOT NULL,
    description VARCHAR(MAX),
    transaction_type VARCHAR(50) CHECK (transaction_type IN ('purchase', 'payment')) NOT NULL
);
GO

-- Tabla de deudas
CREATE TABLE debts (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    debt_type VARCHAR(255) NOT NULL,
    amount DECIMAL(15, 2) NOT NULL,
    interest_rate DECIMAL(5, 2),
    due_date DATE NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Tabla de gastos
CREATE TABLE expenses (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    category VARCHAR(255) NOT NULL,
    amount DECIMAL(15, 2) NOT NULL,
    expense_date DATETIME NOT NULL,
    description VARCHAR(MAX)
);
GO

-- Tabla de ingresos
CREATE TABLE income (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    source VARCHAR(255) NOT NULL,
    amount DECIMAL(15, 2) NOT NULL,
    income_date DATETIME NOT NULL,
    description NVARCHAR(MAX)
);
GO

-- Tabla de presupuestos
CREATE TABLE budgets (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    category VARCHAR(255) NOT NULL,
    amount DECIMAL(15, 2) NOT NULL,
    period VARCHAR(50) CHECK (period IN ('monthly', 'yearly')) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Tabla de metas de ahorro
CREATE TABLE savings_goals (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    goal_name VARCHAR(255) NOT NULL,
    target_amount DECIMAL(15, 2) NOT NULL,
    current_amount DECIMAL(15, 2) DEFAULT 0,
    due_date DATE,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Tabla de informes
CREATE TABLE reports (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    report_type VARCHAR(255) NOT NULL,
    generated_at DATETIME DEFAULT GETDATE(),
    content VARCHAR(MAX)
);
GO

-- Tabla de billeteras virtuales
CREATE TABLE virtual_wallets (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    wallet_name VARCHAR(255) NOT NULL,
    wallet_id VARCHAR(255) UNIQUE NOT NULL,
    balance DECIMAL(15, 2) NOT NULL,
    currency VARCHAR(50) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Tabla de transacciones de billeteras virtuales
CREATE TABLE virtual_wallet_transactions (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    virtual_wallet_id BIGINT FOREIGN KEY REFERENCES virtual_wallets(id),
    amount DECIMAL(15, 2) NOT NULL,
    transaction_date DATETIME NOT NULL,
    description VARCHAR(MAX)
);
GO

-- Tabla de categorías de gastos personalizados
CREATE TABLE expense_categories (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    category_name VARCHAR(255) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Tabla de categorías de ingresos personalizados
CREATE TABLE income_categories (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    category_name VARCHAR(255) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
GO

-- Tabla de alertas o notificaciones
CREATE TABLE notifications (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    notification_type VARCHAR(255) NOT NULL,
    message VARCHAR(MAX),
    notification_date DATETIME DEFAULT GETDATE(),
    is_read BIT DEFAULT 0
);
GO

-- Tabla de tasas de cambio
CREATE TABLE exchange_rates (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    from_currency VARCHAR(50) NOT NULL,
    to_currency VARCHAR(50) NOT NULL,
    rate DECIMAL(15, 6) NOT NULL,
    rate_date DATETIME DEFAULT GETDATE()
);
GO

-- Tabla de pagos recurrentes
CREATE TABLE recurring_payments (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    payment_type VARCHAR(255) NOT NULL,
    amount DECIMAL(15, 2) NOT NULL,
    due_date DATE NOT NULL,
    frequency VARCHAR(50) CHECK (frequency IN ('daily', 'weekly', 'monthly', 'yearly')) NOT NULL,
    next_payment_date DATE NOT NULL,
    created_at DATETIME DEFAULT GETDATE()
);
GO

-- Tabla de impuestos
CREATE TABLE taxes (
    id BIGINT PRIMARY KEY IDENTITY(1,1),
    user_id BIGINT FOREIGN KEY REFERENCES users(id),
    tax_type VARCHAR(255) NOT NULL,
    amount DECIMAL(15, 2) NOT NULL,
    due_date DATE NOT NULL,
    paid BIT DEFAULT 0
);
GO
