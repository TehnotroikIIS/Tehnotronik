﻿using MongoDB.Driver;

namespace Tehnotronik.MongoDB.Factories
{
    public class DatabaseFactory : IDatabaseFactory
    {
        public IMongoDatabase Create()
        {
            var mongoClient = new MongoClient("mongodb+srv://aleksandramitro:SifrazaMongo99!@cluster0.qmuvt.mongodb.net/xml?retryWrites=true&w=majority");
            return mongoClient.GetDatabase("iis");
        }
    }
}
