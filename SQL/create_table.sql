USE Compnay;

------------------ Create Department Table ------------------
Create table Departments
(
	ID int identity(1,1) primary key,
	Name varchar(100)
);

------------------ Create Employee Table ------------------
Create table Employees
(
	ID int identity(1,1) primary key,
	Name varchar(100),
	Salary Decimal(10,2),
	Department_Id int foreign key references Departments(ID)
);

------------------ Create Customer Table ------------------
Create Sequence CustomerSeq Start With 1 increment By 1;

------------------ Create Trigger for Customer Table ------------------
Create Trigger trg_GenerateCustomerID
ON Customers
INSTEAD OF INSERT
AS
BEGIN
	Insert into Customers (ID, Name, Address)
	Select
		'CI-' + RIGHT('000' + CAST(NEXT VALUE FOR CustomerSeq AS varchar(3)),3),
		Name,
		Address
		From inserted;
End;

Create table Customers
(	
	ID varchar(6) primary key,
	Name varchar(100),
	Address varchar(100),
);

------------------ Create Product Table ------------------
Create table Products
(
	ID int identity (100,1) primary key,
	Name varchar(100),
	Cost decimal(10,2)
);

------------------ Create Orders Table ------------------
Create Sequence OrderSeq Start with 1 increment By 1;

Create table Orders
(
	ID varchar(6) primary key,
	Customer_Id varchar(6) foreign key references Customers(ID),
	Product_Id int foreign key references Products(ID),
	Amount int
);

------------------ Create Trigger for Orders Table ------------------
Create Trigger trg_GenerateOrderID
On Orders
instead of insert
as
begin
	insert into Orders (ID, Customer_Id, Product_Id, Amount)
	Select
	'D-' + RIGHT('00' + CAST(NEXT VALUE FOR OrderSeq AS varchar(2)),2),
	Customer_Id,
	Product_Id,
	Amount
	From inserted;
end;

