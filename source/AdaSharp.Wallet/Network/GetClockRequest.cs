using RestSharp;

namespace AdaSharp.Network
{
    public class GetClockRequest : CardanoNodeRequest
    {
        public bool ForceNtpCheck { get; set; }

        internal override IRestRequest ToRestRequest()
        {
            var restRequest = new RestRequest("/network/clock", Method.GET);

            if (ForceNtpCheck)
            {
                restRequest.AddQueryParameter("forceNtpCheck", ToTrueFalse(ForceNtpCheck));
            }
            
            return restRequest;
        }

        internal override void Validate()
        { }
    }
}