namespace APIs.Day2.CleanCrud.BL;

public class DoctorReadDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Specialization { get; set; } = "";
    public int PerformanceRate { get; set; }
}
