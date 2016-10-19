using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPDataBindingDemo.BookData;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPDataBindingDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Book> Books; // Mainpage.xmal中 girdview 绑定的数据是必须名字一致"Books"
        private List<BookCover> Covers;
        private Book MyBook;
  


        public MainPage()
        {
           
            this.InitializeComponent();
            Books = BookManager.getBooks();
            Covers = BookManager.getCovers();
            this.MyBook = new Book("Hello","BarryWang");

            MyBook.PropertyChanged += MyBook_PropertyChanged;


        }

        private void MyBook_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Debug.WriteLine("Hello MyBOOK");
           OneBookBinding.Text = MyBook.Author;//回调的时候 更新UI 达到数据改变UI 改变的目的
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 2个参数 sender 是点击的控件对象 e是控件对象绑定的对象
            var book = (Book)e.ClickedItem;
            SelectedBook.Text = "You selected " + book.Name +"\n"+ book.ImageCover;

        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            String name = BookName.Text;
            String auther = BookAuther.Text;

            var img = (BookCover)BookCoverImg.SelectedItem;
            string cover = img.ImageCover;
            Book newBook = new Book();
            //newBook.Author = auther;
            //newBook.Name = name;
            //newBook.ImageCover = cover;
            //Books.Add(newBook);
            Books.Add(new Book { Name = name, Author = auther, ImageCover = cover });
        }

        private void BookCover_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

        }

        private void ChangeBook_Click(object sender, RoutedEventArgs e)
        {
            //整个数组变化 不管个数增加 还是某个项发生改变ObservableCollection 都会通知到UI
            Book newBook = new Book();
            newBook.Author = "Mike";
            newBook.Name = "Mike";
            newBook.ImageCover = @"Assets/bookCovers/book2.jpg";
            var found = Books.FirstOrDefault(x => x.ImageCover == @"Assets/bookCovers/book2.jpg");
            int i = Books.IndexOf(found);
            Books[i] = newBook;
            //newBook.PropertyChanged += NewBook_PropertyChanged;
            //newBook.setAnther("hAHHAHAHAH");
            //MyBook = newBook;

            //这个对象 继承了INotifyPropertyChanged 当对象发生改变时 会调用自定义事件OnPropertyChanged 
            //然后回调到MyBook_PropertyChanged 在这个方法内部我更新了UI 但是绑定的意义就有问题了？？？？？？？
            MyBook.setAnther("MMMMMMMMMMM");

        }

        private void NewBook_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Debug.WriteLine("Hello");
           // OneBookBinding.Text = MyBook.Author;
        }
    }
}
