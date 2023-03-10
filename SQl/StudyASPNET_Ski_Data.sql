USE [studyASPNET]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2023-01-13 오후 2:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DisplayOrder] [nvarchar](20) NULL,
	[PostDate] [datetime] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notes]    Script Date: 2023-01-13 오후 2:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[ReadCount] [int] NOT NULL,
	[PostDate] [datetime2](7) NOT NULL,
	[Contents] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProFiles]    Script Date: 2023-01-13 오후 2:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProFiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Division] [nvarchar](50) NULL,
	[Title] [nvarchar](100) NULL,
	[Description] [nvarchar](max) NULL,
	[Url] [nvarchar](500) NULL,
	[FileName] [nvarchar](500) NULL,
 CONSTRAINT [PK_ProFiles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [PostDate]) VALUES (1, N'Apple', N'1', CAST(N'2023-01-06T15:20:00.000' AS DateTime))
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [PostDate]) VALUES (4, N'삼성전자', N'2', CAST(N'2023-01-06T15:20:00.000' AS DateTime))
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder], [PostDate]) VALUES (5, N'LG전자', N'3', CAST(N'2023-01-06T15:20:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Notes] ON 

INSERT [dbo].[Notes] ([Id], [UserId], [Name], [Title], [ReadCount], [PostDate], [Contents]) VALUES (1, N'ksuhwan', N'김수환', N'첫번째 게시글', 1, CAST(N'2023-01-09T17:36:18.9673079' AS DateTime2), N'<p>게시글 내용입니다&nbsp;</p><p>블라블라블라블라</p><p>마지막에 Edit로 추추가된 내용입니다.</p>')
INSERT [dbo].[Notes] ([Id], [UserId], [Name], [Title], [ReadCount], [PostDate], [Contents]) VALUES (3, N'Asherld', N'애슐리', N'이제 DB로 내용을 보냈습니다', 15, CAST(N'2023-01-09T12:34:00.0000000' AS DateTime2), N'ㅎ')
INSERT [dbo].[Notes] ([Id], [UserId], [Name], [Title], [ReadCount], [PostDate], [Contents]) VALUES (4, N'Asherld', N'에슐리', N'데이터 추가후 채굴', 4, CAST(N'2023-01-09T14:43:00.0000000' AS DateTime2), N'<p>채굴입니다</p><p><br></p><p>*&nbsp;</p><p><a href="http://www.naver.com" target="_self">http://www.naver.com</a><br></p><p>내용을보조</p><p>이미지를 넣습니다</p><p><img src="https://w.namu.la/s/dc42bb0527e08b0d65f370f3a8ad1c471ccbd90a5f01b85343e6471c7f4100486b9be8514d380c33651c70fdc1c7da610cd2effaa9696b1226d29082faa22131e41b8bd7a75491abd0819c4789a517c02dad5059a08b5d7fd07a01c1ad6fa6e83c6fbb1ea7f05bfb88a5e26947fa78af" alt=""><br></p>')
INSERT [dbo].[Notes] ([Id], [UserId], [Name], [Title], [ReadCount], [PostDate], [Contents]) VALUES (7, N'Asherld', N'애슐리', N'8번째 글 이번엔 안지움', 4, CAST(N'2023-01-10T09:43:11.6151161' AS DateTime2), N'<p>ㅇㅇ</p>')
INSERT [dbo].[Notes] ([Id], [UserId], [Name], [Title], [ReadCount], [PostDate], [Contents]) VALUES (8, N'Asherld', N'애슐리', N'9번째 토스트에서 테스트용', 3, CAST(N'2023-01-10T10:08:15.9407779' AS DateTime2), N'<p>ㅇㅇ</p>')
INSERT [dbo].[Notes] ([Id], [UserId], [Name], [Title], [ReadCount], [PostDate], [Contents]) VALUES (9, N'Asherld', N'애슐리', N'10 번째', 1, CAST(N'2023-01-10T10:10:53.3374818' AS DateTime2), N'<p>토스트 수정</p>')
INSERT [dbo].[Notes] ([Id], [UserId], [Name], [Title], [ReadCount], [PostDate], [Contents]) VALUES (10, N'Asherld', N'애슐리', N'11번째', 1, CAST(N'2023-01-10T10:36:37.4153340' AS DateTime2), N'<p>ㅇ</p>')
INSERT [dbo].[Notes] ([Id], [UserId], [Name], [Title], [ReadCount], [PostDate], [Contents]) VALUES (11, N'Asherld', N'애슐리', N'12번째', 1, CAST(N'2023-01-10T10:36:52.0225731' AS DateTime2), N'<p>ㅇ</p>')
INSERT [dbo].[Notes] ([Id], [UserId], [Name], [Title], [ReadCount], [PostDate], [Contents]) VALUES (12, N'Asherld', N'애슐리', N'13번째', 1, CAST(N'2023-01-10T10:37:04.7969966' AS DateTime2), N'<p>ㅇ</p>')
INSERT [dbo].[Notes] ([Id], [UserId], [Name], [Title], [ReadCount], [PostDate], [Contents]) VALUES (13, N'Asherld', N'애슐리', N'14번째', 0, CAST(N'2023-01-10T10:37:22.3972511' AS DateTime2), N'<p>ㅇ</p>')
INSERT [dbo].[Notes] ([Id], [UserId], [Name], [Title], [ReadCount], [PostDate], [Contents]) VALUES (14, N'Asherld', N'애슐리', N'15번째', 1, CAST(N'2023-01-10T10:37:32.7343428' AS DateTime2), N'<p>ㅇ</p>')
INSERT [dbo].[Notes] ([Id], [UserId], [Name], [Title], [ReadCount], [PostDate], [Contents]) VALUES (15, N'Asherld', N'애슐리', N'16번째', 21, CAST(N'2023-01-10T10:37:46.4622480' AS DateTime2), N'<p>ㅇ</p>')
INSERT [dbo].[Notes] ([Id], [UserId], [Name], [Title], [ReadCount], [PostDate], [Contents]) VALUES (18, N'ㅇㅇ', N'aa', N'ㅇㅇ', 2, CAST(N'2023-01-12T10:28:58.8202607' AS DateTime2), N'<p>ㅇㅇ</p>')
SET IDENTITY_INSERT [dbo].[Notes] OFF
GO
SET IDENTITY_INSERT [dbo].[ProFiles] ON 

INSERT [dbo].[ProFiles] ([Id], [Division], [Title], [Description], [Url], [FileName]) VALUES (3, N'Top', N'넥슨                                                                                               ', N'<p>넥슨입니다.</p>', N'https://www.nexon.com/Home/Game', N'7228ac3c-e008-4347-b867-646102436550_넥슨.png')
INSERT [dbo].[ProFiles] ([Id], [Division], [Title], [Description], [Url], [FileName]) VALUES (4, N'Card1', N'Bubble Fighter                                                                               ', N'<p>게임을 시작하세요.</p>', N'https://bf.nexon.com/Main/Index', N'15bb1d31-3155-45a2-8af4-060c7cce480d_카드1.png')
INSERT [dbo].[ProFiles] ([Id], [Division], [Title], [Description], [Url], [FileName]) VALUES (5, N'Card2', N'KartRider', N'<p>게임을 시작하세요.<br></p>', N'https://kart.nexon.com/events/2023/0112/Event.aspx', N'90b858c1-8d52-49fb-bdd7-c7b1d4b6e1c2_카드2.png')
INSERT [dbo].[ProFiles] ([Id], [Division], [Title], [Description], [Url], [FileName]) VALUES (6, N'Card3', N'Crazy Arcade', N'<p>게임을 시작하세요.<br></p>', N'https://ca.nexon.com/Event_20221229', N'df743ccb-c1e2-4fec-b1b4-a7d08e665023_회원가입화면.png')
SET IDENTITY_INSERT [dbo].[ProFiles] OFF
GO
/****** Object:  StoredProcedure [dbo].[USP_PagingNotes]    Script Date: 2023-01-13 오후 2:23:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김수환
-- Create date: 2022-01-10
-- Description:	게시판 페이징용 SP
-- =============================================
CREATE   PROCEDURE [dbo].[USP_PagingNotes]


	@StartCount Int, -- 페이징 시작카운트
	@EndCount Int	 -- 페이징 종료카운트
AS
BEGIN
	
	SET NOCOUNT ON;

   -- 페이징용 쿼리 시작
	SELECT * 
	  FROM (
			SELECT ROW_NUMBER() OVER (ORDER BY Id DESC) AS rowNum
			     , Id
				 , UserId
				 , Name
				 , Title
				 , ReadCount
				 , PostDate
				 , Contents
			  FROM Notes
	       ) AS base
	 WHERE base.rowNum BETWEEN @StartCount AND @EndCount

END
GO
