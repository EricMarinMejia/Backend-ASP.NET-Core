namespace SchoolApi.Models;

public class SchoolDatabaseSettings
{

    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
    public string StudentsCollectionName { get; set; } = null!;
    public string TeachersCollectionName { get; set; } = null!;
    public string ClassesCollectionName { get; set; } = null!;

}
