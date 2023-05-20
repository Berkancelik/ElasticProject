using ElasticData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticData.Interface
{
    public interface IElasticSearchService
    {
        Task CheckIndex(string indexName);
        Task InmsertDocument(string indexName, Cities cities);
        Task DeleteIndex(string indexName);
        Task DeleteByIdDocument(string indexName, Cities cities);
        Task InsertBulkDocuments(string indexName, List<Cities> cities);
        Task<Cities > GetDocuments(string indexName, string id);
        Task<List<Cities>> GetDocuments(string indexName);
    }
}
