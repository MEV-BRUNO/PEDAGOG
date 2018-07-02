using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Pedagog_MVC.Models.PomocniModelPopisUc;
using ProjektIdio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace Pedagog_MVC.Models.PDF_Reports
{
    public class ProtokolReport
    {


        public byte[] Podaci { get; private set; }

        public ProtokolReport(ModelPU ucenik, Skola škola, Razredni_odjel raz, Nastavnik razrednik, Ucenik_protokol_pracenja protokol)
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
            p = new Paragraph("PROTOKOL PROMATRANJA UČENIKA", naslov);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 30;
            p.SpacingAfter = 30;
            pdfDokument.Add(p);

            p = new Paragraph("IME I PREZIME UCENIKA: " + ucenik.ucenik.ime_prezime);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("RAZREDNI ODJEL: " + raz.naziv);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("RAZREDNIK: " + razrednik.ime_prezime);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("NADNEVAK PROMATRANJA: " + protokol.datum);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("SOCIOEKONOMSKI STATUS UCENIKA: " + protokol.soc_eko);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("CILJ PROMATRANJA: " + protokol.cilj);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 25;
            pdfDokument.Add(p);

            // tablica sa popisom studenata
            PdfPTable t = new PdfPTable(2); // 7 kolona
            t.WidthPercentage = 100; // širina tablice
            t.SetWidths(new float[] { 10, 10 });
            t.DefaultCell.FixedHeight = 500f;

            // dodati zaglavlje
            t.AddCell(VratiCeliju(" Spremnost za kontaktiranje: kako se učenik \n odnosi prema drugim učenicima, je li rezerviran, \n povučen, osamljen, spreman za kontakt", tekst, true, BaseColor.WHITE,50f));
            t.AddCell(VratiCeliju(protokol.sposobnost, tekst, false, BaseColor.WHITE,50));
            t.AddCell(VratiCeliju(" Prilagodljivost: popustljiv, vođa, svojeglav", tekst, true, BaseColor.WHITE,50));
            t.AddCell(VratiCeliju(protokol.prilagodljivost, tekst, true, BaseColor.WHITE,50));
            t.AddCell(VratiCeliju(" Odnos prema drugima: bezobziran, pun ljubavi, \n  grub, proracunat, mijenja prijatelje...", tekst, true, BaseColor.WHITE,50));
            t.AddCell(VratiCeliju(protokol.odnos, tekst, true, BaseColor.WHITE,50));
            t.AddCell(VratiCeliju(" Doprinos životu grupe: aktivan, kritizira, napada, \n ogovara, pouzdan je, spreman pomoći", tekst, true, BaseColor.WHITE,50));
            t.AddCell(VratiCeliju(protokol.doprinos, tekst, true, BaseColor.WHITE, 50));
            t.AddCell(VratiCeliju(" Opis promatrane situacije", tekst, true, BaseColor.WHITE, 130));
            t.AddCell(VratiCeliju(protokol.opis, tekst, true, BaseColor.WHITE, 130));
            t.AddCell(VratiCeliju(" Zakljucak \n (podatci o učenju, vanjski i unutarnji utjecaji \n praćenja)", tekst, true, BaseColor.WHITE, 130));
            t.AddCell(VratiCeliju(protokol.zakljucak, tekst, true, BaseColor.WHITE, 130));



            // dodati tablicu na dokument
            pdfDokument.Add(t);

            // zatvaranje dokumenta
            pdfDokument.Close();
            Podaci = memStream.ToArray();
        }

        private PdfPCell VratiCeliju(string labela, Font font,
            bool nowrap, BaseColor boja, float visina)
        {
            PdfPCell c1 = new PdfPCell(new Phrase(labela, font));
            c1.BackgroundColor = boja;
            c1.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
            c1.Padding = 5;
            c1.NoWrap = nowrap;
            c1.FixedHeight = visina;
            return c1;
        }


    }
}