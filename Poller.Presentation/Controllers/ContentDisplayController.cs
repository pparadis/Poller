namespace Poller.Presentation.Controllers
{
    using Data.Factory;
    using Data.Repository;
    using Hub;
    using Microsoft.AspNet.SignalR;
    using Newtonsoft.Json;
    using System;
    using System.Web.Mvc;
    using Data;

    public class ContentDisplayController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult PushContentToLeftBar(string content)
        {
            var currentUser = User.Identity.Name;
            var postElement = PostElementFactory.Content(content, currentUser);

            var repo = new PostElementRepository();
            repo.InsertDailyPost(postElement);

            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();


            context
                .Clients
                .All
                .pushMessageToLeftBar(JsonConvert.SerializeObject(postElement));

            return RedirectToAction("Index", "SecretGate");
        }

        [ValidateInput(false)]
        public ActionResult PushContentToRightBar(string content)
        {
            var currentUser = User.Identity.Name;
            var postElement = PostElementFactory.Content(content, currentUser);

            var repo = new PostElementRepository();
            repo.InsertTechnologyRadarPost(postElement);

            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context
                .Clients
                .All
                .pushMessageToRightBar(JsonConvert.SerializeObject(postElement));

            return RedirectToAction("Index", "SecretGate");
        }

        [HttpPost]
        public ActionResult PushImageToLeftBar(string imagePath)
        {
            var currentUser = User.Identity.Name;
            var postElement = PostElementFactory.Image(imagePath, currentUser);

            var repo = new PostElementRepository();
            repo.InsertDailyPost(postElement);

            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context
                .Clients
                .All
                .pushImageToLeftBar(JsonConvert.SerializeObject(postElement));

            return RedirectToAction("Index", "SecretGate");
        }

        [HttpPost]
        public ActionResult PushImageToRightBar(string imagePath)
        {
            var currentUser = User.Identity.Name;
            var postElement = PostElementFactory.Image(imagePath, currentUser);

            var repo = new PostElementRepository();
            repo.InsertTechnologyRadarPost(postElement);

            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context
                .Clients
                .All
                .pushImageToRightBar(JsonConvert.SerializeObject(postElement));

            return RedirectToAction("Index", "SecretGate");
        }

        [HttpPost]
        public ActionResult PushLinkToLeftBar(string link)
        {
            var currentUser = User.Identity.Name;
            var postElement = PostElementFactory.Link(link, currentUser);

            var repo = new PostElementRepository();
            repo.InsertDailyPost(postElement);

            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context
                .Clients
                .All
                .pushLinkToLeftBar(JsonConvert.SerializeObject(postElement));

            return RedirectToAction("Index", "SecretGate");
        }

        [HttpPost]
        public ActionResult PushLinkToRightBar(string link)
        {
            var currentUser = User.Identity.Name;
            var postElement = PostElementFactory.Link(link, currentUser);

            var repo = new PostElementRepository();
            repo.InsertTechnologyRadarPost(postElement);

            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context
                .Clients
                .All
                .pushLinkToRightBar(JsonConvert.SerializeObject(postElement));

            return RedirectToAction("Index", "SecretGate");
        }

        [HttpPost]
        public ActionResult PushVideo(string videoPath)
        {
            var currentUser = User.Identity.Name;

            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context
                .Clients.All
                .pushVideoToLeftBar(currentUser, DateTime.Now, videoPath);

            return RedirectToAction("Index", "SecretGate");
        }

        [HttpPost]
        public ActionResult ClearDailyContent()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();

            var repo = new PostElementRepository();
            repo.DeleteAllDailyPosts();

            context
                .Clients
                .All
                .clearDailyContent();

            return RedirectToAction("Index", "SecretGate");
        }

        [HttpPost]
        public ActionResult ReloadClient()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            context.Clients.All.reloadClient();

            return RedirectToAction("Index", "SecretGate");
        }

        [HttpPost]
        public ActionResult ReloadContentColumns()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            var repo = new PostElementRepository();
            var dailyPostElements = repo.GetAllDailyPostElements();

            foreach (var postElement in dailyPostElements)
            {
                switch (postElement.Type)
                {
                    case Constants.PostElementTypes.Content:
                        UserGroup(context).pushMessageToLeftBar(JsonConvert.SerializeObject(postElement));
                        break;

                    case Constants.PostElementTypes.Image:
                        UserGroup(context).pushImageToLeftBar(JsonConvert.SerializeObject(postElement));
                        break;

                    case Constants.PostElementTypes.Link:
                        UserGroup(context).pushLinkToLeftBar(JsonConvert.SerializeObject(postElement));
                        break;
                }
            }

            var technologyRadarElements = repo.GetAllTechnologyRadarPostElements();
            foreach (var postElement in technologyRadarElements)
            {
                switch (postElement.Type)
                {
                    case Constants.PostElementTypes.Content:
                        UserGroup(context).pushMessageToRightBar(JsonConvert.SerializeObject(postElement));
                        break;

                    case Constants.PostElementTypes.Image:
                        UserGroup(context).pushImageToRightBar(JsonConvert.SerializeObject(postElement));
                        break;

                    case Constants.PostElementTypes.Link:
                        UserGroup(context).pushLinkToRightBar(JsonConvert.SerializeObject(postElement));
                        break;
                }
            }


            return new EmptyResult();
        }


        private dynamic UserGroup()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            return context
                .Clients
                .Group(HttpContext.User.Identity.Name);
        }

        private dynamic UserGroup(IHubContext context)
        {
            return context
                .Clients
                .Group(HttpContext.User.Identity.Name);
        }
    }
}