using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WpfAppMVVMskoolsys.Models.Students
{
    class StudentEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public string Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }
    }
}
