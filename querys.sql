create database demo
use demo


create table category(
id int identity(1,1) primary key,
category varchar(50)
);






create table Product(
id int identity(1,1) primary key,
pname varchar(100),
category int foreign key references category,
descriptions varchar(200),
oprice decimal(10,2),
cprice decimal(10,2)
)




create table features(
id int identity(1,1) primary key,
pid int references Product,
features varchar(200)
)

insert into category(category) values ('womens'' fashion');


