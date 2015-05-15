namespace SsrsRdlManager.Apply
{
    public class TemplateApplier
    {
        private string _templateFile;
        private string _targetFile;

        public TemplateApplier(string templateFile, string targetFile)
        {
            _templateFile = templateFile;
            _targetFile = targetFile;
        }

        public void Apply()
        {
            // open the source rdl file
            // open the destination rdl file
            // find object matches on id
            // copy them across
            // write & close
        }
    }
}
