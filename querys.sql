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

insert into features values (1,'Sweat absorbent')
insert into features values (1,'Soft texture')
insert into features values (1,'Easy to wear')

select * from features


truncate table category
insert into category(category) values ('women''s fashion');
update category set category='Children''s fashion' where id=1
insert into category(category) values ('women''s fashion');
insert into category(category) values ('Health and beauty');
insert into category(category) values ('men''s fashion');
insert into category(category) values ('watch bags and jewellery');
insert into category(category) values ('electronic devices');
insert into category(category) values ('TV and Home appliances');
insert into category(category) values ('Electronic appliances');
insert into category(category) values ('Groceries & ptes');
insert into category(category) values ('Babies & toys');
insert into category(category) values ('Kitchen appliences');
insert into category(category) values ('Motors, tools & DIY');

select * from category


alter table product
add proimg VARCHAR(4000)

insert into Product values ('baby partywear',1,'Owing to the efforts of our dedicated team of professionals, we have been constantly engaged in offering the best quality Boy Kids Party Wear Dress.',1200,1000,'https://4.imimg.com/data4/VN/JF/MY-34076214/boy-party-wear-dress-1000x1000.jpg');
insert into Product values ('girl partywear',1,'Owing to the efforts of our dedicated team of professionals, we have been constantly engaged in offering the best quality Boy Kids Party Wear Dress.',1500,1350,'https://5.imimg.com/data5/IQ/YP/AZ/ANDROID-25797291/product-jpeg-500x500.jpg');
insert into Product values ('Long Kurti',2,' Aamayra Fashion House Viral Black Printed High Side Slit Long Kurti For Women',2000,1400,'https://static-01.daraz.com.np/p/2a1e6a1a7f8c8ead07586f65fcc55a12.jpg');
insert into Product values ('Vitamin CEB gel 70g',3,'facial moisturizer best for oily skin',400,300,'https://static-01.daraz.com.np/p/1cd9e16b9f651747c2d5bf2fcefd3826.jpg');
insert into Product values ('Tummy Trimmer',3,'Tummy Trimmer Stomach And Weight Loss Equipment -Double Spring',2000,400,'https://static-01.daraz.com.np/p/d32535d438f85ee6a19d23da1b412b6f.jpg');
insert into Product values ('Windcheater For Men',4,'Streetwear Technical Cargo Pocket Summer Half Windcheater For Men',1400,2000,'https://static-01.daraz.com.np/p/6f84a67e90c034fe7b8d194f0103a294.jpg');
insert into Product values ('WESTAR 9694',5,'WESTAR 9694 Stn Black Dial Analog For Men',23000,22000,'https://static-01.daraz.com.np/p/e0c4622f1af070611b49cafbe4727ed5.jpg');
insert into Product values ('Gameboy advance',6,'Original japanese gameboy',20000,15000,'https://upload.wikimedia.org/wikipedia/commons/7/7d/Nintendo-Game-Boy-Advance-Purple-FL.jpg');

select * from Product
delete from Product where id=7

insert into Product values ('small pet belt',9,'Pet Cat Collar Cute Paw Print Cat Bell Collar Adjustable Nylon Ribbon Collar for Cats Small Dogs Puppy Neck Strap 1.0cm 19-32cm By Crown Aquatics',160,100,'https://static-01.daraz.com.np/p/2c2619af5174d1fd3cfcd676d5c0bbc7.jpg');
insert into Product values ('Toddler Tricycle',10,'4-in-1 design tricycle: can be ridden in 4 ways: stroller, push trike, training trike, independent trike, etc.',8000,6000,'https://static-01.daraz.com.np/p/95ae9d86ee14159f604e54793e9c9fcb.png');
insert into Product values ('YS-ICAT18 Infrared Cooker',11,'Yasuda YS-ICAT18 Infrared Cooker | All Steel/Alumunium Utensil Supportive | 12 Months Brand Warranty',4000,3500,'https://static-01.daraz.com.np/p/d94a94dd1e6c324dfe45bedb12004b32.jpg');
insert into Product values ('DIY kit',12,'Speed Control DIY Fan Home Made Arduino Fan Rechargeable With 18650 Lithium Battery And Battery Holder Motor Speed Controller',4000,3000,'https://static-01.daraz.com.np/p/695e491b538b7de497db24254c083cec.jpg');

select * from product p right join features f on p.id=f.pid

create procedure proInsert @pname varchar(100),@category int,@description varchar(200),@oprice decimal(10,2),@cprice decimal(10,2),@proimg varchar(4000)
AS
	INSERT INTO Product values (@pname,@category,@description,@oprice,@cprice,@proimg)
GO


create procedure proUpdate @id int,@pname varchar(100),@category int,@description varchar(200),@oprice decimal(10,2),@cprice decimal(10,2),@proimg varchar(4000)
AS
	Update Product set pname=@pname,category=@category,descriptions=@description,oprice=@oprice,cprice=@cprice,proimg=@proimg where id=@id
GO

create procedure proDelete @id int
AS
	Delete from Product where id=@id
GO


create procedure proselect
as
	select * from Product
go

create procedure progetselect @id nchar(10)
as
select * from Product where id= @id
go

