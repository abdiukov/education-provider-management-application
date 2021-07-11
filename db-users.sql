use TafeSystem;
begin

-- creating the users

create user manager with password = 'manager';
create user teacher with password = 'teacher';

-- assigning user roles

-- teacher

GRANT EXECUTE ON [dbo].[usp_SelectAllCluster] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllCourse] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllDelivery] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllGender] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllLocation] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllNotOfferedCourse] TO teacher;
GRANT EXECUTE ON [dbo].[usp_SelectAllOutcome] TO teacher;
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


-- manager

GRANT EXECUTE ON [dbo].[usp_InsertUnit] TO manager;
GRANT EXECUTE ON [dbo].[usp_InsertTeacher] TO manager;
GRANT EXECUTE ON [dbo].[usp_InsertStudent] TO manager;
GRANT EXECUTE ON [dbo].[usp_InsertCourseTeacher] TO manager;
GRANT EXECUTE ON [dbo].[usp_InsertCourseStudentPayment] TO manager;
GRANT EXECUTE ON [dbo].[usp_InsertCourseSemester] TO manager;
GRANT EXECUTE ON [dbo].[usp_InsertCourse] TO manager;
GRANT EXECUTE ON [dbo].[usp_InsertCluster] TO manager;
GRANT EXECUTE ON [dbo].[usp_GetCourseInfoToAutoFill] TO manager;
GRANT EXECUTE ON [dbo].[usp_EditUnit] TO manager;
GRANT EXECUTE ON [dbo].[usp_EditTeacher] TO manager;
GRANT EXECUTE ON [dbo].[usp_EditStudentOutcome] TO manager;
GRANT EXECUTE ON [dbo].[usp_EditStudent] TO manager;
GRANT EXECUTE ON [dbo].[usp_EditCourse] TO manager;
GRANT EXECUTE ON [dbo].[usp_DeleteUnit] TO manager;
GRANT EXECUTE ON [dbo].[usp_DeleteTeacher] TO manager;
GRANT EXECUTE ON [dbo].[usp_DeleteStudent] TO manager;
GRANT EXECUTE ON [dbo].[usp_DeleteCourseTeacher] TO manager;
GRANT EXECUTE ON [dbo].[usp_DeleteCourseStudentPayment] TO manager;
GRANT EXECUTE ON [dbo].[usp_DeleteCourseSemester] TO manager;
GRANT EXECUTE ON [dbo].[usp_DeleteCourse] TO manager;
GRANT EXECUTE ON [dbo].[usp_DeleteCluster] TO manager;
GRANT EXECUTE ON [dbo].[usp_AlterPaymentByCourseStudentID] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllCluster] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllCourse] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllDelivery] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllGender] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllLocation] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllNotOfferedCourse] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllOutcome] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllPayment] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllSemester] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllStudent] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllStudentsEnrolledIntoCourse] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllStudentsNotEnrolledIntoCourse] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllTeacher] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllTeacherNotTeachingCourse] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllTeacherTeachingCourse] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllTimetables] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectAllUnit] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectEnrolmentById] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectTeacherHistoryByID] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectUnallocatedUnits] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectUnenrolledStudents] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectUnitsThatBelongToCourse] TO manager;
GRANT EXECUTE ON [dbo].[usp_SelectUnitsThatDontBelongToCourse] TO manager;
GRANT EXECUTE ON [dbo].[usp_StudentResultByID] TO manager;

end