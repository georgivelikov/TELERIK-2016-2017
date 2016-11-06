using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models.Models
{
    public class Post
    {
        private ICollection<User> users;

        public Post()
        {
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        [MinLength(10)]
        [Required]
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public virtual ICollection<User> Users
        {
            get
            {
                return this.users;
            }

            set
            {
                this.users = value;
            }
        }
    }
}
