using System;
using System.Diagnostics;

namespace BadPanda.FreeType.InteropTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var createResult = Library.Create();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            createResult.Match(
                ok => 
                {
                    var faceResult = ok.Value.Open(new Uri(@"C:\temp\Lovely Home.ttf"));

                    faceResult.Match(
                        ok_ => {
                            Console.WriteLine(ok_.Value.Format);
                            Console.WriteLine(ok_.Value.FamilyName);
                        },
                        err => { });

                    ok.Value.Dispose();
                },
                err => Console.WriteLine(err.Value.Message));
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Debugger.Break();
        }
    }
}
