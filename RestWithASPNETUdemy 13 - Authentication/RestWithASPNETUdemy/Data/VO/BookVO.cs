using Tapioca.HATEOAS;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RestWithASPNETUdemy.Data.VO
{
    //LAE - o DataContract faz com que não apareça o links o resultado
    //[DataContract]
    public class BookVO : ISupportsHyperMedia
    {
        //[DataMember (Order =1, Name = "Código")]
        public long? Id { get; set; }
        //[DataMember(Order = 2, Name = "Título")]
        public string Title { get; set; }
        //[DataMember(Order = 3, Name = "Autor")]
        public string Author { get; set; }
        //[DataMember(Order = 5, Name = "Preço")]
        public decimal Price { get; set; }
        //[DataMember(Order = 4, Name = "Data de lançamento")]
        public DateTime LaunchDate { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
