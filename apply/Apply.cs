namespace SsrsRdlManager.Apply
{
    using CommandLine;
    using System.Linq;


    class ConsoleApp
    {
        static int Main(string[] args)
        {
            var parsedArgs = Parser.Default.ParseArguments<Options>(args);
            if (parsedArgs.Errors.Any())
            {
                return 1;
            }
            var opts = parsedArgs.Value;
            var ta = new TemplateApplier(opts.Template, opts.Target);
            ta.Apply();
            return 0;
        }

        class Options
        {
            [Option]
            public string Template { get; set; }

            [Option]
            public string Target { get; set; }
        }
    }
}
