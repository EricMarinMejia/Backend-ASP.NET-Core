using SchoolApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SchoolApi.Services;

public class TeachersService
{
    private readonly IMongoCollection<Teacher> _teachersCollection;

    public TeachersService(IOptions<SchoolDatabaseSettings> schoolDatabaseSettings)
    {
        var mongoClient = new MongoClient(schoolDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(schoolDatabaseSettings.Value.DatabaseName);

        _teachersCollection = mongoDatabase.GetCollection<Teacher>(schoolDatabaseSettings.Value.TeachersCollectionName);
    }


    public async Task<List<Teacher>> GetAsync() =>
        await _teachersCollection.Find(_ => true).ToListAsync();

    public async Task<Teacher?> GetAsync(string code) =>
        await _teachersCollection.Find(x => x.Code == code).FirstOrDefaultAsync();

    public async Task CreateAsync(Teacher newTeacher) =>
        await _teachersCollection.InsertOneAsync(newTeacher);

    public async Task UpdateAsync(string code, Teacher updatedTeacher) =>
        await _teachersCollection.ReplaceOneAsync(x => x.Code == code, updatedTeacher);

    public async Task RemoveAsync(string code) =>
        await _teachersCollection.DeleteOneAsync(x => x.Code == code);

}

