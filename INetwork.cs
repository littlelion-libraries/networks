using System.Collections.Generic;

namespace Networks
{
    public interface INetwork
    {
        IEnumerator<(int, string)> GetRequestAsync(string uri);
    }
}