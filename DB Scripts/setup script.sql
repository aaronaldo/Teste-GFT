/*
		ROLLBACK proc and setup:
			drop procedure if exists DetermineCategory
			drop table if exists [trade].Category
			drop table if exists Trade.trade
			drop table if exists dbo.Output
			drop type if exists TradeList
			drop table if exists ClientSector
			drop schema if exists trade
*/

create schema trade;
GO

create table ClientSector(
	ClientSectorId int identity(1,1) primary key,
	Name varchar(10)
)

insert ClientSector values ('Private'), ('Public')
GO

create table [trade].Category(
	CategoryId int IDENTITY(1,1) primary key,
	Name varchar(30) not null,
	MinValue decimal(10,2) null,
	MaxValue decimal(10,2) null,
	ClientSectorId int foreign key(ClientSectorId) references ClientSector
)

declare @privateSector int = (select ClientSectorId from ClientSector where Name = 'Private'),
		@publicSector int = (select ClientSectorId from ClientSector where Name = 'Public')

insert trade.Category
values ('HIGHRISK', 1000000, null, @privateSector)
	  ,('MEDIUMRISK', 1000000, null, @publicSector)
	  ,('LOWRISK', 0, 1000000, @publicSector)

create table [trade].Trade(
	TradeId int identity(1,1) primary key,
	Value decimal(10,2),
	ClientSectorId int foreign key(ClientSectorId) references ClientSector
)

insert trade.Trade
values (1000 * 1000, @privateSector),
	   (1000, @privateSector),
	   (1000 * 1000, @publicSector),
	   (1000, @publicSector)
GO

create table dbo.Output(
	id int identity(1,1) primary key,
	ExecutionGuid uniqueidentifier,
	IN_Value decimal(10,2),
	IN_Sector varchar(10),
	OUT_CategoryName varchar(30)
)

create type TradeList as table (Value decimal(10,2), Sector varchar(10))