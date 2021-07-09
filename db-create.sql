/****** Object:  Database [TafeSystem]    Script Date: 9/07/2021 2:51:01 PM ******/
CREATE DATABASE [TafeSystem]
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
/****** Object:  Table [dbo].[Cluster]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cluster](
	[courseID] [int] NOT NULL,
	[unitID] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Cluster] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[hoursAmount] [int] NOT NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_SelectAllCluster]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create view [dbo].[vw_SelectAllCluster]
as
select Cluster.id, Unit.name, Unit.hoursAmount from Cluster
inner join Unit on Unit.id = Cluster.unitID

GO
/****** Object:  Table [dbo].[Course]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[locationID] [int] NOT NULL,
	[deliveryID] [int] NOT NULL,
	[isCurrent] [bit] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 9/07/2021 2:51:01 PM ******/
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
/****** Object:  Table [dbo].[CourseSemester]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseSemester](
	[courseID] [int] NOT NULL,
	[semesterID] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CourseSemester] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_SelectCourseStartEndDates]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[vw_SelectCourseStartEndDates]
as
select min(startDate) [startDate],
max(finishDate) [finishDate], Course.id
from CourseSemester
left join Course on CourseSemester.courseID = Course.id 
left join Semester on Semester.id = CourseSemester.semesterID
group by Course.id

GO
/****** Object:  View [dbo].[vw_SelectUnitAmountPerCourse]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_SelectUnitAmountPerCourse]
as
select Course.id, count(unitID) as [UnitsPerCourse]
--( select count(courseID) where Course.id = Cluster.courseID) 
from Course
left join Cluster on Cluster.courseID = Course.id
group by Course.id

GO
/****** Object:  Table [dbo].[CourseTeacher]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseTeacher](
	[courseID] [int] NOT NULL,
	[teacherID] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CourseTeacher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_SelectAmountTeacherPerCourse]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_SelectAmountTeacherPerCourse]
as
select Course.id, count(teacherID) as [TeachersPerCourse]
--( select count(courseID) where Course.id = Cluster.courseID) 
from Course
left join CourseTeacher on CourseTeacher.courseID = Course.id
group by Course.id

GO
/****** Object:  Table [dbo].[CourseStudent]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseStudent](
	[studentID] [int] NOT NULL,
	[courseID] [int] NOT NULL,
	[outcomeID] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_CourseStudent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_SelectStudentAmounPerCourse]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_SelectStudentAmounPerCourse]
as
select Course.id, count(studentID) as [StudentsPerCourse]
--( select count(courseID) where Course.id = Cluster.courseID) 
from Course
left join CourseStudent on CourseStudent.courseID = Course.id
group by Course.id

GO
/****** Object:  View [dbo].[vw_SelectStudentAmountPerCourse]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_SelectStudentAmountPerCourse]
as
select Course.id, count(studentID) as [StudentsPerCourse]
--( select count(courseID) where Course.id = Cluster.courseID) 
from Course
left join CourseStudent on CourseStudent.courseID = Course.id
group by Course.id

GO
/****** Object:  View [dbo].[vw_SelectCurrentStudentIDs]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[vw_SelectCurrentStudentIDs]
as
select CourseStudent.studentID from CourseStudent
left join Course on CourseStudent.courseID = Course.id
where Course.isCurrent = 1

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[amountPaid] [money] NULL,
	[amountDue] [money] NULL,
	[CourseStudentID] [int] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_UnpaidCourseID]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[vw_UnpaidCourseID]
as
		select Payment.CourseStudentID as 'UnpaidCourseStudentID'
		from Payment
		where Payment.amountPaid < Payment.amountDue

GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Delivery] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gender]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gender](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](40) NOT NULL,
	[address] [nvarchar](40) NOT NULL,
	[contact_number] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Outcome]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Outcome](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](45) NOT NULL,
 CONSTRAINT [PK_Outcome] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address] [nvarchar](40) NOT NULL,
	[genderID] [int] NOT NULL,
	[mobile] [nvarchar](40) NOT NULL,
	[email] [nvarchar](40) NOT NULL,
	[dob] [date] NOT NULL,
	[firstname] [nvarchar](40) NOT NULL,
	[lastname] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address] [nvarchar](40) NOT NULL,
	[genderID] [int] NOT NULL,
	[mobile] [nvarchar](40) NOT NULL,
	[email] [nvarchar](40) NOT NULL,
	[dob] [date] NOT NULL,
	[firstname] [nvarchar](40) NOT NULL,
	[lastname] [nvarchar](40) NOT NULL,
	[base_locationID] [int] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cluster] ON 
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (1, 1, 1)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (1, 2, 2)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (1, 3, 3)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (1, 4, 4)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (1, 5, 5)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (1, 6, 6)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (2, 7, 7)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (2, 8, 8)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (2, 9, 9)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (2, 10, 10)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (2, 11, 11)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (3, 12, 12)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (3, 13, 13)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (3, 14, 14)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (4, 15, 15)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (4, 16, 16)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (4, 17, 17)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (4, 18, 18)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (5, 19, 19)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (5, 20, 20)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (5, 21, 21)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (5, 22, 22)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (5, 23, 23)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (5, 24, 24)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (6, 25, 25)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (6, 26, 26)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (6, 27, 27)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (6, 28, 28)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (6, 29, 29)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (6, 30, 30)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (7, 31, 31)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (7, 32, 32)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (7, 33, 33)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (7, 34, 34)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (8, 35, 35)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (8, 36, 36)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (8, 37, 37)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (9, 38, 38)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (9, 39, 39)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (10, 40, 40)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (10, 41, 41)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (11, 42, 42)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (11, 43, 43)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (11, 44, 44)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (11, 45, 45)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (11, 46, 46)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (12, 47, 47)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (12, 48, 48)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (12, 49, 49)
GO
INSERT [dbo].[Cluster] ([courseID], [unitID], [id]) VALUES (12, 50, 50)
GO
SET IDENTITY_INSERT [dbo].[Cluster] OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 
GO
INSERT [dbo].[Course] ([id], [name], [locationID], [deliveryID], [isCurrent]) VALUES (1, N'Certificate IV in Programming', 1, 1, 1)
GO
INSERT [dbo].[Course] ([id], [name], [locationID], [deliveryID], [isCurrent]) VALUES (2, N'Diploma in Software Development', 2, 2, 1)
GO
INSERT [dbo].[Course] ([id], [name], [locationID], [deliveryID], [isCurrent]) VALUES (3, N'Diploma in Social Engineering', 3, 3, 1)
GO
INSERT [dbo].[Course] ([id], [name], [locationID], [deliveryID], [isCurrent]) VALUES (4, N'Certificate III in Advance Cooking', 4, 1, 0)
GO
INSERT [dbo].[Course] ([id], [name], [locationID], [deliveryID], [isCurrent]) VALUES (5, N'Certificate III in Waste Management', 1, 2, 0)
GO
INSERT [dbo].[Course] ([id], [name], [locationID], [deliveryID], [isCurrent]) VALUES (6, N'Certificate II in Accounting', 2, 3, 0)
GO
INSERT [dbo].[Course] ([id], [name], [locationID], [deliveryID], [isCurrent]) VALUES (7, N'Advance Diploma in Computer Science', 3, 1, 0)
GO
INSERT [dbo].[Course] ([id], [name], [locationID], [deliveryID], [isCurrent]) VALUES (8, N'Advance Diploma in Logistics', 4, 2, 0)
GO
INSERT [dbo].[Course] ([id], [name], [locationID], [deliveryID], [isCurrent]) VALUES (9, N'Certificate III in Water Management', 1, 3, 1)
GO
INSERT [dbo].[Course] ([id], [name], [locationID], [deliveryID], [isCurrent]) VALUES (10, N'Certificate IV in Mining', 2, 1, 1)
GO
INSERT [dbo].[Course] ([id], [name], [locationID], [deliveryID], [isCurrent]) VALUES (11, N'Advance Diploma in Software Hacking', 3, 2, 1)
GO
INSERT [dbo].[Course] ([id], [name], [locationID], [deliveryID], [isCurrent]) VALUES (12, N'Advance Diploma in Psychology', 4, 3, 1)
GO
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseSemester] ON 
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (1, 11, 1)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (2, 11, 2)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (3, 10, 3)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (3, 11, 4)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (4, 7, 5)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (5, 6, 6)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (6, 8, 7)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (6, 9, 8)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (7, 5, 9)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (8, 1, 10)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (9, 12, 11)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (9, 13, 12)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (10, 12, 13)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (10, 13, 14)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (11, 12, 15)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (11, 13, 16)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (11, 14, 17)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (12, 11, 18)
GO
INSERT [dbo].[CourseSemester] ([courseID], [semesterID], [id]) VALUES (12, 12, 19)
GO
SET IDENTITY_INSERT [dbo].[CourseSemester] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseStudent] ON 
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (1, 1, 3, 1)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (1, 5, 1, 2)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (2, 1, 3, 3)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (2, 5, 2, 4)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (3, 1, 3, 5)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (3, 5, 1, 6)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (4, 1, 3, 7)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (4, 5, 1, 8)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (5, 1, 3, 9)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (5, 5, 2, 10)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (6, 1, 3, 11)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (6, 5, 1, 12)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (7, 1, 3, 13)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (7, 5, 1, 14)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (8, 1, 3, 15)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (8, 5, 2, 16)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (9, 1, 3, 17)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (9, 5, 2, 18)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (11, 1, 3, 21)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (11, 5, 2, 22)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (12, 1, 3, 23)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (12, 5, 2, 24)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (13, 1, 3, 25)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (13, 5, 2, 26)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (14, 1, 3, 27)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (14, 5, 1, 28)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (15, 1, 3, 29)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (15, 5, 1, 30)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (16, 1, 3, 31)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (16, 5, 2, 32)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (17, 1, 3, 33)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (17, 5, 2, 34)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (18, 1, 3, 35)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (18, 5, 2, 36)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (19, 1, 3, 37)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (19, 5, 2, 38)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (20, 1, 3, 39)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (20, 5, 2, 40)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (21, 2, 3, 41)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (21, 6, 1, 42)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (22, 2, 3, 43)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (22, 6, 2, 44)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (23, 2, 3, 45)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (23, 6, 1, 46)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (24, 2, 3, 47)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (24, 6, 1, 48)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (25, 2, 3, 49)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (25, 6, 2, 50)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (26, 2, 3, 51)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (26, 6, 1, 52)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (27, 2, 3, 53)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (27, 6, 1, 54)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (28, 2, 3, 55)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (28, 6, 2, 56)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (29, 2, 3, 57)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (29, 6, 2, 58)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (30, 2, 3, 59)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (30, 6, 1, 60)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (32, 2, 3, 63)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (32, 6, 2, 64)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (33, 2, 3, 65)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (33, 6, 2, 66)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (34, 2, 3, 67)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (34, 6, 1, 68)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (36, 2, 3, 71)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (36, 6, 2, 72)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (37, 2, 3, 73)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (37, 6, 2, 74)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (38, 2, 3, 75)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (38, 6, 2, 76)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (39, 2, 3, 77)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (39, 6, 2, 78)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (40, 2, 3, 79)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (40, 6, 2, 80)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (41, 3, 3, 81)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (41, 7, 1, 82)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (42, 3, 3, 83)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (42, 7, 2, 84)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (43, 3, 3, 85)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (43, 7, 1, 86)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (44, 3, 3, 87)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (44, 7, 1, 88)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (45, 3, 3, 89)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (45, 7, 2, 90)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (46, 3, 3, 91)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (46, 7, 1, 92)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (47, 3, 3, 93)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (47, 7, 1, 94)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (48, 3, 3, 95)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (48, 7, 2, 96)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (49, 3, 3, 97)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (49, 7, 2, 98)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (50, 3, 3, 99)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (50, 7, 1, 100)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (51, 3, 3, 101)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (51, 7, 2, 102)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (52, 3, 3, 103)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (52, 7, 2, 104)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (53, 3, 3, 105)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (53, 7, 2, 106)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (55, 3, 3, 109)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (55, 7, 1, 110)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (56, 3, 3, 111)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (56, 7, 2, 112)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (57, 3, 3, 113)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (57, 7, 2, 114)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (58, 3, 3, 115)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (58, 7, 2, 116)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (59, 3, 3, 117)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (59, 7, 2, 118)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (60, 3, 3, 119)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (60, 7, 2, 120)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (61, 8, 1, 121)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (61, 12, 3, 122)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (62, 8, 2, 123)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (62, 12, 3, 124)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (63, 8, 1, 125)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (63, 12, 3, 126)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (64, 8, 1, 127)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (64, 12, 3, 128)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (65, 8, 2, 129)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (65, 12, 3, 130)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (66, 8, 1, 131)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (66, 12, 3, 132)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (67, 8, 1, 133)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (67, 12, 3, 134)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (68, 8, 2, 135)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (68, 12, 3, 136)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (69, 8, 2, 137)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (69, 12, 3, 138)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (70, 8, 1, 139)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (70, 12, 3, 140)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (71, 8, 2, 141)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (71, 12, 3, 142)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (73, 8, 2, 145)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (73, 12, 3, 146)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (74, 8, 1, 147)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (74, 12, 3, 148)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (75, 8, 1, 149)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (75, 12, 3, 150)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (77, 8, 2, 153)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (77, 12, 3, 154)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (78, 8, 2, 155)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (78, 12, 3, 156)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (79, 8, 2, 157)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (79, 12, 3, 158)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (80, 8, 2, 159)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (80, 12, 3, 160)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (81, 4, 1, 161)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (82, 4, 2, 162)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (83, 4, 2, 163)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (84, 4, 1, 164)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (86, 4, 2, 166)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (87, 4, 1, 167)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (88, 4, 1, 168)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (89, 4, 1, 169)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (90, 4, 2, 170)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (91, 9, 2, 171)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (93, 9, 1, 173)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (94, 9, 2, 174)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (95, 9, 1, 175)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (96, 9, 1, 176)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (97, 9, 2, 177)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (98, 9, 2, 178)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (99, 9, 1, 179)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (101, 4, 1, 182)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (101, 10, 2, 183)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (102, 4, 1, 184)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (102, 10, 2, 185)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (103, 4, 1, 186)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (103, 10, 1, 187)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (104, 4, 2, 188)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (104, 10, 2, 189)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (105, 4, 2, 190)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (105, 10, 1, 191)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (106, 4, 2, 192)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (106, 10, 1, 193)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (107, 4, 2, 194)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (107, 10, 2, 195)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (108, 10, 2, 196)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (109, 10, 2, 197)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (111, 10, 2, 199)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (112, 10, 2, 200)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (113, 10, 2, 201)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (114, 10, 1, 202)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (115, 10, 1, 203)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (116, 11, 1, 204)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (117, 11, 2, 205)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (118, 11, 2, 206)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (119, 11, 1, 207)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (120, 11, 2, 208)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (141, 2, 3, 209)
GO
INSERT [dbo].[CourseStudent] ([studentID], [courseID], [outcomeID], [id]) VALUES (142, 2, 3, 210)
GO
SET IDENTITY_INSERT [dbo].[CourseStudent] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseTeacher] ON 
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (1, 1, 1)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (1, 2, 2)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (2, 3, 3)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (2, 4, 4)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (3, 5, 5)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (3, 6, 6)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (12, 7, 7)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (12, 8, 8)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (9, 9, 9)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (9, 10, 10)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (10, 12, 12)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (11, 13, 13)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (11, 14, 14)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (4, 13, 15)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (4, 14, 16)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (5, 1, 17)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (5, 2, 18)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (6, 3, 19)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (6, 4, 20)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (7, 5, 21)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (7, 6, 22)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (8, 7, 23)
GO
INSERT [dbo].[CourseTeacher] ([courseID], [teacherID], [id]) VALUES (8, 8, 24)
GO
SET IDENTITY_INSERT [dbo].[CourseTeacher] OFF
GO
SET IDENTITY_INSERT [dbo].[Delivery] ON 
GO
INSERT [dbo].[Delivery] ([id], [description]) VALUES (1, N'Full Time')
GO
INSERT [dbo].[Delivery] ([id], [description]) VALUES (2, N'Part Time')
GO
INSERT [dbo].[Delivery] ([id], [description]) VALUES (3, N'Online')
GO
SET IDENTITY_INSERT [dbo].[Delivery] OFF
GO
SET IDENTITY_INSERT [dbo].[Gender] ON 
GO
INSERT [dbo].[Gender] ([id], [description]) VALUES (1, N'Male')
GO
INSERT [dbo].[Gender] ([id], [description]) VALUES (2, N'Female')
GO
INSERT [dbo].[Gender] ([id], [description]) VALUES (3, N'Other')
GO
SET IDENTITY_INSERT [dbo].[Gender] OFF
GO
SET IDENTITY_INSERT [dbo].[Location] ON 
GO
INSERT [dbo].[Location] ([id], [name], [address], [contact_number]) VALUES (1, N'Mount Druitt', N'20 Mount St, Mount Druitt NSW 2770', N'131870')
GO
INSERT [dbo].[Location] ([id], [name], [address], [contact_number]) VALUES (2, N'Granville', N'136 William St, Granville NSW 2142', N'0496820222')
GO
INSERT [dbo].[Location] ([id], [name], [address], [contact_number]) VALUES (3, N'Online', N'N/A', N'1300 823 366')
GO
INSERT [dbo].[Location] ([id], [name], [address], [contact_number]) VALUES (4, N'Ultimo', N'651-731 Harris Street, Ultimo 2007', N' 0292174040')
GO
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
SET IDENTITY_INSERT [dbo].[Outcome] ON 
GO
INSERT [dbo].[Outcome] ([id], [description]) VALUES (1, N'Satisfactory')
GO
INSERT [dbo].[Outcome] ([id], [description]) VALUES (2, N'Unsatisfactory')
GO
INSERT [dbo].[Outcome] ([id], [description]) VALUES (3, N'No outcome available')
GO
SET IDENTITY_INSERT [dbo].[Outcome] OFF
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (1, 4000.0000, 4000.0000, 1)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (2, 2000.0000, 7000.0000, 2)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (3, 7000.0000, 9000.0000, 3)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (4, 3000.0000, 9000.0000, 4)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (5, 8000.0000, 8000.0000, 5)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (6, 4000.0000, 7000.0000, 6)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (7, 1000.0000, 1000.0000, 7)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (8, 4000.0000, 4000.0000, 8)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (9, 2000.0000, 2000.0000, 9)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (10, 7000.0000, 9000.0000, 10)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (11, 4000.0000, 4000.0000, 11)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (12, 3000.0000, 10000.0000, 12)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (13, 2000.0000, 2000.0000, 13)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (14, 1000.0000, 3000.0000, 14)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (15, 1000.0000, 10000.0000, 15)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (16, 1000.0000, 6000.0000, 16)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (17, 1000.0000, 1000.0000, 17)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (18, 1000.0000, 1000.0000, 18)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (21, 4000.0000, 4000.0000, 21)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (22, 4000.0000, 4000.0000, 22)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (23, 4000.0000, 7000.0000, 23)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (24, 3000.0000, 8000.0000, 24)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (25, 5000.0000, 5000.0000, 25)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (26, 7000.0000, 7000.0000, 26)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (27, 5000.0000, 6000.0000, 27)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (28, 4000.0000, 4000.0000, 28)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (29, 5000.0000, 7000.0000, 29)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (30, 6000.0000, 7000.0000, 30)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (31, 8000.0000, 9000.0000, 31)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (32, 2000.0000, 2000.0000, 32)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (33, 5000.0000, 8000.0000, 33)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (34, 1000.0000, 7000.0000, 34)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (35, 7000.0000, 7000.0000, 35)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (36, 4000.0000, 10000.0000, 36)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (37, 3000.0000, 4000.0000, 37)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (38, 2000.0000, 5000.0000, 38)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (39, 3000.0000, 8000.0000, 39)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (40, 3000.0000, 3000.0000, 40)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (41, 6000.0000, 9000.0000, 41)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (42, 3000.0000, 4000.0000, 42)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (43, 5000.0000, 9000.0000, 43)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (44, 5000.0000, 8000.0000, 44)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (45, 1000.0000, 1000.0000, 45)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (46, 8000.0000, 8000.0000, 46)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (47, 7000.0000, 10000.0000, 47)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (48, 5000.0000, 5000.0000, 48)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (49, 4000.0000, 6000.0000, 49)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (50, 1000.0000, 1000.0000, 50)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (51, 5000.0000, 5000.0000, 51)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (52, 2000.0000, 4000.0000, 52)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (53, 1000.0000, 7000.0000, 53)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (54, 2000.0000, 9000.0000, 54)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (55, 3000.0000, 6000.0000, 55)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (56, 6000.0000, 8000.0000, 56)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (57, 4000.0000, 4000.0000, 57)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (58, 5000.0000, 5000.0000, 58)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (59, 6000.0000, 6000.0000, 59)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (60, 4000.0000, 5000.0000, 60)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (63, 4000.0000, 7000.0000, 63)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (64, 2000.0000, 9000.0000, 64)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (65, 3000.0000, 3000.0000, 65)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (66, 2000.0000, 2000.0000, 66)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (67, 9000.0000, 9000.0000, 67)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (68, 4000.0000, 4000.0000, 68)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (71, 8000.0000, 8000.0000, 71)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (72, 1000.0000, 7000.0000, 72)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (73, 5000.0000, 9000.0000, 73)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (74, 3000.0000, 3000.0000, 74)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (75, 5000.0000, 5000.0000, 75)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (76, 1000.0000, 1000.0000, 76)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (77, 1000.0000, 1000.0000, 77)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (78, 1000.0000, 10000.0000, 78)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (79, 3000.0000, 3000.0000, 79)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (80, 6000.0000, 8000.0000, 80)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (81, 3000.0000, 3000.0000, 81)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (82, 6000.0000, 7000.0000, 82)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (83, 3000.0000, 3000.0000, 83)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (84, 1000.0000, 5000.0000, 84)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (85, 2000.0000, 2000.0000, 85)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (86, 7000.0000, 7000.0000, 86)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (87, 5000.0000, 8000.0000, 87)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (88, 3000.0000, 3000.0000, 88)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (89, 6000.0000, 6000.0000, 89)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (90, 3000.0000, 3000.0000, 90)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (91, 2000.0000, 7000.0000, 91)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (92, 3000.0000, 9000.0000, 92)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (93, 7000.0000, 7000.0000, 93)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (94, 3000.0000, 7000.0000, 94)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (95, 8000.0000, 10000.0000, 95)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (96, 6000.0000, 10000.0000, 96)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (97, 5000.0000, 5000.0000, 97)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (98, 3000.0000, 3000.0000, 98)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (99, 5000.0000, 6000.0000, 99)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (100, 4000.0000, 4000.0000, 100)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (101, 2000.0000, 3000.0000, 101)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (102, 3000.0000, 3000.0000, 102)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (103, 1000.0000, 1000.0000, 103)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (104, 9000.0000, 9000.0000, 104)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (105, 4000.0000, 8000.0000, 105)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (106, 4000.0000, 10000.0000, 106)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (109, 4000.0000, 4000.0000, 109)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (110, 3000.0000, 3000.0000, 110)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (111, 1000.0000, 1000.0000, 111)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (112, 6000.0000, 7000.0000, 112)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (113, 1000.0000, 7000.0000, 113)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (114, 2000.0000, 5000.0000, 114)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (115, 3000.0000, 3000.0000, 115)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (116, 5000.0000, 5000.0000, 116)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (117, 4000.0000, 7000.0000, 117)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (118, 10000.0000, 10000.0000, 118)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (119, 1000.0000, 6000.0000, 119)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (120, 6000.0000, 6000.0000, 120)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (121, 3000.0000, 6000.0000, 121)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (122, 1000.0000, 1000.0000, 122)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (123, 6000.0000, 6000.0000, 123)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (124, 1000.0000, 6000.0000, 124)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (125, 3000.0000, 3000.0000, 125)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (126, 3000.0000, 3000.0000, 126)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (127, 7000.0000, 9000.0000, 127)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (128, 1000.0000, 5000.0000, 128)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (129, 7000.0000, 8000.0000, 129)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (130, 2000.0000, 5000.0000, 130)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (131, 5000.0000, 10000.0000, 131)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (132, 4000.0000, 9000.0000, 132)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (133, 1000.0000, 1000.0000, 133)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (134, 2000.0000, 2000.0000, 134)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (135, 3000.0000, 9000.0000, 135)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (136, 2000.0000, 2000.0000, 136)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (137, 1000.0000, 4000.0000, 137)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (138, 6000.0000, 6000.0000, 138)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (139, 6000.0000, 6000.0000, 139)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (140, 7000.0000, 7000.0000, 140)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (141, 4000.0000, 5000.0000, 141)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (142, 5000.0000, 5000.0000, 142)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (145, 7000.0000, 7000.0000, 145)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (146, 6000.0000, 6000.0000, 146)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (147, 8000.0000, 8000.0000, 147)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (148, 5000.0000, 8000.0000, 148)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (149, 1000.0000, 3000.0000, 149)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (150, 3000.0000, 3000.0000, 150)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (153, 2000.0000, 2000.0000, 153)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (154, 2000.0000, 2000.0000, 154)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (155, 4000.0000, 4000.0000, 155)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (156, 8000.0000, 9000.0000, 156)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (157, 6000.0000, 10000.0000, 157)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (158, 1000.0000, 1000.0000, 158)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (159, 7000.0000, 7000.0000, 159)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (160, 2000.0000, 2000.0000, 160)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (161, 9000.0000, 9000.0000, 161)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (162, 2000.0000, 2000.0000, 162)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (163, 6000.0000, 6000.0000, 163)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (164, 5000.0000, 8000.0000, 164)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (166, 5000.0000, 9000.0000, 166)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (167, 5000.0000, 8000.0000, 167)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (168, 2000.0000, 2000.0000, 168)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (169, 4000.0000, 4000.0000, 169)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (170, 1000.0000, 5000.0000, 170)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (171, 1000.0000, 7000.0000, 171)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (173, 3000.0000, 5000.0000, 173)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (174, 1000.0000, 1000.0000, 174)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (175, 1000.0000, 3000.0000, 175)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (176, 1000.0000, 1000.0000, 176)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (177, 1000.0000, 1000.0000, 177)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (178, 1000.0000, 1000.0000, 178)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (179, 4000.0000, 4000.0000, 179)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (182, 1000.0000, 2000.0000, 182)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (183, 4000.0000, 10000.0000, 183)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (184, 4000.0000, 4000.0000, 184)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (185, 9000.0000, 9000.0000, 185)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (186, 3000.0000, 3000.0000, 186)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (187, 1000.0000, 1000.0000, 187)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (188, 1000.0000, 1000.0000, 188)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (189, 2000.0000, 6000.0000, 189)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (190, 1000.0000, 6000.0000, 190)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (191, 5000.0000, 8000.0000, 191)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (192, 5000.0000, 9000.0000, 192)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (193, 5000.0000, 6000.0000, 193)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (194, 1000.0000, 1000.0000, 194)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (195, 3000.0000, 4000.0000, 195)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (196, 3000.0000, 3000.0000, 196)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (197, 3000.0000, 7000.0000, 197)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (199, 3000.0000, 3000.0000, 199)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (200, 1000.0000, 5000.0000, 200)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (201, 6000.0000, 6000.0000, 201)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (202, 8000.0000, 8000.0000, 202)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (203, 6000.0000, 8000.0000, 203)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (204, 2000.0000, 4000.0000, 204)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (205, 2000.0000, 2000.0000, 205)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (206, 2000.0000, 2000.0000, 206)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (207, 2000.0000, 7000.0000, 207)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (208, 6000.0000, 10000.0000, 208)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (209, 0.0000, 700.0000, 209)
GO
INSERT [dbo].[Payment] ([id], [amountPaid], [amountDue], [CourseStudentID]) VALUES (210, 0.0000, 700.0000, 210)
GO
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[Semester] ON 
GO
INSERT [dbo].[Semester] ([id], [name], [startDate], [finishDate]) VALUES (1, N'Semester 1 2016', CAST(N'2016-02-01' AS Date), CAST(N'2016-07-01' AS Date))
GO
INSERT [dbo].[Semester] ([id], [name], [startDate], [finishDate]) VALUES (2, N'Semester 2 2016', CAST(N'2016-08-01' AS Date), CAST(N'2016-12-01' AS Date))
GO
INSERT [dbo].[Semester] ([id], [name], [startDate], [finishDate]) VALUES (3, N'Semester 1 2017', CAST(N'2017-02-01' AS Date), CAST(N'2017-07-01' AS Date))
GO
INSERT [dbo].[Semester] ([id], [name], [startDate], [finishDate]) VALUES (4, N'Semester 2 2017', CAST(N'2017-08-01' AS Date), CAST(N'2017-12-01' AS Date))
GO
INSERT [dbo].[Semester] ([id], [name], [startDate], [finishDate]) VALUES (5, N'Semester 1 2018', CAST(N'2018-02-01' AS Date), CAST(N'2018-07-01' AS Date))
GO
INSERT [dbo].[Semester] ([id], [name], [startDate], [finishDate]) VALUES (6, N'Semester 2 2018', CAST(N'2018-08-01' AS Date), CAST(N'2018-12-01' AS Date))
GO
INSERT [dbo].[Semester] ([id], [name], [startDate], [finishDate]) VALUES (7, N'Semester 1 2019', CAST(N'2019-02-01' AS Date), CAST(N'2019-07-01' AS Date))
GO
INSERT [dbo].[Semester] ([id], [name], [startDate], [finishDate]) VALUES (8, N'Semester 2 2019', CAST(N'2019-08-01' AS Date), CAST(N'2019-12-01' AS Date))
GO
INSERT [dbo].[Semester] ([id], [name], [startDate], [finishDate]) VALUES (9, N'Semester 1 2020', CAST(N'2020-02-01' AS Date), CAST(N'2020-07-01' AS Date))
GO
INSERT [dbo].[Semester] ([id], [name], [startDate], [finishDate]) VALUES (10, N'Semester 2 2020', CAST(N'2020-08-01' AS Date), CAST(N'2020-12-01' AS Date))
GO
INSERT [dbo].[Semester] ([id], [name], [startDate], [finishDate]) VALUES (11, N'Semester 1 2021', CAST(N'2021-02-01' AS Date), CAST(N'2021-07-01' AS Date))
GO
INSERT [dbo].[Semester] ([id], [name], [startDate], [finishDate]) VALUES (12, N'Semester 2 2021', CAST(N'2021-08-01' AS Date), CAST(N'2021-12-01' AS Date))
GO
INSERT [dbo].[Semester] ([id], [name], [startDate], [finishDate]) VALUES (13, N'Semester 1 2022', CAST(N'2022-02-01' AS Date), CAST(N'2022-07-01' AS Date))
GO
INSERT [dbo].[Semester] ([id], [name], [startDate], [finishDate]) VALUES (14, N'Semester 2 2022', CAST(N'2022-08-01' AS Date), CAST(N'2022-12-01' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Semester] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (1, N'22 Column Street, Blacktown 2133', 1, N'0414-666-123', N'howardee@gmail.com', CAST(N'2003-08-11' AS Date), N'Howard', N'Diz')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (2, N'25 Stevens Road, Bankstown 2200', 2, N'0400-764-912', N'jstevens@gmail.com', CAST(N'2004-09-09' AS Date), N'Jenifer', N'Stevens')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (3, N'7 Mills Street, Strathfield 2100', 1, N'03-5351-8732', N'lukehides@gmail.com', CAST(N'2005-01-02' AS Date), N'Luke', N'Hides')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (4, N'46 Todd Street, Michinbury 2770', 1, N'08-9015-2031', N'Fmoth@gmail.com', CAST(N'1958-02-02' AS Date), N'Ferguson', N'Moth')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (5, N'53 Roseta Road, Toongabie 2089', 1, N'0405-385-663', N'bfynn@hotmail.com', CAST(N'1989-04-04' AS Date), N'Brayden', N'Fynn')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (6, N'56  Grandis Road, Corangula 2440', 1, N'0401-687-772', N'stuchyen@mail.ru', CAST(N'1995-01-19' AS Date), N'Adam', N'Pomeroy')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (7, N'36 Parkway Street, Vineyard 2060', 2, N'0400-265-593', N'maria231@gmail.com', CAST(N'1983-02-02' AS Date), N'Maria', N'Galindio')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (8, N'114  Ocean Street, Riverstone 2703', 3, N'0412-031-231', N'too@gmail.com', CAST(N'2000-02-12' AS Date), N'Tristan', N'O''burn')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (9, N'59 Ocean Street, Riverstone 2700', 1, N'0413-521-351', N'evedbeg@gmail.com', CAST(N'1999-01-31' AS Date), N'Eve', N'Beg')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (11, N'42A UNWIN ROAD,CABRAMATTA WEST,NSW,2166', 1, N'0485-354-150', N'Emmanuel.Dentino@gmail.com', CAST(N'1970-06-12' AS Date), N'Emmanuel', N'Dentino')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (12, N'19 VALLEY ROAD,HAZELBROOK,NSW,2779', 2, N'0471-078-437', N'Meggan.Tudisco@gmail.com', CAST(N'1976-10-19' AS Date), N'Meggan', N'Tudisco')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (13, N'71 RAWSON AVENUE,BEXLEY,NSW,2207', 2, N'0494-315-050', N'Justine.Posen@gmail.com', CAST(N'1979-06-14' AS Date), N'Justine', N'Posen')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (14, N'13 MITCHELL DRIVE,GLOSSODIA,NSW,2756', 1, N'0474-498-283', N'Grover.Kinnare@gmail.com', CAST(N'1951-07-09' AS Date), N'Grover', N'Kinnare')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (15, N'394 MOORE PARK ROAD,PADDINGTON,NSW,2021', 2, N'0426-324-081', N'Lisa.Donn@gmail.com', CAST(N'1956-11-15' AS Date), N'Lisa', N'Donn')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (16, N'16A ASTROLABE ROAD,DACEYVILLE,NSW,2032', 1, N'0403-005-780', N'Ollie.Amejorado@gmail.com', CAST(N'1994-11-28' AS Date), N'Ollie', N'Amejorado')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (17, N'49 FIFTH AVENUE,KATOOMBA,NSW,2780', 1, N'0466-149-628', N'Napoleon.Kilmister@gmail.com', CAST(N'2002-01-19' AS Date), N'Napoleon', N'Kilmister')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (18, N'14 CARBEEN ROAD,WESTLEIGH,NSW,2120', 2, N'0403-896-615', N'Lavone.Vanbramer@gmail.com', CAST(N'1964-04-15' AS Date), N'Lavone', N'Vanbramer')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (19, N'28 EASTBOURNE WAY,BELLA VISTA,NSW,2153', 1, N'0436-521-128', N'Collin.Capalbo@gmail.com', CAST(N'1968-09-26' AS Date), N'Collin', N'Capalbo')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (20, N'89 LEUMEAH ROAD,LEUMEAH,NSW,2560', 2, N'0461-019-549', N'Merrill.Giacchino@gmail.com', CAST(N'1955-05-17' AS Date), N'Merrill', N'Giacchino')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (21, N'101 PINE CREEK CIRCUIT,ST CLAIR,NSW,2759', 2, N'0454-210-335', N'Sam.Sutcliffe@gmail.com', CAST(N'1964-04-17' AS Date), N'Sam', N'Sutcliffe')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (22, N'16 MATTHEW AVENUE,HECKENBERG,NSW,2168', 2, N'0434-202-843', N'Angelita.Perrier@gmail.com', CAST(N'1964-09-03' AS Date), N'Angelita', N'Perrier')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (23, N'34 AMAZON ROAD,SEVEN HILLS,NSW,2147', 1, N'0415-792-685', N'Morton.Vlchek@gmail.com', CAST(N'1977-06-17' AS Date), N'Morton', N'Vlchek')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (24, N'20 JEFFREY STREET,CANTERBURY,NSW,2193', 1, N'0442-876-084', N'Sammy.Fiallos@gmail.com', CAST(N'1973-05-25' AS Date), N'Sammy', N'Fiallos')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (25, N'12 Wexford Street, Small HEIGHTS,NSW,223', 1, N'0498-555-555', N'Anton.Jeakoshvili@gmail.com', CAST(N'1954-01-12' AS Date), N'Anton', N'Jeakoshvili')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (26, N'147 SPINKS ROAD,GLOSSODIA,NSW,2756', 1, N'0420-868-168', N'Jeffery.Lenarz@gmail.com', CAST(N'1990-09-07' AS Date), N'Jeffery', N'Lenarz')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (27, N'86 FORBES STREET,WOOLLOOMOOLOO,NSW,2011', 2, N'0477-048-569', N'Ardella.Mosha@gmail.com', CAST(N'1954-02-15' AS Date), N'Ardella', N'Mosha')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (28, N'2 EDMUND BLACKETT CLOSE,ST CLAIR,NSW,275', 2, N'0457-785-582', N'Ashlee.Varnon@gmail.com', CAST(N'1976-10-15' AS Date), N'Ashlee', N'Varnon')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (29, N'16 PERCY STREET,HILL TOP,NSW,2575', 1, N'0457-133-201', N'Lorenzo.Kopec@gmail.com', CAST(N'1966-02-05' AS Date), N'Lorenzo', N'Kopec')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (30, N'77 OXFORD ROAD,INGLEBURN,NSW,2565', 2, N'0407-627-162', N'Emilia.Maurizio@gmail.com', CAST(N'1998-02-04' AS Date), N'Emilia', N'Maurizio')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (32, N'19B GARDEN STREET,EASTLAKES,NSW,2018', 2, N'0414-652-546', N'Jayne.Pasch@gmail.com', CAST(N'1997-10-09' AS Date), N'Jayne', N'Pasch')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (33, N'34A SAMUEL STREET,MONA VALE,NSW,2103', 1, N'0415-100-344', N'Mohamed.Devoto@gmail.com', CAST(N'1988-11-05' AS Date), N'Mohamed', N'Devoto')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (34, N'14 MARMION ROAD,KATOOMBA,NSW,2780', 1, N'0468-318-423', N'Harland.Aurelio@gmail.com', CAST(N'1972-04-13' AS Date), N'Harland', N'Aurelio')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (36, N'14 ANDERSON STREET,WESTMEAD,NSW,2145', 2, N'0417-196-495', N'Hermelinda.Ellingson@gmail.com', CAST(N'1992-03-11' AS Date), N'Hermelinda', N'Ellingson')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (37, N'46 ANVIL AVENUE,ELDERSLIE,NSW,2570', 2, N'0429-010-522', N'Voncile.December@gmail.com', CAST(N'1985-07-01' AS Date), N'Voncile', N'December')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (38, N'19 FLORENCE AVENUE,EASTLAKES,NSW,2018', 2, N'0445-220-557', N'Nenita.Rickles@gmail.com', CAST(N'1985-01-10' AS Date), N'Nenita', N'Rickles')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (39, N'132 PACIFIC HIGHWAY,ROSEVILLE,NSW,2069', 2, N'0412-473-811', N'India.Fuery@gmail.com', CAST(N'1954-10-15' AS Date), N'India', N'Fuery')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (40, N'67B AQUEDUCT STREET,LEPPINGTON,NSW,2179', 2, N'0449-922-582', N'Kasey.Diamante@gmail.com', CAST(N'1954-12-18' AS Date), N'Kasey', N'Diamante')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (41, N'13 GUTHEGA CLOSE,WOODCROFT,NSW,2767', 1, N'0488-894-035', N'Patrick.Quackenbush@gmail.com', CAST(N'1998-08-09' AS Date), N'Patrick', N'Quackenbush')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (42, N'66 THE ESPLANADE,SYLVANIA,NSW,2224', 2, N'0410-097-806', N'Dulce.Legler@gmail.com', CAST(N'1974-09-27' AS Date), N'Dulce', N'Legler')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (43, N'20 VINE STREET,PITT TOWN,NSW,2756', 1, N'0413-739-113', N'Irving.Baumgard@gmail.com', CAST(N'1993-03-05' AS Date), N'Irving', N'Baumgard')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (44, N'56 ANDERSON ROAD,KINGS LANGLEY,NSW,2147', 1, N'0478-716-099', N'Brady.Metivier@gmail.com', CAST(N'1978-01-23' AS Date), N'Brady', N'Metivier')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (45, N'25 TOOTH AVENUE,NEWINGTON,NSW,2127', 1, N'0479-416-531', N'Dewitt.Furtick@gmail.com', CAST(N'1953-08-22' AS Date), N'Dewitt', N'Furtick')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (46, N'1A BUSBY ROAD,BUSBY,NSW,2168', 1, N'0499-638-245', N'Rex.Moncivais@gmail.com', CAST(N'1952-02-07' AS Date), N'Rex', N'Moncivais')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (47, N'22 MERTON STREET,SUTHERLAND,NSW,2232', 1, N'0482-087-437', N'Kelly.Woolcott@gmail.com', CAST(N'1993-07-26' AS Date), N'Kelly', N'Woolcott')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (48, N'9 BARNSTAPLE ROAD,FIVE DOCK,NSW,2046', 1, N'0475-153-281', N'Forest.Picetti@gmail.com', CAST(N'1991-04-16' AS Date), N'Forest', N'Picetti')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (49, N'91 MARLBOROUGH ROAD,WILLOUGHBY,NSW,2068', 2, N'0401-174-996', N'Juanita.Curpupoz@gmail.com', CAST(N'1955-01-13' AS Date), N'Juanita', N'Curpupoz')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (50, N'200 HOLDEN STREET,ASHFIELD,NSW,2131', 1, N'0406-495-855', N'Damian.Huttman@gmail.com', CAST(N'1989-10-28' AS Date), N'Damian', N'Huttman')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (51, N'12 MARTHA CRESCENT,CRANEBROOK,NSW,2749', 2, N'0441-239-023', N'Shala.Weiss@gmail.com', CAST(N'1991-08-25' AS Date), N'Shala', N'Weiss')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (52, N'24 CAVAN ROAD,KILLARNEY HEIGHTS,NSW,2087', 2, N'0466-414-877', N'Trish.Nardy@gmail.com', CAST(N'1979-07-20' AS Date), N'Trish', N'Nardy')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (53, N'348 PACIFIC HIGHWAY,LINDFIELD,NSW,2070', 1, N'0414-270-609', N'Billie.Adler@gmail.com', CAST(N'1957-12-24' AS Date), N'Billie', N'Adler')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (55, N'2A UNION STREET,ERSKINEVILLE,NSW,2043', 2, N'0496-019-429', N'Carli.Hosfield@gmail.com', CAST(N'1961-02-16' AS Date), N'Carli', N'Hosfield')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (56, N'2 PACIFIC HIGHWAY,MOONEY MOONEY,NSW,2083', 2, N'0488-174-812', N'Ashton.Gambardella@gmail.com', CAST(N'1960-08-11' AS Date), N'Ashton', N'Gambardella')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (57, N'46 FOXALL STREET,ELANORA HEIGHTS,NSW,210', 2, N'0497-805-847', N'Kandra.Quent@gmail.com', CAST(N'1978-01-19' AS Date), N'Kandra', N'Quent')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (58, N'27 HUGHES AVENUE,HARRINGTON PARK,NSW,256', 2, N'0412-042-133', N'Renay.Gaskey@gmail.com', CAST(N'1965-03-13' AS Date), N'Renay', N'Gaskey')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (59, N'520 DEVONSHIRE ROAD,KEMPS CREEK,NSW,2178', 2, N'0445-177-576', N'Jessenia.Eiesland@gmail.com', CAST(N'1987-02-10' AS Date), N'Jessenia', N'Eiesland')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (60, N'128 CUMBERLAND ROAD,GREYSTANES,NSW,2145', 2, N'0422-825-245', N'Arnette.Gitchell@gmail.com', CAST(N'1989-05-19' AS Date), N'Arnette', N'Gitchell')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (61, N'4 BELAH PLACE,MACQUARIE FIELDS,NSW,2564', 1, N'0425-125-131', N'Shannon.Maestri@gmail.com', CAST(N'1975-01-11' AS Date), N'Shannon', N'Maestri')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (62, N'33 LACEY STREET,KOGARAH BAY,NSW,2217', 1, N'0422-073-766', N'Barney.Gommer@gmail.com', CAST(N'1960-10-12' AS Date), N'Barney', N'Gommer')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (63, N'12 LOTUS STREET,MARSDEN PARK,NSW,2765', 2, N'0448-396-443', N'Tami.Newens@gmail.com', CAST(N'1999-07-04' AS Date), N'Tami', N'Newens')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (64, N'7 GERTRUDE STREET,BALGOWLAH HEIGHTS,NSW,', 1, N'0401-729-128', N'King.Vining@gmail.com', CAST(N'1953-11-05' AS Date), N'King', N'Vining')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (65, N'28 MONTGOMERY ROAD,BONNYRIGG,NSW,2177', 1, N'0475-270-172', N'Charlie.Lage@gmail.com', CAST(N'1970-01-15' AS Date), N'Charlie', N'Lage')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (66, N'9 LONG STREET,SMITHFIELD,NSW,2164', 2, N'0420-555-035', N'Leonor.Waibel@gmail.com', CAST(N'1997-07-04' AS Date), N'Leonor', N'Waibel')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (67, N'15 RAVENSWORTH PLACE,AIRDS,NSW,2560', 1, N'0451-879-588', N'Daniel.Lucian@gmail.com', CAST(N'1951-11-13' AS Date), N'Daniel', N'Lucian')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (68, N'40 AMY ROAD,PEAKHURST,NSW,2210', 1, N'0408-234-010', N'Wilmer.Diehl@gmail.com', CAST(N'1953-03-22' AS Date), N'Wilmer', N'Diehl')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (69, N'22 TINAKILL AVENUE,ENGADINE,NSW,2233', 1, N'0402-985-963', N'Wyatt.Dietsch@gmail.com', CAST(N'1966-06-12' AS Date), N'Wyatt', N'Dietsch')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (70, N'30 NELSON STREET,PENSHURST,NSW,2222', 1, N'0400-668-979', N'Faustino.Schnetzer@gmail.com', CAST(N'1972-11-11' AS Date), N'Faustino', N'Schnetzer')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (71, N'62 MELBA DRIVE,EAST RYDE,NSW,2113', 1, N'0481-683-582', N'Steve.Sarault@gmail.com', CAST(N'1969-05-17' AS Date), N'Steve', N'Sarault')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (73, N'104 GROSVENOR ROAD,LINDFIELD,NSW,2070', 2, N'0485-531-406', N'Lael.Kingry@gmail.com', CAST(N'1983-01-11' AS Date), N'Lael', N'Kingry')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (74, N'12 JORDON STREET,CAMBRIDGE PARK,NSW,2747', 1, N'0445-689-101', N'Federico.Gal@gmail.com', CAST(N'1957-04-03' AS Date), N'Federico', N'Gal')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (75, N'13 FLEMING STREET,SPRING FARM,NSW,2570', 1, N'0402-523-374', N'Hobert.Gravenstein@gmail.com', CAST(N'1962-06-04' AS Date), N'Hobert', N'Gravenstein')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (77, N'82 MINNAMORRA AVENUE,EARLWOOD,NSW,2206', 2, N'0424-734-483', N'Dora.Dekeyser@gmail.com', CAST(N'1999-10-17' AS Date), N'Dora', N'Dekeyser')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (78, N'258 PITT STREET,SYDNEY,NSW,2000', 2, N'0410-388-925', N'Elanor.Bereda@gmail.com', CAST(N'1961-09-13' AS Date), N'Elanor', N'Bereda')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (79, N'12 DORA CRESCENT,DUNDAS,NSW,2117', 1, N'0425-078-585', N'Heath.Striffler@gmail.com', CAST(N'1961-06-25' AS Date), N'Heath', N'Striffler')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (80, N'69 NORTH WEST ARM ROAD,GYMEA,NSW,2227', 1, N'0470-043-839', N'Lenny.Minniti@gmail.com', CAST(N'1981-11-08' AS Date), N'Lenny', N'Minniti')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (81, N'73 KING ROAD,HORNSBY,NSW,2077', 2, N'0411-644-766', N'Dale.Dwaileebe@gmail.com', CAST(N'2002-06-19' AS Date), N'Dale', N'Dwaileebe')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (82, N'137 BRIDGE STREET,SCHOFIELDS,NSW,2762', 2, N'0432-029-953', N'Elease.Eskenazi@gmail.com', CAST(N'1990-09-15' AS Date), N'Elease', N'Eskenazi')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (83, N'7 THIRD AVENUE,MACQUARIE FIELDS,NSW,2564', 2, N'0446-974-666', N'Demetrius.Kinnard@gmail.com', CAST(N'1980-03-23' AS Date), N'Demetrius', N'Kinnard')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (84, N'59 JACARANDA CRESCENT,CASULA,NSW,2170', 1, N'0452-544-493', N'Damion.Verkler@gmail.com', CAST(N'1982-04-16' AS Date), N'Damion', N'Verkler')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (86, N'11 THE ESPLANADE,DRUMMOYNE,NSW,2047', 2, N'0494-364-658', N'Andrea.Rehberg@gmail.com', CAST(N'1967-10-21' AS Date), N'Andrea', N'Rehberg')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (87, N'19 LAMONT PLACE,SOUTH WINDSOR,NSW,2756', 1, N'0446-079-554', N'Guy.Steifle@gmail.com', CAST(N'1984-10-17' AS Date), N'Guy', N'Steifle')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (88, N'57 GIPPS ROAD,GREYSTANES,NSW,2145', 2, N'0449-811-219', N'Debera.Gutkowski@gmail.com', CAST(N'1962-07-01' AS Date), N'Debera', N'Gutkowski')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (89, N'32 DENZIL AVENUE,ST CLAIR,NSW,2759', 2, N'0427-552-895', N'Pennie.Schwallie@gmail.com', CAST(N'1992-02-20' AS Date), N'Pennie', N'Schwallie')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (90, N'27 STAPYLTON STREET,WIN1E,NSW,2777', 1, N'0453-892-029', N'Normand.Baatz@gmail.com', CAST(N'1957-12-24' AS Date), N'Normand', N'Baatz')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (91, N'21 CHAPLIN DRIVE,LANE COVE WEST,NSW,2066', 2, N'0466-974-241', N'Donita.Whetsell@gmail.com', CAST(N'1952-01-04' AS Date), N'Donita', N'Whetsell')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (93, N'153 WOODPARK ROAD,SMITHFIELD,NSW,2164', 1, N'0434-470-066', N'Gilbert.Cuthbert@gmail.com', CAST(N'1972-06-22' AS Date), N'Gilbert', N'Cuthbert')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (94, N'34A MACQUARIE AVENUE,CAMDEN,NSW,2570', 2, N'0464-156-513', N'Geri.Schwerdtfeger@gmail.com', CAST(N'1982-11-20' AS Date), N'Geri', N'Schwerdtfeger')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (95, N'56 THE LANES,KIRKHAM,NSW,2570', 1, N'0479-442-349', N'Carmelo.Laflin@gmail.com', CAST(N'1968-04-16' AS Date), N'Carmelo', N'Laflin')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (96, N'10B KANDY AVENUE,EPPING,NSW,2121', 2, N'0433-604-565', N'Tennille.Hrbacek@gmail.com', CAST(N'1951-06-24' AS Date), N'Tennille', N'Hrbacek')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (97, N'12 HERITAGE DRIVE,APPIN,NSW,2560', 1, N'0491-685-496', N'Raymundo.Caliendo@gmail.com', CAST(N'1993-11-17' AS Date), N'Raymundo', N'Caliendo')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (98, N'65 WARATAH STREET,OATLEY,NSW,2223', 2, N'0403-090-853', N'Lesley.Revak@gmail.com', CAST(N'1958-12-03' AS Date), N'Lesley', N'Revak')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (99, N'18 VALERIE STREET,TAHMOOR,NSW,2573', 1, N'0409-605-849', N'Ross.Flammang@gmail.com', CAST(N'1985-10-28' AS Date), N'Ross', N'Flammang')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (101, N'55 STURT STREET,CAMPBELLTOWN,NSW,2560', 2, N'0486-549-382', N'Kimberlie.Santaloci@gmail.com', CAST(N'1993-06-08' AS Date), N'Kimberlie', N'Santaloci')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (102, N'3 DARGHAN STREET,GLEBE,NSW,2037', 2, N'0407-482-584', N'Shayla.Oliveri@gmail.com', CAST(N'2001-07-07' AS Date), N'Shayla', N'Oliveri')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (103, N'157 RESERVOIR ROAD,PROSPECT,NSW,2148', 2, N'0483-958-500', N'Cira.Arimoto@gmail.com', CAST(N'1972-08-21' AS Date), N'Cira', N'Arimoto')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (104, N'9 TORRINGTON AVENUE,SEFTON,NSW,2162', 2, N'0476-890-134', N'Roselee.Mckiver@gmail.com', CAST(N'1995-11-10' AS Date), N'Roselee', N'Mckiver')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (105, N'90 AVOCA STREET,RANDWICK,NSW,2031', 2, N'0429-142-036', N'Jenine.Landman@gmail.com', CAST(N'1999-01-26' AS Date), N'Jenine', N'Landman')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (106, N'46 MITCHELL ROAD,PITT TOWN,NSW,2756', 2, N'0404-074-564', N'Porsha.Aeling@gmail.com', CAST(N'1997-11-06' AS Date), N'Porsha', N'Aeling')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (107, N'29 KIMBERLEY STREET,VAUCLUSE,NSW,2030', 1, N'0469-806-522', N'Jeffrey.Kaul@gmail.com', CAST(N'1973-10-20' AS Date), N'Jeffrey', N'Kaul')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (108, N'13 HURLSTONE AVENUE,SUMMER HILL,NSW,2130', 2, N'0455-734-818', N'Adela.Ducat@gmail.com', CAST(N'1995-04-03' AS Date), N'Adela', N'Ducat')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (109, N'143 PROBERT STREET,NEWTOWN,NSW,2042', 1, N'0449-634-318', N'Daren.Dunlavy@gmail.com', CAST(N'1963-11-03' AS Date), N'Daren', N'Dunlavy')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (111, N'29 SHANNON STREET,GREENACRE,NSW,2190', 2, N'0494-303-276', N'Rubi.Lalley@gmail.com', CAST(N'1991-10-15' AS Date), N'Rubi', N'Lalley')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (112, N'21 ORARA ROAD,ALLAMBIE HEIGHTS,NSW,2100', 1, N'0468-872-012', N'Norman.Manista@gmail.com', CAST(N'1961-10-13' AS Date), N'Norman', N'Manista')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (113, N'8 WARATAH AVENUE,CASULA,NSW,2170', 2, N'0422-349-393', N'Nilda.Shoffner@gmail.com', CAST(N'1972-05-21' AS Date), N'Nilda', N'Shoffner')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (114, N'65 MORAY STREET,RICHMOND,NSW,2753', 2, N'0480-031-873', N'Jesus.Dematos@gmail.com', CAST(N'1967-08-22' AS Date), N'Jesus', N'Dematos')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (115, N'50 COWAN DRIVE,COTTAGE POINT,NSW,2084', 2, N'0486-405-141', N'Luciana.Senato@gmail.com', CAST(N'1955-12-28' AS Date), N'Luciana', N'Senato')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (116, N'1A ASSISI CLOSE,CRANEBROOK,NSW,2749', 2, N'0429-664-459', N'Ariel.Nickolas@gmail.com', CAST(N'1962-03-26' AS Date), N'Ariel', N'Nickolas')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (117, N'169 CANBERRA STREET,ST MARYS,NSW,2760', 2, N'0402-138-115', N'Jesusa.Majic@gmail.com', CAST(N'1958-10-25' AS Date), N'Jesusa', N'Majic')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (118, N'39B BALMORAL ROAD,KELLYVILLE,NSW,2155', 2, N'0449-222-458', N'Kathy.Borgstrom@gmail.com', CAST(N'1991-03-06' AS Date), N'Kathy', N'Borgstrom')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (119, N'227B MIDSON ROAD,EPPING,NSW,2121', 2, N'0405-866-161', N'Luisa.Delasko@gmail.com', CAST(N'1994-12-04' AS Date), N'Luisa', N'Delasko')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (120, N'31 WANDA STREET,MERRYLANDS WEST,NSW,2160', 1, N'0472-207-383', N'Wilbur.Coffie@gmail.com', CAST(N'1959-09-20' AS Date), N'Wilbur', N'Coffie')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (121, N'5 ORCHARD ROAD,BASS HILL,NSW,2197', 1, N'0441-296-446', N'Lorenzo.Lons@gmail.com', CAST(N'1958-05-06' AS Date), N'Lorenzo', N'Lons')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (122, N'39 APOLLO AVENUE,BAULKHAM HILLS,NSW,2153', 2, N'0448-659-187', N'Jacqui.Acevado@gmail.com', CAST(N'1968-02-04' AS Date), N'Jacqui', N'Acevado')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (123, N'20 TAMORA STREET,ROSEMEADOW,NSW,2560', 1, N'0447-595-939', N'Raymond.Keuper@gmail.com', CAST(N'1994-09-07' AS Date), N'Raymond', N'Keuper')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (124, N'51 LINDESAY STREET,LEUMEAH,NSW,2560', 1, N'0450-569-180', N'Virgilio.Bailly@gmail.com', CAST(N'1973-06-14' AS Date), N'Virgilio', N'Bailly')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (125, N'23 RICHMOND CLOSE,ST JOHNS PARK,NSW,2176', 2, N'0418-801-516', N'Violet.Ransbottom@gmail.com', CAST(N'1974-02-06' AS Date), N'Violet', N'Ransbottom')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (126, N'15 THERRY STREET,AVALON BEACH,NSW,2107', 1, N'0411-175-015', N'Royal.Ostwald@gmail.com', CAST(N'1999-10-11' AS Date), N'Royal', N'Ostwald')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (127, N'5 KINGSDALE ROAD,PRESTONS,NSW,2170', 1, N'0434-598-984', N'Boyd.Macguire@gmail.com', CAST(N'1955-01-19' AS Date), N'Boyd', N'Macguire')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (128, N'88 TARGO ROAD,GIRRAWEEN,NSW,2145', 2, N'0482-368-873', N'Gertrudis.Arrison@gmail.com', CAST(N'1957-11-20' AS Date), N'Gertrudis', N'Arrison')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (129, N'168 BONDI ROAD,BONDI,NSW,2026', 1, N'0405-403-858', N'Richie.Wal@gmail.com', CAST(N'1976-12-17' AS Date), N'Richie', N'Wal')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (130, N'31 TEMPLETON CRESCENT,MOOREBANK,NSW,2170', 2, N'0469-738-545', N'Vania.Zarnick@gmail.com', CAST(N'1967-05-23' AS Date), N'Vania', N'Zarnick')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (131, N'148 HECTOR STREET,CHESTER HILL,NSW,2162', 2, N'0480-245-821', N'Princess.Regueira@gmail.com', CAST(N'1967-03-19' AS Date), N'Princess', N'Regueira')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (132, N'1 RAILWAY VIEW PARADE,ROOTY HILL,NSW,276', 1, N'0403-282-573', N'Porter.Tong@gmail.com', CAST(N'1951-03-07' AS Date), N'Porter', N'Tong')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (133, N'47A SPOFFORTH STREET,MOSMAN,NSW,2088', 2, N'0447-796-015', N'Elene.Cady@gmail.com', CAST(N'1979-10-25' AS Date), N'Elene', N'Cady')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (134, N'111 CATTAI CREEK DRIVE,KELLYVILLE,NSW,21', 1, N'0487-391-462', N'Hobert.Rook@gmail.com', CAST(N'1994-05-14' AS Date), N'Hobert', N'Rook')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (135, N'31 NICOLAIDIS CRESCENT,ROOTY HILL,NSW,27', 1, N'0488-775-282', N'Mario.Lastufka@gmail.com', CAST(N'1986-09-09' AS Date), N'Mario', N'Lastufka')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (136, N'12 TRAMWAY STREET,TEMPE,NSW,2044', 1, N'0432-005-760', N'Gavin.Waneka@gmail.com', CAST(N'1971-04-03' AS Date), N'Gavin', N'Waneka')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (137, N'606 HOXTON PARK ROAD,HOXTON PARK,NSW,217', 1, N'0414-918-588', N'Keith.Leiker@gmail.com', CAST(N'1950-11-07' AS Date), N'Keith', N'Leiker')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (138, N'2 WESTMORE DRIVE,WEST PENNANT HILLS,NSW,', 1, N'0487-574-205', N'Rodolfo.Weddle@gmail.com', CAST(N'1991-02-20' AS Date), N'Rodolfo', N'Weddle')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (139, N'24 ADAH STREET,GUILDFORD,NSW,2161', 1, N'0479-038-971', N'Roman.Kym@gmail.com', CAST(N'1951-01-14' AS Date), N'Roman', N'Kym')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (140, N'61 WAIROA AVENUE,NORTH BONDI,NSW,2026', 2, N'0484-530-191', N'Tiffiny.Koelzer@gmail.com', CAST(N'1978-11-03' AS Date), N'Tiffiny', N'Koelzer')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (141, N'18 Mother Street', 1, N'0414000123', N'myemail@gmail.com', CAST(N'1991-12-12' AS Date), N'Michael', N'Road')
GO
INSERT [dbo].[Student] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname]) VALUES (142, N'18 Mother Street', 1, N'0414000123', N'myemail@gmail.com', CAST(N'2001-10-01' AS Date), N'Michael', N'Road')
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 
GO
INSERT [dbo].[Teacher] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname], [base_locationID]) VALUES (1, N'12 William Street, Granville 2140', 1, N'0421-128-901', N'joe@gmail.com', CAST(N'2001-09-12' AS Date), N'Joe', N'Bloke', 2)
GO
INSERT [dbo].[Teacher] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname], [base_locationID]) VALUES (2, N'22 William Street, Auburn 2140', 1, N'0421-128-801', N'bloke@gmail.com', CAST(N'1999-09-12' AS Date), N'Bloke', N'Joe', 1)
GO
INSERT [dbo].[Teacher] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname], [base_locationID]) VALUES (3, N'99 James Street, Granville 2140', 2, N'0421-921-901', N'sarah@hotmail.com', CAST(N'2003-09-22' AS Date), N'Sarah', N'James', 3)
GO
INSERT [dbo].[Teacher] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname], [base_locationID]) VALUES (4, N'22 Church Street, Parramatta 2150', 1, N'0404-123-321', N'jdoe@gmail.com', CAST(N'1979-09-01' AS Date), N'Joe', N'Doe', 1)
GO
INSERT [dbo].[Teacher] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname], [base_locationID]) VALUES (5, N'24 Church Street, Parramatta 2150', 3, N'0400-556-098', N'uwu@gmail.com', CAST(N'1989-10-10' AS Date), N'Connor', N'Android', 4)
GO
INSERT [dbo].[Teacher] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname], [base_locationID]) VALUES (6, N'77 Williams Street, Wentworthville 2200', 1, N'0477-321-867', N'mmyers@gmail.com', CAST(N'1970-01-03' AS Date), N'Michael', N'Myers', 4)
GO
INSERT [dbo].[Teacher] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname], [base_locationID]) VALUES (7, N'45 Riverstone Street, Liverpool 2700', 2, N'0456-231-688', N'maryjane@gmail.com', CAST(N'2000-01-11' AS Date), N'Mary', N'Jane', 2)
GO
INSERT [dbo].[Teacher] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname], [base_locationID]) VALUES (8, N'12 Uber Street, Liverpool 2700', 2, N'0456-642-235', N'monsmith@hotmail.com', CAST(N'2003-01-11' AS Date), N'Monica', N'Smith', 3)
GO
INSERT [dbo].[Teacher] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname], [base_locationID]) VALUES (9, N'23 River Street, Parramatta 2150', 1, N'0451-032-123', N'joerogan@hotmail.com', CAST(N'1950-01-21' AS Date), N'Joe', N'Rogan', 1)
GO
INSERT [dbo].[Teacher] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname], [base_locationID]) VALUES (10, N'33 Elevator Street, Richmond 2230', 2, N'0415-035-123', N'salek@gmail.com', CAST(N'1999-01-05' AS Date), N'Svetlana', N'Alexandrovna', 4)
GO
INSERT [dbo].[Teacher] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname], [base_locationID]) VALUES (12, N'18 Junior Street, Seven Hills 1998', 1, N'0413-213-321', N'roshik@gmail.com', CAST(N'2001-01-01' AS Date), N'Roshik', N'Wery', 1)
GO
INSERT [dbo].[Teacher] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname], [base_locationID]) VALUES (13, N'01 Senior Street, Seven Hills 1950', 3, N'0413-231-321', N'johnbest@gmail.com', CAST(N'1965-03-03' AS Date), N'Johnathan', N'Byest', 3)
GO
INSERT [dbo].[Teacher] ([id], [address], [genderID], [mobile], [email], [dob], [firstname], [lastname], [base_locationID]) VALUES (14, N'04 Cobble Street, Cabramatta 2176', 1, N'0444-444-123', N'rockjohnson@gmail.com', CAST(N'1970-03-12' AS Date), N'Rock', N'Johnson', 1)
GO
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (1, N'Use query language to work with databases', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (2, N'Develop web based mobile applications', 300)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (3, N'Apply object-oriented design and language skills', 400)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (4, N'Write and maintain program code', 300)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (5, N'Test, debug, diagnose and correct errors and faults in applications', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (6, N'Address cyber security requirements', 300)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (7, N'Manage the software development lifecycle', 300)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (8, N'Create and test software programs', 100)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (9, N'Use different programming languages and tools', 400)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (10, N'Design and develop web-related products and applications', 100)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (11, N'Contribute to copyright, ethics and privacy in an IT environment', 100)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (12, N'Apply occupational psychology skills', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (13, N'Use interpersonal skills', 100)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (14, N'Manipulate a team to improve productivity', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (15, N'Prepare dishes uses different techniques, equipment and methods', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (16, N'Develop and adapt menus to meet dietary requirements', 400)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (17, N'Manage kitchen operations', 300)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (18, N'Lead a team and coach individuals', 100)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (19, N'Establish, develop and monitor teams', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (20, N'Conduct waste resource recovery', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (21, N'Identify and respond to hazards and emergencies in waste management', 400)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (22, N'Develop proposals for waste management services', 100)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (23, N'Assess and advise on waste avoidance options', 100)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (24, N'Develop waste management plans', 100)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (25, N'Apply accounting fundamentals', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (26, N'Create financial reports', 400)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (27, N'Process financial transactions', 300)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (28, N'Use computerised accounting and payroll systems', 300)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (29, N'Create and lodge Business Activity Statements (BAS)', 400)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (30, N'Use essential industry tools and programs', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (31, N'Learn to navigate computer software and hardware', 100)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (32, N'Practise algorithm programming', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (33, N'Gain advanced problem-solving skills', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (34, N'Apply your learning to complex computing challenges', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (35, N'Manage the flow of goods between suppliers and customers', 300)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (36, N'Perform record-keeping duties', 400)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (37, N'Manage transportation', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (38, N'Apply risk management principles of water industry standards, guidelines and legislation', 300)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (39, N'Assess, implement and report environmental procedures', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (40, N'Manage risk', 400)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (41, N'Create management plans across drainage, gas, excavation and ventilation functions', 400)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (42, N'Implement secure encryption technologies', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (43, N'Design and implement a security perimeter for ICT networks', 400)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (44, N'Design and implement a security system', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (45, N'Plan, configure and test advanced server-based security', 100)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (46, N'Integrate sustainability in ICT planning and design projects', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (47, N'Work collaboratively with other services', 100)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (48, N'Understand trauma care', 200)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (49, N'Respond to crises', 100)
GO
INSERT [dbo].[Unit] ([id], [name], [hoursAmount]) VALUES (50, N'Support people experiencing mental illness and psychiatric disability', 100)
GO
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
ALTER TABLE [dbo].[Cluster]  WITH CHECK ADD  CONSTRAINT [FK__Cluster__courseI__50FB042B] FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Cluster] CHECK CONSTRAINT [FK__Cluster__courseI__50FB042B]
GO
ALTER TABLE [dbo].[Cluster]  WITH CHECK ADD FOREIGN KEY([unitID])
REFERENCES [dbo].[Unit] ([id])
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK__Course__delivery__2CBDA3B5] FOREIGN KEY([deliveryID])
REFERENCES [dbo].[Delivery] ([id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK__Course__delivery__2CBDA3B5]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK__Course__location__3F466844] FOREIGN KEY([locationID])
REFERENCES [dbo].[Location] ([id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK__Course__location__3F466844]
GO
ALTER TABLE [dbo].[CourseSemester]  WITH CHECK ADD  CONSTRAINT [FK__CourseSem__cours__53D770D6] FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[CourseSemester] CHECK CONSTRAINT [FK__CourseSem__cours__53D770D6]
GO
ALTER TABLE [dbo].[CourseSemester]  WITH CHECK ADD FOREIGN KEY([semesterID])
REFERENCES [dbo].[Semester] ([id])
GO
ALTER TABLE [dbo].[CourseStudent]  WITH CHECK ADD  CONSTRAINT [FK__CourseStu__cours__0F624AF8] FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[CourseStudent] CHECK CONSTRAINT [FK__CourseStu__cours__0F624AF8]
GO
ALTER TABLE [dbo].[CourseStudent]  WITH CHECK ADD  CONSTRAINT [FK__CourseStu__cours__10566F31] FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[CourseStudent] CHECK CONSTRAINT [FK__CourseStu__cours__10566F31]
GO
ALTER TABLE [dbo].[CourseStudent]  WITH CHECK ADD  CONSTRAINT [FK__CourseStu__outco__4222D4EF] FOREIGN KEY([outcomeID])
REFERENCES [dbo].[Outcome] ([id])
GO
ALTER TABLE [dbo].[CourseStudent] CHECK CONSTRAINT [FK__CourseStu__outco__4222D4EF]
GO
ALTER TABLE [dbo].[CourseStudent]  WITH CHECK ADD  CONSTRAINT [FK__CourseStu__stude__0E6E26BF] FOREIGN KEY([studentID])
REFERENCES [dbo].[Student] ([id])
GO
ALTER TABLE [dbo].[CourseStudent] CHECK CONSTRAINT [FK__CourseStu__stude__0E6E26BF]
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD  CONSTRAINT [FK__CourseTea__cours__4AB81AF0] FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[CourseTeacher] CHECK CONSTRAINT [FK__CourseTea__cours__4AB81AF0]
GO
ALTER TABLE [dbo].[CourseTeacher]  WITH CHECK ADD  CONSTRAINT [FK__CourseTea__teach__4BAC3F29] FOREIGN KEY([teacherID])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[CourseTeacher] CHECK CONSTRAINT [FK__CourseTea__teach__4BAC3F29]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD FOREIGN KEY([CourseStudentID])
REFERENCES [dbo].[CourseStudent] ([id])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK__Student__genderI__49C3F6B7] FOREIGN KEY([genderID])
REFERENCES [dbo].[Gender] ([id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK__Student__genderI__49C3F6B7]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK__Teacher__base_lo__4BAC3F29] FOREIGN KEY([base_locationID])
REFERENCES [dbo].[Location] ([id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK__Teacher__base_lo__4BAC3F29]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK__Teacher__genderI__4CA06362] FOREIGN KEY([genderID])
REFERENCES [dbo].[Gender] ([id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK__Teacher__genderI__4CA06362]
GO
/****** Object:  StoredProcedure [dbo].[usp_AlterPaymentByCourseStudentID]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_AlterPaymentByCourseStudentID] @CourseStudentID int, @amountPaid money, @amountDue money
as
update Payment
set amountPaid = @amountPaid, 
amountDue = @amountDue
where Payment.CourseStudentID = @CourseStudentID
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteCourse]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_DeleteCourse] @courseID int
as
delete from dbo.Cluster where Cluster.courseID = @courseID
delete from dbo.CourseSemester where CourseSemester.courseID = @courseID
delete from dbo.CourseTeacher where CourseTeacher.courseID = @courseID
delete from dbo.Payment where Payment.CourseStudentID in (select CourseStudent.id from CourseStudent where CourseStudent.courseID = @courseID)
delete from dbo.CourseStudent where CourseStudent.courseID = @courseID
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteStudent]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_DeleteStudent] @studentID int
as

delete from dbo.Payment where Payment.CourseStudentID in (select CourseStudent.id from CourseStudent where CourseStudent.studentID = @studentID)

delete from dbo.CourseStudent where CourseStudent.studentID = @studentID
delete from dbo.Student where Student.id = @studentID

GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteTeacher]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_DeleteTeacher] @teacherID int
as
delete from CourseTeacher where CourseTeacher.teacherID = @teacherID
delete from dbo.Teacher where Teacher.id = @teacherID   
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteUnit]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_DeleteUnit] @unitID int
as
delete from dbo.Cluster where Cluster.unitID = @unitID
delete from dbo.Unit where Unit.id = @unitID

GO
/****** Object:  StoredProcedure [dbo].[usp_EditStudent]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_EditStudent] @studentID int,
	@address nvarchar(40), @genderID int,
	@mobile nvarchar(40),
	@email nvarchar(40),
	@dob date,
	@firstname nvarchar(40),
	@lastname nvarchar(40)
as
update Student
set Student.address = @address, Student.dob = @dob,
Student.email = @email, Student.firstname = @firstname, Student.genderID = @genderID, Student.lastname = @lastname, Student.mobile = @mobile
where Student.id = @studentID

GO
/****** Object:  StoredProcedure [dbo].[usp_EditStudentOutcome]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_EditStudentOutcome] @outcomeID int, @courseStudentID int
as
update CourseStudent
set CourseStudent.outcomeID = @outcomeID where CourseStudent.id = @courseStudentID
GO
/****** Object:  StoredProcedure [dbo].[usp_EditTeacher]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_EditTeacher] @teacherID int,  @address nvarchar(40), @genderID int,
	@mobile nvarchar(40),
	@email nvarchar(40),
	@dob date,
	@firstname nvarchar(40),
	@lastname nvarchar(40),
	@base_locationID int
as
update Teacher
set Teacher.address = @address, Teacher.base_locationID = @base_locationID, Teacher.dob = @dob,
Teacher.email = @email, Teacher.firstname = @firstname, Teacher.genderID = @genderID, Teacher.lastname = @lastname, Teacher.mobile = @mobile
where Teacher.id = @teacherID

GO
/****** Object:  StoredProcedure [dbo].[usp_EditUnit]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_EditUnit] @unitID int, @unitName nvarchar(100), @hoursAmount int
as
update Unit
set Unit.hoursAmount = @hoursAmount, Unit.name = @unitName
where Unit.id = @unitID

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCluster]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_InsertCluster] @courseID int, @unitID int
as
begin
insert into dbo.Cluster values(@courseID, @unitID)
end

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCourse]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_InsertCourse] 	@name nvarchar(40) ,
	@locationID int ,
	@deliveryID int ,
	@isCurrent bit
as
begin

insert into dbo.Course values(@name, @locationID, @deliveryID, @isCurrent)

declare @CourseID int;
set @CourseID =(select top(1) Course.id from Course
					where Course.name = @name and Course.locationID = @locationID and Course.deliveryID = @deliveryID
					and Course.isCurrent = @isCurrent)

select @CourseID;

end

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCourseSemester]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_InsertCourseSemester] @courseID int, @semesterID int
as
begin
insert into dbo.CourseSemester values(@courseID, @semesterID)
end

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCourseStudentPayment]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_InsertCourseStudentPayment] @studentID int, @courseID int, @amountDue money
as
begin
insert into CourseStudent values(@studentID,@courseID,3 )

declare @CourseStudentID int;
set @CourseStudentID = IDENT_CURRENT( 'CourseStudent' )
insert into dbo.Payment values (0, @amountDue, @CourseStudentID)

end

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCourseTeacher]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_InsertCourseTeacher] @courseID int, @teacherID int
as
begin
insert into dbo.CourseTeacher values(@courseID, @teacherID)
end

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertStudent]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_InsertStudent] 	
	@address nvarchar(40), @genderID int,
	@mobile nvarchar(40),
	@email nvarchar(40),
	@dob date,
	@firstname nvarchar(40),
	@lastname nvarchar(40),
	@courseID int,
	@amountDue money
as
begin
insert into dbo.Student values (@address, @genderID, @mobile, @email, @dob, @firstname, @lastname);

declare @StudentID int
set @StudentID = (select top(1) Student.id from dbo.Student
where Student.address = @address and Student.genderID = @genderID and Student.mobile = @mobile and Student.email = @email
and Student.dob = @dob and Student.firstname = @firstname and Student.lastname = @lastname)

insert into dbo.CourseStudent values(@StudentID, @courseID, 3)

declare @CourseStudentID int

set @CourseStudentID = IDENT_CURRENT('CourseStudent')  

insert into dbo.Payment values(0, @amountDue, @CourseStudentID)
end

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertTeacher]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_InsertTeacher] 	@address nvarchar(40), @genderID int,
	@mobile nvarchar(40),
	@email nvarchar(40),
	@dob date,
	@firstname nvarchar(40),
	@lastname nvarchar(40),
	@base_locationID int,
	@courseID money
as
begin

insert into dbo.Teacher values(@address, @genderID, @mobile, @email, @dob, @firstname, @lastname, @base_locationID)

declare @TeacherID int;
set @TeacherID = (select top(1) Teacher.id from Teacher
where Teacher.address = @address and Teacher.genderID = @genderID and Teacher.mobile = @mobile and Teacher.email = @email
and Teacher.dob = @dob and Teacher.firstname = @firstname and Teacher.lastname = @lastname and Teacher.base_locationID = @base_locationID)

insert into CourseTeacher values(@courseID, @TeacherID)

end

GO
/****** Object:  StoredProcedure [dbo].[usp_InsertUnit]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_InsertUnit] @unitName nvarchar(100), @hoursAmount int
as
begin
insert into dbo.Unit values(@unitName, @hoursAmount)
end
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllCluster]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_SelectAllCluster]
as
select * from vw_SelectAllCluster

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllCourse]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_SelectAllCourse]
as
select Course.id, Course.name,  [Location].name, Delivery.description from dbo.Course
inner join [Location] on [Location].id = Course.locationID
inner join Delivery on Delivery.id = Course.deliveryID

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllDelivery]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllDelivery]
as
begin
select Delivery.id, Delivery.description from Delivery
end

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllGender]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllGender]
as
select Gender.id, Gender.description from Gender

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllLocation]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllLocation]
as
select * from Location;

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllNotOfferedCourse]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllNotOfferedCourse]
as
select Course.id, Course.name,  [Location].name, Delivery.description from dbo.Course
inner join [Location] on [Location].id = Course.locationID
inner join Delivery on Delivery.id = Course.deliveryID
where  Course.isCurrent != 1

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllOutcome]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[usp_SelectAllOutcome]
as
select Outcome.id, Outcome.description from Outcome

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllPayment]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllPayment]
as
select * from Payment;

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllSemester]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_SelectAllSemester]
as
select * from Semester;

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllStudent]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_SelectAllStudent]
as
select	Student.id,Student.address, Gender.description, 
		Student.mobile, Student.email, Student.dob, 
		Student.firstname, Student.lastname,
		(
		SELECT count(*) FROM vw_UnpaidCourseID
		where CourseStudentID = [UnpaidCourseStudentID]
		) as 'Fees not paid'
		, Delivery.description, Course.isCurrent
	from Student
	inner join Gender on Gender.id = Student.genderID
	inner join CourseStudent on CourseStudent.studentID = Student.id
	inner join Payment on Payment.CourseStudentID = CourseStudent.id
	inner join Course on CourseStudent.courseID = Course.id
	inner join Delivery on Course.deliveryID = Delivery.id

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllStudentsEnrolledIntoCourse]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllStudentsEnrolledIntoCourse] @CourseID int
as
select Student.id, Student.firstname, Student.lastname, Student.address
from Student
where Student.id in 
(select CourseStudent.studentID from CourseStudent where CourseStudent.courseID = @CourseID)
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllStudentsNotEnrolledIntoCourse]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllStudentsNotEnrolledIntoCourse] @CourseID int
as
select Student.id, Student.firstname, Student.lastname, Student.address
from Student
where Student.id not in 
(select CourseStudent.studentID from CourseStudent where CourseStudent.courseID = @CourseID)
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllTeacher]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_SelectAllTeacher]
as
select Teacher.id, Teacher.address, Gender.description, Teacher.mobile, Teacher.email, 
Teacher.dob, Teacher.firstname, Teacher.lastname,  Delivery.description, Course.isCurrent,
Teacher.base_locationID, Course.locationID

from Teacher
inner join Gender on Gender.id = Teacher.genderID
inner join CourseTeacher on CourseTeacher.teacherID = Teacher.id
inner join Course on Course.id = CourseTeacher.courseID
inner join Delivery on Course.deliveryID = Delivery.id
order by Teacher.id asc

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllTeacherNotTeachingCourse]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllTeacherNotTeachingCourse] @courseID int
as
select Teacher.id, Teacher.firstname, Teacher.lastname from Teacher
where Teacher.id not in (select CourseTeacher.teacherID  from CourseTeacher where CourseTeacher.courseID = @courseID)
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllTeacherTeachingCourse]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllTeacherTeachingCourse] @courseID int
as
select Teacher.id, Teacher.firstname, Teacher.lastname from Teacher
where Teacher.id in (select CourseTeacher.teacherID  from CourseTeacher where CourseTeacher.courseID = @courseID)
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllTimetables]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllTimetables]
as
select distinct(Course.id), Course.name, vw_SelectCourseStartEndDates.startDate, vw_SelectCourseStartEndDates.finishDate,
[Location].name, [Location].contact_number,  Delivery.description, [UnitsPerCourse],
[TeachersPerCourse], [StudentsPerCourse], Course.isCurrent

from vw_SelectCourseStartEndDates
left join vw_SelectUnitAmountPerCourse on vw_SelectUnitAmountPerCourse.id = vw_SelectCourseStartEndDates.id
left join vw_SelectAmountTeacherPerCourse on vw_SelectAmountTeacherPerCourse.id = vw_SelectCourseStartEndDates.id
left join vw_SelectStudentAmountPerCourse on vw_SelectStudentAmountPerCourse.id = vw_SelectCourseStartEndDates.id
left join Course on Course.id = vw_SelectCourseStartEndDates.id
left join [Location] on [Location].id = Course.locationID
left join Delivery on Delivery.id = Course.deliveryID
left join CourseSemester on CourseSemester.courseID = Course.id
left join Semester on Semester.id = CourseSemester.id
left join Cluster on Cluster.courseID = Course.id

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllUnit]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllUnit]
as
select * from Unit;

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectEnrolmentById]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_SelectEnrolmentById] @studentID int
as
select Student.firstname, Student.lastname, Course.name, amountPaid,amountDue, Location.name, Location.address, Course.isCurrent,
CourseStudent.id

from Student 
inner join CourseStudent on CourseStudent.studentID = Student.id
inner join Payment on Payment.CourseStudentID = CourseStudent.id
inner join Course on Course.id = CourseStudent.courseID
inner join Location on Location.id = Course.locationID
where Student.id = @studentID

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectTeacherHistoryByID]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_SelectTeacherHistoryByID] @TeacherID int
as

select Course.name, Semester.name, Location.name, Delivery.description, Course.isCurrent from CourseTeacher
left join Teacher on Teacher.id = CourseTeacher.id
left join Course on Course.id = CourseTeacher.courseID
left join Delivery on Delivery.id = deliveryID
left join [Location] on Location.id = Course.locationID
left join CourseSemester on CourseSemester.courseID = Course.id
left join Semester on Semester.id = CourseSemester.semesterID
where CourseTeacher.teacherID = @TeacherID

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectUnallocatedUnits]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_SelectUnallocatedUnits]
as
select unitID, name, hoursAmount from Cluster
inner join Unit on Unit.id = Cluster.unitID
where Cluster.unitID not in (
select unitID from dbo.Course
inner join Cluster on Cluster.courseID = Course.id
where  Course.isCurrent = 1)

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectUnenrolledStudents]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectUnenrolledStudents]
as
select Student.id, Student.firstname, Student.lastname, Student.address
from Student
where Student.id not in (select * from vw_SelectCurrentStudentIDs)

GO
/****** Object:  StoredProcedure [dbo].[usp_SelectUnitsThatBelongToCourse]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectUnitsThatBelongToCourse] @CourseID int
as
select * from Unit
where Unit.id 
in (select Cluster.unitID from Cluster where Cluster.courseID = @CourseID)
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectUnitsThatDontBelongToCourse]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectUnitsThatDontBelongToCourse] @CourseID int
as
select * from Unit
where Unit.id 
not in (select Cluster.unitID from Cluster where Cluster.courseID = @CourseID)
GO
/****** Object:  StoredProcedure [dbo].[usp_StudentResultByID]    Script Date: 9/07/2021 2:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_StudentResultByID] @studentID int
as
select CourseStudent.studentID, Course.name, Location.name, Outcome.description, CourseStudent.id from CourseStudent
inner join dbo.Outcome on Outcome.id = CourseStudent.outcomeID
inner join Course on Course.id = CourseStudent.courseID
inner join Location on Location.id = Course.locationID
where CourseStudent.studentID = @studentID

GO
ALTER DATABASE [TafeSystem] SET  READ_WRITE 
GO
