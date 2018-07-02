using iTextSharp.text;
using iTextSharp.text.pdf;
using Pedagog_MVC.Models.PomocniModelLista;
using Pedagog_MVC.Models.PomocniModelPopisUc;
using ProjektIdio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Pedagog_MVC.Models.PDF_Reports
{
    public class ListaReport
    {

        public byte[] Podaci { get; private set; }

        public ListaReport(ModelLP ucenik, Skola škola)
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
            p = new Paragraph("LISTA PRAĆENJA - PEDAGOŠKA OBRADA I ANAMNEZA", naslov);
            p.Alignment = Element.ALIGN_CENTER;
            p.SpacingBefore = 30;
            p.SpacingAfter = 30;
            pdfDokument.Add(p);

            p = new Paragraph("ŠKOLA: " + škola.naziv);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("RAZREDNI ODJEL: " + ucenik.Razred.naziv);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("RAZREDNIK: " + ucenik.Razrednik.ime_prezime);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("IME I PREZIME UCENIKA: " + ucenik.ucenik.ime_prezime);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("DAN, MJESEC I GODINA RODENJA:" + ucenik.ucenik.datum);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("MJESTO I DRŽAVA RODENJA: " + ucenik.ucenik.grad);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("ADRESA STANOVANJA: " + ucenik.ucenik.adresa);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 10;
            pdfDokument.Add(p);

            p = new Paragraph("NADNEVAK POCETKA PRACENJA UCENIKA: " + ucenik.listaPracenja.datum);
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 25;
            pdfDokument.Add(p);

            p = new Paragraph("1.PODATCI O OBITELJI ");
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 5;
            pdfDokument.Add(p);

            // tablica sa popisom studenata
            PdfPTable t = new PdfPTable(4); // 4 kolone
            t.WidthPercentage = 100; // širina tablice
            t.SetWidths(new float[] { 3, 8, 6, 6 });

            // dodati zaglavlje
            t.AddCell(VratiCeliju("  ", tekst, true, BaseColor.WHITE,25));
            t.AddCell(VratiCeliju("IME I PREZIME", tekst, false, BaseColor.WHITE,25));
            t.AddCell(VratiCeliju("ZANIMANJE", tekst, true, BaseColor.WHITE,25));
            t.AddCell(VratiCeliju("BROJ TELEFONA", tekst, true, BaseColor.WHITE,25));

            // dodajemo popis obitelji
           
            foreach (Obitelj ob in ucenik.Obitelj)
            {
                t.AddCell(VratiCeliju(ob.vrsta.ToString(), tekst, true, BaseColor.WHITE,40));
                t.AddCell(VratiCeliju(ob.ime_prezime, tekst, false, BaseColor.WHITE,40));
                t.AddCell(VratiCeliju(ob.zanimanje, tekst, true, BaseColor.WHITE,40));
                t.AddCell(VratiCeliju(ob.tel, tekst, true, BaseColor.WHITE,40));
               
            }

            // dodati tablicu na dokument
            pdfDokument.Add(t);


            p = new Paragraph("2.RAZLOG POKRETANJA PRACENJA UCENIKA ");
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 5;
            p.SpacingBefore = 25;
            pdfDokument.Add(p);

            PdfPTable ta = new PdfPTable(1); // 4 kolone
            ta.WidthPercentage = 100; // širina tablice
            ta.SetWidths(new float[] { 50});

    
 
            ta.AddCell(VratiCeliju(ucenik.listaPracenja.razlog, tekst, false, BaseColor.WHITE, 90));
           
  

            // dodati tablicu na dokument
            pdfDokument.Add(ta);

            pdfDokument.NewPage();

            p = new Paragraph("3.PROCJENA UCENIKA ");
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 5;
            p.SpacingBefore = 25;
            pdfDokument.Add(p);

            PdfPTable tab = new PdfPTable(1); // 4 kolone
            tab.WidthPercentage = 100; // širina tablice
            tab.SetWidths(new float[] { 50 });



            tab.AddCell(VratiCeliju("3.1 INICIJALNA PROCJENA - razgovor s učenikom", tekst, false, BaseColor.WHITE, 20));
            tab.AddCell(VratiCeliju(ucenik.listaPracenja.inic_ucenik, tekst, false, BaseColor.WHITE, 90));
            tab.AddCell(VratiCeliju("3.2 INICIJALNA PROCJENA - razgovor s roditeljem/skrbnikom", tekst, false, BaseColor.WHITE, 20));
            tab.AddCell(VratiCeliju(ucenik.listaPracenja.inic_ucenik, tekst, false, BaseColor.WHITE, 90));
            tab.AddCell(VratiCeliju("3.3 INICIJALNA PROCJENA - razgovor s razrednikom", tekst, false, BaseColor.WHITE, 20));
            tab.AddCell(VratiCeliju(ucenik.listaPracenja.inic_razrednik, tekst, false, BaseColor.WHITE, 90));


            // dodati tablicu na dokument
            pdfDokument.Add(tab);

            p = new Paragraph("4.SOCIO-EKONOMSKI UVJETI I ODGOJNO-OBRAZOVNI UTJECAJ ");
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 5;
            p.SpacingBefore = 25;
            pdfDokument.Add(p);

            PdfPTable tabl = new PdfPTable(1); // 4 kolone
            tabl.WidthPercentage = 100; // širina tablice
            tabl.SetWidths(new float[] { 50 });



            tabl.AddCell(VratiCeliju(ucenik.listaPracenja.soc_eko, tekst, false, BaseColor.WHITE, 100));
           


            // dodati tablicu na dokument
            pdfDokument.Add(tabl);

            p = new Paragraph("5.UCENJE I SAZRIJEVANJE");
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 5;
            p.SpacingBefore = 25;
            pdfDokument.Add(p);

            PdfPTable tabli = new PdfPTable(1); // 4 kolone
            tabli.WidthPercentage = 100; // širina tablice
            tabli.SetWidths(new float[] { 50 });



            tabli.AddCell(VratiCeliju(ucenik.listaPracenja.ucenje, tekst, false, BaseColor.WHITE, 100));



            // dodati tablicu na dokument
            pdfDokument.Add(tabli);

            pdfDokument.NewPage();

            p = new Paragraph("6.SOCIJALNE VJESTINE UCENIKA I ODNOS PREMA OBVEZAMA");
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 5;
            p.SpacingBefore = 25;
            pdfDokument.Add(p);

            PdfPTable tablic = new PdfPTable(1); // 4 kolone
            tablic.WidthPercentage = 100; // širina tablice
            tablic.SetWidths(new float[] { 50 });



            tablic.AddCell(VratiCeliju(ucenik.listaPracenja.vjestine, tekst, false, BaseColor.WHITE, 100));



            // dodati tablicu na dokument
            pdfDokument.Add(tablic);

            p = new Paragraph("7.OBRAZOVNA POSTIGNUCA");
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 5;
            p.SpacingBefore = 25;
            pdfDokument.Add(p);

            PdfPTable tablica = new PdfPTable(3); // 4 kolone
            tablica.WidthPercentage = 100; // širina tablice
            tablica.SetWidths(new float[] { 8,5,24 });



            tablica.AddCell(VratiCeliju("ŠKOLSKA GODINA", tekst, false, BaseColor.WHITE, 20));
            tablica.AddCell(VratiCeliju("RAZRED", tekst, false, BaseColor.WHITE, 20));
            tablica.AddCell(VratiCeliju("NAPOMENA", tekst, false, BaseColor.WHITE, 20));


            foreach(Ucenik_obrazovna_postignuca post in ucenik.Postignuca)
            {
                tablica.AddCell(VratiCeliju(post.godina.ToString(), tekst, true, BaseColor.WHITE, 50));
                tablica.AddCell(VratiCeliju(post.razred.ToString(), tekst, false, BaseColor.WHITE, 50));
                tablica.AddCell(VratiCeliju(post.napomena, tekst, true, BaseColor.WHITE, 50));
               

            }

            // dodati tablicu na dokument
            pdfDokument.Add(tablica);


            p = new Paragraph("8.NEPOSREDNI RAD PEDAGOGA");
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 5;
            p.SpacingBefore = 25;
            pdfDokument.Add(p);

            PdfPTable tablica1 = new PdfPTable(2); // 4 kolone
            tablica1.WidthPercentage = 100; // širina tablice
            tablica1.SetWidths(new float[] { 8, 30 });



            tablica.AddCell(VratiCeliju("NADNEVAK", tekst, false, BaseColor.WHITE, 20));
            tablica.AddCell(VratiCeliju("OBLICI I NAČINI RADA S UČENIKOM, RODITELJIMA I DRUGIMA", tekst, false, BaseColor.WHITE, 20));
            


            foreach (Ucenik_neposredni_rad nep in ucenik.NeposredniRadovi)
            {
                tablica1.AddCell(VratiCeliju(nep.datum.ToString(), tekst, true, BaseColor.WHITE, 60));
                tablica1.AddCell(VratiCeliju(nep.biljeska, tekst, false, BaseColor.WHITE, 60));


            }

            // dodati tablicu na dokument
            pdfDokument.Add(tablica1);

           

            p = new Paragraph("9.SURADNJA S INSTITUCIJAMA");
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 5;
            p.SpacingBefore = 25;
            pdfDokument.Add(p);

            PdfPTable tablica2 = new PdfPTable(1); // 4 kolone
            tablica2.WidthPercentage = 100; // širina tablice
            tablica2.SetWidths(new float[] { 50 });



            tablica2.AddCell(VratiCeliju(ucenik.listaPracenja.suradnja, tekst, false, BaseColor.WHITE, 100));



            // dodati tablicu na dokument
            pdfDokument.Add(tablica2);


            p = new Paragraph("10.ZAVRSNI ZAKLJUCAK PRACENJA UCENIKA");
            p.Alignment = Element.ALIGN_LEFT;
            p.SpacingAfter = 5;
            p.SpacingBefore = 25;
            pdfDokument.Add(p);

            PdfPTable tablica3 = new PdfPTable(1); // 4 kolone
            tablica3.WidthPercentage = 100; // širina tablice
            tablica3.SetWidths(new float[] { 50 });



            tablica3.AddCell(VratiCeliju(ucenik.listaPracenja.zakljucak, tekst, false, BaseColor.WHITE, 100));



            // dodati tablicu na dokument
            pdfDokument.Add(tablica3);



            // zatvaranje dokumenta
            pdfDokument.Close();
            Podaci = memStream.ToArray();
        }

        private PdfPCell VratiCeliju(string labela, Font font,
            bool nowrap, BaseColor boja,float visina)
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