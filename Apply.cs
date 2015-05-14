namespace SsrsRdlManager.Apply
{
    class ConsoleApp
    {
        static void Main(string[] args)
        {
            var opts = new Options();
            var parsedArgs = CommandLine.Parser.Default.ParseArguments(args, opts);
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
