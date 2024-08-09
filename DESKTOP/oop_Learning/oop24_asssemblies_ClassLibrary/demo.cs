using System.Reflection;

namespace asssemblies24_ClassLibrary
{
    public class demo
    {

        public static void track()
        {
            Console.WriteLine("retacking....");
            Console.WriteLine("GetExecutingAssembly " + Assembly.GetExecutingAssembly());
            Console.WriteLine("GetEntryAssembly " + Assembly.GetEntryAssembly());
            Console.WriteLine("GetCallingAssembly " + Assembly.GetCallingAssembly());
        }
    }
}
