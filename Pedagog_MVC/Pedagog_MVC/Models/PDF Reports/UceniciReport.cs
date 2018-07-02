using iTextSharp.text;
using iTextSharp.text.pdf;
using Pedagog_MVC.Models.PomocniModelPopisUc;
using ProjektIdio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models
{
    public class UceniciReport
    {


        public byte[] Podaci { get; private set; }

        public UceniciReport(List<ModelPU> ucenici, Skola škola,Razredni_odjel raz, Nastavnik razrednik)
        {
            // generiranje pdf-a

            // novi dokument, sa veličinom stranice i marginama
            // mjere u iText# -> point = 1/72 inch
            Document pdfDokument = new Document(
                PageSize.A4, 50, 50, 20, 50);

            MemoryStream memStream = new MemoryStream();
            PdfWriter.GetInstance(pdfDokument, memStream).
                CloseStream = false;

            // otvaranje dokumenta
            pdfDokument.Open();

            // dodamo neki sadržaj za test
            //pdfDokument.Add(new Paragraph("Test 123..."));

            // fontovi
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA,
                BaseFont.CP1250, false);
            Font header = new Font(font, 12, Font.NORMAL, BaseColor.DARK_GRAY);
            Font naslov = new Font(font, 14, Font.BOLDITALIC, BaseColor.BLACK);
            Font tekst = new Font(font, 10, Font.NORMAL, BaseColor.BLACK);
         

            // logo
            /*
            var logo = iTextSharp.text.Image.GetInstance(
                HostingEnvironment.MapPath("~/Content/MEV_LOGO.jpg"));
            logo.Alignment = Element.ALIGN_LEFT;
            logo.ScaleAbsoluteHeight(100);
            logo.ScaleAbsoluteWidth(100);
            pdfDokument.Add(logo);*/

            // header
            Paragraph p = new Paragraph("IZVJEŠTAJ", header);
            pdfDokument.Add(p);

            // naslov 
            p = new Paragraph("Popis učenika u razrednom odjelu", naslov);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 30;
            p.SpacingAfter = 30;
            pdfDokument.Add(p);

            p = new Paragraph("Škola: "+ škola.naziv);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("Razredni odjel: " + raz.naziv);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("Razrednik: " + razrednik.ime_prezime);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 25;
            pdfDokument.Add(p);

            // tablica sa popisom studenata
            PdfPTable t = new PdfPTable(7); // 7 kolona
            t.WidthPercentage = 100; // širina tablice
            t.SetWidths(new float[] { 3, 6, 4, 5,10,6,8 });

            // dodati zaglavlje
            t.AddCell(VratiCeliju("R.br.", tekst, true, BaseColor.WHITE));
            t.AddCell(VratiCeliju("Ime i prezime učenika", tekst, false, BaseColor.WHITE));
            t.AddCell(VratiCeliju("Roditelji", tekst, true, BaseColor.WHITE));
            t.AddCell(VratiCeliju("Adresa", tekst, true, BaseColor.WHITE));
            t.AddCell(VratiCeliju("Ponavlja razred DA/NE", tekst, true, BaseColor.WHITE));
            t.AddCell(VratiCeliju("Putnik  DA/NE", tekst, true, BaseColor.WHITE));
            t.AddCell(VratiCeliju("Posebna zaduženja", tekst, true, BaseColor.WHITE));

            // dodajemo popis studenata
            int i = 1;
            foreach (ModelPU ucenik in ucenici)
            {
                t.AddCell(VratiCeliju((i++).ToString(), tekst, true, BaseColor.WHITE));
                t.AddCell(VratiCeliju(ucenik.ucenik.ime_prezime, tekst, false, BaseColor.WHITE));
                t.AddCell(VratiCeliju("-", tekst, true, BaseColor.WHITE));
                t.AddCell(VratiCeliju(ucenik.ucenik.adresa, tekst, true, BaseColor.WHITE));
                if (ucenik.godUcenik.ponavlja == 1)
                {
                    t.AddCell(VratiCeliju("DA", tekst, true, BaseColor.WHITE));
                }
                else
                {
                    t.AddCell(VratiCeliju("NE", tekst, true, BaseColor.WHITE));
                }

                if (ucenik.godUcenik.putnik == 1)
                {
                    t.AddCell(VratiCeliju("DA", tekst, true, BaseColor.WHITE));
                }
                else
                {
                    t.AddCell(VratiCeliju("NE", tekst, true, BaseColor.WHITE));
                }

                t.AddCell(VratiCeliju(ucenik.godUcenik.zaduzenja, tekst, true, BaseColor.WHITE));
            }

            // dodati tablicu na dokument
            pdfDokument.Add(t);

            // zatvaranje dokumenta
            pdfDokument.Close();
            Podaci = memStream.ToArray();
        }

        private PdfPCell VratiCeliju(string labela, Font font,
            bool nowrap, BaseColor boja)
        {
            PdfPCell c1 = new PdfPCell(new Phrase(labela, font));
            c1.BackgroundColor = boja;
            c1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            c1.Padding = 5;
            c1.NoWrap = nowrap;
            return c1;
        }


    }
}