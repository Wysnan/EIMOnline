USE ERM_DB

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
INSERT [dbo].[SecurityUser] ([ID], [SystemStatus], [UserName], [UserLoginID], [UserLoginPwd], [CreatedOn]) VALUES (1, 0, N'zhangsan', N'admin', N'admin', CAST(0x0000A03700000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[SecurityUser] OFF
END

----插入测试模块
--IF NOT EXISTS (SELECT ID FROM [SystemModule] WHERE id=1)
--begin
--SET IDENTITY_INSERT [dbo].[SystemModule] ON
--INSERT [dbo].[SystemModule] ([ID], [SystemStatus], [ControllerModule], [ModuleName], [SortOrder], [ModuleMainUrl], [ModuleTypeId]) VALUES (1, 0, N'SecurityUser', N'用户', 1, N'/Administration/SecurityUser', 1)
--INSERT [dbo].[SystemModule] ([ID], [SystemStatus], [ControllerModule], [ModuleName], [SortOrder], [ModuleMainUrl], [ModuleTypeId]) VALUES (1, 0, N'SecurityUser', N'用户', 1, N'/Administration/SecurityUser', 1)
--SET IDENTITY_INSERT [dbo].[SystemModule] OFF
--END