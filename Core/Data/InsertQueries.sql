USE [DAW_INDEXING]
GO
SET IDENTITY_INSERT [dbo].[tblMenu] ON 
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (1, NULL, N'Home', N'Menu', 1, 0, 1, N'/home/', N'home')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (2, NULL, N'Security', N'Menu', 1, 0, 1, N'/security/', N'security')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (3, NULL, N'Setup', N'Menu', 1, 0, 1, N'/setup/', N'settingapplications')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (4, NULL, N'Transactions', N'Menu', 1, 0, 1, N'/setup/', N'settingapplications')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (5, NULL, N'Inquiry', N'Menu', 1, 0, 1, N'/setup/', N'settingapplications')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (6, 2, N'Users', N'Form', 1, 0, 1, N'/security/users', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (7, 2, N'Role', N'Form', 1, 0, 1, N'/security/role', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (8, 3, N'Department', N'Form', 1, 0, 1, N'/Setup/department', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (9, 3, N'Machine Master', N'Form', 1, 0, 1, N'/setup/machine', N'machine')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (10, 3, N'Loss Category', N'Form', 1, 0, 1, N'/setup/testtype', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (11, 6, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (12, 6, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (13, 6, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (14, 6, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (15, 7, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (16, 7, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (17, 7, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (18, 7, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (19, 8, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (20, 8, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (21, 8, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (22, 8, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (23, 9, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (24, 9, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (25, 9, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (26, 9, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (27, 10, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (28, 10, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (29, 10, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (30, 10, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (31, 4, N'Tag Assigned', N'Form', 2, 0, 1, N'/tagassigned/', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (32, 31, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (33, 31, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (34, 31, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (35, 31, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (36, 4, N'Tag Raised', N'Form', 1, 0, 1, N'/tagissued/', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (37, 36, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (38, 36, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (39, 36, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (40, 36, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (41, 3, N'Location', N'Form', 1, 0, 1, N'/setup/location', N'/setup/location')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (42, 41, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (43, 41, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (44, 41, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (45, 41, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (46, 3, N'Section', N'Form', 1, 0, 1, N'machineSection', N'machineSection')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (47, 46, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (48, 46, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (49, 46, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (50, 46, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (51, 3, N'Email', N'Form', 1, 0, 1, N'/email', N'/email')
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (52, 51, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (53, 51, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (54, 51, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (55, 51, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (67, 3, N'AssemblyLine', N'Form', 1, 0, 1, N'/assemblyForm', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (69, 67, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (70, 67, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (71, 67, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (72, 67, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (73, 4, N'Tag Dashboard', N'Form', 1, 0, 1, N'/assembly', NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (74, 73, N'GET', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (75, 73, N'POST', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (76, 73, N'PUT', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
INSERT [dbo].[tblMenu] ([ControlId], [Pcid], [ControlName], [ControlType], [SortOrder], [IsAp], [IsMenu], [Route], [Icon]) VALUES (77, 73, N'DELETE', N'Ctrl', 1, 0, 1, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[tblMenu] OFF
GO
INSERT [dbo].[tblRole] ([Id], [IsActive], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c7b013f0-5201-4317-abd8-c211f91b7330', 1, N'User', N'USER', N'ab216618-c1fd-4f3b-b639-c9cc28dc7f42')
GO
INSERT [dbo].[tblRole] ([Id], [IsActive], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'fab4fac1-c546-41de-aebc-a14da6895711', 1, N'Admin', N'ADMIN', N'6f34f540-297a-4790-8c47-c38ceb32fe3d')
GO
SET IDENTITY_INSERT [dbo].[tblPermission] ON 
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (108, 1, N'c7b013f0-5201-4317-abd8-c211f91b7330', N'home', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (109, 4, N'c7b013f0-5201-4317-abd8-c211f91b7330', N'transactions', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (110, 33, N'c7b013f0-5201-4317-abd8-c211f91b7330', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (111, 32, N'c7b013f0-5201-4317-abd8-c211f91b7330', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (112, 34, N'c7b013f0-5201-4317-abd8-c211f91b7330', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (113, 35, N'c7b013f0-5201-4317-abd8-c211f91b7330', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (114, 4, N'c7b013f0-5201-4317-abd8-c211f91b7330', N'transactions', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (115, 38, N'c7b013f0-5201-4317-abd8-c211f91b7330', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (116, 37, N'c7b013f0-5201-4317-abd8-c211f91b7330', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (117, 39, N'c7b013f0-5201-4317-abd8-c211f91b7330', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (118, 40, N'c7b013f0-5201-4317-abd8-c211f91b7330', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (175, 1, N'fab4fac1-c546-41de-aebc-a14da6895711', N'home', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (176, 2, N'fab4fac1-c546-41de-aebc-a14da6895711', N'security', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (177, 12, N'fab4fac1-c546-41de-aebc-a14da6895711', N'users', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (178, 11, N'fab4fac1-c546-41de-aebc-a14da6895711', N'users', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (179, 13, N'fab4fac1-c546-41de-aebc-a14da6895711', N'users', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (180, 14, N'fab4fac1-c546-41de-aebc-a14da6895711', N'users', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (181, 2, N'fab4fac1-c546-41de-aebc-a14da6895711', N'security', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (182, 16, N'fab4fac1-c546-41de-aebc-a14da6895711', N'role', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (183, 15, N'fab4fac1-c546-41de-aebc-a14da6895711', N'role', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (184, 17, N'fab4fac1-c546-41de-aebc-a14da6895711', N'role', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (185, 18, N'fab4fac1-c546-41de-aebc-a14da6895711', N'role', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (186, 3, N'fab4fac1-c546-41de-aebc-a14da6895711', N'setup', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (187, 20, N'fab4fac1-c546-41de-aebc-a14da6895711', N'department', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (188, 19, N'fab4fac1-c546-41de-aebc-a14da6895711', N'department', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (189, 21, N'fab4fac1-c546-41de-aebc-a14da6895711', N'department', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (190, 22, N'fab4fac1-c546-41de-aebc-a14da6895711', N'department', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (191, 3, N'fab4fac1-c546-41de-aebc-a14da6895711', N'setup', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (192, 24, N'fab4fac1-c546-41de-aebc-a14da6895711', N'machine master', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (193, 23, N'fab4fac1-c546-41de-aebc-a14da6895711', N'machine master', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (194, 25, N'fab4fac1-c546-41de-aebc-a14da6895711', N'machine master', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (195, 26, N'fab4fac1-c546-41de-aebc-a14da6895711', N'machine master', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (196, 3, N'fab4fac1-c546-41de-aebc-a14da6895711', N'setup', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (197, 28, N'fab4fac1-c546-41de-aebc-a14da6895711', N'loss category', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (198, 27, N'fab4fac1-c546-41de-aebc-a14da6895711', N'loss category', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (199, 29, N'fab4fac1-c546-41de-aebc-a14da6895711', N'loss category', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (200, 30, N'fab4fac1-c546-41de-aebc-a14da6895711', N'loss category', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (201, 3, N'fab4fac1-c546-41de-aebc-a14da6895711', N'setup', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (202, 43, N'fab4fac1-c546-41de-aebc-a14da6895711', N'location', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (203, 42, N'fab4fac1-c546-41de-aebc-a14da6895711', N'location', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (204, 44, N'fab4fac1-c546-41de-aebc-a14da6895711', N'location', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (205, 45, N'fab4fac1-c546-41de-aebc-a14da6895711', N'location', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (206, 3, N'fab4fac1-c546-41de-aebc-a14da6895711', N'setup', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (207, 48, N'fab4fac1-c546-41de-aebc-a14da6895711', N'section', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (208, 47, N'fab4fac1-c546-41de-aebc-a14da6895711', N'section', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (209, 49, N'fab4fac1-c546-41de-aebc-a14da6895711', N'section', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (210, 50, N'fab4fac1-c546-41de-aebc-a14da6895711', N'section', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (211, 3, N'fab4fac1-c546-41de-aebc-a14da6895711', N'setup', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (212, 53, N'fab4fac1-c546-41de-aebc-a14da6895711', N'email', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (213, 52, N'fab4fac1-c546-41de-aebc-a14da6895711', N'email', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (214, 54, N'fab4fac1-c546-41de-aebc-a14da6895711', N'email', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (215, 55, N'fab4fac1-c546-41de-aebc-a14da6895711', N'email', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (216, 4, N'fab4fac1-c546-41de-aebc-a14da6895711', N'transactions', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (217, 33, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (218, 32, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (219, 34, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (220, 35, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag assigned', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (221, 4, N'fab4fac1-c546-41de-aebc-a14da6895711', N'transactions', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (222, 38, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (223, 37, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (224, 39, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (225, 40, N'fab4fac1-c546-41de-aebc-a14da6895711', N'tag raised', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (226, 3, N'fab4fac1-c546-41de-aebc-a14da6895711', N'setup', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (227, 70, N'fab4fac1-c546-41de-aebc-a14da6895711', N'assembly', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (228, 69, N'fab4fac1-c546-41de-aebc-a14da6895711', N'assembly', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (229, 71, N'fab4fac1-c546-41de-aebc-a14da6895711', N'assembly', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (230, 72, N'fab4fac1-c546-41de-aebc-a14da6895711', N'assembly', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (231, 4, N'fab4fac1-c546-41de-aebc-a14da6895711', N'transactions', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tblPermission] ([Id], [ControlId], [RoleId], [Route], [CreatedOn], [UpdatedOn], [DeletedOn], [CreatedBy], [UpdatedBy], [DeletedBy], [IsActive]) VALUES (232, 74, N'fab4fac1-c546-41de-aebc-a14da6895711', N'design', NULL, NULL, NULL, NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[tblPermission] OFF
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
