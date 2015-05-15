namespace SsrsRdlManager.Apply
{
    using System;
    using System.Xml.Linq;

    public class TemplateApplier
    {
        private readonly string _templateFile;
        private readonly string _targetFile;

        public TemplateApplier(string templateFile, string targetFile)
        {
            _templateFile = templateFile;
            _targetFile = targetFile;
        }

        public void Apply()
        {
            var template = LoadRdl(_templateFile);
            // open the destination rdl file
            var target = LoadRdl(_targetFile);
            // find object matches on id
            // copy them across
            // write & close
        }

        private XDocument LoadRdl(string path)
        {
            var doc = XDocument.Load(path);

            if (doc.Root == null)
            {
                throw new Exception(string.Format("Loaded XDocument Root is null. File: {0}", path));
            }
            return doc;
        }
    }
}
