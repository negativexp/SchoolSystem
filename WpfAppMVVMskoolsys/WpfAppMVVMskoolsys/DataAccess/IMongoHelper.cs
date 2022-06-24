﻿using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace WpfAppMVVMskoolsys.DataAccess
{
    public class MongoHelper
    {
        private IMongoDatabase db;

        public MongoHelper(string connectionString, string databaseName)
        {
            //Create new database connection
            var client = new MongoClient(connectionString);
            db = client.GetDatabase(databaseName);
        }

        public void InsertDocument<T>(string collectionName, T document)
        {
            var collection = db.GetCollection<T>(collectionName);
            collection.InsertOne(document);
        }

        public List<T> LoadAllDocuments<T>(string collectionName)
        {
            var collection = db.GetCollection<T>(collectionName);

            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadDocumentById<T>(string collectionName, Guid id)
        {
            var collection = db.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.Find(filter).First();
        }

        public void UpdateDocument<T>(string collectionName, Guid id, T document)
        {
            var collection = db.GetCollection<T>(collectionName);

            var result = collection.ReplaceOne(
                new BsonDocument("Id", id),
                document,
                new UpdateOptions { IsUpsert = false });
        }

        public void UpsertDocument<T>(string collectionName, Guid id, T document)
        {
            var collection = db.GetCollection<T>(collectionName);

            var result = collection.ReplaceOne(
                new BsonDocument("Id", id),
                document,
                new UpdateOptions { IsUpsert = true });
        }

        public void DeleteDocument<T>(string collectionName, ObjectId id)
        {
            var collection = db.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }
    }
}
