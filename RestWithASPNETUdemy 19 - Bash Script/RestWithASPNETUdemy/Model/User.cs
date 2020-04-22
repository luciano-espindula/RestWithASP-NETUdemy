using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("users")]
    public class User
    {
        [Column("id")]
        public long? Id { get; set; }

        [Column("Login")]
        public string Login { get; set; }

        [Column("AccessKey")]
        public string AccessKey { get; set; }

    }
}
