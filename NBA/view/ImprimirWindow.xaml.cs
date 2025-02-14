// EXAMEN 1
using NBA.view.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NBA
{
    /// <summary>       
    /// Lógica de interacción para ImprimirWindow.xaml
    /// </summary>
    public partial class ImprimirWindow : Window
    {
        private Grid grid;
        private List<ViewTeam> teams;
        /// <summary>
        /// Constructor para imprimir de manera gráfica el <c><paramref name="grid"/></c> dado
        /// </summary>
        /// <param name="grid">El Grid a imprimir de manera gráfica</param>
        public ImprimirWindow(Grid grid)
        {
            this.grid = grid;
            InitializeComponent();
            FixedDocument fixedDoc = new FixedDocument();
            PageContent pageContent = new PageContent();
            FixedPage fixedPage = new FixedPage();
            var visualBrush = new VisualBrush(grid);
            visualBrush.Stretch = Stretch.Uniform;
            var rectangle = new Rectangle()
            {
                Width = grid.ActualWidth,
                Height = grid.ActualHeight,
                Fill = visualBrush
            };
            fixedPage.Width = grid.ActualWidth;
            fixedPage.Height = grid.ActualHeight;
            fixedPage.Children.Add(rectangle);
            ((IAddChild)pageContent).AddChild(fixedPage);

            fixedDoc.Pages.Add(pageContent);
            documentViewer.Document = fixedDoc;
        }

        // EXAMEN 1
        public ImprimirWindow(List<ViewTeam> teams)
        {
            InitializeComponent();
            this.teams = teams;
              FixedDocument fixedDoc = new FixedDocument();
            // Crear una página para el FixedDocument
            PageContent pageContent = new PageContent();
            FixedPage fixedPage = new FixedPage();
            // Agregar contenido a la FixedPage
            StringReader reader = new StringReader(String.Join("\n", teams));
            TextBlock textBlock = new TextBlock
            {
                Text = reader.ReadToEnd(),
                FontSize = 24,
                Margin = new Thickness(20)
            };
            fixedPage.Children.Add(textBlock);
            ((IAddChild)pageContent).AddChild(fixedPage);
            // Agregar la PageContent al FixedDocument
            fixedDoc.Pages.Add(pageContent);
            // Asignar el FixedDocument al DocumentViewer
            documentViewer.Document = fixedDoc;

        }
        /// <summary>
        /// Manejador de evento para el botón de imprimir
        /// </summary>
        private void Imprimir_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // Imprimir el documento mostrado en el DocumentViewer
                printDialog.PrintDocument(((IDocumentPaginatorSource)
                documentViewer.Document).DocumentPaginator, "Imprimiendo Documento");
            }
        }

        /// <summary>
        /// Manejador de evento para el botón de cancelar
        /// </summary>
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
