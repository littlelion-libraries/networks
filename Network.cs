using System.Collections.Generic;
using UnityEngine.Networking;

namespace Networks
{
    public class Network : INetwork
    {
        public IEnumerator<int> CodeGetRequestAsync(string uri)
        {
            using var webRequest = UnityWebRequest.Get(uri);
            var routine = webRequest.SendWebRequest();
            while (!routine.isDone)
            {
                yield return ResponseCode.Processing;
            }

            yield return (int)webRequest.responseCode;
        }

        public IEnumerator<(int, string)> GetRequestAsync(string uri)
        {
            using var webRequest = UnityWebRequest.Get(uri);
            var routine = webRequest.SendWebRequest();
            while (!routine.isDone)
            {
                yield return (ResponseCode.Processing, null);
            }

            yield return ((int)webRequest.responseCode, webRequest.downloadHandler.text);
        }
    }
}