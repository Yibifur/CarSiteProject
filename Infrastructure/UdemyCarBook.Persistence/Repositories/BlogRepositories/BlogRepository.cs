﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository:IBlogRepository
    {
        private readonly CarBookContext _carBookContext;

        public BlogRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public List<Blog> GetAllBlogsWithAuthor()
        {
            return _carBookContext.Blogs.Include(x => x.Author).Include(x=>x.Category).ToList();
        }

        List<Blog> IBlogRepository.GetLast3BlogsWithAuthorAsync()
        {
            return  _carBookContext.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToList();
        }
    }
}
