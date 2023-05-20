using AutoMapper.Configuration;
using ElasticData.Entity;
using ElasticData.Interface;
using ElasticData.Mapping;
using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticData.Service
{
    public class ElasticSearchManager : IElasticSearchService
    {
        private readonly IConfiguration _configuratioın;
        private readonly IElasticClient _elasticClient;

        public ElasticSearchManager(IConfiguration configuratioın, IElasticClient elasticClient)
        {
            _configuratioın = configuratioın;
            _elasticClient = elasticClient;
        }

        private ElasticClient CreateInstance()
        {
            string host = _configuratioın.GetSection("ElasticSearchServer:Host").Value;
            string port = _configuratioın.GetSection("ElasticSearchServer:Port").Value;
            string username = _configuratioın.GetSection("ElasticSearchServer:Username").Value;
            string password = _configuratioın.GetSection("ElasticSearchServer:Password").Value;

            var settings = new ConnectionSettings(new Uri(host + ":" + port));
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                settings.BasicAuthentication(username, password);
            return new ElasticClient(settings);
        }

        public async Task CheckIndex(string indexName)
        {
            var any = await _elasticClient.Indices.ExistsAsync(indexName);
            if (any.Exists)
                return;

            var response = await _elasticClient.Indices.CreateAsync(indexName,
            ci => ci
            .Index(indexName)
            .CitiesMapping()
            .Settings(s => s.NumberOfShards(3).NumberOfReplicas(1))
            );

            return;
        }

        public async Task DeleteIndex(string indexName)
        {
            await _elasticClient.Indices.DeleteAsync(indexName);
        }

        public Task DeleteByIdDocument(string indexName, Cities cities)
        {
            throw new NotImplementedException();
        }

        public async Task<Cities> GetDocuments(string indexName, string id)
        {
            var response = await _elasticClient.GetAsync<Cities>(id, q => q.Index(indexName));
            return response.Source;
        }

        public async Task<List<Cities>> GetDocuments(string indexName)
        {
            //#region Wilcard aradaki harfi kendi tamamlıyor

            //var response = await _elasticClient.SearchAsync<Cities>(s =>
            //s.From(0)
            //.Take(10)
            //.Index(indexName)
            //.Query(q => q
            //.Bool(b => b
            //.Should(m => m
            //.Wildcard(w => w
            //.Field("city")
            //.Value("r*ze"))))));
            //#endregion

            #region Fuzzy kendi kendini tammalar parametrikde olabilir 
            //var response = await _elasticClient.SearchAsync<Cities>(s => s
            //                       .Index(indexName)
            //                       .Query(q => q
            //                       .Fuzzy(fz => fz.Field("city")
            //                       .Value("anka").Fuzziness(Fuzziness.EditDistance(4))
            //                       ) ));

            // harflerin yer değiştirmesi 

            //var response = await _elasticClient.SearchAsync<Cities>(s => s
            //.Index(indexName)
            //.Query(q => q
            //.Fuzzy(fz => fz.Field("city")
            //.Value("rie").Transpositions(true))));

            #endregion

            #region MatchPhrasePrefix aradaki harfi kendi tanımlıyor Wildcard göre performans olarak daha yüksek

            //var response = await _elasticClient.SearchAsync<Cities>(s => s
            //.Index(indexName)
            //.Query(q => q.MatchPhrasePrefix(m => m.Field(f => f.City).Query("iz").MaxExpansions(10))));
            #endregion

            #region MultiMatch çoklu büyük küçük duyarlığı olmaz

            var response = await _elasticClient.SearchAsync<Cities>(s => s.Index(indexName)
            .Query(q =>q
            .MultiMatch(mm=>mm
            .Fields(f => f
            .Field(ff => ff.)
            #endregion

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
