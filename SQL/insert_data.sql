------------------ Insert Data Into Department Table ------------------
insert into Departments (Name) values
('IT'),
('Operations'),
('Human Resources'),
('Accounting and Finance'),
('Research and Development (R&D)')

------------------ Insert Data Into Employees Table ------------------
insert into Employees (Name, Salary, Department_Id) values
('Ahmed', 5000, 3),
('Mohamed', 4000, 1),
('Peter', 3000, 2),
('Clara', 6000, 4),
('Beeshoy', 7000, 4),
('Menna', 5500, 2),
('Gina', 9400, 3)

------------------ Insert Data Into Customers Table ------------------
insert into Customers (Name, Address) values
('Customer 1', 'Cairo'),
('Customer 2', 'Cairo'),
('Customer 3', 'Giza'),
('Customer 4', 'Banha'),
('Customer 5', 'Alex')

------------------ Insert Data Into Products Table ------------------
insert into Products (Name, Cost) values
('Product 1', 100.05),
('Product 2', 150.40),
('Product 3', 800.00),
('Product 4', 790.50),
('Product 5', 500.00),
('Product 6', 200.50)

------------------ Insert Data Into Orders Table ------------------
insert into Orders (Customer_Id, Product_Id, Amount) values
('CI-002', 100, 5),
('CI-004', 101, 8),
('CI-004', 103, 4),
('CI-005', 105, 3)