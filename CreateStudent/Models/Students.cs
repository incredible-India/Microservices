
using System.Runtime.Serialization;

namespace CreateStudent.Models
{
    public class Students
    {
        public int Id { get; set; }
        [DataMember(Name = "name", EmitDefaultValue = false, Order = 1)]
        public string? Name { get; set; }
        [DataMember(Name = "email", EmitDefaultValue = false, Order = 1)]
        public string? Email { get; set; }

     
    }
}
