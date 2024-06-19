namespace APIs.Day2.CleanCrud.DAL;

public class IssuesRepo : GenericRepo<Issue>, IIssuesRepo
{
    public IssuesRepo(HospitalContext context) : base(context)
    {

    }
}
