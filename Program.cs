using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using iTextSharp.tool.xml.xtra.xfa;
using iText.Licensing.Base;

LicenseKey.LoadLicenseFile(new FileStream(@"C:\temp\f8252cd70306c4f870d28f921f75dae6f1c0de53c743a6971ef6fc7534770a29.json", FileMode.Open));


namespace iText.Samples.Sandbox.Xfa
{
    public class FlattenXfaDocument
    {
        public static readonly String DEST = @"C:\temp\xfa-form-flatten.pdf";
        public static readonly String XFA = @"C:\temp\xfa-form.pdf";

        public static void Main(String[] args)
        {
            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();

            new FlattenXfaDocument().ManipulatePdf(DEST);
        }

        protected void ManipulatePdf(String dest)
        {
            MetaData metaData = new MetaData()
                .SetAuthor("iText Samples")
                .SetLanguage("EN")
                .SetSubject("Showing off our flattening skills")
                .SetTitle("Flattened XFA");

            XFAFlattenerProperties flattenerProperties = new XFAFlattenerProperties()
                .SetPdfVersion(XFAFlattenerProperties.PDF_1_7)
                .CreateXmpMetaData()
                .SetTagged()
                .SetMetaData(metaData);

            List<String> javascriptEvents = new List<string>()
            {
                "click"
            };

            XFAFlattener xfaFlattener = new XFAFlattener()
                .SetExtraEventList(javascriptEvents)
                .SetFlattenerProperties(flattenerProperties)
                .SetViewMode(XFAFlattener.ViewMode.SCREEN);

            xfaFlattener.Flatten(new FileStream(XFA, FileMode.Open), new FileStream(dest, FileMode.Create));
        }
    }
}
