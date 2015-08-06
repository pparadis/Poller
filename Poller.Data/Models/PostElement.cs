using System;

namespace Poller.Presentation.Models
{
    public class PostElement
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }

        public string User { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FormattedCreatedOn
        {
            get { return CreatedOn.ToString("yyyy/MM/dd HH:mm:ss"); }
        }
    }
}