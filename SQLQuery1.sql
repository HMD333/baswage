--Q1
create proc find
as
begin

select (first_name +''+ last_name) as fullname 
,city, phone from sales.customers
end

find
--Q2
create proc _sum(
@one int,
@two int)
as
begin
+
select (@one + @two) as __sum 
end

_sum 5,5

--Q3
select SQUARE(5) as square_root
