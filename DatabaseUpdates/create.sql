 create table "DatabaseUpdate" (
       Name varchar(255),
       Date timestamp,
       primary key (Name)
)

create table "User" (
	Id  serial,
	PhoneNumber varchar(255),
	Username varchar(255),
	DeviceId varchar(255),
	ValidationCode varchar(255),
	ValidationCodeSent timestamp,
	Validated timestamp,
	Created timestamp,
	primary key (Id)
)

create table "Vibe" (
	Id uuid not null,
	Type varchar(255),
	Delivered timestamp,
	Received timestamp,
	Created timestamp,
	FromId int4,
	ToId int4,
	primary key (Id)
)

alter table "Vibe" 
	add constraint FK_Vibe_From 
	foreign key (FromId) 
	references "User"

alter table "Vibe" 
	add constraint FK_Vibe_To 
	foreign key (ToId) 
	references "User"