using RestSharp;

namespace AdaSharp.Model
{
    public abstract class CardanoNodeRequest
    {
        internal abstract IRestRequest ToRestRequest();

        internal abstract void Validate();

        protected string ToTrueFalse(bool value)
        {
            return value ? "true" : "false";
        }
    }
}