/*
For testing purposes:

truncate table dbo.Output;

declare @trades as tradelist
insert into @trades
values (1000 * 1000, 'Private'),
	   (1000, 'Private'),
	   (1000 * 1000, 'Public'),
	   (1000, 'Public')

exec DetermineCategory @trades
*/

create or alter procedure DetermineCategory
(@trades TradeList readonly) as
BEGIN
	set nocount on;

	declare @privateSector int = (select ClientSectorId from ClientSector where Name = 'Private'),
			@publicSector int = (select ClientSectorId from ClientSector where Name = 'Public')

	declare @procGuid uniqueidentifier = newId()
	INSERT dbo.Output (ExecutionGuid, IN_Value, IN_Sector, OUT_CategoryName)
	SELECT @procGuid, t.value, cs.clientsectorid, cat.name
	from @trades t
	inner join ClientSector cs on cs.name = t.sector
	inner join trade.category cat on cat.clientsectorid = cs.clientsectorid
	where cat.minValue <= t.value
	and (cat.maxValue is null or cat.maxValue >= t.value)

	select *
	from dbo.Output
END