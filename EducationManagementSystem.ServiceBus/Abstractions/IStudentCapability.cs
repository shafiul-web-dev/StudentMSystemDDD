namespace EducationManagementSystem.ServiceBus.Abstractions
{
    public interface IStudentCapability
    {
        Task<bool> ExistsAsync(int studentId);
    }
}