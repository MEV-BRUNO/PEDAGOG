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
using Pedagog_MVC.Models.PomocniModelOsobni;

namespace Pedagog_MVC.Models.PDF_Reports
{
    public class OsobniReport
    {


        public byte[] Podaci { get; private set; }

        public OsobniReport(ModelOS ucenik, Skola škola, Razredni_odjel raz, List<Obitelj> obitelj)
        {
            // generiranje pdf-a

            
            // mjere u iText# -> point = 1/72 inch
            Document pdfDokument = new Document(
                PageSize.A4, 50, 50, 20, 50);

            MemoryStream memStream = new MemoryStream();
            PdfWriter.GetInstance(pdfDokument, memStream).
                CloseStream = false;

            // otvaranje dokumenta
            pdfDokument.Open();

            

            // fontovi
            BaseFont font = BaseFont.CreateFont(BaseFont.HELVETICA,
                BaseFont.CP1250, false);
            Font header = new Font(font, 12, Font.NORMAL, BaseColor.DARK_GRAY);
            Font naslov = new Font(font, 14, Font.BOLDITALIC, BaseColor.BLACK);
            Font tekst = new Font(font, 10, Font.NORMAL, BaseColor.BLACK);


          

            // header
            Paragraph p = new Paragraph("IZVJEŠTAJ", header);
            pdfDokument.Add(p);

            // naslov 
            p = new Paragraph("BILJESKE O RADU S UCENIKOM", naslov);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 30;
            p.SpacingAfter = 30;
            pdfDokument.Add(p);

            p = new Paragraph("SKOLA: " + škola.naziv);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("IME I PREZIME UCENIKA: " + ucenik.ucenik.ime_prezime);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("RAZREDNI ODJEL: " + raz.naziv);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            

            p = new Paragraph("DAN, MJESEC I DRZAVA RODENJA: " + ucenik.ucenik.datum);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("MJESTO I DRZAVA RODENJA: " + ucenik.ucenik.grad);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("ADRESA STANOVANJA: " + ucenik.ucenik.adresa);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("NADNEVAK POCETKA PRACENJA UCENIKA: " + ucenik.biljeska.datum_pocetak);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 25;
            pdfDokument.Add(p);

            p = new Paragraph("1.PODATCI O OBITELJI ");
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 5;
            pdfDokument.Add(p);


            // tablica sa popisom studenata
            PdfPTable t = new PdfPTable(4); // 7 kolona
            t.WidthPercentage = 100; // širina tablice
            t.SetWidths(new float[] { 4,10, 6,6 });
            

            // dodati zaglavlje
            t.AddCell(VratiCeliju("", tekst, true, BaseColor.WHITE, 20));
            t.AddCell(VratiCeliju("IME I PREZIME", tekst, true, BaseColor.WHITE, 20));
            t.AddCell(VratiCeliju("ZANIMANJE", tekst, true, BaseColor.WHITE, 20));
            t.AddCell(VratiCeliju("BROJ TELEFONA", tekst, true, BaseColor.WHITE, 20));

            foreach (Obitelj ob in obitelj)
            {
                t.AddCell(VratiCeliju(ob.vrsta.ToString(), tekst, true, BaseColor.WHITE, 40));
                t.AddCell(VratiCeliju(ob.ime_prezime, tekst, false, BaseColor.WHITE, 40));
                t.AddCell(VratiCeliju(ob.zanimanje, tekst, true, BaseColor.WHITE, 40));
                t.AddCell(VratiCeliju(ob.tel, tekst, true, BaseColor.WHITE, 40));

            }


            // dodati tablicu na dokument
            pdfDokument.Add(t);

            p = new Paragraph("2.INICIJALNI PODACI O UCENIKU ");
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 5;
            p.SpacingBefore = 25;
            pdfDokument.Add(p);

            PdfPTable tab = new PdfPTable(1); // 4 kolone
            tab.WidthPercentage = 100; // širina tablice
            tab.SetWidths(new float[] { 50 });

            tab.AddCell(VratiCeliju(ucenik.biljeska.inicijalni_podaci, tekst, false, BaseColor.WHITE, 100));


            pdfDokument.Add(tab);

            pdfDokument.NewPage();
           
            PdfPTable tab1 = new PdfPTable(2); // 2 kolone
            tab1.WidthPercentage = 100; // širina tablice
            tab1.SetWidths(new float[] { 10,50 });

            tab1.AddCell(VratiCeliju("MJESEC", tekst, false, BaseColor.WHITE, 20));
            tab1.AddCell(VratiCeliju("MJESECNA BILJESKA", tekst, false, BaseColor.WHITE, 20));

            tab1.AddCell(VratiCeliju("SIJECANJ", tekst, false, BaseColor.WHITE, 90));
            tab1.AddCell(VratiCeliju(ucenik.biljeska.biljeska_1, tekst, false, BaseColor.WHITE, 90));

            tab1.AddCell(VratiCeliju("VELJACA", tekst, false, BaseColor.WHITE, 90));
            tab1.AddCell(VratiCeliju(ucenik.biljeska.biljeska_2, tekst, false, BaseColor.WHITE, 90));

            tab1.AddCell(VratiCeliju("OZUJAK", tekst, false, BaseColor.WHITE, 90));
            tab1.AddCell(VratiCeliju(ucenik.biljeska.biljeska_3, tekst, false, BaseColor.WHITE, 90));

            tab1.AddCell(VratiCeliju("TRAVANJ", tekst, false, BaseColor.WHITE, 90));
            tab1.AddCell(VratiCeliju(ucenik.biljeska.biljeska_4, tekst, false, BaseColor.WHITE, 90));
            tab1.AddCell(VratiCeliju("SVIBANJ", tekst, false, BaseColor.WHITE, 90));
            tab1.AddCell(VratiCeliju(ucenik.biljeska.biljeska_5, tekst, false, BaseColor.WHITE, 90));

            tab1.AddCell(VratiCeliju("LIPANJ", tekst, false, BaseColor.WHITE, 90));
            tab1.AddCell(VratiCeliju(ucenik.biljeska.biljeska_6, tekst, false, BaseColor.WHITE, 90));

            tab1.AddCell(VratiCeliju("SRPANJ", tekst, false, BaseColor.WHITE, 90));
            tab1.AddCell(VratiCeliju(ucenik.biljeska.biljeska_7, tekst, false, BaseColor.WHITE, 90));

            tab1.AddCell(VratiCeliju("KOLOVOZ", tekst, false, BaseColor.WHITE, 90));
            tab1.AddCell(VratiCeliju(ucenik.biljeska.biljeska_8, tekst, false, BaseColor.WHITE, 90));

            tab1.AddCell(VratiCeliju("RUJAN", tekst, false, BaseColor.WHITE, 90));
            tab1.AddCell(VratiCeliju(ucenik.biljeska.biljeska_9, tekst, false, BaseColor.WHITE, 90));

            tab1.AddCell(VratiCeliju("LISTOPAD", tekst, false, BaseColor.WHITE, 90));
            tab1.AddCell(VratiCeliju(ucenik.biljeska.biljeska_10, tekst, false, BaseColor.WHITE, 90));

            tab1.AddCell(VratiCeliju("STUDENI", tekst, false, BaseColor.WHITE, 90));
            tab1.AddCell(VratiCeliju(ucenik.biljeska.biljeska_11, tekst, false, BaseColor.WHITE, 90));

            tab1.AddCell(VratiCeliju("PROSINAC", tekst, false, BaseColor.WHITE, 90));
            tab1.AddCell(VratiCeliju(ucenik.biljeska.biljeska_12, tekst, false, BaseColor.WHITE, 90));

            tab1.AddCell(VratiCeliju("ZAKLJUCCI:", tekst, false, BaseColor.WHITE, 90));
            tab1.AddCell(VratiCeliju(ucenik.biljeska.zakljucak, tekst, false, BaseColor.WHITE, 90));



            pdfDokument.Add(tab1);

            

            PdfPTable tab2 = new PdfPTable(1); // 4 kolone
            tab2.WidthPercentage = 100; // širina tablice
            tab2.SetWidths(new float[] { 50 });
            tab2.SpacingBefore = 15;

            tab2.AddCell(VratiCeliju("Ostala zapazanja: " + ucenik.biljeska.zapazanja, tekst, false, BaseColor.WHITE, 200));


            pdfDokument.Add(tab2);

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