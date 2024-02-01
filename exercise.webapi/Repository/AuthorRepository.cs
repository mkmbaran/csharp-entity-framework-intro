﻿using exercise.webapi.Data;
using exercise.webapi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace exercise.webapi.Repository
{
    public class AuthorRepository : IAuthorRepository
    {

        DataContext _db;

        public AuthorRepository(DataContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _db.Authors.Include(a => a.Books).ToListAsync();
        }

        public async Task<Author> GetById(int id)
        {
            return await _db.Authors.Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}