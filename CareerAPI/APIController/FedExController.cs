using CareerAPI.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Web.Http;


namespace CareerAPI.APIController
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class FedExController : ApiController
    {
        // GET: FedEx
        /// <summary>
        /// Gets the tracking details by tracking number asynchronous.
        /// </summary>
        /// <param name="trackingNumber">The tracking number.</param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult GetTrackingDetailsByTrackingNumber([FromBody] string trackingNumber)
        {
            try
            {
                string tokenResultInJSON = string.Empty;
                string tokenURL = CommonValues.CommonValues.TokenURL;
                using (var tokenClient = new RestClient(tokenURL))
                {
                    var tokenRequest = new RestRequest();
                    tokenRequest.Method = Method.Post;
                    tokenRequest.AddHeader("Content-Type", CommonValues.CommonValues.TokenContentType);

                    tokenRequest.AddParameter("grant_type", CommonValues.CommonValues.GrantType);
                    tokenRequest.AddParameter("client_id", CommonValues.CommonValues.ClientId);
                    tokenRequest.AddParameter("client_secret", CommonValues.CommonValues.ClientSecret);
                    var tokenResponse = tokenClient.Execute(tokenRequest);
                    tokenResultInJSON = tokenResponse.Content;
                }

                Token token = !string.IsNullOrWhiteSpace(tokenResultInJSON) ? JsonConvert.DeserializeObject<Token>(tokenResultInJSON) : new Token();

                string trackingAPIURL = CommonValues.CommonValues.TrackingAPIURL;
                string trackingResult = string.Empty;
                if (!string.IsNullOrWhiteSpace(token.access_token))
                {
                    using (var trackingClient = new RestClient(trackingAPIURL))
                    {
                        var trackingRequest = new RestRequest();
                        trackingRequest.Method = Method.Post;
                        trackingRequest.AddHeader("Authorization", "Bearer " + token.access_token);
                        trackingRequest.AddHeader("X-locale", CommonValues.CommonValues.XLocale);
                        trackingRequest.AddHeader("Content-Type", CommonValues.CommonValues.TrackingAPIContentType);

                        TrackingAPIModel trackingAPIModel = new TrackingAPIModel
                        {
                            includeDetailedScans = true,
                            trackingInfo = new List<trackingInfo> {
                            new trackingInfo {
                                trackingNumberInfo = new trackingNumberInfo {
                                    trackingNumber = trackingNumber
                                }
                            }
                        }
                        };

                        var trackingAPIInput = JsonConvert.SerializeObject(trackingAPIModel);
                        trackingRequest.AddParameter(CommonValues.CommonValues.TrackingAPIParameterName, trackingAPIInput, ParameterType.RequestBody);
                        var trackingResponse = trackingClient.Execute(trackingRequest);
                        trackingResult = trackingResponse.Content;
                    }
                    return Ok(trackingResult);
                }
                else
                {
                    return BadRequest("Not able to get Token. Retry again or check credentials!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.ToString());
            }
        }
    }
}