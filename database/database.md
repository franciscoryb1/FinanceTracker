### **Esquema de la base de datos:**

---

### 1. **`users`** - **Usuarios**
Esta tabla contiene la información básica de los usuarios registrados en la aplicación.

- **id** (bigint, primary key, identity): Identificador único del usuario.
- **username** (nvarchar(255), unique, not null): Nombre de usuario único.
- **email** (nvarchar(255), unique, not null): Correo electrónico único.
- **password_hash** (nvarchar(max), not null): Contraseña cifrada.
- **created_at** (datetime2, default getdate()): Fecha y hora de creación del usuario.
- **updated_at** (datetime2, default getdate()): Fecha y hora de la última actualización del usuario.

---

### 2. **`bank_accounts`** - **Cuentas Bancarias**
Contiene la información de las cuentas bancarias de los usuarios.

- **id** (bigint, primary key, identity): Identificador único de la cuenta bancaria.
- **user_id** (bigint, foreign key): Relaciona la cuenta con un usuario.
- **account_number** (nvarchar(255), unique, not null): Número único de la cuenta bancaria.
- **bank_name** (nvarchar(255), not null): Nombre del banco.
- **balance** (decimal(15, 2), not null): Saldo de la cuenta.
- **created_at** (datetime2, default getdate()): Fecha de creación de la cuenta.
- **updated_at** (datetime2, default getdate()): Fecha de última actualización de la cuenta.

---

### 3. **`bank_transactions`** - **Transacciones Bancarias**
Registra las transacciones realizadas en las cuentas bancarias.

- **id** (bigint, primary key, identity): Identificador único de la transacción.
- **bank_account_id** (bigint, foreign key): Relaciona la transacción con una cuenta bancaria.
- **amount** (decimal(15, 2), not null): Monto de la transacción.
- **transaction_date** (datetime2, not null): Fecha de la transacción.
- **description** (nvarchar(max)): Descripción de la transacción.
- **transaction_type** (nvarchar(50), check): Tipo de transacción: `'credit'` o `'debit'`.

---

### 4. **`cash_wallets`** - **Carteras de Efectivo**
Registra el dinero en efectivo disponible de los usuarios.

- **id** (bigint, primary key, identity): Identificador único de la cartera.
- **user_id** (bigint, foreign key): Relaciona la cartera con un usuario.
- **amount** (decimal(15, 2), not null): Monto de dinero en efectivo.
- **currency** (nvarchar(50), not null): Moneda utilizada (ejemplo: "MXN", "USD").
- **updated_at** (datetime2, default getdate()): Fecha de última actualización del saldo.

---

### 5. **`credit_cards`** - **Tarjetas de Crédito**
Contiene la información de las tarjetas de crédito de los usuarios.

- **id** (bigint, primary key, identity): Identificador único de la tarjeta.
- **user_id** (bigint, foreign key): Relaciona la tarjeta con un usuario.
- **card_number** (nvarchar(255), unique, not null): Número de la tarjeta.
- **card_limit** (decimal(15, 2), not null): Límite de crédito de la tarjeta.
- **balance** (decimal(15, 2), not null): Saldo pendiente de pago en la tarjeta.
- **due_date** (date, not null): Fecha de vencimiento de pago.
- **created_at** (datetime2, default getdate()): Fecha de creación de la tarjeta.
- **updated_at** (datetime2, default getdate()): Fecha de última actualización de la tarjeta.

---

### 6. **`credit_card_transactions`** - **Transacciones de Tarjetas de Crédito**
Registra las transacciones realizadas con las tarjetas de crédito.

- **id** (bigint, primary key, identity): Identificador único de la transacción.
- **credit_card_id** (bigint, foreign key): Relaciona la transacción con una tarjeta de crédito.
- **amount** (decimal(15, 2), not null): Monto de la transacción.
- **transaction_date** (datetime2, not null): Fecha de la transacción.
- **description** (nvarchar(max)): Descripción de la transacción.
- **transaction_type** (nvarchar(50), check): Tipo de transacción: `'purchase'` o `'payment'`.

---

### 7. **`debts`** - **Deudas**
Contiene las deudas de los usuarios (préstamos, créditos, etc.).

- **id** (bigint, primary key, identity): Identificador único de la deuda.
- **user_id** (bigint, foreign key): Relaciona la deuda con un usuario.
- **debt_type** (nvarchar(255), not null): Tipo de deuda (ejemplo: "Préstamo", "Tarjeta de crédito").
- **amount** (decimal(15, 2), not null): Monto total de la deuda.
- **interest_rate** (decimal(5, 2)): Tasa de interés de la deuda.
- **due_date** (date, not null): Fecha de vencimiento de la deuda.
- **created_at** (datetime2, default getdate()): Fecha de creación de la deuda.
- **updated_at** (datetime2, default getdate()): Fecha de última actualización de la deuda.

---

### 8. **`expenses`** - **Gastos**
Almacena los gastos realizados por los usuarios.

- **id** (bigint, primary key, identity): Identificador único del gasto.
- **user_id** (bigint, foreign key): Relaciona el gasto con un usuario.
- **category** (nvarchar(255), not null): Categoría del gasto.
- **amount** (decimal(15, 2), not null): Monto del gasto.
- **expense_date** (datetime2, not null): Fecha en que se realizó el gasto.
- **description** (nvarchar(max)): Descripción del gasto.

---

### 9. **`income`** - **Ingresos**
Registra los ingresos obtenidos por los usuarios.

- **id** (bigint, primary key, identity): Identificador único del ingreso.
- **user_id** (bigint, foreign key): Relaciona el ingreso con un usuario.
- **source** (nvarchar(255), not null): Fuente del ingreso (ejemplo: "Salario", "Freelance").
- **amount** (decimal(15, 2), not null): Monto del ingreso.
- **income_date** (datetime2, not null): Fecha en que se recibió el ingreso.
- **description** (nvarchar(max)): Descripción del ingreso.

---

### 10. **`budgets`** - **Presupuestos**
Gestiona los presupuestos establecidos por los usuarios.

- **id** (bigint, primary key, identity): Identificador único del presupuesto.
- **user_id** (bigint, foreign key): Relaciona el presupuesto con un usuario.
- **category** (nvarchar(255), not null): Categoría del presupuesto.
- **amount** (decimal(15, 2), not null): Monto máximo asignado al presupuesto.
- **period** (nvarchar(50), check): Periodo del presupuesto: `'monthly'` o `'yearly'`.
- **created_at** (datetime2, default getdate()): Fecha de creación del presupuesto.
- **updated_at** (datetime2, default getdate()): Fecha de última actualización del presupuesto.

---

### 11. **`savings_goals`** - **Metas de Ahorro**
Gestiona las metas de ahorro de los usuarios.

- **id** (bigint, primary key, identity): Identificador único de la meta de ahorro.
- **user_id** (bigint, foreign key): Relaciona la meta con un usuario.
- **goal_name** (nvarchar(255), not null): Nombre de la meta de ahorro.
- **target_amount** (decimal(15, 2), not null): Monto objetivo.
- **current_amount** (decimal(15, 2), default 0): Monto ahorrado hasta el momento.
- **due_date** (date): Fecha límite de la meta.
- **created_at** (datetime2, default getdate()): Fecha de creación de la meta.
- **updated_at** (datetime2, default getdate()): Fecha de última actualización de la meta.

---

### 12. **`reports`** - **Informes**
Almacena los informes generados sobre las finanzas del usuario.

- **id** (bigint, primary key, identity): Identificador único del informe.
- **user_id** (bigint, foreign key): Relaciona el informe con un usuario.
- **report_type** (nvarchar(255), not null): Tipo de informe (ejemplo: "Informe de presupuesto").
- **generated_at** (datetime2, default getdate()): Fecha de generación del informe.
- **content** (nvarchar(max)): Contenido del informe (resumen o análisis).

---

### 13. **`virtual_wallets`** - **Billeteras Virtuales**
Gestiona las billeteras virtuales de los usuarios (MercadoPago, PayPal, etc.).

- **id** (bigint, primary key, identity): Identificador único de la billetera virtual.
- **user_id** (bigint, foreign key): Relaciona la billetera con un usuario.
- **wallet_name** (nvarchar(255), not null): Nombre de la billetera virtual.
- **wallet_id** (nvarchar(255), unique, not null): Identificador único de la billetera.
- **balance** (decimal(15, 2), not null): Saldo disponible en la billetera virtual.
- **currency** (nvarchar(50), not null): Moneda utilizada.
- **created_at** (datetime2, default getdate()): Fecha de creación de la billetera.
- **updated_at** (datetime2, default getdate()): Fecha de última actualización de la billetera.

---

### 14. **`virtual_wallet_transactions`** - **Transacciones de Billeteras Virtuales**
Registra las transacciones realizadas con las billeteras virtuales.

- **id** (bigint, primary key, identity): Identificador único de la transacción.
- **virtual_wallet_id** (bigint, foreign key): Relaciona la transacción con una billetera virtual.
- **amount** (decimal(15, 2), not null): Monto de la transacción.
- **transaction_date** (datetime2, not null): Fecha de la transacción.
- **description**