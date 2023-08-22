using FluentAssertions;
using RestSharp;

namespace UscArmSip
{
    public class RestRequestService
    {
        public RestRequestService(
            Api api,
            RestRequest request)
        {
            _request = request;
            _request.AlwaysMultipartFormData = true;
            _baseUrl = "http://" + "test-esk-api.nposapfir.ru";

            _options = new($"{_baseUrl}:{(int)api}")
            {
                MaxTimeout = -1,
            };

            _restClient = new(_options);
        }

        public RestRequestService(
            Api api,
            RestRequest request,
            CabinetRequestData cabinetRequest) : this(api, request)
        {
            if (api is Api.Cabinet)
            {
                request.AddHeader("Authorization", $"{cabinetRequest.AuthToken}");
            }
        }

        public dynamic response;

        private readonly string _baseUrl;
        private readonly RestRequest _request;
        private readonly RestClient _restClient;
        private readonly RestClientOptions _options;


        public void SendRequest()
        {
            var r = _restClient.Execute(_request);
            r.IsSuccessful.Should().BeTrue();
            response = r.Deserealize();
        }
    }

    public enum Api
    {
        Portal = 17055,
        Cabinet = 17125
    }
}
