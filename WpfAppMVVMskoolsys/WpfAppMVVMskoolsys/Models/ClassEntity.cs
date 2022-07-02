using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace WpfAppMVVMskoolsys.Models
{
    class ClassEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ClassName { get; set; }
        public string Grade { get; set; }
        public string RootTeacher { get; set; }
        public Dictionary<string, string> Students { get; set; }
    }
}
