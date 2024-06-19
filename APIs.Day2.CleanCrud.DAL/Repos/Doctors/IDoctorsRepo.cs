namespace APIs.Day2.CleanCrud.DAL;

public interface IDoctorsRepo : IGenericRepo<Doctor>
{
    Doctor? GetDetailsById(int id);
    List<Doctor> GetAllByPerformance(int rate);
}