using SchoolApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace SchoolApi.Services;

public class ClassesService
{
    private readonly IMongoCollection<Class> _classesCollection;

    public ClassesService(IOptions<SchoolDatabaseSettings> schoolDatabaseSettings)
    {
        var mongoClient = new MongoClient(schoolDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(schoolDatabaseSettings.Value.DatabaseName);

        _classesCollection = mongoDatabase.GetCollection<Class>(schoolDatabaseSettings.Value.ClassesCollectionName);
    }

    public async Task<List<Class>> GetAsync() =>
        await _classesCollection.Find(_ => true).ToListAsync();

    public async Task<Class?> GetAsync(string code) =>
        await _classesCollection.Find(x => x.Code == code).FirstOrDefaultAsync();

    public async Task CreateAsync(Class @class) =>
        await _classesCollection.InsertOneAsync(@class);

    public async Task UpdateAsync(string code, Class updatedClass) =>
        await _classesCollection.ReplaceOneAsync(x => x.Code == code, updatedClass);

    public async Task DeleteAsync(string code) =>
        await _classesCollection.DeleteOneAsync(x => x.Code == code);
}
