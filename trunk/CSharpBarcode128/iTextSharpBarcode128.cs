using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace CSharpBarcode128
{
    public class iTextSharpBarcode128 : Barcode128
    {
        public string CodeAbove { get; set; }

        public System.Drawing.Bitmap GetBarcodeBMPImage()
        {
            // Create image background, while color.
            System.Drawing.Bitmap bgBuff = new Bitmap(189, 75);
            if (bgBuff == null)
            {
                return null;
            }

            // Get background graphics.
            System.Drawing.Graphics grph = Graphics.FromImage(bgBuff);
            if (grph == null)
            {
                return null;
            }

            // Fill while background color.
            grph.FillRectangle(new SolidBrush(Color.White), 0, 0, bgBuff.Width, bgBuff.Height);

            // Create barcode image.
            System.Drawing.Image imgBarcode = CreateDrawingImage(Color.Black, Color.White);
            if (imgBarcode == null)
            {
                return null;
            }

            // Fill barcode image into background image.
            grph.DrawImage(imgBarcode, 12, 22);

            // New font.
            System.Drawing.Font font = new System.Drawing.Font("Cordia New", 12, FontStyle.Regular);
            System.Drawing.SolidBrush brush = new SolidBrush(Color.Black);

            // Draw string HN (Above)
            grph.DrawString(
                CodeAbove,
                font,
                brush,
                10,
                3
                );

            // Draw string AN + Section (Below)
            grph.DrawString(
                Code,
                font,
                brush,
                10,
                bgBuff.Height - 30
                );

            return bgBuff;
        }

        public string SaveBarcodeToFile()
        {
            // Create image background, while color.
            System.Drawing.Bitmap bgBuff = new Bitmap(175, 95);
            if (bgBuff == null)
            {
                return "";
            }

            // Get background graphics.
            System.Drawing.Graphics grph = Graphics.FromImage(bgBuff);
            if (grph == null)
            {
                return "";
            }

            // Fill while background color.
            grph.FillRectangle(new SolidBrush(Color.White), 0, 0, bgBuff.Width, bgBuff.Height);

            // Create barcode image.
            System.Drawing.Image imgBarcode = CreateDrawingImage(Color.Black, Color.White);
            if (imgBarcode == null)
            {
                return "";
            }

            // Fill barcode image into background image.
            grph.DrawImage(imgBarcode, 25, 30);

            // Draw data string below barcode
            System.Drawing.StringFormat strFormat = new System.Drawing.StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;
            strFormat.Alignment = StringAlignment.Center;

            // Draw string HN (Above)
            grph.DrawString(
                CodeAbove,
                new System.Drawing.Font(FontFactory.TIMES_ROMAN, 7, FontStyle.Regular),
                new SolidBrush(Color.Black),
                5,
                10
                );

            // Draw string AN + Section (Below)
            grph.DrawString(
                Code,
                new System.Drawing.Font(FontFactory.TIMES_ROMAN, 7, FontStyle.Regular), 
                new SolidBrush(Color.Black),
                bgBuff.Width / 2,
                bgBuff.Height - 15,
                strFormat
                );

            // Save stream to file. If the file is exist, delete it.
            string filename = null;
            filename = Code + "_" + DateTime.Now.ToString("dd_MM_yy-HH_mm_ss") + ".bmp";
            bgBuff.Save(filename);
            return filename;
        }

        public System.Drawing.Image GetBarcodeImage()
        {
            return null;
        }
    }
}
