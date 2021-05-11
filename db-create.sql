USE [master]
GO
/****** Object:  Database [TafeSystem]    Script Date: 11/05/2021 11:10:38 AM ******/
CREATE DATABASE [TafeSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TafeSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TafeSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TafeSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TafeSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TafeSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TafeSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TafeSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TafeSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TafeSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TafeSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TafeSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [TafeSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TafeSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TafeSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TafeSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TafeSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TafeSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TafeSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TafeSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TafeSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TafeSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TafeSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TafeSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TafeSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TafeSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TafeSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TafeSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TafeSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TafeSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TafeSystem] SET  MULTI_USER 
GO
ALTER DATABASE [TafeSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TafeSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TafeSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TafeSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TafeSystem] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TafeSystem] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TafeSystem] SET QUERY_STORE = OFF
GO
USE [TafeSystem]
GO
/****** Object:  Table [dbo].[Assessment]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assessment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[startDate] [date] NULL,
	[dueDate] [date] NULL,
	[type] [int] NOT NULL,
	[unitID] [int] NOT NULL,
 CONSTRAINT [PK_Assessment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cluster]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cluster](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[courseID_ref] [int] NOT NULL,
 CONSTRAINT [PK_Cluster] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[CourseStudent]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseStudent](
	[studentID] [int] NOT NULL,
	[courseID] [int] NOT NULL,
	[outcome] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[studentID] ASC,
	[courseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseTeacher]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseTeacher](
	[courseID] [int] NOT NULL,
	[teacherID] [int] NOT NULL,
	[clusterID] [int] NOT NULL,
	[semesterID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[courseID] ASC,
	[teacherID] ASC,
	[clusterID] ASC,
	[semesterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[address] [nvarchar](40) NOT NULL,
	[contact_number] [int] NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NOT NULL,
	[studentID] [int] NOT NULL,
	[courseID] [int] NOT NULL,
	[status] [bit] NOT NULL,
	[type] [int] NOT NULL,
	[amount] [money] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Semester](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[startDate] [date] NOT NULL,
	[finishDate] [date] NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[Teacher]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[Unit]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[User]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[password] [nvarchar](40) NOT NULL,
	[username] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Assessment]  WITH CHECK ADD  CONSTRAINT [FK__Assessmen__unitI__52593CB8] FOREIGN KEY([unitID])
REFERENCES [dbo].[Unit] ([id])
GO
ALTER TABLE [dbo].[Assessment] CHECK CONSTRAINT [FK__Assessmen__unitI__52593CB8]
GO
ALTER TABLE [dbo].[Cluster]  WITH CHECK ADD  CONSTRAINT [FK__Cluster__courseI__5070F446] FOREIGN KEY([courseID_ref])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Cluster] CHECK CONSTRAINT [FK__Cluster__courseI__5070F446]
GO
ALTER TABLE [dbo].[CourseStudent]  WITH CHECK ADD FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[CourseStudent]  WITH CHECK ADD FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[CourseStudent]  WITH CHECK ADD FOREIGN KEY([studentID])
REFERENCES [dbo].[Student] ([id])
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD  CONSTRAINT [FK__CourseTea__clust__4E88ABD4] FOREIGN KEY([clusterID])
REFERENCES [dbo].[Cluster] ([id])
GO
ALTER TABLE [dbo].[CourseTeacher] CHECK CONSTRAINT [FK__CourseTea__clust__4E88ABD4]
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD  CONSTRAINT [FK__CourseTea__cours__4AB81AF0] FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[CourseTeacher] CHECK CONSTRAINT [FK__CourseTea__cours__4AB81AF0]
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD  CONSTRAINT [FK__CourseTea__semes__4F7CD00D] FOREIGN KEY([semesterID])
REFERENCES [dbo].[Semester] ([id])
GO
ALTER TABLE [dbo].[CourseTeacher] CHECK CONSTRAINT [FK__CourseTea__semes__4F7CD00D]
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD  CONSTRAINT [FK__CourseTea__teach__4BAC3F29] FOREIGN KEY([teacherID])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[CourseTeacher] CHECK CONSTRAINT [FK__CourseTea__teach__4BAC3F29]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK__Payment__courseI__5535A963] FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK__Payment__courseI__5535A963]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK__Payment__student__5441852A] FOREIGN KEY([studentID])
REFERENCES [dbo].[Student] ([id])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK__Payment__student__5441852A]
GO
ALTER TABLE [dbo].[Unit]  WITH CHECK ADD FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([id])
GO
/****** Object:  StoredProcedure [dbo].[usp_AttemptLogin]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_AttemptLogin] @username nvarchar(40), @password nvarchar(40)
as
select username, [password] from [User]
where username = @username and password = @password;
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllAssessment]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllAssessment]
as
select * from Assessment;
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllCluster]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllCluster]
as
select * from Cluster;
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllCourse]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllCourse]
as
select * from Course;
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllLocation]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllLocation]
as
select * from Location;
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllPayment]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllPayment]
as
select * from Payment;
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllSemester]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_SelectAllSemester]
as
select * from Semester;
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllStudent]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllStudent]
as
select * from Student;
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllTeacher]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllTeacher]
as
select * from Teacher;
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllUnit]    Script Date: 11/05/2021 11:10:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllUnit]
as
select * from Unit;
GO
USE [master]
GO
ALTER DATABASE [TafeSystem] SET  READ_WRITE 
GO
