using System;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace AdaSharp.Model
{
    public abstract class CardanoNodeResponse
    {
        public HttpStatusCode HttpStatusCode { get; protected set; }

        protected CardanoNodeResponse(HttpStatusCode statusCode)
        {
            HttpStatusCode = statusCode;
        }

        /// <remarks>
        /// This method was created because there needs to be a way to check if the IRestResponse
        /// that is passed to the constructor of a inherited CardanoNodeResponse class is not null.
        /// Since this base class requires an HttpStatusCode value, the inheriting classes need a
        /// way to check for a null IRestResponse prior to calling the base constructor. This method
        /// helps achieve that.
        /// </remarks>
        protected static HttpStatusCode GetStatusCodeIn(IRestResponse response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            return response.StatusCode;
        }

        protected void PopulateSelfWith(IRestResponse responseFromNode)
        {
            PopulateTo(this, responseFromNode);
        }

        protected void PopulateTo(object @object, IRestResponse responseFromNode)
        {
            JsonConvert.PopulateObject(responseFromNode.Content, @object);
        }
    }
}
