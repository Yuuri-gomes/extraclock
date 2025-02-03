using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class OvertimeRepository {
  private readonly IMongoCollection<Overtime> _overtimeCollection;

  public OvertimeRepository(IConfiguration configuration) {
    var settings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
    var client = new MongoClient(settings?.ConnectionString);
    var database = client.GetDatabase(settings?.DatabaseName);

    _overtimeCollection = database.GetCollection<Overtime>("overtime");
  }

  public async Task RegisterOvertime(Overtime overtime) {
    await _overtimeCollection.InsertOneAsync(overtime);
  }

  public async Task<List<Overtime>> Overtime(string user) {
    return await _overtimeCollection.Find(overtime => overtime.User == user).ToListAsync();
  }
}