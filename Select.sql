create proc selectstafemember
	(@ID int,
	@Fname varchar(50) out,
	 @lname varchar(50) out,
	 @Email varchar(255) out,
	 @Phone varchar(50) out,
	 @active tinyint out)
as
begin
select 
		@Fname = first_name,
		@lname = last_name,
		@Email = email,
		@Phone = phone,
		@active = active from sales.staffs
where staff_id = @ID
end;