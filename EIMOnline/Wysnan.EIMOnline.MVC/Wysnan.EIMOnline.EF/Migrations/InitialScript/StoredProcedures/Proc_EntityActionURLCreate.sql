CREATE PROCEDURE [dbo].[Proc_EntityActionURLCreate]
(
	@Area varchar(256),	
	@ControllerName varchar(256)
)
AS
BEGIN

	DECLARE @SortOrder INT
	DECLARE @ModuleMainUrl varchar(100)
	DECLARE @ModuleTypeId INT
	DECLARE @SystemModelID INT
	DECLARE @SystemModelDetailPageID INT
	DECLARE @RoleId INT
	DECLARE @ModuleName INT
	--Add SystemModule
	SELECT TOP 1 @ModuleName= ID FROM dbo.SystemModule WHERE ModuleMainUrl LIKE '%/'+@Area+'/'+@ControllerName+'/%' 
	--ModuleName=@ControllerName
	IF @ModuleName IS NULL
	BEGIN	
	SELECT @SortOrder=MAX(SortOrder) FROM dbo.SystemModule WHERE ControllerModule=@ControllerName
	IF @SortOrder IS NULL
	BEGIN	
	 SET @SortOrder=1	
	END	
	ELSE
	BEGIN
	SET @SortOrder=@SortOrder+1
	END
	SELECT TOP 1 @ModuleTypeId= ID FROM dbo.SystemModuleType WHERE Area=@Area
	SET @ModuleMainUrl = '/' + @Area + '/' + @ControllerName + '/' + 'Index'
	
	SET NOCOUNT ON
	INSERT INTO dbo.SystemModule(SystemStatus,ControllerModule,ModuleName,SortOrder,ModuleMainUrl,ModuleTypeId) VALUES
	(0,@ControllerName,@ControllerName,
	@SortOrder,
	@ModuleMainUrl,
	@ModuleTypeId)
	
	--Add SystemModuleDetailPage
	SET @ModuleMainUrl = '/' + @Area + '/' + @ControllerName + '/' + 'Index'
	SELECT TOP 1 @SystemModelID=ID FROM dbo.SystemModule WHERE ModuleName=@ControllerName
	
	INSERT INTO dbo.SystemModuleDetailPage
	        ( SystemStatus ,
	          DetailPageTitle ,
	          DetailPageAction ,
	          DetailPageUrl ,
	          SystemModuleID
	        )
	VALUES  ( 0 , -- SystemStatus - tinyint	         
	          @ControllerName, -- DetailPageTitle - nvarchar(max)
			  N'Index', -- DetailPageAction - nvarchar(max)
	          @ModuleMainUrl , -- DetailPageUrl - nvarchar(max)	
	          @SystemModelID -- SystemModuleID - int
	        )
	SET @ModuleMainUrl = '/' + @Area + '/' + @ControllerName + '/' + 'List'
	
	INSERT INTO dbo.SystemModuleDetailPage
	        ( SystemStatus ,
	          DetailPageTitle ,
	          DetailPageAction ,
	          DetailPageUrl ,
	          SystemModuleID
	        )
	VALUES  ( 0 , -- SystemStatus - tinyint	         
	          @ControllerName, -- DetailPageTitle - nvarchar(max)
			  N'List', -- DetailPageAction - nvarchar(max)
	          @ModuleMainUrl , -- DetailPageUrl - nvarchar(max)	 
	          @SystemModelID -- SystemModuleID - int
	        )
	        
	SET @ModuleMainUrl = '/' + @Area + '/' + @ControllerName + '/' + 'Add'
	
	INSERT INTO dbo.SystemModuleDetailPage
	        ( SystemStatus ,
	          DetailPageTitle ,
	          DetailPageAction ,
	          DetailPageUrl ,
	          SystemModuleID
	        )
	VALUES  ( 0 , -- SystemStatus - tinyint	         
	          @ControllerName, -- DetailPageTitle - nvarchar(max)
			  N'Add', -- DetailPageAction - nvarchar(max)
	          @ModuleMainUrl , -- DetailPageUrl - nvarchar(max)	 
	          @SystemModelID -- SystemModuleID - int
	        )
	        
	SET @ModuleMainUrl = '/' + @Area + '/' + @ControllerName + '/' + 'Edit'
	
	INSERT INTO dbo.SystemModuleDetailPage
	        ( SystemStatus ,
	          DetailPageTitle ,
	          DetailPageAction ,
	          DetailPageUrl ,
	          SystemModuleID
	        )
	VALUES  ( 0 , -- SystemStatus - tinyint	         
	          @ControllerName, -- DetailPageTitle - nvarchar(max)
			  N'Edit', -- DetailPageAction - nvarchar(max)
	          @ModuleMainUrl , -- DetailPageUrl - nvarchar(max)	   
	          @SystemModelID -- SystemModuleID - int
	        )
	  
	SET @ModuleMainUrl = '/' + @Area + '/' + @ControllerName + '/' + 'View'
	
	INSERT INTO dbo.SystemModuleDetailPage
	        ( SystemStatus ,
	          DetailPageTitle ,
	          DetailPageAction ,
	          DetailPageUrl ,
	          SystemModuleID
	        )
	VALUES  ( 0 , -- SystemStatus - tinyint	         
	          @ControllerName, -- DetailPageTitle - nvarchar(max)
			  N'View', -- DetailPageAction - nvarchar(max)
	          @ModuleMainUrl , -- DetailPageUrl - nvarchar(max)
	          @SystemModelID -- SystemModuleID - int
	        )  
	            
	SET @ModuleMainUrl = '/' + @Area + '/' + @ControllerName + '/' + 'Delete'
	
	INSERT INTO dbo.SystemModuleDetailPage
	        ( SystemStatus ,
	          DetailPageTitle ,
	          DetailPageAction ,
	          DetailPageUrl ,
	          SystemModuleID
	        )
	VALUES  ( 0 , -- SystemStatus - tinyint	         
	          @ControllerName, -- DetailPageTitle - nvarchar(max)
			  N'Delete', -- DetailPageAction - nvarchar(max)
	          @ModuleMainUrl , -- DetailPageUrl - nvarchar(max)	   
	          @SystemModelID -- SystemModuleID - int
	        )	   
	SELECT TOP 1 @RoleID= ID FROM dbo.SecurityRole WHERE RoleName='admin'
	SELECT TOP 1 @SystemModelDetailPageID=ID FROM dbo.SystemModuleDetailPage WHERE  DetailPageTitle=@ControllerName AND DetailPageAction='Index'
	INSERT INTO dbo.SystemPermission
	        ( SystemStatus ,	         
	          SystemModuleTypeID ,
	          SystemModuleID ,
	          SystemModulDatailPageID ,
	          RoleID
	        )
	VALUES  ( 0 , -- SystemStatus - tinyint	         
	          @ModuleTypeId , -- SystemModuleTypeID - int
	          @SystemModelID , -- SystemModuleID - int
	          @SystemModelDetailPageID , -- SystemModulDatailPageID - int
	          @RoleID  -- RoleID - int
	        )
	SELECT TOP 1 @SystemModelDetailPageID=ID FROM dbo.SystemModuleDetailPage WHERE  DetailPageTitle=@ControllerName AND DetailPageAction='List'
	INSERT INTO dbo.SystemPermission
	        ( SystemStatus ,	         
	          SystemModuleTypeID ,
	          SystemModuleID ,
	          SystemModulDatailPageID ,
	          RoleID
	        )
	VALUES  ( 0 , -- SystemStatus - tinyint	         
	          @ModuleTypeId , -- SystemModuleTypeID - int
	          @SystemModelID , -- SystemModuleID - int
	          @SystemModelDetailPageID , -- SystemModulDatailPageID - int
	          @RoleID  -- RoleID - int
	        )
	        
	SELECT TOP 1 @SystemModelDetailPageID=ID FROM dbo.SystemModuleDetailPage WHERE  DetailPageTitle=@ControllerName AND DetailPageAction='Add'	        
	INSERT INTO dbo.SystemPermission
	        ( SystemStatus ,	         
	          SystemModuleTypeID ,
	          SystemModuleID ,
	          SystemModulDatailPageID ,
	          RoleID
	        )
	VALUES  ( 0 , -- SystemStatus - tinyint	         
	          @ModuleTypeId , -- SystemModuleTypeID - int
	          @SystemModelID , -- SystemModuleID - int
	          @SystemModelDetailPageID , -- SystemModulDatailPageID - int
	          @RoleID  -- RoleID - int
	        )
	SELECT TOP 1 @SystemModelDetailPageID=ID FROM dbo.SystemModuleDetailPage WHERE  DetailPageTitle=@ControllerName AND DetailPageAction='Edit'
	INSERT INTO dbo.SystemPermission
	        ( SystemStatus ,	         
	          SystemModuleTypeID ,
	          SystemModuleID ,
	          SystemModulDatailPageID ,
	          RoleID
	        )
	VALUES  ( 0 , -- SystemStatus - tinyint	         
	          @ModuleTypeId , -- SystemModuleTypeID - int
	          @SystemModelID , -- SystemModuleID - int
	          @SystemModelDetailPageID , -- SystemModulDatailPageID - int
	          @RoleID  -- RoleID - int
	        )
	SELECT TOP 1 @SystemModelDetailPageID=ID FROM dbo.SystemModuleDetailPage WHERE  DetailPageTitle=@ControllerName AND DetailPageAction='View'
	INSERT INTO dbo.SystemPermission
	        ( SystemStatus ,	         
	          SystemModuleTypeID ,
	          SystemModuleID ,
	          SystemModulDatailPageID ,
	          RoleID
	        )
	VALUES  ( 0 , -- SystemStatus - tinyint	         
	          @ModuleTypeId , -- SystemModuleTypeID - int
	          @SystemModelID , -- SystemModuleID - int
	          @SystemModelDetailPageID , -- SystemModulDatailPageID - int
	          @RoleID  -- RoleID - int
	        )
	SELECT TOP 1 @SystemModelDetailPageID=ID FROM dbo.SystemModuleDetailPage WHERE  DetailPageTitle=@ControllerName AND DetailPageAction='Delete'
	INSERT INTO dbo.SystemPermission
	        ( SystemStatus ,	         
	          SystemModuleTypeID ,
	          SystemModuleID ,
	          SystemModulDatailPageID ,
	          RoleID
	        )
	VALUES  ( 0 , -- SystemStatus - tinyint	         
	          @ModuleTypeId , -- SystemModuleTypeID - int
	          @SystemModelID , -- SystemModuleID - int
	          @SystemModelDetailPageID , -- SystemModulDatailPageID - int
	          @RoleID  -- RoleID - int
	        )
	        	
	PRINT CONVERT(VARCHAR(23), GETDATE(), 120) + ' SystemModuleInfo'	
	SELECT * FROM SystemModule WHERE ModuleName=@ControllerName
	SELECT * FROM dbo.SystemModuleDetailPage WHERE DetailPageTitle=@ControllerName
	SELECT * FROM dbo.SystemPermission WHERE SystemModuleID=@SystemModelID
	SET NOCOUNT OFF	
	END
	ELSE 
	BEGIN
	PRINT 'The Module has existed!Command completed unsuccessfully! '
	END	
END