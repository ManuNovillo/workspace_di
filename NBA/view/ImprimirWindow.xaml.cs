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

    namespace NBA
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

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintQueue = new PrintQueue(new PrintServer(), "Microsoft Print to PDF") ;
                printDialog.PrintTicket.PageMediaSize = new PageMediaSize(grid.ActualWidth, grid.ActualHeight);
                printDialog.PrintTicket. PageOrientation = PageOrientation.Landscape;
                printDialog.PrintVisual(grid, "NBA pdf");
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
