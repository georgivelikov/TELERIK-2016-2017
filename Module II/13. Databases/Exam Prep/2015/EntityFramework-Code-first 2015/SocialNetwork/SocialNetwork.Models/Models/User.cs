using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models.Models
{
    public class User
    {
        private ICollection<Image> images;

        private ICollection<Message> messages;

        private ICollection<Post> posts;

        public User()
        {
            this.images = new HashSet<Image>();
            this.messages = new HashSet<Message>();
            this.posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(20), MinLength(4)]
        [Required]
        public string Username { get; set; }

        [MaxLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [MaxLength(50), MinLength(2)]
        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }

            set
            {
                this.images = value;
            }
        }

        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }

            set
            {
                this.posts = value;
            }
        }

        public virtual ICollection<Message> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }
    }
}
