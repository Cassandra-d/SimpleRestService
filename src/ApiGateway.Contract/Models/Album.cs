using System.Runtime.Serialization;

namespace ApiGateway.Contract.Models
{
    [DataContract]
    public class Album
    {
        [DataMember(Name = "id")]
        public int Id { get; internal set; }

        [DataMember(Name = "name")]
        public string Title { get; set; }
    }
}
