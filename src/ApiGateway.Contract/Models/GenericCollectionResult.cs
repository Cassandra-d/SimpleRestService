using System.Runtime.Serialization;

namespace ApiGateway.Contract.Models
{
    [DataContract]
    public class GenericCollectionResult<T> where T : class
    {
        [DataMember(Name = "data")]
        public T[] Data { get; set; }
    }
}
