using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace SchoolApi.Models;

public class Class
{

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Code")]
    public string Code { get; set; }

    [BsonElement("Title")]
    public string Title { get; set; }

    [BsonElement("Description")]
    public string Description { get; set; }

    [BsonElement("Creator")]
    public Teacher Creator { get; set; }

    [BsonElement("Students")]
    public List<Student> Students { get; set; }
}
