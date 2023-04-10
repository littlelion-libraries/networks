using System.Collections.Generic;
using UnityEngine.Networking;

namespace Networks
{
    public class Network : INetwork
    {
        public IEnumerator<(int, string)> GetRequestAsync(string uri)
        {
            using var webRequest = UnityWebRequest.Get(uri);
            var routine = webRequest.SendWebRequest();
            while (!routine.isDone)
            {
                yield return (-1, null);
            }

            yield return ((int)webRequest.responseCode, webRequest.downloadHandler.text);
        }
    }
}