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
        List<Books> DBooks = new List<Books>();
        List<Members> DMembers = new List<Members>();
        List<Rents> DRents = new List<Rents>(); 
        public MainWindow()
        {
            InitializeComponent();
            
            ReadAllLines("konyvek.txt");
            Mebber("tagok.txt");
            Rents("kolcsonzesek.txt");
        }


        public void ReadAllLines(string fileName)
        {
            
            /*DataGridXAML.Items.Clear();
            DBooks.Clear();*/
            //int i = 0;

            //Könyvek beolvasása//
            DataGridXAML.ItemsSource = DBooks;

            foreach (var item in File.ReadAllLines(fileName))
            {
                DBooks.Add(new Books(item));
                /*DataGridXAML.Items.Add(DBooks[i]);
                i++;*/
            }
        }

        public void Mebber(string fileName)
        {
            //Tagok beolvasása//
            DataGridXAMLMembers.ItemsSource = DMembers;

            foreach (var item in File.ReadAllLines(fileName))
            {
                DMembers.Add(new Members(item));
            }
        }


        public void Rents(string fileName)
        {
            //Tagok beolvasása//
            DataGridXAMLRent.ItemsSource = DRents;

            foreach (var item in File.ReadAllLines(fileName))
            {
                DRents.Add(new Rents(item));
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Search.Text=="")
            {
                DataGridXAML.ItemsSource = DBooks;
            }
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
            // DataGridXAML.SelectedCells.RemoveAt(DataGridXAML.SelectedIndex));
            DataGridXAML.ItemsSource = DBooks;
            var sasa=DataGridXAML;
            if(sasa.SelectedIndex>=0)
            {
                DBooks.RemoveAt(sasa.SelectedIndex);
                sasa.Items.Refresh();
            }
        }

        private void DeleteRentBT_Click(object sender, RoutedEventArgs e)
        {
            DataGridXAMLRent.ItemsSource = DRents;
            var sasa = DataGridXAMLRent;
            if (sasa.SelectedIndex >= 0)
            {
                DRents.RemoveAt(sasa.SelectedIndex);
                sasa.Items.Refresh();
            }
        }

        private void AddRentBT_Click(object sender, RoutedEventArgs e)
        {
            var Solution = DBooks.Where(book => book.Author.StartsWith(Search.Text) || book.ReleaseDate.StartsWith(Search.Text) || book.Book.StartsWith(Search.Text) || book.Publisher.StartsWith(Search.Text));
            DataGridXAMLRent.ItemsSource = Solution;
            Rents NewRent = new Rents("dd");
            try
            {
                
                NewRent.RentID = DRents.Count + 1;
                NewRent.RBookID = int.Parse(BookIDBT.Text);
                NewRent.RMemberID = int.Parse(MemberIDBT.Text);
                NewRent.StartOfRent = StartOfRentBT.Text;
                NewRent.EndOfRent = EndOfRentBT.Text;
            }
            catch(Exception)
            {
                MessageBox.Show("A megadott karakterlánc helytelen");
            }


                DRents.Add(NewRent);
                DataGridXAMLRent.ItemsSource = DRents;


        }

        private void SearchMember_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchMember.Text == "")
            {
                DataGridXAMLMembers.ItemsSource = DMembers;
            }
            //Kis/Nagy-betű érzékeny
            var filtered = DMembers.Where(member => member.Name.StartsWith(SearchMember.Text) || member.Street.StartsWith(SearchMember.Text) || member.PlaceOfResidence.StartsWith(SearchMember.Text) || member.PostalCode.StartsWith(SearchMember.Text));

            DataGridXAMLMembers.ItemsSource = filtered;
        }

        private void StreetBT_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void AddMemberBT_Click(object sender, RoutedEventArgs e)
        {
            var Solution = DBooks.Where(book => book.Author.StartsWith(Search.Text) || book.ReleaseDate.StartsWith(Search.Text) || book.Book.StartsWith(Search.Text) || book.Publisher.StartsWith(Search.Text));
            DataGridXAMLMembers.ItemsSource = Solution;
            ///

            ///
            Members NewMember = new Members("dx");
            NewMember.MemberID = DMembers.Count + 1;
            NewMember.Street = StreetBT.Text;
            NewMember.PlaceOfResidence = PlaceOfResidssenceBT.Text;
            NewMember.PostalCode = PostalCodeBTM.Text;
            NewMember.BirthDate = BirthDateBT.Text;
            NewMember.Name = NameBT.Text;
            DMembers.Add(NewMember);
            DataGridXAMLMembers.ItemsSource = DMembers;

            /*StreamWriter sw = new StreamWriter("tagok.txt", true);
            sw.WriteLine("{0};{1};{2};{3};{4};{5}", NewMember.MemberID, NewMember.Name, NewMember.BirthDate, NewMember.PostalCode, NewMember.PlaceOfResidence, NewMember.Street);
            sw.Close();
            Mebber("tagok.txt");*/
        }

        private void DeleteMemberBT_Click(object sender, RoutedEventArgs e)
        {
            DataGridXAMLMembers.ItemsSource = DMembers;
            var sasa = DataGridXAMLMembers;
            if (sasa.SelectedIndex >= 0)
            {
                DMembers.RemoveAt(sasa.SelectedIndex);
                sasa.Items.Refresh();
            }
        }

        private void DataGridXAMLSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*Members selected = (Members)DataGridXAMLMembers.SelectedItem;
            if (selected != null)
            {
                NameBT.Text = selected.Name;
                BirthDateBT.Text = selected.BirthDate;
                PostalCodeBTM.Text = selected.PostalCode;
                PlaceOfResidssenceBT.Text = selected.PlaceOfResidence;
                StreetBT.Text = selected.Street;
            }*/
        }
    }
}
