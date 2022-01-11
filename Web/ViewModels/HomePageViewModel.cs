using System.Collections.Generic;
using System.Linq;
using MoviesService.Models;

namespace Web.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<int> MyList { get; set; }
        public IEnumerable<Media> AllMedia { get; set;}

        public HomePageViewModel(IEnumerable<UsersToMedia> myList, IEnumerable<Media> allMedia, string userId)
        {
            MyList = myList.Where(x => x.AddToWatch == true).Where(x => x.ApplicationUserId == userId).Select(x => x.MediaId);
            AllMedia = allMedia;
        }
    }
}