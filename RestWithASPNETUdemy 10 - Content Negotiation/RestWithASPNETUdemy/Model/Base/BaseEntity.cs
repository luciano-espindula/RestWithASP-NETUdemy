using System.Runtime.Serialization;

namespace RestWithASPNETUdemy.Model.Base
{
    //LAE - precisaria definir para todos os atributos
    //[DataContract]
    public class BaseEntity
    {
        public long? Id { get; set; }
    }
}
