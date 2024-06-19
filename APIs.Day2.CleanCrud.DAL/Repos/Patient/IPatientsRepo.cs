namespace APIs.Day2.CleanCrud.DAL;

public interface IPatientsRepo : IGenericRepo<Patient>
{
    int GetIssueCountForPatient(int id);
}
