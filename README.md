## Itext FlattenXfaDocument (c#)

This repository contains code that has been taken and modified from the iText project (https://itextpdf.com/). All rights to this code belong to the original authors of iText. This code is not my original work.

The iText project is distributed under the AGPL (Affero General Public License). For more information, please visit the official iText website: AGPL License.

**František Rýsl, 2024**

### Converts (Flatten) XFA PDF files to static PDF.

A license key is required.

PdfXFA only supports MS.NET Framework >= 4.6.1

"Flat XFA" is a term used in relation to PDF documents, particularly those that contain forms. XFA stands for XML Forms Architecture, a technology by Adobe that allows the creation of dynamic forms within PDF files. These forms can include interactive fields, scripts, dynamic content, and more.

When a PDF is labeled as "flat XFA," it means that the form has been "flattened." This typically means that the interactive elements of the form have been removed or converted into static content. In other words, the form is no longer interactive – instead, it is displayed as a static image or text, and users can no longer fill out or edit the fields in the form.

Using flat XFA can be appropriate for archiving or in situations where it is important to preserve the final version of a document without allowing any modifications.

## How to Run the Program
The program is executed with the following command:

program.exe <input_file> <output_file>

The license file must be located in the same directory as `program.exe`.

### Requirements
- .NET Framework 4.8.0 is required to run the program.

