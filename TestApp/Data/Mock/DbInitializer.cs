using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestApp.Controllers;
using TestApp.Models;

namespace TestApp.Data.Mock
{
    public static class DbInitializer
    {
        public static void Initialize(StorageContext context)
        {
            if(!context.Database.IsInMemory())
                context.Database.Migrate();

            if (!context.Users.Any())
            {
                InitUsers(context);
                InitAlbums(context);
                context.SaveChanges();
            }
        }

        private static void InitUsers(StorageContext context)
        {
            string downloadingJson;
            using (WebClient client = new WebClient())
            {
                downloadingJson = client.DownloadString(InitialConsts.ExternalApiAddress + InitialConsts.UserLink);
            }

            List<User> users = JsonConvert.DeserializeObject<List<User>>(downloadingJson);
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static void InitAlbums(StorageContext context)
        {
            string downloadingJson;
            using (WebClient client = new WebClient())
            {
                downloadingJson = client.DownloadString(InitialConsts.ExternalApiAddress + InitialConsts.AlbumLink);
            }

            List<Album> users = JsonConvert.DeserializeObject<List<Album>>(downloadingJson);
            context.Albums.AddRange(users);
            context.SaveChanges();
        }
    }
}
