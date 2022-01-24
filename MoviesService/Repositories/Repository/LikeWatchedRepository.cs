using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MoviesService.Context;
using MoviesService.Models;

namespace MoviesService.Repositories.Repository
{
    public class LikeWatchedRepository
    {
        private readonly MediaDbContext _context;
        public LikeWatchedRepository(MediaDbContext context) => _context = context;
        public IEnumerable<UsersToMedia> Entities => _context.UsersToMediaTable;
        public Media Like(int mediaId, int usersAmount, string userId)
        {
            var userToMedia = _context.UsersToMediaTable.Where((x) => x.MediaId == mediaId).FirstOrDefault(x => x.ApplicationUserId == userId);

            if (userToMedia is null && userId != null)
            {
                Watch(userId,mediaId);
                ++usersAmount;
                userToMedia = _context.UsersToMediaTable.Where((x) => x.MediaId == mediaId).FirstOrDefault(x => x.ApplicationUserId == userId);
            }

            var media = _context.MediaTable.FirstOrDefault(x => x.Id == mediaId);

            userToMedia.Liked = !userToMedia.Liked;

            if (userToMedia.Liked)
                ++media.AmountOfLikes;
            else
                --media.AmountOfLikes;

            if (media.AmountOfLikes != 0)
            {
                media.SiteUsersRatings = 10.0 - (Convert.ToDouble(media.AmountOfLikes) / Convert.ToDouble(usersAmount)) < 0 ? 0 : Math.Round(10.0 - (Convert.ToDouble(media.AmountOfLikes) / Convert.ToDouble(usersAmount)),1);
            }
            else
            {
                media.SiteUsersRatings = 0;
            }

            _context.SaveChanges();

            return media;
        }

        public void Watch(string userId, int mediaId)
        {
            var check = _context.UsersToMediaTable.Where(x => x.MediaId == mediaId).FirstOrDefault(x => x.ApplicationUserId == userId);

            if (check != null)
            {
                check.Date = DateTime.Now; 
                _context.SaveChanges();
                return;
            }

            var media = _context.MediaTable.FirstOrDefault(x => x.Id == mediaId);

            media.AmountOfLikes ??= 0;

            var userToMedia = new UsersToMedia
            {
                ApplicationUserId = userId,
                Liked = false,
                Watched = true,
                AddToWatch = false,
                Date = DateTime.Now,
                MediaId = mediaId
            };

            _context.UsersToMediaTable.AddOrUpdate(userToMedia);

            _context.SaveChanges();
        }

        public void AddMyList(string userId, int mediaId)
        {
            var userToMedia = _context.UsersToMediaTable.Where(x => x.MediaId == mediaId).FirstOrDefault(x => x.ApplicationUserId == userId);

            if (userToMedia is null && userId != null)
            {
                Watch(userId, mediaId);
                userToMedia = _context.UsersToMediaTable.Where((x) => x.MediaId == mediaId).FirstOrDefault(x => x.ApplicationUserId == userId);
            }

            if (userToMedia.AddToWatch)
                return;

            userToMedia.AddToWatch = true;

            _context.SaveChanges();
        }

        public void DeleteFromMyList(string userId, int mediaId)
        {
            var userToMedia = _context.UsersToMediaTable.Where(x => x.MediaId == mediaId).FirstOrDefault(x => x.ApplicationUserId == userId);

            userToMedia.AddToWatch = false;

            _context.SaveChanges();
        }
    }
}
