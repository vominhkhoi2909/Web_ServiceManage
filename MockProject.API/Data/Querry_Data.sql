--Hướng dẫn chạy file querry
--1. Tô đậm phần cần chạy lấy dữ liệu.
--2. Ấn nút tam giá xanh lá trên cùng phần đếm số dòng code bên trái.
--3. Cửa sở bật lên chọn Local > db là MSSQLLocalDB.
--4. Phía dưới có dòng Databasename nhấp vào chọn DB_iHome.
--5. Ấn ok.

USE [DB_iHome]
GO
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Address], [WardId], [DistrictId], [CityId], [Status], [Avatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [CreateDate]) VALUES (N'2d2b3f87-5620-4bf5-a549-cd9278088ccc', N'Alice', N'141 Ho Chi Minh', 0, 0, 0, 1, N'images (1)202202310757.jpg', N'long02@example.com', N'LONG02@EXAMPLE.COM', N'long02@example.com', N'LONG02@EXAMPLE.COM', 1, N'AQAAAAEAACcQAAAAEBDbkbWZgyzfwS0Jikrvi7jo35R9cXuznHoRc0B48vZdB0eF+mt+c/jeFWDEGVloIQ==', N'6HJLWD6JYP4BQRR2LCHWTUYNC5JXXRHU', N'9a6389ef-1299-4c54-b3a7-58a73a9b51ba', N'0919813000', 0, 0, NULL, 1, 0, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Address], [WardId], [DistrictId], [CityId], [Status], [Avatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [CreateDate]) VALUES (N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f', N'Alex Teo', N'America, Inc.
5454 I 55 North
Jackson, Mississippi 39211', 0, 0, 0, 1, N'hinh-anh-avatar-nam-1202205310713.jpg', N'hoanglong13606@gmail.com', N'HOANGLONG13606@GMAIL.COM', N'hoanglong13606@gmail.com', N'HOANGLONG13606@GMAIL.COM', 1, NULL, N'BM3JMFAYWG62B4KWTDKTYTPVNGNZ4ILW', N'f162d870-2ee1-4aeb-beff-bc55b8030536', N'0919813000', 0, 0, NULL, 1, 0, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Address], [WardId], [DistrictId], [CityId], [Status], [Avatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [CreateDate]) VALUES (N'52b64d3f-aee1-41c2-92eb-cce2fa22b121', N'Johny Nguyen', N'Can Tho city', 0, 0, 0, 1, N'default.png', N'long01@example.com', N'LONG01@EXAMPLE.COM', N'long01@example.com', N'LONG01@EXAMPLE.COM', 1, N'AQAAAAEAACcQAAAAEMJV6MR/zm+xMNCfmtO3BfGcGE5LNB35FfcvkwZNyGenpSEcDBg1s1rdkWtsv40GbA==', N'6QLNGSIGK5Q6CQQV7XD67RASILJJFQ5F', N'689d854e-93b0-487f-8384-848cd7785867', N'0919813002', 0, 0, NULL, 1, 0, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Address], [WardId], [DistrictId], [CityId], [Status], [Avatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [CreateDate]) VALUES (N'7f6da323-9a1e-4117-bec8-dec619e01606', N'Mike', N'HCM city', 0, 0, 0, 1, N'anh-Avatar-cute-min202207310722.jpg', N'long03@example.com', N'LONG03@EXAMPLE.COM', N'long03@example.com', N'LONG03@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAEBTdPuOh0geFERi7dyx56vXaPQxjyN6WaGvOMWPrWLJ5ntI8we+BF2BV2YBEI1JAiw==', N'EMKUT7PIDHBJWH3NCVBQBIEOKT4UOQ66', N'802af6a7-d209-4de9-9c49-1b55bd360d5e', N'0919813001', 0, 0, NULL, 1, 0, CAST(N'2022-07-24T15:36:23.983' AS DateTime))
INSERT [dbo].[AspNetUsers] ([Id], [Name], [Address], [WardId], [DistrictId], [CityId], [Status], [Avatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [CreateDate]) VALUES (N'baf65a83-99a2-4e39-98cc-5ffb93e46001', N'Robert', N'6 East Leeton Ridge Street Bronx, NY 10453', 0, 0, 0, 1, N'images (2)202240310744.jpg', N'Robert@example.com', N'ROBERT@EXAMPLE.COM', N'Robert@example.com', N'ROBERT@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAEKbPjxFgcOSRcpPDCWlcP9vQ2UIjadxCgtXsjhju0t5FK2SzggLObRk47GacbKB6iw==', N'VMPDJN6S2TCZMHYUWVA47TW42VQS2I3R', N'25dc91ad-fa43-4f09-81a4-8a215270e999', N'0919813012', 0, 0, NULL, 1, 0, CAST(N'2022-07-31T16:40:47.157' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[tReviews] ON 

INSERT [dbo].[tReviews] ([ReviewId], [RatingScore], [Comment], [CreateAt], [Status], [CreateBy]) VALUES (1, 3, N'Lorem ipsum dolor sit, amet consectetur adipisicing elit. Accusamus numquam assumenda
                                hic
                                aliquam vero sequi velit molestias doloremque molestiae dicta? Lorem ipsum dolor sit, amet consectetur adipisicing elit. Accusamus numquam assumenda
                                hic
                                aliquam vero sequi velit molestias doloremque molestiae dicta? Lorem ipsum dolor sit, amet consectetur adipisicing elit. Accusamus numquam assumenda
                                hic
                                aliquam vero sequi velit molestias doloremque molestiae dicta?', CAST(N'2022-05-05T00:00:00.000' AS DateTime), 1, N'52b64d3f-aee1-41c2-92eb-cce2fa22b121')
INSERT [dbo].[tReviews] ([ReviewId], [RatingScore], [Comment], [CreateAt], [Status], [CreateBy]) VALUES (2, 2, N'Lorem ipsum dolor sit, amet consectetur adipisicing elit. Accusamus numquam assumenda
                                hic
                                aliquam vero sequi velit molestias doloremque molestiae dicta?', CAST(N'2022-04-17T00:00:00.000' AS DateTime), 1, N'52b64d3f-aee1-41c2-92eb-cce2fa22b121')
INSERT [dbo].[tReviews] ([ReviewId], [RatingScore], [Comment], [CreateAt], [Status], [CreateBy]) VALUES (4, 5, N'the service is good, I''m very happy', CAST(N'2022-07-18T22:51:16.933' AS DateTime), 1, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f')
INSERT [dbo].[tReviews] ([ReviewId], [RatingScore], [Comment], [CreateAt], [Status], [CreateBy]) VALUES (8, 4, N'Service is good, the staffs are professional', CAST(N'2022-07-24T17:01:19.303' AS DateTime), 1, N'2d2b3f87-5620-4bf5-a549-cd9278088ccc')
INSERT [dbo].[tReviews] ([ReviewId], [RatingScore], [Comment], [CreateAt], [Status], [CreateBy]) VALUES (12, 1, N'The service is bad', CAST(N'2022-07-31T00:00:00.000' AS DateTime), 1, N'7f6da323-9a1e-4117-bec8-dec619e01606')
SET IDENTITY_INSERT [dbo].[tReviews] OFF
GO
SET IDENTITY_INSERT [dbo].[tRoles] ON 

INSERT [dbo].[tRoles] ([RoleId], [Name], [Status]) VALUES (1, N'Admin', 1)
INSERT [dbo].[tRoles] ([RoleId], [Name], [Status]) VALUES (2, N'Staff', 1)
SET IDENTITY_INSERT [dbo].[tRoles] OFF
GO
SET IDENTITY_INSERT [dbo].[tAdminUsers] ON 

INSERT [dbo].[tAdminUsers] ([UserId], [FullName], [Phone], [Email], [Address], [Username], [PasswordSalt], [Avatar], [Status], [RoleId], [PasswordHash], [ResetToken], [ResetTokenExpire], [Permission]) VALUES (29, N'Administrator', N'0976293294', N'quangminhit.dev1102@gmail.com', N'101 Independence Avenue, S.E.
Washington, D.C. 20559-6000', N'admin', N'Fc1do3Wjf6H8YaT4G0rIdFKSIvU3s2rPi2qmcv1AnrFefwb8GSeL7QGaevhtvTrJIFV2zhOFq872F39e3mlpcdi3Kx8xXNmmfMYzU8fMnT4UBlX00lWJx1I0NiTG8LumZMZ5ckWQFItViqnS0xk7g6XTjQkgjkcB8FD5PKqUexo=', N'red-admin-sign-pc-laptop-vector-illustration-administrator-icon-screen-controller-man-system-box-88756468202230280715.jpg', 1, 1, N'/771jq0fBW+3pCvvANsUSGTFV/ZPB7OS68AJ+tmKlsronM6lz9zHbyQ2bdP4oSxE71kI/36ZB6xYcADnZXc4Vg==', NULL, NULL, NULL)
INSERT [dbo].[tAdminUsers] ([UserId], [FullName], [Phone], [Email], [Address], [Username], [PasswordSalt], [Avatar], [Status], [RoleId], [PasswordHash], [ResetToken], [ResetTokenExpire], [Permission]) VALUES (30, N'Staff 01', N'0976293294', N'staff01@example.com', N'HCM city', N'staff01', N'77KijwDH1LNdBucRP1HZvZn7BQ94rdgycHdd7UyG1e3bJC6KcedCDixpPuuYvsrmkBqa6E4NgGl2ZOSgromUH56sV8J/yQ3/J3BEEMgsBZ4i468lf5fqsK0xjmsWFZNNgybtpR0yGJ8hUoSNNBoykOMqnhZ2tnMda2FGVkMH4/I=', N'download202232280703.png', 1, 2, N'7MPKpqJ/BGOS7b5w7fUIw869EZITANdfyzIMzYpYHqMUtptdCz32XoYz3uF+V9llqeSWBUdFm6XSdJKtVaVRqw==', NULL, NULL, N'1,2,3,9')
INSERT [dbo].[tAdminUsers] ([UserId], [FullName], [Phone], [Email], [Address], [Username], [PasswordSalt], [Avatar], [Status], [RoleId], [PasswordHash], [ResetToken], [ResetTokenExpire], [Permission]) VALUES (31, N'Staff 02', N'0919813002', N'staff02@example.com', N'HCM city', N'staff02', N'jhgQyMHd8csrWGj6EKRlow4IeVFFPYt91BZZF3TepWuRnho8rOMsZ7CK9JWuJo2jxJL9BxzeKZ7z+gb0W3O2IQd7Q8i8LAcUG+352R7h7IhmWPalvgv5TLlGzg7reZiI6xAEqYBxHl07f++rU1kujmHiIpz8s/AE/MB1QvYTozo=', N'download202256290756.png', 1, 2, N'cT+UNNnsIBMPuSG5q3l1LcGqvJViPBTlRoOzyuqGd/rK+0ca2SMHZ+SMndvjik4Q94jBukrEQ7Bo6w3zy6AjqQ==', NULL, NULL, N'1')
INSERT [dbo].[tAdminUsers] ([UserId], [FullName], [Phone], [Email], [Address], [Username], [PasswordSalt], [Avatar], [Status], [RoleId], [PasswordHash], [ResetToken], [ResetTokenExpire], [Permission]) VALUES (32, N'Staff 03', N'0919813003', N'Staff03@example.com', N'L.A USA', N'staff03', N'vxvkpASWAO8XP67dHetOcqRqbm/MUFfBunJZBRybI8CUVzXiymnlVGmjpArXg1OXQYLAU6PlK8U0KWFYknKU9MVMDUSCaDGPqIlWGK3yObWxJR/TIAFfrepFHjX3IKEb53BJrKZW0D0eY39CQSKxfAyIac2ljw8cFR/pJBwTWh8=', N'download202255300735.png', 1, 2, N'X1NP7i/3IoP/EhTboEaRyaeyX4RVJwzj68518AI7qbjZAS9VzwULsFyTESojeRMAdK6zicnz/u4CfgElpVDoHA==', NULL, NULL, N'5,4,3,2,1')
INSERT [dbo].[tAdminUsers] ([UserId], [FullName], [Phone], [Email], [Address], [Username], [PasswordSalt], [Avatar], [Status], [RoleId], [PasswordHash], [ResetToken], [ResetTokenExpire], [Permission]) VALUES (33, N'Staff 04', N'0919813003', N'Staff04@example.com', N'L.A USA', N'staff04', N'vxvkpASWAO8XP67dHetOcqRqbm/MUFfBunJZBRybI8CUVzXiymnlVGmjpArXg1OXQYLAU6PlK8U0KWFYknKU9MVMDUSCaDGPqIlWGK3yObWxJR/TIAFfrepFHjX3IKEb53BJrKZW0D0eY39CQSKxfAyIac2ljw8cFR/pJBwTWh8=', N'download202255300735.png', 1, 2, N'X1NP7i/3IoP/EhTboEaRyaeyX4RVJwzj68518AI7qbjZAS9VzwULsFyTESojeRMAdK6zicnz/u4CfgElpVDoHA==', NULL, NULL, N'1')
INSERT [dbo].[tAdminUsers] ([UserId], [FullName], [Phone], [Email], [Address], [Username], [PasswordSalt], [Avatar], [Status], [RoleId], [PasswordHash], [ResetToken], [ResetTokenExpire], [Permission]) VALUES (34, N'Staff 05', N'0919813003', N'Staff05@example.com', N'L.A USA', N'staff05', N'vxvkpASWAO8XP67dHetOcqRqbm/MUFfBunJZBRybI8CUVzXiymnlVGmjpArXg1OXQYLAU6PlK8U0KWFYknKU9MVMDUSCaDGPqIlWGK3yObWxJR/TIAFfrepFHjX3IKEb53BJrKZW0D0eY39CQSKxfAyIac2ljw8cFR/pJBwTWh8=', N'download202255300735.png', 1, 2, N'X1NP7i/3IoP/EhTboEaRyaeyX4RVJwzj68518AI7qbjZAS9VzwULsFyTESojeRMAdK6zicnz/u4CfgElpVDoHA==', NULL, NULL, N'1')
INSERT [dbo].[tAdminUsers] ([UserId], [FullName], [Phone], [Email], [Address], [Username], [PasswordSalt], [Avatar], [Status], [RoleId], [PasswordHash], [ResetToken], [ResetTokenExpire], [Permission]) VALUES (35, N'Staff 06', N'0919813003', N'Staff06@example.com', N'L.A USA', N'staff06', N'vxvkpASWAO8XP67dHetOcqRqbm/MUFfBunJZBRybI8CUVzXiymnlVGmjpArXg1OXQYLAU6PlK8U0KWFYknKU9MVMDUSCaDGPqIlWGK3yObWxJR/TIAFfrepFHjX3IKEb53BJrKZW0D0eY39CQSKxfAyIac2ljw8cFR/pJBwTWh8=', N'download202255300735.png', 1, 2, N'X1NP7i/3IoP/EhTboEaRyaeyX4RVJwzj68518AI7qbjZAS9VzwULsFyTESojeRMAdK6zicnz/u4CfgElpVDoHA==', NULL, NULL, N'1')
INSERT [dbo].[tAdminUsers] ([UserId], [FullName], [Phone], [Email], [Address], [Username], [PasswordSalt], [Avatar], [Status], [RoleId], [PasswordHash], [ResetToken], [ResetTokenExpire], [Permission]) VALUES (36, N'Staff 07', N'0919813003', N'Staff07@example.com', N'L.A USA', N'staff07', N'vxvkpASWAO8XP67dHetOcqRqbm/MUFfBunJZBRybI8CUVzXiymnlVGmjpArXg1OXQYLAU6PlK8U0KWFYknKU9MVMDUSCaDGPqIlWGK3yObWxJR/TIAFfrepFHjX3IKEb53BJrKZW0D0eY39CQSKxfAyIac2ljw8cFR/pJBwTWh8=', N'download202255300735.png', 1, 2, N'X1NP7i/3IoP/EhTboEaRyaeyX4RVJwzj68518AI7qbjZAS9VzwULsFyTESojeRMAdK6zicnz/u4CfgElpVDoHA==', NULL, NULL, N'1')
INSERT [dbo].[tAdminUsers] ([UserId], [FullName], [Phone], [Email], [Address], [Username], [PasswordSalt], [Avatar], [Status], [RoleId], [PasswordHash], [ResetToken], [ResetTokenExpire], [Permission]) VALUES (37, N'Staff 08', N'0919813003', N'Staff08@example.com', N'L.A USA', N'staff08', N'vxvkpASWAO8XP67dHetOcqRqbm/MUFfBunJZBRybI8CUVzXiymnlVGmjpArXg1OXQYLAU6PlK8U0KWFYknKU9MVMDUSCaDGPqIlWGK3yObWxJR/TIAFfrepFHjX3IKEb53BJrKZW0D0eY39CQSKxfAyIac2ljw8cFR/pJBwTWh8=', N'download202255300735.png', 1, 2, N'X1NP7i/3IoP/EhTboEaRyaeyX4RVJwzj68518AI7qbjZAS9VzwULsFyTESojeRMAdK6zicnz/u4CfgElpVDoHA==', NULL, NULL, N'1')
INSERT [dbo].[tAdminUsers] ([UserId], [FullName], [Phone], [Email], [Address], [Username], [PasswordSalt], [Avatar], [Status], [RoleId], [PasswordHash], [ResetToken], [ResetTokenExpire], [Permission]) VALUES (38, N'Staff 09', N'0919813003', N'Staff09@example.com', N'L.A USA', N'staff09', N'vxvkpASWAO8XP67dHetOcqRqbm/MUFfBunJZBRybI8CUVzXiymnlVGmjpArXg1OXQYLAU6PlK8U0KWFYknKU9MVMDUSCaDGPqIlWGK3yObWxJR/TIAFfrepFHjX3IKEb53BJrKZW0D0eY39CQSKxfAyIac2ljw8cFR/pJBwTWh8=', N'download202255300735.png', 1, 2, N'X1NP7i/3IoP/EhTboEaRyaeyX4RVJwzj68518AI7qbjZAS9VzwULsFyTESojeRMAdK6zicnz/u4CfgElpVDoHA==', NULL, NULL, N'1')
INSERT [dbo].[tAdminUsers] ([UserId], [FullName], [Phone], [Email], [Address], [Username], [PasswordSalt], [Avatar], [Status], [RoleId], [PasswordHash], [ResetToken], [ResetTokenExpire], [Permission]) VALUES (39, N'Staff 10', N'0919813003', N'Staff10@example.com', N'L.A USA', N'staff10', N'vxvkpASWAO8XP67dHetOcqRqbm/MUFfBunJZBRybI8CUVzXiymnlVGmjpArXg1OXQYLAU6PlK8U0KWFYknKU9MVMDUSCaDGPqIlWGK3yObWxJR/TIAFfrepFHjX3IKEb53BJrKZW0D0eY39CQSKxfAyIac2ljw8cFR/pJBwTWh8=', N'download202255300735.png', 1, 2, N'X1NP7i/3IoP/EhTboEaRyaeyX4RVJwzj68518AI7qbjZAS9VzwULsFyTESojeRMAdK6zicnz/u4CfgElpVDoHA==', NULL, NULL, N'1')
SET IDENTITY_INSERT [dbo].[tAdminUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[tJobOrders] ON 

INSERT [dbo].[tJobOrders] ([JOId], [Duration], [StartAt], [Address], [WardId], [DistrictId], [CityId], [Description], [State], [Status], [StaffId], [CustomerId]) VALUES (26, 8.5, CAST(N'2022-01-05T14:31:00.000' AS DateTime), N'America, Inc.5454 I 55 NorthJackson, Mississippi 39211', 0, 0, 0, N'', 4, 1, 30, N'2d2b3f87-5620-4bf5-a549-cd9278088ccc')
INSERT [dbo].[tJobOrders] ([JOId], [Duration], [StartAt], [Address], [WardId], [DistrictId], [CityId], [Description], [State], [Status], [StaffId], [CustomerId]) VALUES (27, 2.5, CAST(N'2022-03-02T15:23:00.000' AS DateTime), N'America, Inc.5454 I 55 NorthJackson, Mississippi 39211', 0, 0, 0, N'Please on time', 4, 1, 30, N'2d2b3f87-5620-4bf5-a549-cd9278088ccc')
INSERT [dbo].[tJobOrders] ([JOId], [Duration], [StartAt], [Address], [WardId], [DistrictId], [CityId], [Description], [State], [Status], [StaffId], [CustomerId]) VALUES (28, 4.5, CAST(N'2022-07-03T15:37:00.000' AS DateTime), N'America, Inc.5454 I 55 NorthJackson, Mississippi 39211', 0, 0, 0, N'I need help', 4, 1, 31, N'7f6da323-9a1e-4117-bec8-dec619e01606')
INSERT [dbo].[tJobOrders] ([JOId], [Duration], [StartAt], [Address], [WardId], [DistrictId], [CityId], [Description], [State], [Status], [StaffId], [CustomerId]) VALUES (29, 4.5, CAST(N'2022-04-01T15:42:00.000' AS DateTime), N'HCM City', 0, 0, 0, N'Carefully please', 4, 1, 32, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f')
INSERT [dbo].[tJobOrders] ([JOId], [Duration], [StartAt], [Address], [WardId], [DistrictId], [CityId], [Description], [State], [Status], [StaffId], [CustomerId]) VALUES (30, 5.5, CAST(N'2022-04-01T15:45:00.000' AS DateTime), N'141 Can Tho city', 0, 0, 0, N'', 4, 1, 33, N'52b64d3f-aee1-41c2-92eb-cce2fa22b121')
INSERT [dbo].[tJobOrders] ([JOId], [Duration], [StartAt], [Address], [WardId], [DistrictId], [CityId], [Description], [State], [Status], [StaffId], [CustomerId]) VALUES (31, 2.5, CAST(N'2022-05-02T15:47:00.000' AS DateTime), N'America, Inc.5454 I 55 NorthJackson, Mississippi 39211', 0, 0, 0, N'', 4, 1, 34, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f')
INSERT [dbo].[tJobOrders] ([JOId], [Duration], [StartAt], [Address], [WardId], [DistrictId], [CityId], [Description], [State], [Status], [StaffId], [CustomerId]) VALUES (32, 1.5, CAST(N'2022-08-02T15:49:00.000' AS DateTime), N'America, Inc.5454 I 55 NorthJackson, Mississippi 39211', 0, 0, 0, N'', 3, 1, NULL, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f')
INSERT [dbo].[tJobOrders] ([JOId], [Duration], [StartAt], [Address], [WardId], [DistrictId], [CityId], [Description], [State], [Status], [StaffId], [CustomerId]) VALUES (33, 3.5, CAST(N'2022-08-11T15:50:00.000' AS DateTime), N'America, Inc.5454 I 55 NorthJackson, Mississippi 39211', 0, 0, 0, N'', 2, 1, 30, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f')
INSERT [dbo].[tJobOrders] ([JOId], [Duration], [StartAt], [Address], [WardId], [DistrictId], [CityId], [Description], [State], [Status], [StaffId], [CustomerId]) VALUES (34, 1.5, CAST(N'2022-08-31T15:50:00.000' AS DateTime), N'America, Inc.5454 I 55 NorthJackson, Mississippi 39211', 0, 0, 0, N'', 1, 1, NULL, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f')
INSERT [dbo].[tJobOrders] ([JOId], [Duration], [StartAt], [Address], [WardId], [DistrictId], [CityId], [Description], [State], [Status], [StaffId], [CustomerId]) VALUES (35, 3.5, CAST(N'2022-08-11T16:08:00.000' AS DateTime), N'America, Inc.5454 I 55 NorthJackson, Mississippi 39211', 0, 0, 0, N'', 1, 1, NULL, N'52b64d3f-aee1-41c2-92eb-cce2fa22b121')
INSERT [dbo].[tJobOrders] ([JOId], [Duration], [StartAt], [Address], [WardId], [DistrictId], [CityId], [Description], [State], [Status], [StaffId], [CustomerId]) VALUES (36, 3.5, CAST(N'2022-08-03T17:59:00.000' AS DateTime), N'America, Inc.5454 I 55 NorthJackson, Mississippi 39211', 0, 0, 0, N'cancel for me please', 3, 1, 30, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f')
INSERT [dbo].[tJobOrders] ([JOId], [Duration], [StartAt], [Address], [WardId], [DistrictId], [CityId], [Description], [State], [Status], [StaffId], [CustomerId]) VALUES (37, 3.5, CAST(N'2022-08-06T23:20:00.000' AS DateTime), N'America, Inc.5454 I 55 NorthJackson, Mississippi 39211', 0, 0, 0, N'', 1, 1, NULL, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f')
SET IDENTITY_INSERT [dbo].[tJobOrders] OFF
GO
SET IDENTITY_INSERT [dbo].[tOptions] ON 

INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (1, N'HEATING AND AIR
CONDITIONING REPAIR AND
INSTALLATION COMPANY', 9, N'Accumsan bibendum the sit amet, consectetur adipiscing elit.
Pellentesque accumsan bibendum bibendum diam et. Ac
vulputate morbi egestas porta posuere curabitur.

Pellentesque accumsan bibendum bibendum diam et. Ac
vulputate morbi egestas porta posuere curabitur.', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (2, N'Air Conditioner', 1, N' <div class="bold-text">How do consumers see your brand
                                                                relative to your competitors? How should a new product
                                                                be positioned when it’s launched? Which customer
                                                                segments are most interested in our current offerings?
                                                            </div>
                                                            <p>How do consumers see your brand relative to your
                                                                competitors? How should a new product be positioned when
                                                                it’s launched? Which customer segments are most
                                                                interested in our current offerings?</p>
                                                            <p>For these questions and many others, surveys remain the
                                                                tried and true method for gaining marketing insights.
                                                            </p>', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (3, N'Mattress', 2, N' <div class="bold-text">How do consumers see your brand
                                                                relative to your competitors? How should a new product
                                                                be positioned when it’s launched? Which customer
                                                                segments are most interested in our current offerings?
                                                            </div>
                                                            <p>How do consumers see your brand relative to your
                                                                competitors? How should a new product be positioned when
                                                                it’s launched? Which customer segments are most
                                                                interested in our current offerings?</p>
                                                            <p>For these questions and many others, surveys remain the
                                                                tried and true method for gaining marketing insights.
                                                            </p>', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (4, N'Miscellaneous', 3, N' <div class="bold-text">How do consumers see your brand
                                                                relative to your competitors? How should a new product
                                                                be positioned when it’s launched? Which customer
                                                                segments are most interested in our current offerings?
                                                            </div>
                                                            <p>How do consumers see your brand relative to your
                                                                competitors? How should a new product be positioned when
                                                                it’s launched? Which customer segments are most
                                                                interested in our current offerings?</p>
                                                            <p>For these questions and many others, surveys remain the
                                                                tried and true method for gaining marketing insights.
                                                            </p>', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (5, N'MIT Heavy', 4, N'lorem', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (6, N'Panasonic', 4, N'Lorem', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (7, N'Toshiba', 4, N'lorem', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (8, N'King ', 5, N'lorem', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (9, N'Queen', 5, N'lorem', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (10, N'I''m busy', 6, N'lorem', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (11, N'I found another vendor', 6, N'lorem', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (12, N'I''m not sure', 7, N'lorem', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (13, N'I have another account', 7, N'lorem', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (14, N'Client not available', 8, N'lorem', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (15, N'Cancel request by client', 8, N'lorem', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (16, N'Postpone by client', 8, N'lorem', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (17, N'Other', 10, N'lorem', NULL, 1)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (18, N'', 4, N'', N'', 0)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (19, N'wertyui', 4, N'', N'', 0)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (20, N's', 4, N'', N'', 0)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (21, N' ', 4, N'', N'', 0)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (22, N'', 4, N'', N'', 0)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (23, N'   s', 4, N'', N'', 0)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (24, N' new brand', 4, N'', N'', 0)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (25, N' a', 4, N'', N'', 0)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (26, N' x', 5, N'', N'', 0)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (27, N'adas', 4, N'', N'', 0)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (28, N'xa', 5, N'', N'', 0)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (29, N'xx', 4, N'', N'', 0)
INSERT [dbo].[tOptions] ([OptionId], [Title], [Type], [Description], [Image], [Status]) VALUES (30, N'xx', 5, N'', N'', 0)
SET IDENTITY_INSERT [dbo].[tOptions] OFF
GO
SET IDENTITY_INSERT [dbo].[tServices] ON 

INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (1, N'General Aircon Services', 1, 22, 3, N'General Aircon Services accumsan bibendum the sit amet, consectetur adipiscing elit. Pellentesque accumsan bibendum bibendum diam et. Ac vulputate morbi egestas porta posuere curabitur. ', 1)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (2, N'Chemical Wash', 1, 20, 1, N'Chemical Wash accumsan bibendum the sit amet, consectetur adipiscing elit. Pellentesque accumsan bibendum bibendum diam et. Ac vulputate morbi egestas porta posuere curabitur. ', 1)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (3, N'Chemical Overhaul', 1, 10, 1, N'Chemical Overhaul accumsan bibendum the sit amet, consectetur adipiscing elit. Pellentesque accumsan bibendum bibendum diam et. Ac vulputate morbi egestas porta posuere curabitur. ', 1)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (4, N'Condensing Unit Service', 1, 20, 1, N'Condensing Unit Service accumsan bibendum the sit amet, consectetur adipiscing elit. Pellentesque accumsan bibendum bibendum diam et. Ac vulputate morbi egestas porta posuere curabitur. ', 1)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (5, N'Refrigirant (gas) Top Up', 1, 30, 2, N'Refrigirant (gas) Top Up accumsan bibendum the sit amet, consectetur adipiscing elit. Pellentesque accumsan bibendum bibendum diam et. Ac vulputate morbi egestas porta posuere curabitur. ', 1)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (6, N'Repair Checking', 1, 10, 0.5, N'Repair Checking accumsan bibendum the sit amet, consectetur adipiscing elit. Pellentesque accumsan bibendum bibendum diam et. Ac vulputate morbi egestas porta posuere curabitur. ', 1)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (7, N'Mattress Cleaning', 2, 15, 1, N'Mattress Cleaning accumsan bibendum the sit amet, consectetur adipiscing elit. Pellentesque accumsan bibendum bibendum diam et. Ac vulputate morbi egestas porta posuere curabitur. ', 1)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (8, N'Mattress Steam', 2, 25, 2, N'Mattress Steam accumsan bibendum the sit amet, consectetur adipiscing elit. Pellentesque accumsan bibendum bibendum diam et. Ac vulputate morbi egestas porta posuere curabitur. ', 1)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (12, N'Carpet Cleaning', 3, 20, 1, N'Carpet Cleaning accumsan bibendum the sit amet, consectetur adipiscing elit. Pellentesque accumsan bibendum bibendum diam et. Ac vulputate morbi egestas porta posuere curabitur. ', 1)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (13, N'Pillow Cleaning', 3, 20, 0.5, N'Pillow Cleaning accumsan bibendum the sit amet, consectetur adipiscing elit. Pellentesque accumsan bibendum bibendum diam et. Ac vulputate morbi egestas porta posuere curabitur. ', 1)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (14, N'1', 2, 1, 1, N'1', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (15, N'1', 1, 1, 1, N'1', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (16, N'12', 3, 12, 12, N'	Pillow Cleaning accumsan bibendum the sit amet, consectetur adipiscing elit. Pellentesque accumsan bibendum bibendum diam et. Ac vulputate morbi egestas porta posuere curabitur.', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (17, N'2', 1, 2, 2, N'2', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (18, N'string', 1, 0, 0, N'string', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (19, N'3', 1, 3, 3, N'3', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (20, N'4', 1, 4, 4, N'4', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (21, N'4', 1, 4, 4, N'4', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (22, N'5', 1, 5, 5, N'5', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (23, N'6', 1, 6, 6, N'6', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (24, N'7', 1, 7, 7, N'7', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (25, N'1', 2, 1, 1, N'1', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (26, N'x', 1, 1, 12, N'1', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (27, N's', 1, 1, 1, N' dsad', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (28, N'1', 1, 1.2000000476837158, 1, N'1', 0)
INSERT [dbo].[tServices] ([ServiceId], [Name], [Type], [Price], [Duration], [Description], [Status]) VALUES (29, N'x', 3, 1, 1.5199999809265137, N'sa', 0)
SET IDENTITY_INSERT [dbo].[tServices] OFF
GO
SET IDENTITY_INSERT [dbo].[tJobOrderDetails] ON 

INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (38, 2, N' ', 5, 3, 26, 10)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (39, 1, N' ', 8, 7, 26, 15)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (40, 1, N' ', 6, 3, 26, 10)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (41, 2, N' ', 5, 2, 26, 20)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (42, 1, N' ', 6, 2, 26, 20)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (43, 2, N' ', 10, 12, 26, 20)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (44, 2, N' ', 10, 13, 27, 20)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (45, 1, N' ', 10, 12, 27, 20)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (46, 2, N' ', 5, 4, 28, 20)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (47, 2, N' ', 5, 3, 28, 10)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (48, 2, N' ', 8, 8, 29, 25)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (49, 1, N' ', 6, 1, 30, 22)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (50, 1, N' ', 6, 5, 30, 30)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (51, 2, N' ', 6, 4, 31, 20)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (52, 1, N' ', 5, 3, 32, 10)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (53, 1, N' ', 5, 1, 33, 22)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (54, 1, N' ', 6, 4, 34, 20)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (55, 1, N' ', 6, 1, 35, 22)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (56, 1, N' ', 8, 7, 36, 15)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (57, 1, N' ', 10, 12, 36, 20)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (58, 1, N' ', 9, 7, 36, 15)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (59, 1, N' ', 5, 5, 36, 30)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (60, 2, N' ', 5, 3, 37, 10)
INSERT [dbo].[tJobOrderDetails] ([JODetailId], [Quantily], [Image], [OptionId], [ServiceId], [JOId], [Price]) VALUES (61, 2, N' ', 5, 6, 37, 10)
SET IDENTITY_INSERT [dbo].[tJobOrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[tPermissions] ON 

INSERT [dbo].[tPermissions] ([PermissionId], [Title], [Status], [Link]) VALUES (1, N'Staff Job Order', 1, N'Admin/StaffJobOrder')
INSERT [dbo].[tPermissions] ([PermissionId], [Title], [Status], [Link]) VALUES (2, N'Config Management', 1, N'Admin/Config')
INSERT [dbo].[tPermissions] ([PermissionId], [Title], [Status], [Link]) VALUES (3, N'Slider Management', 1, N'Admin/Slider')
INSERT [dbo].[tPermissions] ([PermissionId], [Title], [Status], [Link]) VALUES (4, N'Review Management', 1, N'Admin/Review')
INSERT [dbo].[tPermissions] ([PermissionId], [Title], [Status], [Link]) VALUES (5, N'Contact Management', 1, N'Admin/Contact')
SET IDENTITY_INSERT [dbo].[tPermissions] OFF
GO
SET IDENTITY_INSERT [dbo].[tNotes] ON 

INSERT [dbo].[tNotes] ([NoteId], [CreateAt], [Title], [Type], [Description], [Status], [CreateBy]) VALUES (2, CAST(N'2022-07-29T13:49:37.310' AS DateTime), N'Give salary to employee', 1, N'Blandit tempus porttitor aasfs. Integer posuere erat a ante venenatis.', 1, 30)
INSERT [dbo].[tNotes] ([NoteId], [CreateAt], [Title], [Type], [Description], [Status], [CreateBy]) VALUES (4, CAST(N'2022-07-29T14:39:08.903' AS DateTime), N'x', 2, N'x', 0, 30)
INSERT [dbo].[tNotes] ([NoteId], [CreateAt], [Title], [Type], [Description], [Status], [CreateBy]) VALUES (5, CAST(N'2022-07-29T14:39:16.067' AS DateTime), N'Give Review for design ', 1, N'Blandit tempus porttitor aasfs. Integer posuere erat a ante venenatis.', 1, 30)
INSERT [dbo].[tNotes] ([NoteId], [CreateAt], [Title], [Type], [Description], [Status], [CreateBy]) VALUES (6, CAST(N'2022-07-29T14:49:54.210' AS DateTime), N'á', 1, N's', 0, 30)
INSERT [dbo].[tNotes] ([NoteId], [CreateAt], [Title], [Type], [Description], [Status], [CreateBy]) VALUES (7, CAST(N'2022-07-29T14:59:09.770' AS DateTime), N'Change a Design', 1, N'Blandit tempus porttitor aasfs. Integer posuere erat a ante venenatis.', 1, 31)
INSERT [dbo].[tNotes] ([NoteId], [CreateAt], [Title], [Type], [Description], [Status], [CreateBy]) VALUES (8, CAST(N'2022-07-29T15:00:12.587' AS DateTime), N'Launch new template', 2, N'Blandit tempus porttitor aasfs. Integer posuere erat a ante venenatis.', 1, 31)
INSERT [dbo].[tNotes] ([NoteId], [CreateAt], [Title], [Type], [Description], [Status], [CreateBy]) VALUES (9, CAST(N'2022-07-29T16:08:38.480' AS DateTime), N'Book a Ticket for Movie', 3, N'Blandit tempus porttitor aasfs. Integer posuere erat a ante venenatis.', 1, 30)
INSERT [dbo].[tNotes] ([NoteId], [CreateAt], [Title], [Type], [Description], [Status], [CreateBy]) VALUES (10, CAST(N'2022-07-29T16:13:28.607' AS DateTime), N'Finish Mockup Project', 2, N'Blandit tempus porttitor aasfs. Integer posuere erat a ante venenatis.', 1, 30)
INSERT [dbo].[tNotes] ([NoteId], [CreateAt], [Title], [Type], [Description], [Status], [CreateBy]) VALUES (11, CAST(N'2022-07-29T16:13:39.040' AS DateTime), N'x', 2, N'x', 0, 30)
INSERT [dbo].[tNotes] ([NoteId], [CreateAt], [Title], [Type], [Description], [Status], [CreateBy]) VALUES (12, CAST(N'2022-07-29T16:15:08.280' AS DateTime), N'abc@123', 1, N'xBlandit tempus porttitor aasfs. Integer posuere erat a ante venenatis.Blandit tempus porttitor aasfs. Integer posuere erat a ante venenatis.Blandit tempus porttitor aasfs. Integer posuere erat a ante venenatis.Blandit tempus porttitor aasfs. Integer posuere erat a ante venenatis.', 1, 30)
SET IDENTITY_INSERT [dbo].[tNotes] OFF
GO
SET IDENTITY_INSERT [dbo].[tNotifications] ON 
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (1, CAST(N'2022-07-31T14:32:11.770' AS DateTime), N'You has been assigned Job Order!', N'Job Order Code: 26', N'', 1, 1, N'30', 10, NULL)
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (2, CAST(N'2022-07-31T14:33:09.327' AS DateTime), N'Job Order Assigned', N'Your job order with ID: 26 has been assigned to our staff. They will contact you soon', N'', 1, 1, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f', 2, NULL)
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (3, CAST(N'2022-07-31T14:33:53.450' AS DateTime), N'Job Order Completed', N'Your job order with ID: 26 has been completed', N'', 1, 1, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f', 2, NULL)
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (4, CAST(N'2022-07-31T15:23:49.920' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 27', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/27')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (5, CAST(N'2022-07-31T15:23:49.940' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 27', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/27')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (6, CAST(N'2022-07-31T15:25:53.203' AS DateTime), N'You has been assigned Job Order!', N'Job Order Code: 27', N'', 1, 1, N'30', 10, N'/Admin/StaffJobOrder/JobOrderDetail/27')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (7, CAST(N'2022-07-31T15:26:13.050' AS DateTime), N'You has been assigned Job Order!', N'Job Order Code: 27', N'', 1, 1, N'30', 10, N'/Admin/StaffJobOrder/JobOrderDetail/27')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (8, CAST(N'2022-07-31T15:26:30.567' AS DateTime), N'Job Order Assigned', N'Your job order with ID: 27 has been assigned to our staff. They will contact you soon', N'', 1, 0, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f', 2, N'/User/JobOrderDetail/27')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (9, CAST(N'2022-07-31T15:26:35.530' AS DateTime), N'Job Order Completed', N'Your job order with ID: 27 has been completed', N'', 1, 0, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f', 2, N'/User/JobOrderDetail/27')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (10, CAST(N'2022-07-31T15:37:49.463' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 28', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/28')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (11, CAST(N'2022-07-31T15:37:49.470' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 28', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/28')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (12, CAST(N'2022-07-31T15:38:12.667' AS DateTime), N'You has been assigned Job Order!', N'Job Order Code: 28', N'', 1, 1, N'31', 10, N'/Admin/StaffJobOrder/JobOrderDetail/28')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (13, CAST(N'2022-07-31T15:43:01.417' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 29', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/29')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (14, CAST(N'2022-07-31T15:45:29.237' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 30', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/30')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (15, CAST(N'2022-07-31T15:45:29.253' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 30', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/30')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (16, CAST(N'2022-07-31T15:47:17.017' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 31', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/31')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (17, CAST(N'2022-07-31T15:49:17.293' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 32', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/32')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (18, CAST(N'2022-07-31T15:50:21.617' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 33', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/33')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (19, CAST(N'2022-07-31T15:51:01.690' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 34', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/34')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (20, CAST(N'2022-07-31T15:51:47.680' AS DateTime), N'You has been assigned Job Order!', N'Job Order Code: 33', N'', 1, 1, N'30', 10, N'/Admin/StaffJobOrder/JobOrderDetail/33')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (21, CAST(N'2022-07-31T15:52:02.630' AS DateTime), N'Job Order Assigned', N'Your job order with ID: 33 has been assigned to our staff. They will contact you soon', N'', 1, 0, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f', 2, N'/User/JobOrderDetail/33')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (22, CAST(N'2022-07-31T16:08:46.330' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 35', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/35')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (23, CAST(N'2022-07-31T17:59:14.407' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 36', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/36')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (24, CAST(N'2022-07-31T17:59:14.407' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 36', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/36')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (25, CAST(N'2022-07-31T17:59:14.397' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 36', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/36')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (26, CAST(N'2022-07-31T17:59:14.433' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 36', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/36')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (27, CAST(N'2022-07-31T18:00:09.333' AS DateTime), N'You has been assigned Job Order!', N'Job Order Code: 36', N'', 1, 1, N'30', 10, N'/Admin/StaffJobOrder/JobOrderDetail/36')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (28, CAST(N'2022-07-31T18:00:44.097' AS DateTime), N'Job Order Canceled', N'Your job order with ID: 36 has been canceled', N'', 2, 1, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f', 2, N'/User/JobOrderDetail/36')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (29, CAST(N'2022-07-31T23:20:58.787' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 37', N'', 1, 0, N'29', 0, N'User/JobOrderDetail/37')
--INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (30, CAST(N'2022-07-31T23:20:58.787' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 37', N'', 1, 1, N'29', 0, N'User/JobOrderDetail/37')

INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (1, CAST(N'2022-07-31T14:32:11.770' AS DateTime), N'You has been assigned Job Order!', N'Job Order Code: 26', N'', 1, 0, N'30', 10, NULL)
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (2, CAST(N'2022-07-31T14:33:09.327' AS DateTime), N'Job Order Assigned', N'Your job order with ID: 26 has been assigned to our staff. They will contact you soon', N'', 1, 0, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f', 2, NULL)
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (3, CAST(N'2022-07-31T14:33:53.450' AS DateTime), N'Job Order Completed', N'Your job order with ID: 26 has been completed', N'', 1, 0, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f', 2, NULL)
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (4, CAST(N'2022-07-31T15:23:49.920' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 27', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/27')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (5, CAST(N'2022-07-31T15:23:49.940' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 27', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/27')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (6, CAST(N'2022-07-31T15:25:53.203' AS DateTime), N'You has been assigned Job Order!', N'Job Order Code: 27', N'', 1, 0, N'30', 10, N'/Admin/StaffJobOrder/JobOrderDetail/27')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (7, CAST(N'2022-07-31T15:26:13.050' AS DateTime), N'You has been assigned Job Order!', N'Job Order Code: 27', N'', 1, 0, N'30', 10, N'/Admin/StaffJobOrder/JobOrderDetail/27')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (8, CAST(N'2022-07-31T15:26:30.567' AS DateTime), N'Job Order Assigned', N'Your job order with ID: 27 has been assigned to our staff. They will contact you soon', N'', 1, 0, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f', 2, N'/User/JobOrderDetail/27')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (9, CAST(N'2022-07-31T15:26:35.530' AS DateTime), N'Job Order Completed', N'Your job order with ID: 27 has been completed', N'', 1, 0, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f', 2, N'/User/JobOrderDetail/27')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (10, CAST(N'2022-07-31T15:37:49.463' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 28', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/28')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (11, CAST(N'2022-07-31T15:37:49.470' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 28', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/28')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (12, CAST(N'2022-07-31T15:38:12.667' AS DateTime), N'You has been assigned Job Order!', N'Job Order Code: 28', N'', 1, 0, N'31', 10, N'/Admin/StaffJobOrder/JobOrderDetail/28')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (13, CAST(N'2022-07-31T15:43:01.417' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 29', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/29')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (14, CAST(N'2022-07-31T15:45:29.237' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 30', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/30')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (15, CAST(N'2022-07-31T15:45:29.253' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 30', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/30')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (16, CAST(N'2022-07-31T15:47:17.017' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 31', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/31')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (17, CAST(N'2022-07-31T15:49:17.293' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 32', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/32')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (18, CAST(N'2022-07-31T15:50:21.617' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 33', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/33')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (19, CAST(N'2022-07-31T15:51:01.690' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 34', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/34')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (20, CAST(N'2022-07-31T15:51:47.680' AS DateTime), N'You has been assigned Job Order!', N'Job Order Code: 33', N'', 1, 0, N'30', 10, N'/Admin/StaffJobOrder/JobOrderDetail/33')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (21, CAST(N'2022-07-31T15:52:02.630' AS DateTime), N'Job Order Assigned', N'Your job order with ID: 33 has been assigned to our staff. They will contact you soon', N'', 1, 0, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f', 2, N'/User/JobOrderDetail/33')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (22, CAST(N'2022-07-31T16:08:46.330' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 35', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/35')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (23, CAST(N'2022-07-31T17:59:14.407' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 36', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/36')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (24, CAST(N'2022-07-31T17:59:14.407' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 36', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/36')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (25, CAST(N'2022-07-31T17:59:14.397' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 36', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/36')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (26, CAST(N'2022-07-31T17:59:14.433' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 36', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/36')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (27, CAST(N'2022-07-31T18:00:09.333' AS DateTime), N'You has been assigned Job Order!', N'Job Order Code: 36', N'', 1, 0, N'30', 10, N'/Admin/StaffJobOrder/JobOrderDetail/36')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (28, CAST(N'2022-07-31T18:00:44.097' AS DateTime), N'Job Order Canceled', N'Your job order with ID: 36 has been canceled', N'', 2, 0, N'311b3baf-431a-49dc-8c8e-f2b40f3fb30f', 2, N'/User/JobOrderDetail/36')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (29, CAST(N'2022-07-31T23:20:58.787' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 37', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/37')
INSERT [dbo].[tNotifications] ([NotifId], [CreateAt], [Title], [Description], [Image], [Type], [Status], [SendTo], [CreateBy], [Link]) VALUES (30, CAST(N'2022-07-31T23:20:58.787' AS DateTime), N'Alex Teo has been ordered an Job', N'Job Order No 37', N'', 1, 0, N'29', 0, N'/Admin/JobOrder/Detail/37')
SET IDENTITY_INSERT [dbo].[tNotifications] OFF
GO

SET IDENTITY_INSERT [dbo].[tConfigs] ON 

INSERT [dbo].[tConfigs] ([ConfigId], [Key], [Value], [Status]) VALUES (1, N'Address', N'341 Wilson Street, Almonte, Ont K0A 1A0', 1)
INSERT [dbo].[tConfigs] ([ConfigId], [Key], [Value], [Status]) VALUES (2, N'Phone', N'613-257-3396', 1)
INSERT [dbo].[tConfigs] ([ConfigId], [Key], [Value], [Status]) VALUES (3, N'Mail', N'info@info9000.ca', 1)
SET IDENTITY_INSERT [dbo].[tConfigs] OFF
GO
SET IDENTITY_INSERT [dbo].[tContacts] ON 

INSERT [dbo].[tContacts] ([ContactId], [FullName], [Phone], [Email], [Description], [ParentServiceId], [Status]) VALUES (1, N'Jonny Khoi', N'0919813001', N'KhoiVM@gmail.com', N'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem.', 1, 1)
INSERT [dbo].[tContacts] ([ContactId], [FullName], [Phone], [Email], [Description], [ParentServiceId], [Status]) VALUES (2, N'Mikel Nguyen', N'0919813002', N'LongNH@gmail.com', N'want to contact', 2, 1)
INSERT [dbo].[tContacts] ([ContactId], [FullName], [Phone], [Email], [Description], [ParentServiceId], [Status]) VALUES (3, N'Johny Minh', N'0919813003', N'QuangNM@gmail.com', N'want to contact', 3, 1)
INSERT [dbo].[tContacts] ([ContactId], [FullName], [Phone], [Email], [Description], [ParentServiceId], [Status]) VALUES (4, N'Lind', N'0919813004', N'long01@gmail.com', N'want to contact', 9, 0)
INSERT [dbo].[tContacts] ([ContactId], [FullName], [Phone], [Email], [Description], [ParentServiceId], [Status]) VALUES (5, N'Mikel Nguyen', N'0919813005', N'long02@gmail.com', N'good service', 1, 1)
INSERT [dbo].[tContacts] ([ContactId], [FullName], [Phone], [Email], [Description], [ParentServiceId], [Status]) VALUES (6, N'Jony Dang', N'0919813006', N'jony@gmail.com', N'want to contact', 9, 1)
INSERT [dbo].[tContacts] ([ContactId], [FullName], [Phone], [Email], [Description], [ParentServiceId], [Status]) VALUES (7, N'Jony', N'', N'email01@gmail.com', N'some thing', 9, 0)
INSERT [dbo].[tContacts] ([ContactId], [FullName], [Phone], [Email], [Description], [ParentServiceId], [Status]) VALUES (8, N'Jony', N'', N'hoanglong13606@gmail.com', N'abc', 9, 0)
SET IDENTITY_INSERT [dbo].[tContacts] OFF
GO
SET IDENTITY_INSERT [dbo].[tPromotions] ON 

INSERT [dbo].[tPromotions] ([PromotionId], [Title], [DateStart], [DateEnd], [DiscountPercent], [DiscountMoney], [Discription], [Image], [ParentServiceId], [Status]) VALUES (1, N'July Promotion', CAST(N'2022-07-01T00:00:00.000' AS DateTime), CAST(N'2022-07-30T00:00:00.000' AS DateTime), NULL, 2, N'Discount for this month', NULL, 1, 0)
INSERT [dbo].[tPromotions] ([PromotionId], [Title], [DateStart], [DateEnd], [DiscountPercent], [DiscountMoney], [Discription], [Image], [ParentServiceId], [Status]) VALUES (2, N'Sanyo Promotion', CAST(N'2022-07-01T00:00:00.000' AS DateTime), CAST(N'2022-07-30T00:00:00.000' AS DateTime), NULL, 1, N'Discount for sanyo', NULL, 1, 0)
INSERT [dbo].[tPromotions] ([PromotionId], [Title], [DateStart], [DateEnd], [DiscountPercent], [DiscountMoney], [Discription], [Image], [ParentServiceId], [Status]) VALUES (3, N'July Promotion', CAST(N'2022-07-01T00:00:00.000' AS DateTime), CAST(N'2022-07-30T00:00:00.000' AS DateTime), NULL, 2, N'Discount for this month', NULL, 2, 0)
INSERT [dbo].[tPromotions] ([PromotionId], [Title], [DateStart], [DateEnd], [DiscountPercent], [DiscountMoney], [Discription], [Image], [ParentServiceId], [Status]) VALUES (4, N'King Koil Promotion', CAST(N'2022-07-01T00:00:00.000' AS DateTime), CAST(N'2022-07-30T00:00:00.000' AS DateTime), NULL, 2, N'Discount for king size mattress', NULL, 2, 0)
SET IDENTITY_INSERT [dbo].[tPromotions] OFF
GO
SET IDENTITY_INSERT [dbo].[tSliders] ON 

INSERT [dbo].[tSliders] ([SliderId], [Title], [Description], [Alt], [Image], [Link], [Status]) VALUES (1, N'We Provide  Professional Services', N'Adipiscing the dolor sit amet, consectetur adipiscing elit. Eu sit pharetra aorem et faucibus quis enim dolor.', NULL, N'image-1.jpg', NULL, 1)
INSERT [dbo].[tSliders] ([SliderId], [Title], [Description], [Alt], [Image], [Link], [Status]) VALUES (2, N'Best Professional Services', N'Pharetra ipsum dolor sit amet, consectetur adipiscing elit. Eu sit pharetra iorem et faucibus quis enim dolor.', NULL, N'slider-1.jpg', NULL, 1)
INSERT [dbo].[tSliders] ([SliderId], [Title], [Description], [Alt], [Image], [Link], [Status]) VALUES (3, N'We Provide Professional Services', N'Adipiscing the dolor sit amet, consectetur adipiscing elit. Eu sit pharetra aorem et faucibus quis enim dolor.', NULL, N'slider-3.jpg', NULL, 1)
SET IDENTITY_INSERT [dbo].[tSliders] OFF
GO
