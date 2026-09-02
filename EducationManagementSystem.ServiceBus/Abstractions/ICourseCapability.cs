namespace EducationManagementSystem.ServiceBus.Abstractions
{
    public interface ICourseCapability
    {
        Task<bool> ExistsAsync(int courseId);

        Task EnrollStudentAsync(int studentId, int courseId);
    }
}