﻿using Newtonsoft.Json;
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
        public static Task<VODMasterObject> GetPreviousStreams(int streamerID, string previousStreamType = "highlight")
        {
            return APICall<VODMasterObject, int>(BaseURL.PastStreamsURL, "user_id=", streamerID, "&type=", previousStreamType);
        }

        public static async Task<UserFollowData> GetFollowedStreamers(int streamerID)
        {
            return await APICall<UserFollowData, int>(BaseURL.FollowedStreamersURL, "from_id=", streamerID);
        }

        /// <summary>
        /// Gets streamer info (such as user ID, login name, profile picture, etc)
        /// </summary>
        /// <param name="username">Streamer username, can be chained with multiple usernames using "&login=" </param>
        /// <returns>UserDataInformation object with a list of UserInformation</returns>
        public static async Task<UserDataInformation> GetStreamerInformation(string username)
        {
            return await APICall<UserDataInformation, string>(BaseURL.UserAccountURL, "login=", username);
        }

        private static Task<T> APICall<T, U>(BaseURL baseURL, string paramaterQueryNameOne, U paramterValueOne, string paramaterQueryNameTwo = "", string parameterValueTwo = "")
        {
            return Task.Run(async() =>
            {

            
            T returnInformation = default(T);
            try
            {
                using (var httpClient = new HttpClient())
                {
                    Console.WriteLine(string.Format("{0}{1}{2}{3}{4}", baseURL.Value, paramaterQueryNameOne, paramterValueOne, paramaterQueryNameTwo, parameterValueTwo));
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), string.Format("{0}{1}{2}{3}{4}", baseURL.Value, paramaterQueryNameOne, paramterValueOne, paramaterQueryNameTwo, parameterValueTwo)))
                    {
                        request.Headers.TryAddWithoutValidation("Client-ID", "axjrc6j57ai3i1hzkvb2gou1mxwp94");
                        var response = await httpClient.SendAsync(request);
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

            });
        }


        /*  private static async Task<T> APICall<T>(BaseURL baseURL, string paramaterQueryNameOne, string paramterValueOne, string paramaterQueryNameTwo = "", string parameterValueTwo = "")
          {
              T returnInformation;
              using (var httpClient = new HttpClient())
              {
                  Console.WriteLine(string.Format("{0}{1}{2}{3}{4}", baseURL.Value, paramaterQueryNameOne, paramterValueOne, paramaterQueryNameTwo, parameterValueTwo));
                  using (var request = new HttpRequestMessage(new HttpMethod("GET"), string.Format("{0}{1}{2}{3}{4}", baseURL.Value, paramaterQueryNameOne, paramterValueOne, paramaterQueryNameTwo, parameterValueTwo)))
                  {


                      request.Headers.TryAddWithoutValidation("Client-ID", "axjrc6j57ai3i1hzkvb2gou1mxwp94");
                      var response = await httpClient.SendAsync(request);
                      T data = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                      returnInformation = data;
                  }
              }
              return returnInformation;
          }

          private static async Task<T> APICall<T>(BaseURL baseURL, string paramaterQueryNameOne, int paramterValueOne, string paramaterQueryNameTwo = "", string parameterValueTwo = "")
          {
              T returnInformation;
              using (var httpClient = new HttpClient())
              {
                  Console.WriteLine(string.Format("{0}{1}{2}{3}{4}", baseURL.Value, paramaterQueryNameOne, paramterValueOne, paramaterQueryNameTwo, parameterValueTwo));
                  using (var request = new HttpRequestMessage(new HttpMethod("GET"), string.Format("{0}{1}{2}{3}{4}", baseURL.Value, paramaterQueryNameOne, paramterValueOne, paramaterQueryNameTwo, parameterValueTwo)))
                  {


                      request.Headers.TryAddWithoutValidation("Client-ID", "axjrc6j57ai3i1hzkvb2gou1mxwp94");
                      var response = await httpClient.SendAsync(request);
                      T data = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                      returnInformation = data;
                  }
              }
              return returnInformation;
          }
          */




        /*public static async Task<T> GetStreamerInformation<T>(string username)
        {
            T userInformation;
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), string.Format("{0}login={1}", BaseURL.UserAccountURL.Value, username)))
                {
                    request.Headers.TryAddWithoutValidation("Client-ID", "axjrc6j57ai3i1hzkvb2gou1mxwp94");
                    var response = await httpClient.SendAsync(request);
                    T data = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    userInformation = data;
                }
            }
            return userInformation;
        }*/


        //public static async Task<T> ExecuteAPICall<T>()
        //{
        //    T VODMaster;
        //    using (var httpClient = new HttpClient())
        //    {
        //        //StreamerInformation.id
        //        using (var request = new HttpRequestMessage(new HttpMethod("GET"), string.Format("{0}user_id={1}&type=highlight", previousStreamURL, streamerID)))
        //        {
        //            request.Headers.TryAddWithoutValidation("Client-ID", "axjrc6j57ai3i1hzkvb2gou1mxwp94");
        //            var response = await httpClient.SendAsync(request);
        //            T data = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        //            VODMaster = data;
        //        }
        //    }
        //    //Console.WriteLine(str);
        //    return VODMaster;
        //}


        //https://api.twitch.tv/helix/videos?user_id={0}&type=highlight
        //https://api.twitch.tv/helix/users?id={0}
        //https://api.twitch.tv/helix/users/follows?from_id={0}&first=20
        //https://api.twitch.tv/helix/users/follows?from_id={0}&after={1}
        //https://api.twitch.tv/helix/users?login={0}
        //
        //
        //
        //
        //
        //



        //pagination
        /*using (var request = new HttpRequestMessage(new HttpMethod("GET"), string.Format("https://api.twitch.tv/helix/users/follows?from_id={0}&after={1}", twitchUserID,pagination)))
                    {
                        request.Headers.TryAddWithoutValidation("Client-ID", "axjrc6j57ai3i1hzkvb2gou1mxwp94");

                        var response = await httpClient.SendAsync(request);
                        UserFollowData data = JsonConvert.DeserializeObject<UserFollowData>(response.Content.ReadAsStringAsync().Result);



                        dynamic parsedJson = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                        //Console.WriteLine(parsedJson);


                        foreach (var item in data.data)
                        {
                            Console.WriteLine(item.to_name);
                        }
                    }*/

    }
}