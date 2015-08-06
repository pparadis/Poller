using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poller.Data.Repository
{
    using Presentation.Models;
    using ServiceStack.Redis;

    public class PostElementRepository
    {
        public void InsertDailyPost(PostElement postElement)
        {
            using (var redisClient = new RedisClient("mtl-ba584:6379"))
            {
                var redis = redisClient.As<PostElement>();
                var currentPosts = redis.Lists["dailyposts"];

                currentPosts.Add(postElement);

            }
        }

        public void InsertTechnologyRadarPost(PostElement postElement)
        {
            using (var redisClient = new RedisClient("mtl-ba584:6379"))
            {
                var redis = redisClient.As<PostElement>();
                var currentPosts = redis.Lists["technologyradar"];

                currentPosts.Add(postElement);

            }
        }

        public IEnumerable<PostElement> GetAllDailyPostElements()
        {
            using (var redisClient = new RedisClient("mtl-ba584:6379"))
            {
                var redis = redisClient.As<PostElement>();
                var currentPosts = redis.Lists["dailyposts"];

                return currentPosts.ToList();

            }
        }

        public IEnumerable<PostElement> GetAllTechnologyRadarPostElements()
        {
            using (var redisClient = new RedisClient("mtl-ba584:6379"))
            {
                var redis = redisClient.As<PostElement>();
                var currentPosts = redis.Lists["technologyradar"];

                return currentPosts.ToList();

            }
        }

        public void DeleteAllDailyPosts()
        {
            using (var redisClient = new RedisClient("mtl-ba584:6379"))
            {
                var redis = redisClient.As<PostElement>();
                redis.Lists["dailyposts"].RemoveAll();
            }
        }

        public void DeleteAllTechnologyRadarPosts()
        {
            using (var redisClient = new RedisClient("mtl-ba584:6379"))
            {
                var redis = redisClient.As<PostElement>();
                redis.Lists["technologyradar"].RemoveAll();
            }
        }
    }
}
