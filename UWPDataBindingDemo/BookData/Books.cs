using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UWPDataBindingDemo.BookData;

namespace UWPDataBindingDemo.BookData
{
    public class Book : INotifyPropertyChanged

    {
        public string ImageCover { get; set; }
        public string Name { get; set; }
        public string Author { get; set;}


        public void setAnther(string auther)
        {
            Author = auther;
            OnPropertyChanged();
        } 

        public Book(String name, string author)
        {
            Name = name;
            Author = author;
          
        }

        public Book()
        {
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                Debug.WriteLine("hello notification");
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    public class BookCover
    {
        public string ImageCover { get; set; }
    }
    public class BookManager
    {

        public static ObservableCollection<Book> getBooks()
        {
            var bookList = new ObservableCollection<Book>();
            bookList.Add(new Book { ImageCover = "/Assets/bookCovers/book1.jpg", Name = "ADAPTIVE WEB DESIGN", Author = "Aaron Gustafson" });
            bookList.Add(new Book { ImageCover = @"Assets/bookCovers/book2.jpg", Name = "The Doctor In War", Author = "Woods Hutchinson" });
            bookList.Add(new Book { ImageCover = @"Assets/bookCovers/book3.jpg", Name = "Mysterious", Author = "John Doe" });
            bookList.Add(new Book { ImageCover = @"Assets/bookCovers/book4.jpg", Name = "Harry Potter", Author = "J.K. Rowling" });
            bookList.Add(new Book { ImageCover = @"Assets/bookCovers/book5.jpg", Name = "The ICEBERG", Author = "Tove Jansson" });
            bookList.Add(new Book { ImageCover = @"Assets/bookCovers/book6.jpg", Name = "The Cobra", Author = "Mike X X Ma" });
            bookList.Add(new Book { ImageCover = @"Assets/bookCovers/book7.jpg", Name = "The MAZE Runner", Author = "James Dashner" });
            bookList.Add(new Book { ImageCover = @"Assets/bookCovers/book8.jpg", Name = "1984", Author = "George Orwell" });
            return bookList;
        }
        public static List<BookCover> getCovers()
        {
            var bookCovers = new List<BookCover>();
            bookCovers.Add(new BookCover { ImageCover = @"Assets/bookCovers/book1.jpg" });
            bookCovers.Add(new BookCover { ImageCover = @"Assets/bookCovers/book2.jpg" });
            bookCovers.Add(new BookCover { ImageCover = @"Assets/bookCovers/book3.jpg" });
            bookCovers.Add(new BookCover { ImageCover = @"Assets/bookCovers/book4.jpg" });
            bookCovers.Add(new BookCover { ImageCover = @"Assets/bookCovers/book5.jpg" });
            bookCovers.Add(new BookCover { ImageCover = @"Assets/bookCovers/book6.jpg" });
            bookCovers.Add(new BookCover { ImageCover = @"Assets/bookCovers/book7.jpg" });
            bookCovers.Add(new BookCover { ImageCover = @"Assets/bookCovers/book8.jpg" });
            return bookCovers;
        }

    }
}
