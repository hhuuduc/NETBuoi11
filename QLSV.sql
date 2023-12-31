USE [QLSV]
GO
/****** Object:  Table [dbo].[DANGNHAP]    Script Date: 29/11/2023 15:40:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DANGNHAP](
	[USERNAME] [nvarchar](50) NOT NULL,
	[PASSWORD] [nvarchar](50) NOT NULL,
	[SAVE] [bit] NOT NULL,
 CONSTRAINT [PK_DANGNHAP] PRIMARY KEY CLUSTERED 
(
	[USERNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SINHVIEN]    Script Date: 29/11/2023 15:40:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SINHVIEN](
	[MASV] [int] NOT NULL,
	[HOTEN] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SINHVIEN] PRIMARY KEY CLUSTERED 
(
	[MASV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[DANGNHAP] ([USERNAME], [PASSWORD], [SAVE]) VALUES (N'admin', N'admin', 1)
INSERT [dbo].[DANGNHAP] ([USERNAME], [PASSWORD], [SAVE]) VALUES (N'user', N'user', 0)
INSERT [dbo].[SINHVIEN] ([MASV], [HOTEN]) VALUES (1, N'Huỳnh Hữu Đức')
INSERT [dbo].[SINHVIEN] ([MASV], [HOTEN]) VALUES (2, N'Huỳnh Hữu Tính')
INSERT [dbo].[SINHVIEN] ([MASV], [HOTEN]) VALUES (3, N'Nguyễn Văn A')
INSERT [dbo].[SINHVIEN] ([MASV], [HOTEN]) VALUES (4, N'Nguyễn Văn C')
INSERT [dbo].[SINHVIEN] ([MASV], [HOTEN]) VALUES (5, N'Trần Văn D')
INSERT [dbo].[SINHVIEN] ([MASV], [HOTEN]) VALUES (6, N'Huỳnh Hữu D')
INSERT [dbo].[SINHVIEN] ([MASV], [HOTEN]) VALUES (7, N'Huỳnh Lê Phương Nghi')
INSERT [dbo].[SINHVIEN] ([MASV], [HOTEN]) VALUES (8, N'Huỳnh Hữu Đức Dậu')
INSERT [dbo].[SINHVIEN] ([MASV], [HOTEN]) VALUES (9, N'Huỳnh Đức Dậu')
