using System;
using System.Collections.Generic;
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

    public class BlogDashboard
    {
        public List<Blog> blog { get; set; }
        public List<User> user { get; set; }
        public List<Roles> roles { get; set; }

        public BlogDashboard()

        {
            blog = new List<Blog>();
            user = new List<User>();
            roles = new List<Roles>();
        }
    }
}