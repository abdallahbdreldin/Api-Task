using Microsoft.EntityFrameworkCore;

namespace APIs.Day2.CleanCrud.DAL;

public class DoctorsRepo : GenericRepo<Doctor>, IDoctorsRepo
{
    private readonly HospitalContext _context;

    public DoctorsRepo(HospitalContext context) : base(context)
    {
        _context = context;
    }

    public Doctor? GetDetailsById(int id)
    {
        return _context.Set<Doctor>()
            .Include(d => d.Patients)
                .ThenInclude(p => p.Issues)
            .FirstOrDefault(x => x.Id == id);
    }

    public List<Doctor> GetAllByPerformance(int rate)
    {
        return _context.Set<Doctor>()
            .Where(d => d.PerformanceRate >= rate)
            .ToList();
    }
}
