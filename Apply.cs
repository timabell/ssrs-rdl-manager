using CommandLine.Text;

namespace SsrsRdlManager.Apply
{
    class ConsoleApp
    {
        static void Main(string[] args)
        {
            var parsedArgs = CommandLine.Parser.Default.ParseArguments<Options>(args);
            var opts = parsedArgs.Value;
            var ta = new TemplateApplier(opts.template, opts.target);
            ta.Apply();
        }

        class Options
        {
            public string template { get; set; }
            public string target { get; set; }
        }
    }
}
