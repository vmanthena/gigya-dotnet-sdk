namespace Gigya.Socialize.SDK.Internals
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed class GigyaHttpClient : HttpClient
    {
        private static GigyaHttpClient _currentInstance = null;
        private static object _singletonLock = new object();

        public static GigyaHttpClient Instance
        {
            get
            {
                if (_currentInstance == null)
                {
                    lock (_singletonLock)
                    {
                        if (_currentInstance == null)
                        {
                            _currentInstance = new GigyaHttpClient(new HttpClientHandler
                            {
                                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
                            });
                        }
                    }
                }
                return _currentInstance;
            }
        }

        private GigyaHttpClient(HttpClientHandler httpClientHandler)
            : base(httpClientHandler)
        {
            this.Timeout = TimeSpan.FromSeconds(30_000);
            this.DefaultRequestHeaders.ConnectionClose = true;
            this.DefaultRequestHeaders.ExpectContinue = false;
        }

        public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}