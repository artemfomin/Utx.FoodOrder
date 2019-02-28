using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Utx.FoodOrder.Clients.BaseClient
{
    //                                We assume that food menu items source is HttpClient

    /// <summary>
    /// Base class for all HTTP food provider clients
    /// </summary>
    /// <typeparam name="T">Provider internal product type. Should implement IProduct</typeparam>
    public abstract class BaseClient<T> : IDisposable where T : class, new()
    {
        /// <summary>
        /// Source HTTP(S) Address
        /// </summary>
        protected Uri Url { get; }

        /// <summary>
        /// HTTP client for connections
        /// </summary>
        protected HttpClient Client { get; } = new HttpClient();

        #region Public constructors

        public BaseClient(string url)
        {
            Url = new Uri(url);
            Client.BaseAddress = Url;
        }

        public BaseClient(Uri url)
        {
            Url = url;
            Client.BaseAddress = Url;
        }

        #endregion

        public abstract IList<IProduct> GetAvailableProducts();

        public abstract bool PlaceOrder(IList<IProduct> order);

        public void Dispose()
        {
            Client.CancelPendingRequests();
            Client.Dispose();
        }
    }
}
