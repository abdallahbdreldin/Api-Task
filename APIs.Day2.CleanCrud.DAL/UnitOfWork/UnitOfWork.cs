namespace APIs.Day2.CleanCrud.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly HospitalContext _context;

    public IDoctorsRepo DoctorsRepo { get; }
    public IIssuesRepo IssuesRepo { get; }
    public IPatientsRepo PatientsRepo { get; }

    public UnitOfWork(HospitalContext context,
        IDoctorsRepo doctorsRepo,
        IIssuesRepo issuesRepo,
        IPatientsRepo patientsRepo)
    {
        _context = context;
        DoctorsRepo = doctorsRepo;
        IssuesRepo = issuesRepo;
        PatientsRepo = patientsRepo;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}