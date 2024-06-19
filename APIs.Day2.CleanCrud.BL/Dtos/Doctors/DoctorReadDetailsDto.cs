namespace APIs.Day2.CleanCrud.BL;

public class DoctorReadDetailsDto
{
    public required int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required string Specialization { get; set; } = "";
    public required int PerformanceRate { get; set; }
    public required List<PatientChildDto> Patients { get; set; } = new();
}

public class PatientChildDto
{
    public required int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required List<IssueChildDto> Issues { get; set; } = new();
}

public class IssueChildDto
{
    public required int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
}