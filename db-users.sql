use TafeSystem;
begin

-- creating the users

create user manager with password = 'manager';
create user teacher with password = 'teacher';
create user payment with password ='payment';

-- assigning user roles


-- teacher
GRANT EXECUTE ON [dbo].[usp_SelectAllCluster] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllCourse] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllDelivery] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllGender] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllLocation] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllNotOfferedCourse] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllPayment] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllSemester] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllStudent] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllStudentsEnrolledIntoCourse] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllStudentsNotEnrolledIntoCourse] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllTeacher] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllTeacherNotTeachingCourse] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllTeacherTeachingCourse] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllTimetables] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllUnit] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectEnrolmentById] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectTeacherHistoryByID] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectUnallocatedUnits] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectUnenrolledStudents] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectUnitsThatBelongToCourse] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectUnitsThatDontBelongToCourse] TO teacher;
GRANT EXECUTE ON [dbo].[usp_StudentResultByID] TO teacher;


-- payment





-- manager
GRANT EXECUTE ON dbo.usp_DeleteStudent TO manager;
GRANT EXECUTE ON dbo.usp_DeleteTeacher TO manager;
GRANT EXECUTE ON dbo.usp_DeleteUnit TO manager;
GRANT EXECUTE ON dbo.usp_EditStudent TO manager;
GRANT EXECUTE ON dbo.usp_EditTeacher TO manager;
GRANT EXECUTE ON dbo.usp_EditUnit TO manager;
GRANT EXECUTE ON dbo.usp_Insert TO manager;



end