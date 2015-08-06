using System;

namespace Poller.Presentation.CustomAttributes
{
    using System.Web;
    using System.Web.Mvc;

    public class AuthorizeAccessIfUserHasRole : AuthorizeAttribute
    {
        private readonly Role role;

        public AuthorizeAccessIfUserHasRole(Role role)
        {
            this.role = role;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var userHasAccess = role != Role.Admin;

            if (userHasAccess)
                return true;

            throw new Exception("Access Denied");
        }
    }

    public enum Role
    {
        User,
        Admin,
    }
}