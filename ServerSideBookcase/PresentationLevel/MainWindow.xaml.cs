using System.Collections.Generic;
using System.Linq;
using System.Windows;
using PresentationLevel.POCO;
using DataAccessLevel.Managers;
namespace PresentationLevel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Book> _books;
        private FileBookManager _manager;

        private bool GridsIsVisible
        {
            set
            {
                if (value)
                {
                    
                    BooksListDataGrid.Visibility = Visibility.Visible;
                    BookDetailsAndRemoveGrid.Visibility = Visibility.Visible;
                }
                else
                {
                    BooksListDataGrid.Visibility = Visibility.Hidden;
                    BookDetailsAndRemoveGrid.Visibility = Visibility.Hidden;
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            _books = new List<Book>();
            _manager = new FileBookManager();
            LoadData();
            InitiateGrids();
        }

        private void InitiateGrids()
        {
            if (_books.Count==0)
            {
                GridsIsVisible = false;
                return;
            }

            var booksNames = new List<string>();
            foreach (var book in _books)
            {
                booksNames.Add(book.Name);
            }

            BooksListDataGrid.ItemsSource = booksNames;
            SelectFirstBookFromList();
            
            
        }

        private void SelectFirstBookFromList()
        {
            if (_books.Count==0)
                return;
            BookNameLabel.Content = _books[0].Name;
            BookAuthorLabel.Content = _books[0].Author;
            BookDescriptionLabel.Content = _books[0].Description;
            BookTitleImage.Source = _books[0].TitleImage;
        }

        private void LoadData()
        {
            BooksListLoader booksListLoader = new BooksListLoader(_manager);
            _books = booksListLoader.GetBooks();
        }
    }
}
