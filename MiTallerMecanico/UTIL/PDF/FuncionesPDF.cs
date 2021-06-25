using System;
using System.Collections.Generic;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web;

namespace MiTallerMecanico.UTIL.PDF
{
    public class FuncionesPDF
    {

        public PdfPCell creaColumna(string texto, PDFOpciones opciones)
        {
            opciones = new PDFOpciones()
            {
                TamanoBorde = opciones.TamanoBorde != -99999 ? opciones.TamanoBorde : 0f,
                Fuente = opciones.Fuente != null ? opciones.Fuente : new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK),
                AlineacionHorizontal = opciones.AlineacionHorizontal != null ? opciones.AlineacionHorizontal : PdfAlineacionHorizontalPdf.Centrado,
                TipoColor = opciones.TipoColor != null ? opciones.TipoColor : PdfTipoColorFondo.ActividadN1,
            };

            PdfPCell retorno = new PdfPCell(new Phrase(texto, opciones.Fuente));
            retorno.BorderWidth = opciones.TamanoBorde;
            BaseColor baseColor = new BaseColor(218, 218, 218);
            retorno.BackgroundColor = baseColor;

            retorno.HorizontalAlignment = (int)opciones.AlineacionHorizontal;

            return retorno;
        }
        public PdfPCell creaCelda(string texto, PDFOpciones opciones)
        {
            opciones = new PDFOpciones()
            {
                TamanoBorde = opciones.TamanoBorde != -99999 ? opciones.TamanoBorde : 0.5f,
                Fuente = opciones.Fuente != null ? opciones.Fuente : new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK),
                AlineacionHorizontal = opciones.AlineacionHorizontal != null ? opciones.AlineacionHorizontal : PdfAlineacionHorizontalPdf.Izquierda,
                TipoColor = opciones.TipoColor != null ? opciones.TipoColor : PdfTipoColorFondo.SinColor,
            };

            PdfPCell retorno = new PdfPCell(new Phrase(texto, opciones.Fuente));
            retorno.BorderWidth = opciones.TamanoBorde;
            BaseColor baseColor = null;

            retorno.HorizontalAlignment = (int)opciones.AlineacionHorizontal;

            switch (opciones.TipoColor)
            {
                case PdfTipoColorFondo.SinColor: { baseColor = null; } break;
                case PdfTipoColorFondo.ActividadMaestra: { baseColor = new BaseColor(164, 164, 164); } break;
                case PdfTipoColorFondo.ActividadN1: { baseColor = new BaseColor(218, 218, 218); } break;
                case PdfTipoColorFondo.ActividadN2: { baseColor = new BaseColor(255, 255, 255); } break;
            }

            retorno.BackgroundColor = baseColor;

            return retorno;
        }
    }
    public enum PdfTipoColorFondo
    {
        SinColor = 1,
        ActividadMaestra = 2,
        ActividadN1 = 3,
        ActividadN2 = 4
    }

    public enum PdfAlineacionHorizontalPdf
    {
        Centrado = Element.ALIGN_CENTER,
        Izquierda = Element.ALIGN_LEFT,
        Derecha = Element.ALIGN_RIGHT
    }

    public class PDFOpciones
    {
        public PDFOpciones()
        {
            this.TamanoBorde = -99999;
            this.TipoColor = null;
            this.AlineacionHorizontal = null;
            this.Fuente = null;
        }

        public float TamanoBorde { get; set; }
        public PdfTipoColorFondo? TipoColor { get; set; }
        public PdfAlineacionHorizontalPdf? AlineacionHorizontal { get; set; }
        public iTextSharp.text.Font Fuente { get; set; }
    }
}