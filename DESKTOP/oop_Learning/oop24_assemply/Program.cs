using asssemblies24_ClassLibrary;
using System.Reflection;

namespace assemply24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(emploee);
            Console.WriteLine(type);
            var assem = type.Assembly;
            Console.WriteLine(assem.FullName);
            var assem2 = Assembly.GetExecutingAssembly();
            Console.WriteLine(assem2.FullName);
            Console.WriteLine("====================================================================");
            Console.WriteLine("====================================================================");
            demo.track();
            Console.WriteLine("====================================================================");
            Console.WriteLine("====================================================================");
            var type2 = typeof(Program);
            var aseem3 = type2.Assembly;
            Console.WriteLine("FullName:" + aseem3.FullName);
            Console.WriteLine("Location:" + aseem3.Location);
            var assempliesname = aseem3.GetName();
            Console.WriteLine("Name:" + assempliesname.Name);
            Console.WriteLine("Version:" + assempliesname.Version);
            Console.WriteLine("GetPublicKeyToken:" + assempliesname.GetPublicKeyToken().Length);
            Console.WriteLine("CodeBase:" + assempliesname.CodeBase);
            Console.WriteLine("DateTime  +   Assembly   +  Name: " + typeof(DateTime).Assembly.GetName().Name);
            Console.WriteLine("====================================================================");
            Console.WriteLine("====================================================================");
            var type4 = typeof(Program);
            var aseem5 = type4.Assembly;
            /////////////////var stream = aseem5.GetManifestResourceStream("CAAssemblies.data.mydata.json");
            var streamm = aseem5.GetManifestResourceStream(type4, "data.mydata.json");
            var data = new BinaryReader(streamm).ReadBytes((int)streamm.Length);

            for (int i = 0; i < data.Length; i++)
            {
                Console.Write((char) data[i]);
                System.Threading.Thread.Sleep(300);
            }
            streamm.Close();
            Console.WriteLine("====================================================================");
            Console.WriteLine("====================================================================");

            Console.ReadKey();
        }
        class emploee 
        {
        
        }
    }
}
