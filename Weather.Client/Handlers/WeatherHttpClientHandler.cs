//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Options;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Weather.Client.Handlers
//{
//    public class WeatherHttpClientHandler : HttpClientHandler
//    {
//        protected const string AuthorizationHeaderKey = "Authorization";
//        protected const string Bearer = "Bearer";

//        protected readonly IHttpContextAccessor _httpContextAccessor;
//        protected readonly ApiSettings _tokenSettings;

//        public WeatherHttpClientHandler(IHttpContextAccessor httpContextAccessor, IOptions<ApiSettings> tokenSettings)
//        {
//            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
//            CheckCertificateRevocationList = false;

//            _httpContextAccessor = httpContextAccessor;
//            _tokenSettings = tokenSettings.Value;
//        }
//        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//        {
//            var authHeader = request.Headers.Authorization;

//            if (authHeader == null)
//            {
//                AddAuthorizationHeader(request);
//            }

//            return await base.SendAsync(request, cancellationToken);
//        }
//        protected virtual void AddAuthorizationHeader(HttpRequestMessage request)
//        {
//            if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Request.Headers.TryGetValue(AuthorizationHeaderKey, out var value))
//            {
//                var token = value.ToString().Split(" ").LastOrDefault();
//                request.Headers.Authorization = new AuthenticationHeaderValue(Bearer, token);
//            }
//            else if (!string.IsNullOrWhiteSpace(_tokenSettings.Token))
//            {
//                request.Headers.Authorization = new AuthenticationHeaderValue(Bearer, _tokenSettings.Token);
//            }
//            else
//            {
//                this.AddHeader(request);
//            }
//        }
//        protected virtual void AddHeader(HttpRequestMessage request) { }
//    }
//}
