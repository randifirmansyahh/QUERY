using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QUERY.Models
{
    public class Blog
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; }

        [DisplayName("Author")]
        public User User { get; set; }
    }
}