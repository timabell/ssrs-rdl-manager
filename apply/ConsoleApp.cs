namespace SsrsRdlManager.Apply
{
    using CommandLine;
    using System.Linq;


    class ConsoleApp
    {
        private const int ReturnError = 1;
        private const int ReturnSuccess = 0;

        static int Main(string[] args)
        {
            var parsedArgs = Parser.Default.ParseArguments<Options>(args);
            if (parsedArgs.Errors.Any())
            {
                return ReturnError;
            }
            var opts = parsedArgs.Value;
            var ta = new TemplateApplier(opts.Template, opts.Target);
            ta.Apply();
            return ReturnSuccess;
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
