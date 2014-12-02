--if OBJECT_ID('IPORTLIB')
Create Database IPORTLIB
go
Use IPORTLIB;
go
Create Table Statuses
(
	StatusId int identity(1, 1) primary key,
	StatusName nvarchar(128) not null
)
go
Create Procedure InsertStatus
(
	@StatusName nvarchar(128)
)
as
	Insert into Statuses (StatusName) values(@StatusName);
go
Create Procedure GetStatuses
as
	Select StatusId, StatusName from Statuses;
go
--Exec GetStatuses;

Exec InsertStatus N'Active';
Exec InsertStatus N'Expired';


Create Table Configs
(
	ConfigId int not null identity(1, 1) primary key,
	ConfigName nvarchar(128) not null,
	DataType varchar(8) not null,
	Value varchar(16) not null,
	StatusId int not null references Statuses(StatusId)
)
go
Create Procedure InsertConfig
(
	@ConfigName nvarchar(128),
	@DataType varchar(8),
	@Value varchar(16),
	@Status int
)
as
	Insert into Configs (ConfigName, DataType, Value, StatusId) values(@ConfigName, @DataType, @Value, @Status);
go

Create Table Countries
(
	CountryId int not null identity(1, 1) primary key,
	CountryName nvarchar(128)
)
go
Create Procedure InsertCountry
(
	@CountryName nvarchar(128)
)
as
	Insert into Countries (CountryName) values(@CountryName);
go
Exec InsertCountry N'Việt Nam';
go

--Tinh thanh
--Drop Table Provinces;
Create Table Provinces
(
	ProvinceId int not null identity(1, 1) primary key,
	CountryId int not null references Countries(CountryId),
	ProvinceNo varchar(8),
	ProvinceName nvarchar(128) not null
)
go

Create Procedure InsertProvince
(
	@CountryId int,
	@ProvinceNo varchar(8) = null,
	@ProvinceName nvarchar(128)
)
as
	Insert into Provinces (CountryId, ProvinceNo, ProvinceName) values(@CountryId, @ProvinceNo, @ProvinceName);
go
Create Procedure GetProvinces
(
	@CountryId int
)
as
	Select ProvinceId, ProvinceNo, ProvinceName from Provinces where CountryId = @CountryId;
go
Exec GetProvinces 1;

--Nha cung cap
Create Table Suppliers
(
	SupplierId int not null identity(1, 1) primary key,
	SupplierName nvarchar(256) not null,
	Address nvarchar(256),
	ProvinceId int not null references Provinces(ProvinceId),
	Email varchar(128),
	WebPage varchar(128),
	Phone varchar(16),
	AccountName nvarchar(128),
	BankName varchar(128),
	TaxCode varchar(16)
)
go
Alter Procedure InsertSupplier
(
	@SupplierName nvarchar(256),
	@Address nvarchar(256),
	@ProvinceId int,
	@Email varchar(128) = null,
	@WebPage varchar(128) = null,
	@Phone varchar(16) = null,
	@AccountName nvarchar(128) = null,
	@BankName varchar(128) = null,
	@TaxCode varchar(16) = null
)
as
	Insert into Suppliers (SupplierName, Address, ProvinceId, Email, WebPage, Phone, AccountName, BankName, TaxCode)
	values(@SupplierName, @Address, @ProvinceId, @Email, @WebPage, @Phone, @AccountName, @BankName, @TaxCode);
go
Exec InsertSupplier N'Fahasa', '60 - 62 Lê Lợi, Quận 1', 53, N'nfo@fahasa.com', 'fahasa.com', '39206097';
go
--Select * from Provinces
--Nha xuat ban
Create Table Publishers
(
	PublisherId int not null identity(1, 1) primary key,
	PublisherName nvarchar(256) not null,
	Note varchar(MAX)
)
go
----Select * from Publishers

----Insert into Publishers (PublisherName) Select distinct Publisher from BigData.dbo.Books where Publisher not in ('0', '02/2014', '06/2013', '07/2008', '8936066701631', '900');
----SElect * from BigData.dbo.Books where Publisher = '0';
----select * from BigData.dbo.Articles where ArticleId = 25784;
--Tac gia hay nhom tac gia
Create Table Authors
(
	AuthorId int not null identity(1, 1) primary key,
	AuthorNo varchar(16) null,
	AuthorName nvarchar(256) not null,
	Note nvarchar(256)
)
go
--insert into Authors (AuthorName) Select distinct Author from BigData.dbo.Books;
--Select * from Authors;


--De muc sach
--Drop Table Topics;
Create Table Topics
(
	TopicId int not null identity(1, 1) primary key,
	TopicName nvarchar(256) not null,
	Note nvarchar(256)
)
go
Create Procedure InsertTopic
(
	@TopicName nvarchar(256),
	@Note nvarchar(256) = null
)
as
	Insert into Topics (TopicName, Note) values(@TopicName, @Note);
go
--Insert into Topics (TopicName) Select CategoryName from BigData.dbo.Categories;
--go



--Loai an pham
--Drop Table PublicationTypes
Create Table PublicationTypes
(
	PublicationTypeId int not null identity(1, 1) primary key,
	PublicationTypeName nvarchar(64) not null
)
go
Create Procedure InsertPublicationType
(
	@PublicationTypeName nvarchar(64)
)
as
	Insert into PublicationTypes (PublicationTypeName) values(@PublicationTypeName);
go
Exec InsertPublicationType N'Sách';
Exec InsertPublicationType N'Tạp chí';
go

--Select * from BigData.dbo.Categories;

--Don vi tinh
Create Table Units
(
	UnitId int not null identity(1, 1) primary key,
	UnitName nvarchar(128) not null
)
--Tien te
Create Table Currencies
(
	CurrencyId int not null identity(1, 1) primary key,
	CurrencyName nvarchar(64) not null
)
go
--Chuyen nghanh
Create Table Majors
(
	MajorId int not null identity(1, 1) primary key,
	MajorName nvarchar(128) not null
)
go
--Ngon ngu
Create Table Languages
(
	LanguageId int not null identity(1, 1) primary key,
	LanguageName nvarchar(128) not null
)
go
Create Procedure InsertLanguage
(
	@LanguageName nvarchar(128)
)
as
	Insert into Languages(LanguageName) values(@LanguageName);
go
Exec InsertLanguage N'Tiếng Việt';
Exec InsertLanguage N'Tiếng Anh';
go
	
--An pham
Create Table Publications
(
	PublicationId int not null identity(1, 1) primary key,
	TopicId int not null references Topics(TopicId),
	AuthorId int not null references Authors(AuthorId),
	PublisherId int not null references Publishers(PublisherId),
	PublicationTypeId int not null references PublicationTypes(PublicationTypeId),
	MajorId int not null references Majors(MajorId),
	LanguageId int not null references Languages(LanguageId),
	Title nvarchar(256) not null,
	SubTitle nvarchar(256),
	PublisherYear int not null,
	Edition int,
	Copyright nvarchar(128),
	Description nvarchar(512),
	Size varchar(64),
	UnitId int not null references Units(UnitId),
	Price int not null,
	CurrencyId int not null references Currencies(CurrencyId),
	Quantity int not null,
	NumberDewey varchar(32),
	ISBN varchar(16),
	Note nvarchar(256),
)
go
--Kho luu tru
Create Table Stores
(
	StoreId int not null identity(1, 1) primary key,
	StoreName nvarchar(128) not null
)
go
--Sach
Create Table Books
(
	BookId int not null identity(1, 1) primary key,
	PublicationId int not null references Publications(PublicationId),
	StoreId int not null references Stores(StoreId),
	NumberSpecific varchar(16) not null,
	Status bit not null default 0
)
go

--Table Khoa
--Drop Table Departments;
Create Table Departments
(
	DepartmentId int not null primary key,
	DepartmentName nvarchar(128) not null
)
go
Create Procedure InsertDepartment
(
	@DepartmentId int,
	@DepartmentName nvarchar(128)
)
as
	Insert into Departments (DepartmentId, DepartmentName) values(@DepartmentId, @DepartmentName);
go
Exec InsertDepartment 11, N'Toán Tin';
Exec InsertDepartment 12, N'Công Nghệ Thông Tin';
Exec InsertDepartment 13, N'Vật Lý';
Exec InsertDepartment 14, N'Hóa Học';
Exec InsertDepartment 15, N'Sinh Học';
Exec InsertDepartment 16, N'Địa Chất';
Exec InsertDepartment 17, N'Môi Trường';
Exec InsertDepartment 18, N'Công Nghệ Sinh Học';
Exec InsertDepartment 19, N'Khoa Học Vật Liệu';
Exec InsertDepartment 20, N'Điện Tử Viễn Thông';
Exec InsertDepartment 21, N'Vật lý';
Exec InsertDepartment 22, N'Môi Trường';
Exec InsertDepartment 23, N'Chưa Biết';
Exec InsertDepartment 60, N'Cao Đẳng';
Exec InsertDepartment 61, N'Cao Đẳng';
Exec InsertDepartment 62, N'Cao Đẳng';
go
Create Procedure GetDepartments
as
	Select DepartmentId, DepartmentName from Departments;
go
--Select * from Departments



--Table Nhom
Create Table Groups
(
	GroupId int not null identity(1, 1) primary key,
	GroupName nvarchar(128) not null
)
go
Create Procedure InsertGroup
(
	@GroupName nvarchar(128)
)
as
	Insert into Groups (GroupName) values(@GroupName);
go
Exec InsertGroup N'Sinh viên';
go

Create Procedure GetGroups
as
	Select GroupId, GroupName from Groups;
go


Create Table AttachmentTypes
(
	AttachmentTypeId int not null identity(1, 1) primary key,
	AttachmentTypeName nvarchar(128)
)
go
Create Procedure InsertAttachmentType
(
	@AttachmentTypeName nvarchar(128)
)
as
	Insert into AttachmentTypes (AttachmentTypeName) values(@AttachmentTypeName);
go
Exec InsertAttachmentType N'Hình thẻ';
Exec InsertAttachmentType N'Ảnh minh họa sách';
go


--Table Tap tin dinh kem
Create Table Attachments
(
	AttachmentId int not null identity(1, 1) primary key,
	Url nvarchar(128) not null,
	AttachmentTypeId int not null references AttachmentTypes(AttachmentTypeId)
)
go
Create Procedure InsertAttachment
(
	@AttachmentId int output,
	@Url nvarchar(128),
	@AttachmentTypeId int
)
as
	Insert into Attachments (Url, AttachmentTypeId) values(@Url, @AttachmentTypeId);
	Set @AttachmentId = SCOPE_IDENTITY();
go

CREATE PROCEDURE GetAttachments
AS
	SELECT Attachments.AttachmentId, Url, Users.UserNo, AttachmentTypeId
	FROM Attachments LEFT JOIN Users ON Attachments.AttachmentId = Users.AttachmentId
GO

CREATE PROCEDURE DeleteAttachmentById
(
	@AttachmentId INT
)
AS
	DELETE Attachments WHERE AttachmentId = @AttachmentId;
	UPDATE Users
	SET Users.AttachmentId = NULL
	WHERE Users.AttachmentId = @AttachmentId;
GO

--Drop Table Users;
Create Table Users
(
	UserId int not null identity(1, 1) primary key,
	DepartmentId int not null references Departments(DepartmentId),
	ProvinceId int references Provinces(ProvinceId),
	GroupId int not null references Groups(GroupId),
	AttachmentId int references Attachments(AttachmentId),
	UserNo varchar(8) not null unique,--MSSV
	FirstName nvarchar(64) not null,
	LastName nvarchar(32) not null,
	Gender bit,
	BirthDay date,
	Address nvarchar(256),
	Phone varchar(16),
	IdentityCard varchar(16),
	Email varchar(128)
)
go
--Select * from Attachments;
Alter Procedure GetUsers
(
	@PageIndex int,
	@PageSize int
)
as
	Select * from (Select ROW_NUMBER() over (order by UserId desc) as RowNumber, UserId, Departments.DepartmentId, Departments.DepartmentName, ProvinceId, GroupId, AttachmentId, UserNo, FirstName, LastName, Gender, BirthDay, Address, Phone, IdentityCard from Users inner join Departments on Departments.DepartmentId = Users.DepartmentId) as Reader
	where Reader.RowNumber between @PageIndex*@PageSize+ 1 and (@PageIndex + 1) * @PageSize;
go

Alter Procedure ReportUsers
(
	@DepartmentId int,
	@ProvinceId int = null
)
as
	Select UserId, Departments.DepartmentId, Departments.DepartmentName, ProvinceId, GroupId, AttachmentId, UserNo, FirstName, LastName, Gender, BirthDay, Address, Phone, IdentityCard from Users inner join Departments on Departments.DepartmentId = Users.DepartmentId
	where Departments.DepartmentId = @DepartmentId;-- and ProvinceId = @ProvinceId;
go
Exec ReportUsers 11



Create Procedure GetUserById
(
	@UserId int
)
as
	Select UserId, Departments.DepartmentId, Departments.DepartmentName, ProvinceId, GroupId, Users.AttachmentId, UserNo, FirstName,
			LastName, Gender, BirthDay, Address, Phone, IdentityCard, Attachments.Url
	from Users inner join Departments on Departments.DepartmentId = Users.DepartmentId
				left join Attachments on Users.AttachmentId = Attachments.AttachmentId
	where UserId = @UserId;
go
Alter Procedure GetUserByNo
(
	@UserNo varchar(8)
)
as
	Select UserId, Departments.DepartmentId, Departments.DepartmentName, ProvinceId, GroupId, AttachmentId, UserNo, FirstName, LastName, Gender, BirthDay, Address, Phone, IdentityCard from Users inner join Departments on Departments.DepartmentId = Users.DepartmentId
	where UserNo = @UserNo;
go
Alter Procedure GetUsersByFullName
(
	@Keyword nvarchar(64)
)
as

	Select UserId, Departments.DepartmentId, Departments.DepartmentName, ProvinceId, GroupId, AttachmentId, UserNo, FirstName, LastName, Gender, BirthDay, Address, Phone, IdentityCard 
	from Users inner join Departments on Departments.DepartmentId = Users.DepartmentId
	where FirstName + ' ' + LastName like '%' + @Keyword + '%';
go

Exec GetUsersByFullName N'Nguyễn Phan Chí Thành';
	

Create Procedure CountUsers
as
	Select COUNT(*) from Users;
go
Exec CountUsers
--Exec GetUsers 0, 10;
--Exec GetUsers 1, 10;

	

Alter Procedure InsertUser
(
	@UserId int output,
	@DepartmentId int,
	@ProvinceId int = null,
	@GroupId int,
	@AttachmentId int = null,
	@UserNo varchar(8),
	@FirstName nvarchar(64),
	@LastName nvarchar(32),
	@Gender bit = null,
	@BirthDay date = null,
	@Address nvarchar(256) = null,
	@Phone varchar(16) = null,
	@IdentityCard varchar(16) = null,
	@Email varchar(128) = null
)
as
	Insert into Users (DepartmentId, ProvinceId, GroupId, AttachmentId, UserNo, 
	FirstName, LastName, Gender, BirthDay, Address, Phone, IdentityCard, Email)
	values(@DepartmentId, @ProvinceId, @GroupId, @AttachmentId, @UserNo, @FirstName, 
	@LastName, @Gender, @BirthDay, @Address, @Phone, @IdentityCard, @Email);
	set @UserId = SCOPE_IDENTITY();
go

Alter Procedure InsertUser
(
	@DepartmentId int,
	@UserNo varchar(8),
	@FirstName nvarchar(64),
	@LastName nvarchar(32)
)
as
	Insert into Users (DepartmentId, UserNo, FirstName, LastName)
	values(@DepartmentId, @UserNo, @FirstName, @LastName);
go

Create Procedure UpdateUser
(
	@UserId int,
	@DepartmentId int,
	@ProvinceId int = null,
	@GroupId int,
	@AttachmentId int = null,
	@UserNo varchar(8),
	@FirstName nvarchar(64),
	@LastName nvarchar(32),
	@Gender bit = null,
	@BirthDay date = null,
	@Address nvarchar(256) = null,
	@Phone varchar(16) = null,
	@IdentityCard varchar(16) = null,
	@Email varchar(128) = null
)
as
	UPDATE Users
	SET DepartmentId = @DepartmentId, ProvinceId = @ProvinceId, GroupId = @GroupId,
		AttachmentId = @AttachmentId, UserNo = @UserNo, FirstName = @FirstName,
		LastName = @LastName, Gender = @Gender, BirthDay = @BirthDay,
		Address = @Address, Phone = @Phone, IdentityCard = @IdentityCard, Email = @Email
	WHERE UserId = @UserId
go

CREATE PROCEDURE DeleteUserByID
(
	@UserId INT
)
AS
	DELETE Users WHERE UserId = @UserId	
GO


--Select * from Users


Create Table CardUsers
(
	CardUserId int not null identity(1, 1) primary key,
	UserId int not null references Users(UserId),
	CardUserNo varchar(16) not null,
	UserName nvarchar(16) not null,
	Password nvarchar(32) not null,
	Status bit not null default 0,
	DueDate date not null
)
go



--Alter Procedure InsertUser
--(
--	@DepartmentId int,
--	@UserNo varchar(8),
--	@FirstName nvarchar(64),
--	@LastName nvarchar(32),
--	@Gender bit = NULL,
--	@BirthDay date = NULL
--)
--as
--	Insert into Users (UserNo, DepartmentId, FirstName, LastName, Gender, BirthDay)
--	values(@UserNo, @DepartmentId, @FirstName, @LastName, @Gender, @BirthDay);
--go
--Create Procedure GetUsers
--as
--	Select Top 100 * from Users;
--go

--Phieu muon sach
Create Table Loans
(
	LoanId int not null identity(1, 1) primary key,
	DateCreated datetime not null,
	UserId int not null references Users(UserId)
)
go
--Chi tiet phieu muon sach
Create Table LoanDetails
(
	LoanDetailId int identity(1, 1) primary key,
	LoanId int not null references Loans(LoanId),
	BookId int not null references Books(BookId),
	DateLoan datetime not null,
	DatePay datetime,
	unique (LoanId, BookId)
)
go

Alter Procedure GetUsersByDepartments
as
	Select Users.DepartmentId, DepartmentName, UserNo, FirstName, LastName from Users inner join Departments on Users.DepartmentId = Departments.DepartmentId;
go

Exec GetUsersByDepartments;

-- Thống kê số lượng độc giả theo khoa
create procedure ReportUsersDepartments
as
	select Departments.DepartmentName, count(*) as CountUsers
	from Users inner join Departments on Users.DepartmentId=Departments.DepartmentId 
	group by Departments.DepartmentName;
go


-- Thống kê số lượng độc giả mượn sách theo năm
create procedure ReportUsersLoan
 as
	select DATEPART(yyyy,Loans.DateCreated) as Year, COUNT(distinct(UserNo)) as CountUsers
	from Loans inner join Users on Loans.UserId = Users.UserId
	group by DATEPART(yyyy,Loans.DateCreated);
 go

 -- Thống kê các độc giả mượn sách theo từng năm
 create procedure GetReportUsersLoanByYear
 (
	@year varchar(4)
 )
 as
	select Users.UserNo,Users.FirstName,Users.LastName,C.CountLoan
	from (select Users.UserNo,count(*) as CountLoan
			from Users inner join Loans on Users.UserId = Loans.UserId
			where DATEPART(yyyy,Loans.DateCreated) = @year
			group by Loans.UserId,Users.UserNo
			) as C inner join Users on C.UserNo = Users.UserNo
	order by C.CountLoan DESC
 go

 -- Thống kê độc giả mượn sách theo các sơ sở
create procedure ReportLoansPercent
as
	select Stores.StoreName as storename,(count(distinct Loans.LoanId) / CAST ((select count(distinct Loans.LoanId)
																 from Loans inner join LoanDetails on Loans.LoanId = LoanDetails.LoanId
																	inner join Books on LoanDetails.BookId = Books.BookId
																	inner join Stores on Books.StoreId = Stores.StoreId) as decimal) * 100.00) as LoanPercent
	from Loans inner join LoanDetails on Loans.LoanId = LoanDetails.LoanId
		inner join Books on LoanDetails.BookId = Books.BookId
		inner join Stores on Books.StoreId = Stores.StoreId
	group by Stores.StoreName
go
 
-- Thống kê các độc giả trễ hẹn trả sách
create procedure GetReportOutOfDateLoans
as
select Users.UserNo,Users.FirstName,Users.LastName,LoanDetails.DateLoan,LoanDetails.DatePay,Publications.Title,Books.NumberSpecific
from	Users inner join Loans on Loans.UserId = Users.UserId
		inner join LoanDetails on Loans.LoanId = LoanDetails.LoanId
		inner join Books on LoanDetails.BookId = Books.BookId
		inner join Stores on Books.StoreId = Stores.StoreId
		inner join Publications on Publications.PublicationId = Books.PublicationId
where Books.Status = 1 and LoanDetails.DatePay <= GETDATE()
order by UserNo
go

