﻿using leave_management.Contracts;
using leave_management.Data;
using System.Collections.Generic;
using System.Linq;

namespace leave_management.Repository
{
    public class LeaveHistoryRepository : ILeaveHistoryRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveHistoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveHistory entity)
        {
            _db.LeaveHistories.Add(entity);
            return Save();
        }

        public bool Delete(LeaveHistory entity)
        {
            _db.LeaveHistories.Remove(entity);
            return Save();
        }

        public ICollection<LeaveHistory> FindAll()
        {
            var leaveHistories = _db.LeaveHistories.ToList();

            return leaveHistories;
        }

        public LeaveHistory FindById(int id)
        {
            var leaveHistories = _db.LeaveHistories.Find(id);
            //_db.LeaveHistories.FirstOrDefault();
            return leaveHistories;
        }

        public bool isExists(int id)
        {
            var exists = _db.LeaveHistories.Any(q => q.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveHistory entity)
        {
            _db.LeaveHistories.Update(entity);
            return Save();
        }
    }
}
