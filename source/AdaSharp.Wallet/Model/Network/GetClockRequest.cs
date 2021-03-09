using RestSharp;

namespace AdaSharp.Model.Network
{
    public class GetClockRequest : CardanoNodeRequest
    {
        public bool ForceNtpCheck { get; set; }

        internal override IRestRequest ToRestRequest()
        {
            Validate();

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