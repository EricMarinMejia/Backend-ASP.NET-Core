using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SchoolApi.Models;

public class Teacher
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Code")]
    public string Code { get; set; }

    [BsonElement("FirstName")]
    public string FirstName { get; set; }

    [BsonElement("LastName")]
    public string LastName { get; set; }

    [BsonElement("Classes")]
    public List<Class> Classes { get; set; }

}
