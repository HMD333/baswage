create proc updetestafemember
	(@ID int,
	 @Fname varchar(50),
	 @lname varchar(50),
	 @Email varchar(255),
	 @Phone varchar(50),
	 @active tinyint )

as
begin
update sales.staffs
set first_name = @Fname,
	last_name = @lname,
	email = @Email,
	phone = @Phone,
	active = @active,
	store_id = 1
where staff_id = @ID
end;