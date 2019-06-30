using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTManager.Utility.Helpers
{
    public class CosmosDBHelper<T> where T : class
    {
        private readonly DocumentClient _client;
        private readonly string _databaseId;
        private readonly string _collectionId;

        public CosmosDBHelper(string endpointUrl, string authKey, string databaseId, string collectionId)
        {
            this._client = new DocumentClient(new Uri(endpointUrl), authKey);
            this.CreateDatabaseIfNotExists(databaseId);
            this.CreateCollectionIfNotExists(databaseId, collectionId);
            this._databaseId = databaseId;
            this._collectionId = collectionId;
        }

        private void CreateDatabaseIfNotExists(string databaseId)
        {
            this._client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(databaseId)).Wait();
        }

        private void CreateCollectionIfNotExists(string databaseId, string collectionId)
        {
            this._client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(databaseId, collectionId)).Wait();
        }

        public Document CreateItem(T item)
        {
            return this._client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(this._databaseId, this._collectionId), item).Result;
        }

        public T GetItem(string id)
        {
            try
            {
                Document document = this._client.ReadDocumentAsync(UriFactory.CreateDocumentUri(this._databaseId, this._collectionId, id)).Result;
                return (T)(dynamic)document;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
