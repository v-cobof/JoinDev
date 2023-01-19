﻿using JoinDev.Application.Data;
using MongoDB.Driver;

namespace JoinDev.Infra.Data.Read
{
    public class ReplicationRepository<T> : IReplicationRepository<T>
    {
        private readonly MongoDbContext _context;
        private IMongoCollection<T> _collection => _context.Database.GetCollection<T>(nameof(T));

        public ReplicationRepository(MongoDbContext context)
        {
            _context = context;
        }

        public void Create(T model)
        {
            
        }
    }
}