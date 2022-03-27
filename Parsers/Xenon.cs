using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MicroART.NTFX.Internal;
using MicroART.NTFX.Models;
using MicroART.Pipe;

namespace MicroART.NTFX.Parsers
{
    class Xenon : IParser
    {
        public Version Version
        {
            get => new Version("1.0.0");
        }
        public string[] Capabilities
        {
            get => new string[]
            {
                "SupportsParsing",
                "SupportsAdmin",
                "SupportsErrorChecking",
                "SupportsDebugging",
                "SupportsLogging"
            };
        }

        public (IClass, IApplication, string, ParserFlags, int) Parse(string content, StorageProvider storage)
        {
            string _content = content;
            string[] tokens = _content.Split(' ');
            string adminId = "#admin#";
            string superId = "#su#";
            bool isAdmin = false;
            bool isSuper = false;

            bool showInfo = true;

            if (tokens[0].Equals(adminId, StringComparison.OrdinalIgnoreCase))
            {
                isAdmin = true;
                _content = _content.Substring(adminId.Length).Trim();
                tokens = _content.Split(' ');
            }
            if (tokens[0].Equals(superId, StringComparison.OrdinalIgnoreCase))
            {
                isSuper = true;
                _content = _content.Substring(superId.Length).Trim();
                tokens = _content.Split(' ');
            }
            // Actual parsing starts
            IClass selectedClass = null;
            IApplication application = null;
            string arguments = "";
            if (string.IsNullOrWhiteSpace(_content))
            {
                goto End;
            }
            var tokenex = new List<string>(tokens);
            int args = tokenex.FindIndex(x => x.StartsWith("--"));
            if (args > -1)
            {
                arguments = string.Join(' ', tokenex.Skip(args));
                tokenex.RemoveRange(args, tokenex.Count - args);
                tokens = tokenex.ToArray();
            }

            for (int i = 0; i < tokens.Length; i++)
            {
                if (i == 0)
                {
                    selectedClass = storage.Classes.Find(x => x.Name.Equals(tokens[i], StringComparison.OrdinalIgnoreCase));
                    if (selectedClass == null)
                    {
                        ClassNotFoundError(tokens, selectedClass, i);
                        //return (null, null, null, ParserFlags.Null, 0);
                        showInfo = false;
                        break;
                    }
                }
                else if (i == tokens.Length - 1)
                {
                    if (selectedClass.Applications != null)
                    {
                        application = selectedClass.Applications.Find(x => x.Name.Equals(tokens[i], StringComparison.OrdinalIgnoreCase));
                        if (application == default(IClass))
                        {
                            if (selectedClass.Classes != null)
                            {
                                var d = selectedClass.Classes.Find(x => x.Name.Equals(tokens[i], StringComparison.OrdinalIgnoreCase));
                                if (d != null)
                                {
                                    selectedClass = d;
                                }
                                else
                                {
                                    AppNotFoundError(tokens, selectedClass, i);
                                    showInfo = false;
                                    break;
                                }
                            }
                            else
                            {
                                AppNotFoundError(tokens, selectedClass, i);
                                showInfo = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (selectedClass.Classes != null)
                        {
                            selectedClass = selectedClass.Classes.Find(x => x.Name.Equals(tokens[i], StringComparison.OrdinalIgnoreCase));
                            if (selectedClass == null)
                            {
                                AppNotFoundError(tokens, selectedClass, i);
                                showInfo = false;
                                break;
                            }
                        }
                        else
                        {
                            AppNotFoundError(tokens, selectedClass, i);
                            showInfo = false;
                            break;
                        }
                    }
                }
                else if (i > 0)
                {
                    if (selectedClass.Classes != null)
                    {
                        selectedClass = selectedClass.Classes.Find(x => x.Name.Equals(tokens[i], StringComparison.OrdinalIgnoreCase));
                        if (selectedClass == null)
                        {
                            ClassNotFoundError(tokens, selectedClass, i);
                            showInfo = false;
                            /*return (null, null, null, ParserFlags.Null, 0);*/
                            break;
                        }
                    }
                    else
                    {
                        ClassNotFoundError(tokens, selectedClass, i);
                        showInfo = false;
                        break;
                    }
                }
            }

            End:
            // Take care of parser flags
            ParserFlags flags = ParserFlags.Null;
            if (isAdmin) flags = flags | ParserFlags.RequestAdministrator;
            if (isSuper) flags = flags | ParserFlags.RequestSuperuser;
            if (showInfo) flags = flags | ParserFlags.ShowClassInfo;
            return (selectedClass, application, arguments, flags, tokens.Length);
        }

        private void AppNotFoundError(string[] tokens, IClass selectedClass, int i)
        {
            if (selectedClass != null)
            {
                Write.Red($"Application '{tokens[i]}' not found in class '{selectedClass.Name.ToUpper()}'", true);
            }
        }
        private void ClassNotFoundError(string[] tokens, IClass selectedClass, int i)
        {
            if (selectedClass != null)
            {
                Write.Red($"Subclass '{tokens[i]}' not found in class '{selectedClass.Name.ToUpper()}'", true);
            }
            else
            {
                Write.Red($"Class '{tokens[i]}' not found", true);
            }
        }

    }
}
