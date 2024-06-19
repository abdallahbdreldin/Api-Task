using Microsoft.EntityFrameworkCore;

namespace APIs.Day2.CleanCrud.DAL;

public class PatientsRepo : GenericRepo<Patient>, IPatientsRepo
{
    private readonly HospitalContext _context;

    public PatientsRepo(HospitalContext context) : base(context)
    {
        _context = context;
    }

    public int GetIssueCountForPatient(int id)
    {
        return _context.Patients
            .Include(p => p.Issues) 
            .First(p => p.Id == id)
            .Issues
            .Count();
    }
}
