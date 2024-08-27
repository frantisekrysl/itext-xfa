using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.tool.xml.xtra.xfa;
using iText.Licensing.Base;

namespace iText.Samples.Sandbox.Xfa
{
    public class FlattenXfaDocument
    {
        public static readonly String DEST = "../../../results/xfa/priznani-vzor-xfa-s-podpisem-original-flatten.pdf";

        public static readonly String XFA = "../../../resources/xfa/priznani-vzor-xfa-s-podpisem-original.pdf";

        public static void Main(String[] args)
        {
            // Načtení licenčního souboru pomocí FileStream
            // LicenseKey.LoadLicenseFile(new FileStream(@"../../../license-key-itext/f8252cd70306c4f870d28f921f75dae6f1c0de53c743a6971ef6fc7534770a29.json", FileMode.Open));

            // Načtení licenčního souboru pomocí FileInfo
            LicenseKey.LoadLicenseFile(new FileInfo(@"../../../license-key-itext/f8252cd70306c4f870d28f921f75dae6f1c0de53c743a6971ef6fc7534770a29.json"));

            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();

            new FlattenXfaDocument().ManipulatePdf(DEST);
        }

        protected void ManipulatePdf(String dest)
        {
            MetaData metaData = new MetaData()
                .SetAuthor("iText FR")
                .SetLanguage("CZ")
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
