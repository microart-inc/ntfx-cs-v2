using MicroART.NTFX.Parsers;
using MicroART.NTFX.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MicroART.Pipe;
using System.Threading.Tasks;

namespace MicroART.NTFX.Internal
{
    public class Context
    {
        public bool IsAdministrator;
        public bool IsSuperuser;
        public string Arguments;
        public string Prompt = "ntfx:~$ ";
        public NtfxInfo NtfxInfo;
        internal StorageProvider Storage;
        internal IParser Parser;
        internal Type TargetParserType;
        internal Dictionary<IApplication, Models.AppContext> ActiveAppContexts;

        internal delegate void InputRecievedHandler(string input, string safeinput);
        internal event InputRecievedHandler InputRecieved;

        public static Context GetDefault()
        {
            Context context = new Context();
            context.TargetParserType = context.TargetParserType == null ? typeof(Xenon) : context.TargetParserType;
            context.Parser = (IParser)Activator.CreateInstance(context.TargetParserType);
            context.Storage = new StorageProvider();
            context.ActiveAppContexts = new Dictionary<IApplication, Models.AppContext>();
            context.NtfxInfo = NtfxInfo.Init();
            //Write.White($"Loaded {context.TargetParserType.Name} parser {context.Parser.Version}", true);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.Black;
            Write.White($"©{DateTime.Now.Year} MicroART Technologies Inc", true);
            Write.White($"NTFX v2 | Powered by: MicroART Phoenix", true);
            return context;
        }

        public async Task StartInputHandler()
        {
        Loop:
            Write.NewLine();
            Write.White(GetPrompt());
            string input = Read.Line();
            if (string.IsNullOrWhiteSpace(input)) goto Loop;
            string safeinput = SetInputSafe(input);
            InputRecieved?.Invoke(input, safeinput);
            goto Loop;
        }

        public string GetPrompt()
        {
            var s = Prompt;
            s = s.Replace("{h}", DateTime.Now.ToString("%h"));
            s = s.Replace("{t}", DateTime.Now.ToString("tt"));
            s = s.Replace("{m}", DateTime.Now.ToString("%m"));
            s = s.Replace("{u}", "User");
            return s;
        }

        internal string SetInputSafe(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input.Trim(), @"\s+", " ").Trim();
        }

        internal Models.AppContext GetAppContext(IApplication app)
        {
            Models.AppContext context = null;
            if (!ActiveAppContexts.TryGetValue(app, out context))
            {
                context = new Models.AppContext();
            }
            return context;
        }
    }
}
