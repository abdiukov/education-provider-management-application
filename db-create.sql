USE [TafeSystem]
GO
/****** Object:  Table [dbo].[Assessment]    Script Date: 10/05/2021 11:50:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assessment](
	[id] [int] NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[startDate] [date] NULL,
	[dueDate] [date] NULL,
	[type] [int] NOT NULL,
	[unitID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cluster]    Script Date: 10/05/2021 11:50:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cluster](
	[id] [int] NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[courseID_ref] [int] NOT NULL,
 CONSTRAINT [PK_Cluster] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 10/05/2021 11:50:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[id] [int] NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[duration] [date] NOT NULL,
	[location] [int] NOT NULL,
	[startdate] [date] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseStudent]    Script Date: 10/05/2021 11:50:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseStudent](
	[studentID] [int] NOT NULL,
	[courseID] [int] NOT NULL,
	[outcome] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseTeacher]    Script Date: 10/05/2021 11:50:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseTeacher](
	[courseID] [int] NOT NULL,
	[teacherID] [int] NOT NULL,
	[clusterID] [int] NOT NULL,
	[semesterID] [int] NOT NULL,
	[courseTeacherID] [int] NOT NULL,
 CONSTRAINT [PK_CourseTeacher] PRIMARY KEY CLUSTERED 
(
	[courseTeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 10/05/2021 11:50:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[id] [int] NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[address] [nvarchar](40) NOT NULL,
	[contact_number] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 10/05/2021 11:50:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[id] [int] NOT NULL,
	[date] [date] NOT NULL,
	[studentID] [int] NOT NULL,
	[courseID] [int] NOT NULL,
	[status] [bit] NOT NULL,
	[type] [int] NOT NULL,
	[amount] [money] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 10/05/2021 11:50:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[id] [int] NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[startDate] [date] NOT NULL,
	[finishDate] [date] NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 10/05/2021 11:50:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[id] [int] NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[address] [nvarchar](40) NOT NULL,
	[gender] [int] NOT NULL,
	[mobile] [int] NOT NULL,
	[email] [nvarchar](40) NOT NULL,
	[locationID] [int] NOT NULL,
	[dob] [date] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 10/05/2021 11:50:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[id] [int] NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[address] [nvarchar](40) NOT NULL,
	[gender] [nvarchar](40) NOT NULL,
	[mobile] [int] NOT NULL,
	[email] [nvarchar](40) NOT NULL,
	[dob] [date] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 10/05/2021 11:50:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[id] [int] NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[hoursAmount] [int] NOT NULL,
	[courseID] [int] NOT NULL,
	[unitPackageName] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10/05/2021 11:50:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] NOT NULL,
	[password] [nvarchar](40) NOT NULL,
	[username] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Assessment]  WITH CHECK ADD  CONSTRAINT [FK__Assessmen__unitI__52593CB8] FOREIGN KEY([unitID])
REFERENCES [dbo].[Unit] ([id])
GO
ALTER TABLE [dbo].[Assessment] CHECK CONSTRAINT [FK__Assessmen__unitI__52593CB8]
GO
ALTER TABLE [dbo].[Cluster]  WITH CHECK ADD FOREIGN KEY([courseID_ref])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD FOREIGN KEY([clusterID])
REFERENCES [dbo].[Cluster] ([id])
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD  CONSTRAINT [FK__CourseTea__semes__4F7CD00D] FOREIGN KEY([semesterID])
REFERENCES [dbo].[Semester] ([id])
GO
ALTER TABLE [dbo].[CourseTeacher] CHECK CONSTRAINT [FK__CourseTea__semes__4F7CD00D]
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD FOREIGN KEY([teacherID])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD FOREIGN KEY([teacherID])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD FOREIGN KEY([teacherID])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK__Payment__student__5441852A] FOREIGN KEY([studentID])
REFERENCES [dbo].[Student] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK__Payment__student__5441852A]
GO
