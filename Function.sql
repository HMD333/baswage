select max(list_price) as"MAX",
	min(list_price) as"MIN",
	sum(list_price) as"SUM",
	AVG(list_price) as"AVG"
	from production.products

select UPPER(first_name) as"UPPER",
	LOWER(first_name) as"LOWER"
	from sales.customers

select UPPER('My Name') as "UPPER"

select first_name, last_name, concat(first_name ,' ',last_name ) as"Full Name"
	from sales.customers