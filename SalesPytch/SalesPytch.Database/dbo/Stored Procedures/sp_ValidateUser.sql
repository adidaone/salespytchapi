CREATE PROCEDURE sp_ValidateUser
@EmailAddress VARCHAR(100),
@Password VARCHAR(100)
AS 
BEGIN

SELECT * FROM tblUser U
INNER JOIN tblRole R ON U.RoleId = R.RoleId
WHERE U.EmailAddress = @EmailAddress AND U.[Password] = @Password AND U.IsActive = 1

END