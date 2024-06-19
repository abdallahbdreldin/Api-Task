namespace APIs.Day2.CleanCrud.DAL;

public interface IUnitOfWork
{
    public IDoctorsRepo DoctorsRepo { get; }
    public IIssuesRepo IssuesRepo { get; }
    public IPatientsRepo PatientsRepo { get; }
    int SaveChanges();
}
