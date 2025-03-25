create proc deletestafemember(@ID int)
as
begin
delete from sales.staffs
where staff_id = @ID
end;