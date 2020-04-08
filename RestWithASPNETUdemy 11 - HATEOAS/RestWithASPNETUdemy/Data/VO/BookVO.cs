using RestWithASPNETUdemy.Model.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RestWithASPNETUdemy.Data.VO
{
    [DataContract]
    public class BookVO
    {
        [DataMember (Order =1, Name = "Código")]
        public long? Id { get; set; }
        [DataMember(Order = 2, Name = "Título")]
        public string Title { get; set; }
        [DataMember(Order = 3, Name = "Autor")]
        public string Author { get; set; }
        [DataMember(Order = 5, Name = "Preço")]
        public decimal Price { get; set; }
        [DataMember(Order = 4, Name = "Data de lançamento")]
        public DateTime LaunchDate { get; set; }
    }
}
