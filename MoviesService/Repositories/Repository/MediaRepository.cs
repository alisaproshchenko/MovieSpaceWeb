﻿using MoviesService.Models;
using MoviesService.Repositories.IRepository;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using MoviesService.Context;

namespace MoviesService.Repositories.Repository
{
    public class MediaRepository : IMediaRepository<Media>
    {
        private readonly MediaDbContext _context;
        public MediaRepository(MediaDbContext context) => _context = context;
        public IEnumerable<Media> Items => _context.MediaTable;

        public Media GetItem(int id)
        {
            var media =  _context.MediaTable.FirstOrDefault(i => i.Id == id);
            return media;
        }

        public void AddItem(Media media)
        {
            _context.MediaTable.AddOrUpdate(media);
            _context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var media = _context.MediaTable.FirstOrDefault(t => t.Id == id);
            if (media != null) _context.MediaTable.Remove(media);
            _context.SaveChanges();
        }

        public void EditItem(Media media)
        {
            _context.MediaTable.AddOrUpdate(media);
            _context.SaveChanges();
        }
    }
}
