using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.tool.xml.xtra.xfa;
using iText.Licensing.Base;

namespace iText.Samples.Sandbox.Xfa
{
    public class FlattenXfaDocument
    {
        public static void Main(String[] args)
        {
            // Ověření, zda byly zadány správné parametry
            if (args.Length != 2)
            {
                Console.WriteLine("Použití: program.exe <vstupní_soubor> <výstupní_soubor>");
                return;
            }

            String vstupniSoubor = args[0];
            String vystupniSoubor = args[1];

            // Načtení licenčního souboru
            // LicenseKey.LoadLicenseFile(new FileInfo(@"../../../license-key-itext/5f94c9ae8c7d035088bc709875102cdf66a50d2db0386cefa499650fa663f158.json"));
            LicenseKey.LoadLicenseFile(new FileInfo(@"5f94c9ae8c7d035088bc709875102cdf66a50d2db0386cefa499650fa663f158.json"));

            FileInfo file = new FileInfo(vystupniSoubor);
            file.Directory.Create();

            // Spuštění manipulace PDF
            new FlattenXfaDocument().ManipulatePdf(vstupniSoubor, vystupniSoubor);
        }

        protected void ManipulatePdf(String vstupniSoubor, String vystupniSoubor)
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

            // Provádí zploštění XFA souboru
            xfaFlattener.Flatten(new FileStream(vstupniSoubor, FileMode.Open), new FileStream(vystupniSoubor, FileMode.Create));
        }
    }
}
