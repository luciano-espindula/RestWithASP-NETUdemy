using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("Users")]
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
