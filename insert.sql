create proc insertstafemember
	(@Fname varchar(50),
	 @lname varchar(50),
	 @Email varchar(255),
	 @Phone varchar(50),
	 @active tinyint )
as
begin
insert into sales.staffs(first_name, last_name, email, phone, active, store_id)
 values (@Fname, @lname, @Email, @Phone, @active,1)
end;