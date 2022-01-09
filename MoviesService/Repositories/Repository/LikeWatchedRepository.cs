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
        public void Like(string userId, int mediaId)
        {
            var userToMedia = _context.UsersToMediaTable.FirstOrDefault(x => x.ApplicationUserId == userId);
            var media = _context.MediaTable.FirstOrDefault(x => x.Id == mediaId);
            if (userToMedia == null)
            {
                userToMedia = new UsersToMedia();
                userToMedia.ApplicationUserId = userId;
                userToMedia.Liked = true;
                userToMedia.Media = _context.MediaTable.FirstOrDefault(x => x.Id == mediaId);

                media.SiteUsersRatings ??= 0;

                ++media.SiteUsersRatings;
            }
            else
            {
                userToMedia = _context.UsersToMediaTable.FirstOrDefault(x => x.Media.Id == mediaId);
                if (userToMedia != null)
                {
                    userToMedia.Liked = !userToMedia.Liked;

                    if (userToMedia.Liked)
                        ++media.SiteUsersRatings;
                    else
                        --media.SiteUsersRatings;
                }
                else
                {
                    userToMedia = new UsersToMedia();
                    userToMedia.ApplicationUserId = userId;
                    userToMedia.Liked = true;
                    userToMedia.Media = _context.MediaTable.FirstOrDefault(x => x.Id == mediaId);

                    media.SiteUsersRatings ??= 0;

                    ++media.SiteUsersRatings;
                }
            }
            _context.UsersToMediaTable.AddOrUpdate(userToMedia);
            
            _context.SaveChanges();

   
        }
    }
}
