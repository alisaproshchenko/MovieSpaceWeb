﻿using System.Data.Entity.Migrations;
using System.Linq;
using MoviesService.Context;
using MoviesService.Models;

namespace MoviesService.Repositories.Repository
{
    public class LikeWatchedRepository
    {
        private readonly MediaDbContext _context;
        public LikeWatchedRepository(MediaDbContext context) => _context = context;
        public void Like(int mediaId)
        {
            var userToMedia = _context.UsersToMediaTable.FirstOrDefault(x => x.Media.Id == mediaId);
            var media = _context.MediaTable.FirstOrDefault(x => x.Id == mediaId);

            userToMedia.Liked = !userToMedia.Liked;

            if (userToMedia.Liked)
                ++media.SiteUsersRatings;
            else
                --media.SiteUsersRatings;

            _context.UsersToMediaTable.AddOrUpdate(userToMedia);

            _context.SaveChanges();
        }

        public void Watch(string userId, int mediaId)
        {
            var check = _context.UsersToMediaTable.FirstOrDefault(x => x.Media.Id == mediaId);
            
            if (check != null)
            {
                return;
            }

            var media = _context.MediaTable.FirstOrDefault(x => x.Id == mediaId);

            media.SiteUsersRatings ??= 0;

            var userToMedia = new UsersToMedia
            {
                ApplicationUserId = userId,
                Liked = false,
                Watched = true,
                Media = _context.MediaTable.FirstOrDefault(x => x.Id == mediaId)
            };
            _context.UsersToMediaTable.AddOrUpdate(userToMedia);

            _context.SaveChanges();
        }
    }
}
