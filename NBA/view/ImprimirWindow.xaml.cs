using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    namespace NBA.view
    {
        /// <summary>
        /// Lógica de interacción para ImprimirWindow.xaml
        /// </summary>
        public partial class ImprimirWindow : Window
        {
            private Grid grid;
            public ImprimirWindow(Grid grid)
            {
                this.grid = grid;
                InitializeComponent();
                // Crear un FixedDocument
                FixedDocument fixedDoc = new FixedDocument();
                // Crear una página para el FixedDocument
                PageContent pageContent = new PageContent();
                FixedPage fixedPage = new FixedPage();
                var visualBrush = new VisualBrush(grid);
                var rectangle = new Rectangle
                {
                    Width = grid.ActualWidth,
                    Height = grid.ActualHeight,
                    Fill = visualBrush
                };
                fixedPage.Children.Add(rectangle);
                ((IAddChild)pageContent).AddChild(fixedPage);
                pageContent.Width = grid.ActualWidth;
                pageContent.Height = grid.ActualHeight;
                fixedDoc.Pages.Add(pageContent);
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintQueue = new PrintQueue(new PrintServer(), "Microsoft Print to PDF") ;
                printDialog.PrintTicket.PageMediaSize = new PageMediaSize(grid.ActualWidth, grid.ActualHeight);
                printDialog.PrintTicket. PageOrientation = PageOrientation. Landscape;
                printDialog.PrintVisual(grid, "Grid a PDF");
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
