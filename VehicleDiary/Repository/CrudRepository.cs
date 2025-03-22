﻿using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VehicleDiary.Data;
using VehicleDiary.Interfaces;
using VehicleDiary.Models;

namespace VehicleDiary.Repository
{
    public class CrudRepository<T> : IRepositoryCrud<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CrudRepository(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context= context;
            _userManager= userManager;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Set<T>().FindAsync(id);
            if (user != null)
            { 
                _context.Set<T>().Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new KeyNotFoundException();
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var user = await _context.Set<T>().FindAsync(id);
            if (user != null)
            {
                return user;
            }
            throw new KeyNotFoundException();
        }

        public async Task<IEnumerable<T>> GetDBByIDForUserAsync(ClaimsPrincipal user)
        {
            var userId = _userManager.GetUserId(user);
            if (userId != null)
            {
                return await _context.Set<T>().Where(c => EF.Property<string>(c, "UserId") == userId).ToListAsync();
            }
            throw new KeyNotFoundException();
        }

		public async Task<int> SaveChangesAsync()
		{
            return  await _context.SaveChangesAsync() ;
		}

		public async Task UpdateAsync(T entity)
        {
            try
            { 
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            }
            catch
            {
                throw new KeyNotFoundException();
            }
        }
        
    }
}
