using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace Konyvescucc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Books> DBooks;
        public MainWindow()
        {
            InitializeComponent();
            
            ReadAllLines("konyvek.txt");
            Books konyvek = new Books("xd");
           
            
            /*foreach (var item in DBooks)
            {
                konyvek.BookID = item.BookID;
                konyvek.Book = item.Book;
                konyvek.Author = item.Publisher;
                konyvek.ReleaseDate = item.ReleaseDate;
                konyvek.Publisher = item.Publisher;
                konyvek.Rent = item.Rent;
                DataGridXAML.Items.Add(konyvek);
            }

            /*konyvek.BookID = 1;
            konyvek.Book = "Csodafasz";
            konyvek.Author = "Toth Zalan";
            konyvek.ReleaseDate = "2021.03.11";
            konyvek.Publisher = "Kitalalt Kiado";
            konyvek.Rent = true;*/
            
        }


        public void ReadAllLines(string FileName)
        {
            DBooks = new List<Books>();
            //int i = 0;
            foreach (var item in File.ReadAllLines(FileName))
            {
                DBooks.Add(new Books(item));

                /*DataGridXAML.Items.Add(DBooks[i]);
                i++;*/
            }
            DataGridXAML.ItemsSource = DBooks;
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Kis/Nagy-betű érzékeny
            var filtered = DBooks.Where(book => book.Author.StartsWith(Search.Text) || book.ReleaseDate.StartsWith(Search.Text)|| book.Book.StartsWith(Search.Text) || book.Publisher.StartsWith(Search.Text));

            DataGridXAML.ItemsSource = filtered;
        }

        private void AddBT_Click(object sender, RoutedEventArgs e)
        {
            // HIBAKEZELÉS: //
            // A solution nevű változót azért hoztam létre, és állítottam be ItemsSource-nak, mert ha hozzáadom a NewBook-ot a DataGridXAML-hez miközben az ItemsSource már a DBooks, hiba következik be.
            var Solution = DBooks.Where(book => book.Author.StartsWith(Search.Text) || book.ReleaseDate.StartsWith(Search.Text) || book.Book.StartsWith(Search.Text) || book.Publisher.StartsWith(Search.Text));
            DataGridXAML.ItemsSource = Solution;
            ///
            
            ///
            Books NewBook = new Books("xd");
            NewBook.BookID = DBooks.Count + 1;
            NewBook.Author = AuthorBT.Text;
            NewBook.ReleaseDate = ReleaseDateBT.Text;
            NewBook.Book = BookBT.Text;
            NewBook.Publisher = PublisherBT.Text;
            NewBook.Rent = true;
            DBooks.Add(NewBook);
            DataGridXAML.ItemsSource = DBooks;
        }

        private void DeleteBT_Click(object sender, RoutedEventArgs e)
        {
            //DataGridXAML.SelectedCells.RemoveAt(DataGridXAML.SelectedCells.Column);
        }
    }
}
