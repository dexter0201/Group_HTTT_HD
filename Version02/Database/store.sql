CREATE PROCEDURE GetAttachments
AS
	SELECT Attachments.AttachmentId, Url, Users.UserNo, AttachmentTypeId
	FROM Attachments LEFT JOIN Users ON Attachments.AttachmentId = Users.AttachmentId
GO

CREATE PROCEDURE GetAttachmentById
(
	@AttachmentId INT
)
AS
	SELECT * FROM Attachments WHERE AttachmentId = @AttachmentId
GO

CREATE PROCEDURE DeleteAttachmentById
(
	@AttachmentId INT
)
AS
	DELETE Attachments WHERE AttachmentId = @AttachmentId;
	UPDATE Users
	SET Users.AttachmentId = NULL
	WHERE Users.AttachmentId = @AttachmentId;
GO

CREATE PROCEDURE DeleteUserByID
(
	@UserId INT
)
AS
	DELETE Users WHERE UserId = @UserId	
GO