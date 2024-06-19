using APIs.Day2.CleanCrud.DAL;

namespace APIs.Day2.CleanCrud.BL;

public class DoctorsManager : IDoctorsManager
{
    private readonly IUnitOfWork _unitOfWork;

    public DoctorsManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Add(DoctorAddDto doctor)
    {
        Doctor dbDoctor = new Doctor
        {
            Name = doctor.Name,
            Salary = doctor.Salary,
            Specialization = doctor.Specialization
        };
        _unitOfWork.DoctorsRepo.Add(dbDoctor);
        _unitOfWork.SaveChanges();
    }

    public DoctorReadDetailsDto? GetDetailsById(int id)
    {
        Doctor? dbDoctorWithDetails = _unitOfWork.DoctorsRepo.GetDetailsById(id);
        if (dbDoctorWithDetails is null)
            return null;

        return new DoctorReadDetailsDto
        {
            Id = dbDoctorWithDetails.Id,
            Name = dbDoctorWithDetails.Name,
            Specialization = dbDoctorWithDetails.Specialization,
            PerformanceRate = dbDoctorWithDetails.PerformanceRate,

            //Convert List Of Patient to List of PatientChildDto
            Patients = dbDoctorWithDetails.Patients
                .Select(p => new PatientChildDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    // Convert List of issues into list of IssueChildDto
                    Issues = p.Issues
                        .Select(i => new IssueChildDto
                        {
                            Id = i.Id,
                            Name = i.Name,
                        }).ToList()
                }).ToList()
        };
    }

    public List<DoctorReadDto> GetAllForCustomers()
    {
        List<Doctor> dbDoctors = _unitOfWork.DoctorsRepo.GetAll();

        return dbDoctors.Select(d => new DoctorReadDto
        {
            Id = d.Id,
            Name = d.Name,
            Specialization = d.Specialization,
            PerformanceRate = d.PerformanceRate,
        }).ToList();
    }

    public bool Update(DoctorUpdateDto doctorDto)
    {
        Doctor? dbDoctor = _unitOfWork.DoctorsRepo.GetById(doctorDto.Id);
        if (dbDoctor == null)
        {
            return false;
        }

        dbDoctor.Name = doctorDto.Name;
        dbDoctor.Specialization = doctorDto.Specialization;
        dbDoctor.Salary = doctorDto.Salary;

        _unitOfWork.DoctorsRepo.Update(dbDoctor);
        _unitOfWork.SaveChanges();

        return true;
    }
}
