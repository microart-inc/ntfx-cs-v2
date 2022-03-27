using System;
using System.Linq;
using MicroART.NTFX.Parsers;
using MicroART.NTFX.Internal;
using MicroART.NTFX.Models;
using MicroART.Pipe;
using System.Threading.Tasks;

namespace MicroART.NTFX
{
    class Program
    {
        internal static Context _context;

        static async Task Main(string[] args)
        {
            // Create a new context based on the default NTFX template
            _context = Context.GetDefault();
            _context.InputRecieved += OnInputRecieved;
            _context.StartInputHandler();
        }

        async static void OnInputRecieved(string input, string safeinput)
        {
            (IClass, IApplication, string, ParserFlags, int) output = (null, null, null, ParserFlags.Null, 0);
            try
            {
                output = _context.Parser.Parse(safeinput, _context.Storage);
                // Define environment variables in current context

                if (output.Item4.HasFlag(ParserFlags.RequestAdministrator))
                {
                    Write.Red("Requested Super");
                }
                if (output.Item2 != null)
                {
                    var appContext = _context.GetAppContext(output.Item2);
                    appContext.DefineContext(output, _context);
                    output.Item2.Execute(ref appContext);
                    _context.ActiveAppContexts[output.Item2] = appContext;
                }
                else if (output.Item1 != null && output.Item4.HasFlag(ParserFlags.ShowClassInfo))
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Write.Black($" CLASS ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Write.Green($" {output.Item1.Name.ToUpper()} ");
                    Write.Yellow($" {output.Item1.Version} ", true);
                    Write.DarkGray($"{output.Item1.Description}", true);
                    Write.DarkGray($"Location: ntfx://storage/classes/{output.Item1.Name.ToLower()}", true);
                }
            } catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Write.Black($" ERROR ");
                Console.BackgroundColor = ConsoleColor.Black;
                Write.Red(" Exception thrown ", true);
                Write.Yellow(e.Message, true);
                Write.DarkGray($"Stack Trace: ", true);
                Write.DarkGray($"\t|Class: {output.Item1.Name}", true);
                Write.DarkGray($"\t|Application: {output.Item2.Name}", true);
            }

        }
    }
}
