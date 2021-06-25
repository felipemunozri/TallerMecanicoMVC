using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using UTIL;
using UTIL.Models;

namespace MiTallerMecanico.UTIL.PDF
{
    public class PDF: FuncionesPDF
    {

        Document pdfDoc = new Document(iTextSharp.text.PageSize.A4, 15F, 15F, 30F, 30F);
        PdfWriter pdfWriter;

     

      
        #region PDFCotizacion

        public RespuestaModel GeneraPdfCotizacionII(string ruta, EncabezadoDetalle enca, List<DetallePresuModel> deta)
        {
            RespuestaModel respuesta = new RespuestaModel();
            string rutaCompletaArchivo = "";
            rutaCompletaArchivo = ruta + "pdf_informe_" + enca.folioEncabezado + ".pdf";
            pdfWriter = PdfWriter.GetInstance(pdfDoc, new FileStream(rutaCompletaArchivo, FileMode.Create));

            Font FontB6 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 6, iTextSharp.text.Font.BOLD));
            Font FontB7 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 7, iTextSharp.text.Font.BOLD));
            Font FontB8 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.BOLD));

            Font Font12 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 12, iTextSharp.text.Font.BOLD));
            Font Font5 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 5, iTextSharp.text.Font.NORMAL));
            Font Font6 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 6, iTextSharp.text.Font.NORMAL));
            Font Font7 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 7, iTextSharp.text.Font.NORMAL));
            Font Font8 = new Font(FontFactory.GetFont(FontFactory.HELVETICA, 8, iTextSharp.text.Font.NORMAL));


            PdfPCell CVacio = new PdfPCell(new Phrase(""));
            CVacio.Border = 0;

            pdfDoc.Open();

            PdfPCell Col1;
            PdfPCell Col2;
            PdfPCell Col3;
            PdfPCell Col4;
            PdfPCell Col5;
            PdfPCell Col6;
            PdfPCell Col7;
            PdfPCell Col8;
            PdfPCell Col9;
            double ILine;
            int iFila;

            #region Encabezado

            string imagenURL = "c:\\temp\\LogoE.bmp";
            iTextSharp.text.Image imagenBMP;
            imagenBMP = iTextSharp.text.Image.GetInstance(imagenURL);

            //imagenBMP.ScaleToFit(110.0F, 140.0F);
            imagenBMP.ScaleToFit(510.0F, 140.0F);
            imagenBMP.SpacingBefore = 20.0F;
            imagenBMP.SpacingAfter = 10.0F;
            imagenBMP.SetAbsolutePosition(40, 780);
            //imagenBMP.SetAbsolutePosition(40, 780);
            pdfDoc.Add(imagenBMP);


            pdfDoc.Add(new Paragraph("  "));
            pdfDoc.Add(new Paragraph("  "));

            PdfPTable Table1 = new PdfPTable(4);
            Table1.WidthPercentage = 95;
            float[] widths = new float[] {
                2f,
                6f,
                1f,
                5f
                };
            Table1.SetWidths(widths);

            Col1 = new PdfPCell(new Phrase("RAZON SOCIAL", FontB8));
            Col1.Border = 0;
            Table1.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("Agricola y Comercial Navarrete e Hijo", FontB8));
            Col2.Border = 0;
            Table1.AddCell(Col2);
            Col3 = new PdfPCell(new Phrase(" ", FontB8));
            Col3.Border = 0;
            Table1.AddCell(Col3);

            Table1.AddCell(CVacio);
            Col1 = new PdfPCell(new Phrase("RUT", FontB8));
            Col1.Border = 0;
            Table1.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("76337200-6", Font7));
            Col2.Border = 0;
            Table1.AddCell(Col2);
            Table1.AddCell(CVacio);
            Col3 = new PdfPCell(new Phrase(" ", FontB8));
            Col3.Border = 0;
            Table1.AddCell(Col3);

            Col1 = new PdfPCell(new Phrase("GIRO", FontB8));
            Col1.Border = 0;
            Table1.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("Agricola Comercial", Font7));
            Col2.Border = 0;
            Table1.AddCell(Col2);
            Table1.AddCell(CVacio);
            Col3 = new PdfPCell(new Phrase(" ", FontB8));
            Col3.Border = 0;
            Table1.AddCell(Col3);

            Col1 = new PdfPCell(new Phrase("DIRECCION", FontB8));
            Col1.Border = 0;
            Table1.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("Camino Padre Hurtado", Font7));
            Col2.Border = 0;
            Table1.AddCell(Col2);
            Table1.AddCell(CVacio);
            Col3 = new PdfPCell(new Phrase("Fecha                   " + enca.fecha, FontB8));
            Col3.Border = 0;
            Table1.AddCell(Col3);

            Col1 = new PdfPCell(new Phrase("TELEFONO", FontB8));
            Col1.Border = 0;
            Table1.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("(+56)" + "973053456", Font7));
            Col2.Border = 0;
            Table1.AddCell(Col2);
            Table1.AddCell(CVacio);
            Col3 = new PdfPCell(new Phrase("N° Presupuesto      " + enca.folioEncabezado, FontB8));
            Col3.Border = 0;
            Table1.AddCell(Col3);

            Col1 = new PdfPCell(new Phrase("E-MAIL", FontB8));
            Col1.Border = 0;
            Table1.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("navarreteHijo@Gmail.com", Font7));
            Col2.Border = 0;
            Table1.AddCell(Col2);
            Table1.AddCell(CVacio);
            Col3 = new PdfPCell(new Phrase("N° Solicitud         " +  FontB8));
            Col3.Border = 0;
            Table1.AddCell(Col3);


            Col1 = new PdfPCell(new Phrase("ATENCION A", FontB8));
            Col1.Border = 0;
            Table1.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase(enca.Nombre, Font7));
            Col2.Border = 0;
            Table1.AddCell(Col2);
            Table1.AddCell(CVacio);
            Col3 = new PdfPCell(new Phrase("Validez Oferta     15 dias corridos", FontB8));
            Col3.Border = 0;
            Table1.AddCell(Col3);

            Col1 = new PdfPCell(new Phrase(" ", FontB8));
            Col1.Border = 0;
            Table1.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase(enca.rutCliente, Font7));
            Col2.Border = 0;
            Table1.AddCell(Col2);
            Table1.AddCell(CVacio);
            Col3 = new PdfPCell(new Phrase("Plazo de pago      " , FontB8));
            Col3.Border = 0;
            Table1.AddCell(Col3);

            Col1 = new PdfPCell(new Phrase(" ", FontB8));
            Col1.Border = 0;
            Table1.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase( "", Font7));
            Col2.Border = 0;
            Table1.AddCell(Col2);
            Table1.AddCell(CVacio);
            Col3 = new PdfPCell(new Phrase("Forma de pago   " , FontB8));
            Col3.Border = 0;
            Table1.AddCell(Col3);


            pdfDoc.Add(Table1);
            #endregion

            //PintaCuadro(0.7, 410, 710, 530, 770);
            //PintaLinea(0.5, 10, 705, 550, 705);

            #region Cliente
            PdfPTable Table2 = new PdfPTable(4);
            float[] widths2 = new float[] {
                2.2f,
                2f,
                6f,
                6f
            };
            Table2.WidthPercentage = 95;
            Table2.SetWidths(widths2);


            Col1 = new PdfPCell(new Phrase("DATOS EMPRESA", FontB7));
            Col1.Border = 0;
            Table2.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("Razon Social", FontB7));
            Col2.Border = 0;
            Table2.AddCell(Col2);
            Col3 = new PdfPCell(new Phrase("", Font7));
            Col3.Border = 0;
            Table2.AddCell(Col3);
            Col4 = new PdfPCell(new Phrase(" ", Font8));
            Col4.Border = 0;
            Table2.AddCell(Col4);

            Col1 = new PdfPCell(new Phrase(" ", FontB6));
            Col1.Border = 0;
            Table2.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("RUT", FontB7));
            Col2.Border = 0;
            Table2.AddCell(Col2);
            Col3 = new PdfPCell(new Phrase("", Font7));
            Col3.Border = 0;
            Table2.AddCell(Col3);
            Col4 = new PdfPCell(new Phrase("*Favor enviar su Orden de Compra al correo electrónico:", Font6));
            Col4.HorizontalAlignment = Element.ALIGN_CENTER;
            Col4.Border = 0;
            Table2.AddCell(Col4);

            Col1 = new PdfPCell(new Phrase(" ", FontB6));
            Col1.Border = 0;
            Table2.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("Direccion", FontB7));
            Col2.Border = 0;
            Table2.AddCell(Col2);
            Col3 = new PdfPCell(new Phrase("", Font7));
            Col3.Border = 0;
            Table2.AddCell(Col3);
            Col4 = new PdfPCell(new Phrase("odc@emeltec.cl, indicando número de cotización o", Font6));
            Col4.HorizontalAlignment = Element.ALIGN_CENTER;
            Col4.Border = 0;
            Table2.AddCell(Col4);

            Col1 = new PdfPCell(new Phrase(" ", Font8));
            Col1.Border = 0;
            Table2.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("Telefono", FontB7));
            Col2.Border = 0;
            Table2.AddCell(Col2);
            Col3 = new PdfPCell(new Phrase("", Font7));
            Col3.Border = 0;
            Table2.AddCell(Col3);
            Col4 = new PdfPCell(new Phrase("adjuntando PDF de la misma.", Font6));
            Col4.HorizontalAlignment = Element.ALIGN_CENTER;
            Col4.Border = 0;
            Table2.AddCell(Col4);

            Table2.AddCell(CVacio);
            Table2.AddCell(CVacio);
            pdfDoc.Add(Table2);
            #endregion

            #region CabeceraDetalle
            PdfPTable Table3 = new PdfPTable(9);
            float[] widths3 = new float[] {
                1.0F,  /*Item*/
                3.0F,  /*Codigo*/
                7.0F,  /*Descripcion*/
                2.0F,  /*Cantidad*/
                2.0F,  /*MONEDA*/
                3.0F,  /*Venta Emeltec*/
                2.5F,  /*Total venta*/
                1.0F,  /*vacio*/
                3.5F,  /*Plazo Entrega*/
            };
            Table3.WidthPercentage = 95;
            Table3.SetWidths(widths3);
            Col1 = new PdfPCell(new Phrase("Item", FontB8));
            Col1.Border = 0;
            Table3.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("Codigo", FontB8));
            Col2.Border = 0;
            Table3.AddCell(Col2);

            Col3 = new PdfPCell(new Phrase("Descripcion", FontB8));
            Col3.Border = 0;
            Table3.AddCell(Col3);

            Col4 = new PdfPCell(new Phrase("Cantidad", FontB8));
            Col4.Border = 0;
            Table3.AddCell(Col4);

            Col5 = new PdfPCell(new Phrase("MONEDA", FontB8));
            Col5.Border = 0;
            Table3.AddCell(Col5);

            Col6 = new PdfPCell(new Phrase("Venta Emeltec", FontB8));
            Col6.Border = 0;
            Table3.AddCell(Col6);

            Col7 = new PdfPCell(new Phrase("Total venta", FontB8));
            Col7.Border = 0;
            Col7.HorizontalAlignment = 2;
            Table3.AddCell(Col7);

            Col8 = new PdfPCell(new Phrase("   ", FontB8));
            Col8.Border = 0;
            Col8.HorizontalAlignment = 2;
            Table3.AddCell(Col8);

            Col9 = new PdfPCell(new Phrase("Plazo Entrega", FontB8));
            Col9.Border = 0;
            Col9.HorizontalAlignment = 2;
            Table3.AddCell(Col9);

            Table3.AddCell(CVacio);
            pdfDoc.Add(Table3);
            #endregion

            #region Detalle

            int ciclo = deta.Count;
            int item = 1;
            do
            {
                PdfPTable Table4 = new PdfPTable(9);
                float[] widths4 = new float[] {
                    1.0F,  /*Item*/
                    3.0F,  /*Codigo*/
                    7.0F,  /*Descripcion*/
                    2.0F,  /*Cantidad*/
                    2.0F,  /*MONEDA*/
                    3.0F,  /*Venta Emeltec*/
                    2.5F,  /*Total venta*/
                    1.0F,  /*vacio*/
                    3.5F,  /*Plazo Entrega*/
                };

                Table4.WidthPercentage = 95;
                Table4.SetWidths(widths4);

                string codigo = "";
                string producto = "";
                string cantidad = "";
                string precio = "";
                string total = "";
                string moneda = "";
                string fechacierre = "";
                //if (reporteCotizacion.Detalle.Count >= item)
                //{
                //    codigo = reporteCotizacion.Detalle[item - 1].CodProd;
                //    producto = reporteCotizacion.Detalle[item - 1].DetProd;
                //    cantidad = reporteCotizacion.Detalle[item - 1].nvCant.ToString();
                //    precio = "$ " + reporteCotizacion.Detalle[item - 1].nvPrecio.ToString("N0");
                //    total = "$ " + reporteCotizacion.Detalle[item - 1].nvTotLinea.ToString("N0");
                //    fechacierre = reporteCotizacion.Detalle[item - 1].nvFecComprYYYYMMDD2;
                //}
                //else
                //{
                //    moneda = " ";
                //}

                Col1 = new PdfPCell(new Phrase(item.ToString(), Font8));
                Col1.HorizontalAlignment = Element.ALIGN_CENTER;
                Col1.Border = 0;
                Table4.AddCell(Col1);
                Col2 = new PdfPCell(new Phrase(codigo, Font8));
                Col2.Border = 0;
                Table4.AddCell(Col2);

                Col3 = new PdfPCell(new Phrase(producto, Font8));
                Col3.Border = 0;
                Table4.AddCell(Col3);

                Col4 = new PdfPCell(new Phrase(cantidad, Font8));
                Col4.Border = 0;
                Table4.AddCell(Col4);

                Col5 = new PdfPCell(new Phrase(moneda, Font8));
                Col5.Border = 0;
                Table4.AddCell(Col5);

                Col6 = new PdfPCell(new Phrase(precio, FontB8));
                Col6.Border = 0;
                Col6.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                Table4.AddCell(Col6);

                Col7 = new PdfPCell(new Phrase(total, FontB8));
                Col7.Border = 0;
                Col7.HorizontalAlignment = PdfPCell.ALIGN_RIGHT; ;
                Table4.AddCell(Col7);

                Col8 = new PdfPCell(new Phrase("   ", FontB8));
                Col8.Border = 0;
                Col8.HorizontalAlignment = 2;
                Table4.AddCell(Col8);

                Col9 = new PdfPCell(new Phrase(fechacierre, FontB8));
                Col9.Border = 0;
                Col9.HorizontalAlignment = 2;
                Table4.AddCell(Col9);

                Table4.AddCell(CVacio);
                pdfDoc.Add(Table4);
                item += 1;

                double ILineII;
                ILineII = pdfWriter.GetVerticalPosition(true);
                PintaLinea(0.1, 10, Convert.ToInt32(ILineII), 590, Convert.ToInt32(ILineII));
                ILineII += 1;
            }
            while (item <= 20);

            #endregion

            //PintaCuadro(0.7, 410, 710, 530, 770);
            PintaLinea(0.5, 10, 705, 590, 705);  //primera linea
            PintaLinea(0.5, 10, 667, 590, 667);  //segunda linea

            //ini lineas detalle
            PintaLinea(0.5, 10, 621, 590, 621);
            PintaLinea(0.5, 10, 610, 590, 610);
            //fin lineas detalle


            //Observacion
            PdfPTable TableObservacion = new PdfPTable(2);
            float[] widthsObs = new float[] {
                    3.0F,
                    20.0F
                };

            TableObservacion.WidthPercentage = 95;
            TableObservacion.SetWidths(widthsObs);
            Col1 = new PdfPCell(new Phrase("Observaciones: ", Font8));
            Col1.HorizontalAlignment = Element.ALIGN_LEFT;
            Col1.Border = 0;
            TableObservacion.AddCell(Col1);

            Col2 = new PdfPCell(new Phrase(enca.observaciones, Font8));
            Col2.HorizontalAlignment = Element.ALIGN_LEFT;
            Col2.Border = 0;
            TableObservacion.AddCell(Col2);

            pdfDoc.Add(TableObservacion);



            PintaLinea(0.5, 10, 300, 590, 300);
            for (iFila = 1; iFila <= 40; iFila++)
            {
                pdfDoc.Add(new Paragraph(" "));
                ILine = pdfWriter.GetVerticalPosition(true);
                if (ILine < 300)
                {
                    LogUser.agregarLog("ILine" + ILine);
                    break;
                }
            }

            string nvNetoAfecto = enca.neto.ToString("N0");
            #region Totales
            PdfPTable Table5 = new PdfPTable(3);
            float[] widths5 = new float[] {
                3.0F,
                7.0F,
                5.0F
            };
            Table5.WidthPercentage = 56;
            Table5.SetWidths(widths5);

            Table5.AddCell(CVacio);

            Col2 = new PdfPCell(new Phrase("TOTAL NETO (NO INCLUYE IVA): " , Font8));
            Col2.Border = 0;
            Table5.AddCell(Col2);

            Col3 = new PdfPCell(new Phrase("$ " + nvNetoAfecto, FontB8));
            Col3.Border = 0;
            Col3.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            Table5.AddCell(Col3);

            pdfDoc.Add(Table5);
            #endregion

            PdfPTable Table11 = new PdfPTable(1);
            float[] widths11 = new float[] {
                25F
            };
            Table11.WidthPercentage = 95;
            Table11.SetWidths(widths11);

            Col1 = new PdfPCell(new Phrase("Se adjuntan las Condiciones Comerciales y Contractuales, versión 2.4 de fecha 08 de septiembre de 2020, las cuales forman parte integrante de esta cotización y la comp", Font6));
            Col1.Border = 0;
            Table11.AddCell(Col1);
            pdfDoc.Add(Table11);
            #region Pie
            PdfPTable Table6 = new PdfPTable(3);
            float[] widths6 = new float[] {
                3.0F,
                7.0F,
                7.0F
            };
            Table6.WidthPercentage = 95;
            Table6.SetWidths(widths6);

            Table6.AddCell(CVacio);
            Col1 = new PdfPCell(new Phrase("", Font8));
            Col1.Border = 0;
            Table6.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("_________________________", Font8));
            Col2.Border = 0;
            Table6.AddCell(Col2);

            Table6.AddCell(CVacio);
            Col1 = new PdfPCell(new Phrase("", Font8));
            Col1.Border = 0;
            Table6.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("", Font8));
            Col2.Border = 0;
            Table6.AddCell(Col2);

            Table6.AddCell(CVacio);
            Col1 = new PdfPCell(new Phrase("", Font8));
            Col1.Border = 0;
            Table6.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("", Font8));
            Col2.Border = 0;
            Table6.AddCell(Col2);

            Table6.AddCell(CVacio);
            Col1 = new PdfPCell(new Phrase("", Font8));
            Col1.Border = 0;
            Table6.AddCell(Col1);
            Col2 = new PdfPCell(new Phrase("", Font8));
            Col2.Border = 0;
            Table6.AddCell(Col2);

            Table6.AddCell(CVacio);
            Col1 = new PdfPCell(new Phrase("", Font8));
            Col1.Border = 0;
            Table6.AddCell(Col1);

            Col2 = new PdfPCell(new Phrase("", Font8));
            Col2.Border = 0;
            Table6.AddCell(Col2);
            pdfDoc.Add(Table6);
            #endregion

            pdfDoc.Add(new Paragraph("  "));
            pdfDoc.Add(new Paragraph("  "));

            PdfPTable Table7 = new PdfPTable(1);
            float[] widths7 = new float[] {
                20.0F
            };
            Table7.WidthPercentage = 95;
            Table7.SetWidths(widths7);
            string pie = "";
            pie += "El plazo de entrega es informado por nuestro proveedor y es un plazo estimado. Ni EMELTEC ni el proveedor tienen el control ni responsabilidad por las demoras en los";
            pie += " despachos, procesos de desaduanamiento y logística en general.En consecuencia, EMELTEC no será responsable de atrasos.Se deja constancia que, el plazo de entrega,";
            pie += "no ha sido determinante ni esencial para la compra de los productos. Es compromiso y obligación de EMELTEC efectuar la entrega o despacho de los productos al cliente";
            pie += " tan pronto como sea posible, una vez que se encuentren en su bodega.";

            Col1 = new PdfPCell(new Phrase(pie, Font7));
            Table7.AddCell(Col1);
            pdfDoc.Add(Table7);

            //---------- SEGUNDA HOJA
            pdfDoc.Add(new Paragraph("  "));
            pdfDoc.Add(new Paragraph("  "));
            pdfDoc.Add(new Paragraph("  "));
            pdfDoc.Add(new Paragraph("  "));
            pdfDoc.Add(new Paragraph("  "));
            pdfDoc.Add(new Paragraph("  "));

            PdfPTable Tablex = new PdfPTable(1);
            float[] widthsx = new float[] {
                20.0F
            };
            Tablex.WidthPercentage = 95;
            Tablex.SetWidths(widthsx);

            Col1 = new PdfPCell(new Phrase("CONDICIONES COMERCIALES Y CONTRACTUALES", FontB6));
            Col1.Border = 0;
            Col1.HorizontalAlignment = 1;
            Tablex.AddCell(Col1);
            pdfDoc.Add(Tablex);



            //for (int x = 0; x < consideraciones.Count; x++)
            //{

            //    PdfPTable Table8 = new PdfPTable(1);
            //    float[] widths8 = new float[] {
            //    20.0F
            //};
            //    Table8.WidthPercentage = 95;
            //    Table8.SetWidths(widths8);

            //    Col1 = new PdfPCell(new Phrase(consideraciones[x].Titulo, FontB6));
            //    Col1.Border = 0;
            //    Table8.AddCell(Col1);


            //    Col1 = new PdfPCell();

            //    Col1 = new PdfPCell(new Phrase(consideraciones[x].Consideracion, Font6));
            //    Col1.Border = 0;
            //    Table8.AddCell(Col1);
            //    pdfDoc.Add(Table8);
            //}

            pdfDoc.Close();

            respuesta.Verificador = true;
            respuesta.Mensaje = "Reporte generado";
            respuesta.RutaArchivo = rutaCompletaArchivo;
            return respuesta;
        }

        private void PintaLinea(double numGrosor, int X1, int Y1, int X2, int Y2)
        {
            PdfContentByte linea;
            linea = pdfWriter.DirectContent;
            linea.SetLineWidth(numGrosor);
            linea.MoveTo(X1, Y1);
            linea.LineTo(X2, Y2);
            linea.Stroke();
        }
        private void PintaLineaVertical(double numGrosor, int X1, int Y1, int X2, int Y2)
        {
            PdfContentByte linea;
            linea = pdfWriter.DirectContent;
            linea.SetLineWidth(numGrosor);
            linea.MoveTo(X1, X2);
            linea.LineTo(Y1, Y2);
            linea.Stroke();
        }
        private void PintaCuadro(double numGrosor, int X1, int Y1, int X2, int Y2)
        {
            PdfContentByte linea;
            linea = pdfWriter.DirectContent;
            linea.SetLineWidth(numGrosor);
            linea.MoveTo(X1, Y1);
            linea.LineTo(X2, Y1);
            linea.Stroke();

            linea.MoveTo(X2, Y1);
            linea.LineTo(X2, Y2);
            linea.Stroke();

            linea.MoveTo(X2, Y2);
            linea.LineTo(X1, Y2);
            linea.Stroke();

            linea.MoveTo(X1, Y2);
            linea.LineTo(X1, Y1);
            linea.Stroke();
            pdfDoc.Add(Chunk.NEWLINE);
        }
        #endregion
    }
}