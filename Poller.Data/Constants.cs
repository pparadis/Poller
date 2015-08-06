namespace Poller.Data
{
    using System.Collections.Generic;

    public static class Constants
    {
        public class PostElementTypes
        {
            public const string Content = "Content";
            public const string Image = "Image";
            public const string Link = "Link";
        }

        public static string RegisteredGroup = @"FrenchCoding";

        public static List<string> AllowedGroups = new List<string>
        {
            @"FrenchCoding"
        };
    }
}