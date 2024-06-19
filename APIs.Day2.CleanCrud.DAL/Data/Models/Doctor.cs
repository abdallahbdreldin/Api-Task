namespace APIs.Day2.CleanCrud.DAL;

public class Doctor
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialization { get; set; } = "";
    public decimal Salary { get; set; }
    public int PerformanceRate { get; set; }

    public ICollection<Patient> Patients { get; set; }
        = new HashSet<Patient>();
}
