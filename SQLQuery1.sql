create database ManageCourse ;
use ManageCourse ;

create table Admin 
(
	id int primary key identity ,
	name nvarchar(100) ,
	email nvarchar(199) ,
	password nvarchar(30)
);


create table trainer 
( 
	id int primary key identity ( 1 , 1 ) ,
	name nvarchar(100) ,
	email nvarchar(100) ,
	description nvarchar(max) ,
	website nvarchar(250),
	creationDate datetime ,
);


create table category
(
	id int primary key identity(1 ,1 ) ,
	name nvarchar(100) ,
	parentId int foreign key references category(id) ,
);


create table Course
(
	id int primary key identity(1 , 1) ,
	name nvarchar(100) ,
	CreationDate datetime ,
	description nvarchar(max) ,
	trainerId int foreign key references Trainer (ID) on delete CasCade ,
	categoryId int foreign key references category (ID) on delete CasCade,
);

create table Course_Lessons
(
	id int primary key identity ,
	title nvarchar(200) ,
	course_id int foreign key references Course(id) ,
	order_number int ,
);

create table trainee
(
	id int primary key identity ,
	name nvarchar (100) ,
	email nvarchar(100) ,
	password nvarchar(30) ,
	creationDate datetime ,
	isActive bit ,
);


create table trainee_course
(
	trainee_id int foreign key references trainee (id),
	course_id int foreign key references Course (id),
	registration_date datetime ,
	constraint c1 primary key (trainee_id ,course_id )
);