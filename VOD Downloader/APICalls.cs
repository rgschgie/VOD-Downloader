using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VOD_Downloader
{
    public static class APICalls
    {
        /// <summary>
        /// Get VODMasterObject of VOD(video) data
        /// </summary>
        /// <param name="streamerID">ID of the user who owns the video</param>
        /// <param name="previousStreamType">Highlight, archive, upload or all</param>
        /// <returns>VODMasterObject that contains VOD data</returns>
        public static VODMasterObject GetStreams(int streamerID, string previousStreamType = "highlight")
        {
            return APICall<VODMasterObject>(BaseURL.PastStreamURL.ToDescriptionString(), "user_id=", streamerID.ToString(), "&type=", previousStreamType);
        }

        /// <summary>
        /// Get VODMasterObject of VOD(video) data
        /// </summary>
        /// <param name="streamerID">ID of the user who owns the video</param>
        /// <param name="previousStreamType">Highlight, archive, upload or all</param>
        /// <param name="period">Period during which the video was created</param>
        /// <param name="sort">Sort order of the videos. Valid values: "time", "trending", "views"</param>
        /// <param name="first">Maximum number of objects to return</param>
        /// <returns>VODMasterObject that contains VOD data</returns>
        public static VODMasterObject GetStreams(int streamerID, string previousStreamType, string period, string sort, int first)
        {
            return APICall<VODMasterObject>(BaseURL.PastStreamURL.ToDescriptionString(), "user_id=", streamerID.ToString(), "&type=", previousStreamType, "&period=",period,"&sort=",sort,"&first=",first.ToString());
        }

        /// <summary>
        /// Get VODMasterObject of VOD(video) data
        /// </summary>
        /// <param name="streamerID">ID of the user who owns the video</param>
        /// <param name="beforeOrAfter">Cursor for forward or backwards pagination</param>
        /// <param name="pagination">A cursor value, to be used in a subsequent 
        /// request to specify the starting point of the next set of results.</param>
        /// <param name="previousStreamType"></param>
        /// <returns>VODMasterObject that contains VOD data</returns>
        public static VODMasterObject GetStreams(int streamerID, string beforeOrAfter, string pagination, string previousStreamType = "highlight")
        {
            return APICall<VODMasterObject>(BaseURL.PastStreamURL.ToDescriptionString(), "user_id=", streamerID.ToString(), "&type=", previousStreamType, beforeOrAfter, pagination);
        }

        /// <summary>
        /// Get VODMasterObject of VOD(video) data
        /// </summary>
        /// <param name="streamerID">ID of the user who owns the video</param>
        /// <param name="numOfObjects">Maximum number of objects to return</param>
        /// <returns>UserDataInformation object with a list of UserInformation</returns>
        public static UserFollowData GetFollowedStreamers(int streamerID, int numOfObjects)
        {
            return APICall<UserFollowData>(BaseURL.FollowedStreamersURL.ToDescriptionString(), "from_id=", streamerID.ToString(),"&first=",numOfObjects.ToString());
        }

        /// <summary>
        /// Get next UserFollowData object of followed users
        /// </summary>
        /// <param name="streamerID">ID of the user to get followed users</param>
        /// <param name="pagination">A cursor value, to be used in a subsequent 
        /// request to specify the starting point of the next set of results.</param>
        /// <returns>UserDataInformation object with a list of UserInformation</returns>
        public static UserFollowData GetFollowedStreamersNext(int streamerID, string pagination)
        {
            return APICall<UserFollowData>(BaseURL.FollowedStreamersURL.ToDescriptionString(), "from_id=", streamerID.ToString(), "&after=",pagination);
        }

        /// <summary>
        /// Get UserFollowData object of followed users
        /// </summary>
        /// <param name="streamerID">ID of the user to get followed users</param>
        /// <returns>UserDataInformation object with a list of UserInformation</returns>
        public static UserFollowData GetFollowedStreamers(int streamerID)
        {
            return APICall<UserFollowData>(BaseURL.FollowedStreamersURL.ToDescriptionString(), "from_id=", streamerID.ToString());
        }

        /// <summary>
        /// Gets streamer info (such as user ID, login name, profile picture, etc)
        /// </summary>
        /// <param name="username">Streamer username, using "&login=" </param>
        /// <returns>UserDataInformation object with a list of UserInformation</returns>
        public static  UserDataInformation GetStreamerInformation(string username)
        {
            return APICall<UserDataInformation>(BaseURL.UserAccountURL.ToDescriptionString(), "login=", username);
        }
           


        /// <summary>
        /// Constructs and runs a query on the twitch API and binds it to object T
        /// </summary>
        /// <typeparam name="T">Object to be binded and returned</typeparam>
        /// <param name="list">API query arguments</param>
        /// <returns>Object T</returns>
        private static T APICall<T>(params object[] list)
        {
            
            T returnInformation = default(T);
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string queryString = "";

                    
                    //builds api call
                    foreach (string query in list)
                    {
                        queryString = String.Format("{0}{1}",queryString,query.ToString());
                    }

                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), string.Format("{0}",queryString)))
                    {
                        request.Headers.TryAddWithoutValidation("Client-ID", "axjrc6j57ai3i1hzkvb2gou1mxwp94");
                        HttpResponseMessage response = httpClient.SendAsync(request).Result;
                        T data = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                        returnInformation = data;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return returnInformation;

        
        }

    }
}
