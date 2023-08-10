USE [DAW_INDEXING]
--DELETE FROM tblMenu

SET IDENTITY_INSERT [dbo].[tblMenu] ON 
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (1, NULL, N'Home', N'Menu', 1, 0, 1, N'/home/', N'home')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (2, NULL, N'Security', N'Menu', 1, 0, 1, N'/security/', N'security')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (3, NULL, N'Setup', N'Menu', 1, 0, 1, N'/setup/', N'settingapplications')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (4, 2, N'Users', N'Form', 1, 0, 1, N'/security/users', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (5, 2, N'Role', N'Form', 1, 0, 1, N'/security/role', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (6, 3, N'Station', N'Form', 1, 0, 1, N'/Setup/station', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (7, 3, N'Plant', N'Form', 1, 0, 1, N'/setup/plant', N'machine')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (8, 3, N'Product', N'Form', 1, 0, 1, N'/setup/product', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (9, 3, N'Model', N'Form', 1, 0, 1, N'/setup/model', N'/setup/location')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (10, 3, N'Email', N'Form', 1, 0, 1, N'/email', N'/email')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (11, 3, N'Audit Type', N'Form', 1, 0, 1, N'/setup/audit-type', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (12, 3, N'Variant', N'Form', 1, 0, 1, N'/setup/variant', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (13, 3, N'Shift', N'Form', 1, 0, 1, N'/setup/shift', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (14, 3, N'Fault Group', N'Form', 1, 0, 1, N'/setup/fault-group', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (15, 3, N'Auditor', N'Form', 1, 0, 1, N'/setup/auditor', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (16, 3, N'Checkpoint Deviation', N'Form', 1, 0, 1, N'/setup/checkpoint-devation', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (17, 3, N'Checkpoint Class', N'Form', 1, 0, 1, N'/setup/checkpoint-class', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (18, 3, N'Checkpoints', N'Form', 1, 0, 1, N'/setup/checkpoints', NULL)
----User-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (19,4, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (20,4, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (21,4, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (22,4, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
----Role-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (23,5, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (24,5, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (25,5, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (26,5, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
----Station-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (27,6, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (28,6, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (29,6, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (30,6, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
----Plant-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (31,7, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (32,7, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (33,7, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (34,7, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
----Product-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (35,8, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (36,8, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (37,8, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (38,8, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
----Model-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (39,9, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (40,9, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (41,9, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (42,9, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
----Email-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (43,10, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (44,10, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (45,10, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (46,10, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
----Audit Type-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (47,11, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (48,11, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (49,11, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (50,11, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
----Variant-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (51,12, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (52,12, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (53,12, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (54,12, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
----Shift-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (55,13, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (56,13, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (57,13, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (58,13, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
----Fault Group-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (59,14, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (60,14, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (61,14, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (62,14, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
----Auditor-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (63,15, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (64,15, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (65,15, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (66,15, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
----Checkpoint Deviation-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (67,16, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (68,16, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (69,16, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (70,16, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
----Checkpoint Class-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (71,17, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (72,17, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (73,17, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (74,17, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
----Checkpoints-----
GO
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (75,18, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (76,18, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (77,18, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
INSERT [dbo].[tblMenu] ([ControlId],[Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (78,18, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)

SET IDENTITY_INSERT [dbo].[tblMenu] OFF

GO
INSERT [dbo].[tblRole] ([Id], [IsActive], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c7b013f0-5201-4317-abd8-c211f91b7330', 1, N'User', N'USER', N'ab216618-c1fd-4f3b-b639-c9cc28dc7f42')
GO
INSERT [dbo].[tblRole] ([Id], [IsActive], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'fab4fac1-c546-41de-aebc-a14da6895711', 1, N'Admin', N'ADMIN', N'6f34f540-297a-4790-8c47-c38ceb32fe3d')
GO

GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (1, N'fab4fac1-c546-41de-aebc-a14da6895711', N'home', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (2, N'fab4fac1-c546-41de-aebc-a14da6895711', N'transactions', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (3, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (4, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (5, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (6, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (7, N'fab4fac1-c546-41de-aebc-a14da6895711', N'transactions', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (8, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (9, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (10, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (11, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (12, N'fab4fac1-c546-41de-aebc-a14da6895711', N'home', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (13, N'fab4fac1-c546-41de-aebc-a14da6895711', N'security', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (14, N'fab4fac1-c546-41de-aebc-a14da6895711', N'users', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (15, N'fab4fac1-c546-41de-aebc-a14da6895711', N'users', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (16, N'fab4fac1-c546-41de-aebc-a14da6895711', N'users', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (17, N'fab4fac1-c546-41de-aebc-a14da6895711', N'users', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (18, N'fab4fac1-c546-41de-aebc-a14da6895711', N'security', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (19, N'fab4fac1-c546-41de-aebc-a14da6895711', N'role', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (20, N'fab4fac1-c546-41de-aebc-a14da6895711', N'role', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (21, N'fab4fac1-c546-41de-aebc-a14da6895711', N'role', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (22, N'fab4fac1-c546-41de-aebc-a14da6895711', N'role', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (23, N'fab4fac1-c546-41de-aebc-a14da6895711', N'setup', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (24, N'fab4fac1-c546-41de-aebc-a14da6895711', N'department', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (25, N'fab4fac1-c546-41de-aebc-a14da6895711', N'department', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (26, N'fab4fac1-c546-41de-aebc-a14da6895711', N'department', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (27, N'fab4fac1-c546-41de-aebc-a14da6895711', N'department', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (28, N'fab4fac1-c546-41de-aebc-a14da6895711', N'setup', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (29, N'fab4fac1-c546-41de-aebc-a14da6895711', N'machine master', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (30, N'fab4fac1-c546-41de-aebc-a14da6895711', N'machine master', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (31, N'fab4fac1-c546-41de-aebc-a14da6895711', N'machine master', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (32, N'fab4fac1-c546-41de-aebc-a14da6895711', N'machine master', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (33, N'fab4fac1-c546-41de-aebc-a14da6895711', N'setup', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (34, N'fab4fac1-c546-41de-aebc-a14da6895711', N'loss category', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (35, N'fab4fac1-c546-41de-aebc-a14da6895711', N'loss category', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (36, N'fab4fac1-c546-41de-aebc-a14da6895711', N'loss category', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (37, N'fab4fac1-c546-41de-aebc-a14da6895711', N'loss category', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (38, N'fab4fac1-c546-41de-aebc-a14da6895711', N'setup', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (39, N'fab4fac1-c546-41de-aebc-a14da6895711', N'location', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (40, N'fab4fac1-c546-41de-aebc-a14da6895711', N'location', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (41, N'fab4fac1-c546-41de-aebc-a14da6895711', N'location', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (42, N'fab4fac1-c546-41de-aebc-a14da6895711', N'location', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (43, N'fab4fac1-c546-41de-aebc-a14da6895711', N'setup', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (44, N'fab4fac1-c546-41de-aebc-a14da6895711', N'section', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (45, N'fab4fac1-c546-41de-aebc-a14da6895711', N'section', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (46, N'fab4fac1-c546-41de-aebc-a14da6895711', N'section', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (47, N'fab4fac1-c546-41de-aebc-a14da6895711', N'section', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (48, N'fab4fac1-c546-41de-aebc-a14da6895711', N'setup', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (49, N'fab4fac1-c546-41de-aebc-a14da6895711', N'email', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (50, N'fab4fac1-c546-41de-aebc-a14da6895711', N'email', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (51, N'fab4fac1-c546-41de-aebc-a14da6895711', N'email', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (52, N'fab4fac1-c546-41de-aebc-a14da6895711', N'email', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (53, N'fab4fac1-c546-41de-aebc-a14da6895711', N'transactions', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (54, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (55, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (56, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (57, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (58, N'fab4fac1-c546-41de-aebc-a14da6895711', N'transactions', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (59, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (60, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (61, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (62, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (63, N'fab4fac1-c546-41de-aebc-a14da6895711', N'setup', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (64, N'fab4fac1-c546-41de-aebc-a14da6895711', N'assembly', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (65, N'fab4fac1-c546-41de-aebc-a14da6895711', N'assembly', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (66, N'fab4fac1-c546-41de-aebc-a14da6895711', N'assembly', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (67, N'fab4fac1-c546-41de-aebc-a14da6895711', N'assembly', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (68, N'fab4fac1-c546-41de-aebc-a14da6895711', N'transactions', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (69, N'fab4fac1-c546-41de-aebc-a14da6895711', N'design', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (70, N'fab4fac1-c546-41de-aebc-a14da6895711', N'assembly', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (71, N'fab4fac1-c546-41de-aebc-a14da6895711', N'transactions', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (72, N'fab4fac1-c546-41de-aebc-a14da6895711', N'design', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (73, N'fab4fac1-c546-41de-aebc-a14da6895711', N'assembly', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (74, N'fab4fac1-c546-41de-aebc-a14da6895711', N'transactions', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (75, N'fab4fac1-c546-41de-aebc-a14da6895711', N'design', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (76, N'fab4fac1-c546-41de-aebc-a14da6895711', N'assembly', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (77, N'fab4fac1-c546-41de-aebc-a14da6895711', N'transactions', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (78, N'fab4fac1-c546-41de-aebc-a14da6895711', N'design', NULL, NULL, NULL, NULL, NULL, NULL, 1)

GO
INSERT [dbo].[tblUser] ([Id], [Code], [Name], [UserType], [AuthType], [profile_pic], [Token], [TokenExpireOn], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive], [FcmToken], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9D7A44C3-9753-4660-B0DF-71F2316D09D4', N'ADMIN123', N'Admin User', N'Admin', N'Local', N'', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjlEN0E0NEMzLTk3NTMtNDY2MC1CMERGLTcxRjIzMTZEMDlENCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJhZG1pbiIsImVtYWlsIjoiYWRtaW5AZGF3bGFuY2UuY29tIiwic3ViIjoiYWRtaW5AZGF3bGFuY2UuY29tIiwianRpIjoiOTI4Y2VlNDMtYjdhNi00MjRmLTkyNTUtOGNjOTQ0Yzk1MmMxIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE2OTEwNjAzNDB9.wcWGKlwkTYz1UDuT4SMlaM8Hqo9BmDnld-aa_oLsTu0', CAST(N'2023-08-03T10:59:00.0000000' AS DateTime2), CAST(N'2023-08-02T12:00:00.0000000' AS DateTime2), CAST(N'2023-08-02T15:59:01.0243561' AS DateTime2), NULL, NULL, NULL, NULL, 1, N'', N'admin', N'ADMIN', N'admin@dawlance.com', N'ADMIN@DAWLANCE.COM', 1, N'AQAAAAEAACcQAAAAEJmamkIS+tcYkrdiExELPykfseNoBPwwKeIYvP2LEBs8UFYDdeAUAjCdv/W1qMSi9g==', N'529EF40E-A028-4231-A1D9-9BD8210F7A9B', N'05b53b13-cfe4-4c23-bd34-959b554dd485', N'', 0, 0, NULL, 0, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9D7A44C3-9753-4660-B0DF-71F2316D09D4', N'fab4fac1-c546-41de-aebc-a14da6895711')
GO
SET IDENTITY_INSERT [dbo].[tblRefreshToken] ON 
GO
INSERT [dbo].[tblRefreshToken] ([Id], [Token], [JwtId], [IsRevoked], [DateAdded], [DateExpire], [UserId]) VALUES (1, N'3594082d-9d17-4aae-8cb5-11382c905dc3-2a42eb12-54d2-434b-87c5-ed1245b4ac12', N'b6c57c66-243e-4895-bc15-a80630695c4f', 0, CAST(N'2023-08-02T10:57:26.9917129' AS DateTime2), CAST(N'2023-08-02T11:03:26.9917824' AS DateTime2), N'9D7A44C3-9753-4660-B0DF-71F2316D09D4')
GO
INSERT [dbo].[tblRefreshToken] ([Id], [Token], [JwtId], [IsRevoked], [DateAdded], [DateExpire], [UserId]) VALUES (2, N'5eb66149-7ed1-4fde-9693-207cb93845f9-fd149402-25d3-4899-a027-835a5e98133e', N'928cee43-b7a6-424f-9255-8cc944c952c1', 0, CAST(N'2023-08-02T10:59:00.9078502' AS DateTime2), CAST(N'2023-08-02T11:05:00.9078961' AS DateTime2), N'9D7A44C3-9753-4660-B0DF-71F2316D09D4')
GO
SET IDENTITY_INSERT [dbo].[tblRefreshToken] OFF
GO
SET IDENTITY_INSERT [dbo].[tblActivityLog] ON 
GO
INSERT [dbo].[tblActivityLog] ([Id], [Module], [Action], [Path], [UserId], [Token], [RequestedOn], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (1, N'authentication', N'POST', N'https://localhost:7281/api/Authentication/login', N'', N'', CAST(N'2023-08-02T15:56:24.2107959' AS DateTime2), CAST(N'2023-08-02T15:56:24.2111433' AS DateTime2), CAST(N'2023-08-02T15:56:24.2107098' AS DateTime2), NULL, N'', NULL, NULL, 1)
GO
INSERT [dbo].[tblActivityLog] ([Id], [Module], [Action], [Path], [UserId], [Token], [RequestedOn], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (2, N'authentication', N'POST', N'https://localhost:7281/api/Authentication/login', N'', N'', CAST(N'2023-08-02T15:58:58.5666116' AS DateTime2), CAST(N'2023-08-02T15:58:58.5669018' AS DateTime2), CAST(N'2023-08-02T15:58:58.5665534' AS DateTime2), NULL, N'', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[tblActivityLog] OFF
GO
