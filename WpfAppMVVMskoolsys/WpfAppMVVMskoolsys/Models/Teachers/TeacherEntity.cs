using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WpfAppMVVMskoolsys.Models.Teachers
{
    class TeacherEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string Birthday { get; set; }
        public string PhoneNumber { get; set; }
        public string Degree { get; set; }
        public int? Salary { get; set; }
    }
}
