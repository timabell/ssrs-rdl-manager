namespace SsrsRdlManager.Apply
{
    using System;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;


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
            var ns = new XmlNamespaceManager(new NameTable());
            ns.AddNamespace("r", "http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition");

            var templateTextboxes = template.XPathSelectElements("/r:Report/r:Body/r:ReportItems/r:Textbox", ns);

            var targetReportItems = target.XPathSelectElement("/r:Report/r:Body/r:ReportItems", ns);

            // copy them across
            foreach (var templateTextbox in templateTextboxes)
            {
                targetReportItems.Add(templateTextbox);
            }

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
