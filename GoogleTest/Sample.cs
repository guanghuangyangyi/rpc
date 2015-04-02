using Rpc;

namespace Test
{
    public class Sample : IRpcProxy
    {
        public string Echo(string text)
        {
            return text;
        }
    }
}