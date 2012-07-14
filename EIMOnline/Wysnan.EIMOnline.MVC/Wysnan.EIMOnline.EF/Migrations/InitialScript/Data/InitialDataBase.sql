--插入模块类型
IF NOT EXISTS (SELECT ID FROM SystemModuleType)
begin
SET IDENTITY_INSERT [dbo].[SystemModuleType] ON

INSERT INTO dbo.SystemModuleType(ID,SystemStatus ,TimeStamp ,Area ,ModuleTypeName ,SortOrder) VALUES  ( 1,0,NULL,'Personnel', N'人事管理', 1 )  
INSERT INTO dbo.SystemModuleType(ID,SystemStatus ,TimeStamp ,Area ,ModuleTypeName ,SortOrder) VALUES  ( 2,0,NULL,'Permissions', N'权限管理', 2) 
INSERT INTO dbo.SystemModuleType(ID,SystemStatus ,TimeStamp ,Area ,ModuleTypeName ,SortOrder) VALUES  ( 3,0,NULL,'Reimbursement', N'报销管理', 3) 
INSERT INTO dbo.SystemModuleType(ID,SystemStatus ,TimeStamp ,Area ,ModuleTypeName ,SortOrder) VALUES  ( 4,0,NULL,'Purchase', N'采购管理', 4 ) 
INSERT INTO dbo.SystemModuleType(ID,SystemStatus ,TimeStamp ,Area ,ModuleTypeName ,SortOrder) VALUES  ( 5,0,NULL,'Inventory', N'库存管理', 5) 
INSERT INTO dbo.SystemModuleType(ID,SystemStatus ,TimeStamp ,Area ,ModuleTypeName ,SortOrder) VALUES  ( 6,0,NULL,'Assets', N'固定资产管理', 6) 
INSERT INTO dbo.SystemModuleType(ID,SystemStatus ,TimeStamp ,Area ,ModuleTypeName ,SortOrder) VALUES  ( 7,0,NULL,'Task', N'任务管理', 7 ) 
SET IDENTITY_INSERT dbo.SystemModuleType OFF
END

--插入角色
IF NOT EXISTS (SELECT ID FROM [SecurityRole])
begin
SET IDENTITY_INSERT [dbo].[SecurityRole] ON
INSERT [dbo].[SecurityRole] ([ID], [SystemStatus], [RoleName]) VALUES (1, 0, N'admin')
SET IDENTITY_INSERT [dbo].[SecurityRole] OFF
END

--插入用户
IF NOT EXISTS (SELECT ID FROM [SecurityUser])
begin
SET IDENTITY_INSERT [dbo].[SecurityUser] ON
INSERT  INTO SecurityUser
( ID ,SystemStatus ,CreatedOn ,ModifiedOn ,Code ,UserName ,UserNameEn ,UserLoginID ,UserLoginPwd ,Sex ,Country ,Birthplace ,Birthday ,CertificateNo ,Phone ,Email ,UrgentName ,UrgentPhone ,Mobile ,MarriageStatusID ,HomeAddress ,CultureStatusID ,EducationalInstitute ,Professional ,GraduationTime ,StaffCategoryID ,Resume ,StatusID ,VacationDays ,RemainingVacationDays)
VALUES  ( 1 ,0 ,GETDATE() ,GETDATE() ,'USER000001' ,N'管理员' ,'admin' ,'admin' ,'admin' ,9 ,N'中国' ,N'中国' ,GETDATE() ,'1234567890' ,'88763616' ,'shuangqi.wu@wysnan.com' ,N'武双琦' ,'13474137783' ,'13474137783' ,7 ,N'西安' ,1 ,N'西安航专' ,N'电子信息工程' ,GETDATE() ,11 ,NULL ,13 ,10 ,10)
SET IDENTITY_INSERT [dbo].[SecurityUser] OFF
END

--插入考勤管理
IF NOT EXISTS (SELECT ID FROM PersonnelAttendance)
BEGIN
SET IDENTITY_INSERT [dbo].PersonnelAttendance ON
INSERT INTO dbo.PersonnelAttendance
        ( [ID],
          SystemStatus ,
          SecurityUserID ,
          BeginWorkTime ,
          EndWorkTime ,
          IsPunchCard 
        )
VALUES  ( 1,
		  0 , -- SystemStatus - tinyint
          1 , -- SecurityUserID - int
          '2012-05-15 02:32:05' , -- BeginWorkTime - datetime
          '2012-05-15 02:32:05' , -- EndWorkTime - datetime
          1  -- IsPunchCard - bit
        )
SET IDENTITY_INSERT [dbo].PersonnelAttendance OFF
END