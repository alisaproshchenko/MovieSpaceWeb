﻿namespace MoviesService.Services.IService
{
    public interface IAddSeasonService
    {
        void Add(int mediaId);
        void AddEpisode(int seasonId);
    }
}
