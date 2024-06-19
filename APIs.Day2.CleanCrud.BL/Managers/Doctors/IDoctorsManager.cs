namespace APIs.Day2.CleanCrud.BL;

public interface IDoctorsManager
{
    List<DoctorReadDto> GetAllForCustomers();
    void Add(DoctorAddDto doctor);
    bool Update(DoctorUpdateDto doctor);
    DoctorReadDetailsDto? GetDetailsById(int id);
}