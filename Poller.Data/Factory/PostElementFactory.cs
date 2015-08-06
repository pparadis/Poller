using System;

namespace Poller.Data.Factory
{
    using Presentation.Models;

    public static class PostElementFactory
    {
        public static PostElement Content(string content, string currentUser)
        {
            return new PostElement
            {
                Content = content,
                Id = Guid.NewGuid(),
                Type = Constants.PostElementTypes.Content,
                User = currentUser,
                CreatedOn = DateTime.Now
            };
        }

        public static PostElement Image(string content, string currentUser)
        {
            return new PostElement
            {
                Content = content,
                Id = Guid.NewGuid(),
                Type = Constants.PostElementTypes.Image,
                User = currentUser,
                CreatedOn = DateTime.Now
            };
        }

        public static PostElement Link(string link, string currentUser)
        {
            return new PostElement
            {
                Content = link,
                Id = Guid.NewGuid(),
                Type = Constants.PostElementTypes.Link,
                User = currentUser,
                CreatedOn = DateTime.Now
            };
        }
    }
}
