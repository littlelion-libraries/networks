using System;
using System.Collections;
using Tasks;
using UnityEngine.Networking;

namespace Networks.Tasks
{
    public class TaskNetwork// : ITaskNetwork
    {
        private Action<IEnumerator> _step;

        public ITask<int> CodeGetRequestAsync(string uri)
        {
            var awaiter = new Awaiter<int>();
            using var webRequest = UnityWebRequest.Get(uri);
            var routine = webRequest.SendWebRequest();
            return new AwaiterTask<int>(awaiter);
        }
    }
}