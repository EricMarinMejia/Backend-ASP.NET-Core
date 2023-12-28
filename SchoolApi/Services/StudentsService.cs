using SchoolApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SchoolApi.Services;

public class StudentsService
{
    private readonly IMongoCollection<Student> _studentsCollection;

    public StudentsService(IOptions<SchoolDatabaseSettings> schoolDatabaseSettings)
    {
        var mongoClient = new MongoClient(schoolDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(schoolDatabaseSettings.Value.DatabaseName);

        _studentsCollection = mongoDatabase.GetCollection<Student>(schoolDatabaseSettings.Value.StudentsCollectionName);
    }

    public async Task<List<Student>> GetAsync() =>
        await _studentsCollection.Find(_ => true).ToListAsync();

    public async Task<Student?> GetAsync(string code) =>
        await _studentsCollection.Find(x => x.Code == code).FirstOrDefaultAsync();

    public async Task CreateAsync(Student newStudent) =>
        await _studentsCollection.InsertOneAsync(newStudent);

    public async Task UpdateAsync(string code, Student updatedStudent) =>
        await _studentsCollection.ReplaceOneAsync(x => x.Code == code, updatedStudent);

    public async Task DeleteAsync(string code) =>
        await _studentsCollection.DeleteOneAsync(x => x.Code == code);


}
