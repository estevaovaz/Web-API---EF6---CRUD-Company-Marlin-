USE [Marlin]
GO
/****** Object:  Table [dbo].[Aluno]    Script Date: 12/05/2020 15:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Aluno](
	[Matricula] [int] IDENTITY(1,1) NOT NULL,
	[numTurma] [varchar](50) NOT NULL,
	[Nome] [varchar](50) NULL,
 CONSTRAINT [PK_Aluno] PRIMARY KEY CLUSTERED 
(
	[Matricula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Turma]    Script Date: 12/05/2020 15:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Turma](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[numTurma] [varchar](50) NULL,
 CONSTRAINT [PK_Turma] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 12/05/2020 15:16:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NULL,
	[Senha] [varchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Aluno] ON 

INSERT [dbo].[Aluno] ([Matricula], [numTurma], [Nome]) VALUES (1, N'2001', N'JOAO')
INSERT [dbo].[Aluno] ([Matricula], [numTurma], [Nome]) VALUES (2, N'2002', N'PEDRO')
INSERT [dbo].[Aluno] ([Matricula], [numTurma], [Nome]) VALUES (3, N'2003', N'ESTEVAO')
INSERT [dbo].[Aluno] ([Matricula], [numTurma], [Nome]) VALUES (4, N'2001', N'ALEX')
INSERT [dbo].[Aluno] ([Matricula], [numTurma], [Nome]) VALUES (5, N'2001', N'BRUNA')
INSERT [dbo].[Aluno] ([Matricula], [numTurma], [Nome]) VALUES (6, N'2003', N'JOANA')
INSERT [dbo].[Aluno] ([Matricula], [numTurma], [Nome]) VALUES (7, N'3001', N'PATRICIA')
INSERT [dbo].[Aluno] ([Matricula], [numTurma], [Nome]) VALUES (8, N'2001', N'LARA')
INSERT [dbo].[Aluno] ([Matricula], [numTurma], [Nome]) VALUES (9, N'2002', N'WAGNER')
INSERT [dbo].[Aluno] ([Matricula], [numTurma], [Nome]) VALUES (10, N'2003', N'UESLEI')
INSERT [dbo].[Aluno] ([Matricula], [numTurma], [Nome]) VALUES (11, N'2004', N'LIA')
INSERT [dbo].[Aluno] ([Matricula], [numTurma], [Nome]) VALUES (12, N'3001', N'ALICIA')
INSERT [dbo].[Aluno] ([Matricula], [numTurma], [Nome]) VALUES (13, N'2001', N'LETICIA')
INSERT [dbo].[Aluno] ([Matricula], [numTurma], [Nome]) VALUES (14, N'2003', N'GUILHERME')
SET IDENTITY_INSERT [dbo].[Aluno] OFF
SET IDENTITY_INSERT [dbo].[Turma] ON 

INSERT [dbo].[Turma] ([ID], [numTurma]) VALUES (1, N'2001')
INSERT [dbo].[Turma] ([ID], [numTurma]) VALUES (7, N'2002')
INSERT [dbo].[Turma] ([ID], [numTurma]) VALUES (8, N'2003')
INSERT [dbo].[Turma] ([ID], [numTurma]) VALUES (9, N'2004')
INSERT [dbo].[Turma] ([ID], [numTurma]) VALUES (12, N'3001')
INSERT [dbo].[Turma] ([ID], [numTurma]) VALUES (13, N'3002')
SET IDENTITY_INSERT [dbo].[Turma] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([ID], [Nome], [Senha]) VALUES (1, N'marlin', N'marlin')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
