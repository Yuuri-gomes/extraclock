using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
public class Overtime
{
    [BsonId]
    [BsonRepresentation(BsonType.String)] 
    public Guid Id { get; set; }
    public required string User { get; set; }
    public required DateTime InitialTime { get; set; }
    public required DateTime FinishTime { get; set; }
    public required string Description { get; set; }
    public DateTime Date { get; set; }
}