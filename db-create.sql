USE [master]
GO
/****** Object:  Database [TafeSystem]    Script Date: 7/06/2021 11:40:14 AM ******/
CREATE DATABASE [TafeSystem]
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
/****** Object:  Table [dbo].[Course]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  Table [dbo].[Semester]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  Table [dbo].[CourseSemester]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  View [dbo].[vw_SelectCourseStartEndDates]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  Table [dbo].[Cluster]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  View [dbo].[vw_SelectUnitAmountPerCourse]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  Table [dbo].[CourseTeacher]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  View [dbo].[vw_SelectAmountTeacherPerCourse]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  Table [dbo].[CourseStudent]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  View [dbo].[vw_SelectStudentAmounPerCourse]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  View [dbo].[vw_SelectStudentAmountPerCourse]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  View [dbo].[vw_SelectCurrentStudentIDs]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  Table [dbo].[Payment]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  View [dbo].[vw_UnpaidCourseID]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  Table [dbo].[Unit]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  View [dbo].[view_SelectAllCluster]    Script Date: 7/06/2021 11:40:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[view_SelectAllCluster]
as
select Cluster.courseID, Unit.name, Unit.hoursAmount from Cluster
inner join Unit on Unit.id = Cluster.unitID
GO
/****** Object:  Table [dbo].[Assessment]    Script Date: 7/06/2021 11:40:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assessment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[unitID] [int] NOT NULL,
 CONSTRAINT [PK_Assessment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  Table [dbo].[Gender]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  Table [dbo].[Location]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  Table [dbo].[Outcome]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  Table [dbo].[Student]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  Table [dbo].[Teacher]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 7/06/2021 11:40:14 AM ******/
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
ALTER TABLE [dbo].[Assessment]  WITH CHECK ADD  CONSTRAINT [FK__Assessmen__unitI__3B0BC30C] FOREIGN KEY([unitID])
REFERENCES [dbo].[Unit] ([id])
GO
ALTER TABLE [dbo].[Assessment] CHECK CONSTRAINT [FK__Assessmen__unitI__3B0BC30C]
GO
ALTER TABLE [dbo].[Cluster]  WITH CHECK ADD  CONSTRAINT [FK__Cluster__courseI__50FB042B] FOREIGN KEY([courseID])
REFERENCES [dbo].[Course] ([id])
GO
ALTER TABLE [dbo].[Cluster] CHECK CONSTRAINT [FK__Cluster__courseI__50FB042B]
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
/****** Object:  StoredProcedure [dbo].[usp_AttemptLogin]    Script Date: 7/06/2021 11:40:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_AttemptLogin] @username nvarchar(40), @password nvarchar(40)
as
select count(*) from [User]
where username = @username and password = @password;
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertCluster]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_InsertCourse]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_InsertCourseSemester]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_InsertCourseStudentPayment]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_InsertCourseTeacher]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_InsertStudent]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_InsertTeacher]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_SelectAllAssessment]    Script Date: 7/06/2021 11:40:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllAssessment]
as
select * from Assessment;
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllCluster]    Script Date: 7/06/2021 11:40:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_SelectAllCluster]
as
select * from view_SelectAllCluster
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllCourse]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_SelectAllDelivery]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_SelectAllGender]    Script Date: 7/06/2021 11:40:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllGender]
as
select Gender.id, Gender.description from Gender
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllLocation]    Script Date: 7/06/2021 11:40:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllLocation]
as
select * from Location;
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllNotOfferedCourse]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_SelectAllPayment]    Script Date: 7/06/2021 11:40:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllPayment]
as
select * from Payment;
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllSemester]    Script Date: 7/06/2021 11:40:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_SelectAllSemester]
as
select * from Semester;
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectAllStudent]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_SelectAllTeacher]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_SelectAllTimetables]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_SelectAllUnit]    Script Date: 7/06/2021 11:40:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_SelectAllUnit]
as
select * from Unit;
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectEnrolmentById]    Script Date: 7/06/2021 11:40:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_SelectEnrolmentById] @studentID int
as
select Student.firstname, Student.lastname, Course.name,    amountPaid,amountDue, Location.name, Location.address, Course.isCurrent from Student 
inner join CourseStudent on CourseStudent.studentID = Student.id
inner join Payment on Payment.CourseStudentID = CourseStudent.id
inner join Course on Course.id = CourseStudent.courseID
inner join Location on Location.id = Course.locationID
where Student.id = @studentID
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectTeacherHistoryByID]    Script Date: 7/06/2021 11:40:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[usp_SelectTeacherHistoryByID] @TeacherID int
as
select Course.name, Semester.name, Unit.name, hoursAmount,  Location.name, Delivery.description, Course.isCurrent from CourseTeacher
left join Teacher on Teacher.id = CourseTeacher.id
left join Course on Course.id = CourseTeacher.courseID
left join Delivery on Delivery.id = deliveryID
left join Cluster on Cluster.courseID = Course.id
left join Unit on Unit.id = Cluster.unitID
left join [Location] on Location.id = Course.locationID
left join CourseSemester on CourseSemester.courseID = Course.id
left join Semester on Semester.id = CourseSemester.semesterID
where CourseTeacher.teacherID = @TeacherID
GO
/****** Object:  StoredProcedure [dbo].[usp_SelectUnallocatedUnits]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_SelectUnenrolledStudents]    Script Date: 7/06/2021 11:40:14 AM ******/
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
/****** Object:  StoredProcedure [dbo].[usp_StudentResultByID]    Script Date: 7/06/2021 11:40:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_StudentResultByID] @studentID int
as
select CourseStudent.studentID, Course.name, Location.name, Outcome.description from CourseStudent
inner join dbo.Outcome on Outcome.id = CourseStudent.outcomeID
inner join Course on Course.id = CourseStudent.courseID
inner join Location on Location.id = Course.locationID
where CourseStudent.studentID = @studentID
GO
USE [master]
GO
ALTER DATABASE [TafeSystem] SET  READ_WRITE 
GO
