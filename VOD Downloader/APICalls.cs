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
        public static VODMasterObject GetStreams(int streamerID, string previousStreamType = "highlight")
        {
            return APICall<VODMasterObject, int>(BaseURL.PastStreamURL.ToDescriptionString(), "user_id=", streamerID.ToString(), "&type=", previousStreamType);
        }
        public static VODMasterObject GetStreams(int streamerID, string previousStreamType, string period, string sort, int first)
        {
            return APICall<VODMasterObject, int>(BaseURL.PastStreamURL.ToDescriptionString(), "user_id=", streamerID.ToString(), "&type=", previousStreamType, "&period=",period,"&sort=",sort,"&first=",first.ToString());
        }

        public static VODMasterObject GetStreams(int streamerID, string beforeOrAfter, string pagination, string previousStreamType = "highlight")
        {
            return APICall<VODMasterObject, int>(BaseURL.PastStreamURL.ToDescriptionString(), "user_id=", streamerID.ToString(), "&type=", previousStreamType, beforeOrAfter, pagination);
        }

        public static UserFollowData GetFollowedStreamers(int streamerID, int numOfObjects)
        {
            return APICall<UserFollowData, int>(BaseURL.FollowedStreamersURL.ToDescriptionString(), "from_id=", streamerID.ToString(),"&first=",numOfObjects.ToString());
        }

        public static UserFollowData GetFollowedStreamersNext(int streamerID, string pagination)
        {
            return APICall<UserFollowData, int>(BaseURL.FollowedStreamersURL.ToDescriptionString(), "from_id=", streamerID.ToString(), "&after=",pagination);
        }

        /// <summary>
        /// Get followed
        /// </summary>
        /// <param name="streamerID"></param>
        /// <returns></returns>
        public static UserFollowData GetFollowedStreamers(int streamerID)
        {
            return APICall<UserFollowData, int>(BaseURL.FollowedStreamersURL.ToDescriptionString(), "from_id=", streamerID.ToString());
        }

        /// <summary>
        /// Gets streamer info (such as user ID, login name, profile picture, etc)
        /// </summary>
        /// <param name="username">Streamer username, can be chained with multiple usernames using "&login=" </param>
        /// <returns>UserDataInformation object with a list of UserInformation</returns>
        public static  UserDataInformation GetStreamerInformation(string username)
        {
            return APICall<UserDataInformation, string>(BaseURL.UserAccountURL.ToDescriptionString(), "login=", username);
        }

        private static T APICall<T, U>(params object[] list)
        {
            
            T returnInformation = default(T);
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string queryString = "";

                    

                    foreach (string query in list)
                    {
                        queryString = String.Format("{0}{1}",queryString,query.ToString());
                    }
                    //Console.WriteLine(string.Format("{0}{1}{2}{3}{4}", baseURL, paramaterQueryNameOne, paramterValueOne, paramaterQueryNameTwo, parameterValueTwo));
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
