using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public MainPage()
        {
            this.InitializeComponent();
            Books = BookManager.getBooks();
            Covers = BookManager.getCovers();
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // 2个参数 sender 是点击的控件对象 e是控件对象绑定的对象
            var book = (Book)e.ClickedItem;
            SelectedBook.Text = "You selected " + book.Name;
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
    }
}
