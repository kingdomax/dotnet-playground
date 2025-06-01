using Playground.Topics.Interfaces;

namespace Playground.Topics
{
    public class TryCatchFinally : IRunner
    {
        public void Run()
        {
            try
            {
                Console.WriteLine("connect");
                Console.WriteLine("execute");
                throw new Exception("exception");
            }
            catch (Exception ex)
            {
                Console.WriteLine("rollback");
                throw; // if throw ex; it will change stack information
            }
            finally
            {
                Console.WriteLine("commit");
            }
        }
    }
}
