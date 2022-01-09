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

            if (userToMedia != null)
            {
        
            }
            else
            {

            }

            userToMedia = new UsersToMedia
            {
                ApplicationUserId = userId,
                Media = _context.MediaTable.FirstOrDefault(x => x.Id == mediaId)
            };

            userToMedia.Liked = !userToMedia.Liked;
            
            var media = _context.MediaTable.FirstOrDefault(x => x.Id == mediaId);
            
            media.SiteUsersRatings ??= 0;

            if(userToMedia.Liked)
                ++media.SiteUsersRatings;
            else
                --media.SiteUsersRatings;
            
            _context.UsersToMediaTable.AddOrUpdate(userToMedia);
            
            _context.SaveChanges();
        }
    }
}
