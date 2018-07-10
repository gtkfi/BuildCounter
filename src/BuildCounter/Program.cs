using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Globalization;
using System.Threading;


// Use this this way:

// Prebuild event:  call c:\koodi\buildcounter.exe $(ProjectDir) $(ProjectName)


namespace BuildCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // sisään tulee kaksi, eli polku ja nimi:
            if (args.Length < 2)
            {
                Console.WriteLine("No inputs, stop.");
                return;
            }
            string dir = args[0];
            string fn = args[1];

            string filenimi = System.IO.Path.Combine(dir, fn);
            string buildfile = Path.ChangeExtension(filenimi, "built");
            string countfile = Path.ChangeExtension(filenimi, "count");
            
            
            var culture = new CultureInfo("en-US");
            string pvm = DateTime.Now.ToString("dd.MM.yyyy");
            try
            {
                System.IO.File.WriteAllText(buildfile, pvm);
                Console.WriteLine("Datefile: {0}   -> {1}", buildfile, pvm);

                int count = 1;
                if (File.Exists(countfile))
                {
                    string num = File.ReadAllText(countfile);
                    int tmp = Convert.ToInt32(num);
                    count = tmp + 1;
                }
                System.IO.File.WriteAllText(countfile, count.ToString());
                Console.WriteLine("Countfile: {0}   -> {1}", countfile, count);

            }
            catch
            {
                Console.WriteLine("Can't write, files not checked out?");
            }
            
            //Console.WriteLine("Dir: {0} {1}", dir, fn);
            
        }
    }
}
