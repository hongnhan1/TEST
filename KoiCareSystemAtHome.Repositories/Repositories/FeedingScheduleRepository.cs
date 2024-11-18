﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiCareSystemAtHome.Repositories.Entities;
using KoiCareSystemAtHome.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace KoiCareSystemAtHome.Repositories.Repositories
{
    public class FeedingScheduleRepository : IFeedingScheduleRepository
    {
        private readonly KoiCareSystemAtHomeContext _DbContext;
        public FeedingScheduleRepository(KoiCareSystemAtHomeContext dbcontext)
        {
            _DbContext = dbcontext;
        }

        public bool AddFeedingSchedule(FeedingSchedule FeedingSchedule)
        {
            try
            {
                _DbContext.FeedingSchedules.Add(FeedingSchedule);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DelFeedingSchedule(Guid Id)
        {
            try
            {
                var objDel = _DbContext.FeedingSchedules.Where(p => p.FeedingScheduleId.Equals(Id)).FirstOrDefault();
                if (objDel != null)
                {
                    _DbContext.FeedingSchedules.Remove(objDel);
                    _DbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool DelFeedingSchedule(FeedingSchedule FeedingSchedule)
        {
            try
            {
                _DbContext.Remove(FeedingSchedule);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<FeedingSchedule>> GetAllFeedingSchedules()
        {
            return await _DbContext.FeedingSchedules
                .Include(k => k.Fish) // Sử dụng Include để nạp đối tượng KoiFish
                .ToListAsync();
        }
            public async Task<FeedingSchedule?> GetFeedingScheduleById(Guid? Id)
        {
            return await _DbContext.FeedingSchedules.Where(p => p.FeedingScheduleId.Equals(Id)).FirstOrDefaultAsync();
        }

        public bool UpdateFeedingSchedule(FeedingSchedule FeedingSchedule)
        {
            try
            {
                _DbContext.FeedingSchedules.Update(FeedingSchedule);
                _DbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }
    }
}

