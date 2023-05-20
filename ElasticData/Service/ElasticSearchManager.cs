using AutoMapper.Configuration;
using ElasticData.Entity;
using ElasticData.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticData.Service
{
    public class ElasticSearchManager : IElasticSearchService
    {
        private readonly IConfiguration _configuratioın:;

        public Task CheckIndex(string indexName)
        {
            throw new NotImplementedException();
        }

        public Task DeleteIndex(string indexName)
        {
            throw new NotImplementedException();
        }

        public Task DelteByIdDocumen(string indexName, Cities cities)
        {
            throw new NotImplementedException();
        }

        public Task<Cities> GetDocuments(string indexName, string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cities>> GetDocuments(string indexName)
        {
            throw new NotImplementedException();
        }

        public Task InmsertDocument(string indexName, Cities cities)
        {
            throw new NotImplementedException();
        }

        public Task InsertBulkDocuments(string indexName, List<Cities> cities)
        {
            throw new NotImplementedException();
        }
    }
}
