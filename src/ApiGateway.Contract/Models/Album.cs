using System.Runtime.Serialization;

namespace ApiGateway.Contract.Models
{
    [DataContract]
    public class Album
    {
        [DataMember(Name = "id")]
        public int Id { get; internal set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "year")]
        public int Year { get; set; }

        [DataMember(Name = "cover")]
        public string CoverUrl { get; set; }
    }
}
