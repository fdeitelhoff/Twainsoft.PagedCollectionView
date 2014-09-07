using System.Collections.ObjectModel;
using System.Windows;
using Twainsoft.PCV.Data;
using Twainsoft.PCV.WPF.TestApplication.Model;

namespace Twainsoft.PCV.WPF.TestApplication
{
    public partial class MainWindow
    {
        private PagedCollectionView ArticleCollectionView { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            var data = new ObservableCollection<Article> { new Article("Test 1", "Author 1", 3),
                new Article("Test 2", "Author 2", 3.3f), new Article("Test 3", "Author 3", 17.9f) };

            ArticleCollectionView = new PagedCollectionView(data) { PageSize = 1 };

            DataGrid.ItemsSource = ArticleCollectionView;
        }

        private void SearchOnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Search.Text))
            {
                ArticleCollectionView.Filter = null;
            }
            else
            {
                ArticleCollectionView.Filter += delegate(object item)
                {
                    var article = item as Article;

                    if (article == null)
                    {
                        return false;
                    }

                    return article.Author.ToLower().Contains(Search.Text.ToLower())
                           || article.Name.ToLower().Contains(Search.Text.ToLower());
                };
            }
        }

        private void LastPageOnClick(object sender, RoutedEventArgs e)
        {
            ArticleCollectionView.MoveToLastPage();
        }

        private void FirstPageOnClick(object sender, RoutedEventArgs e)
        {
            ArticleCollectionView.MoveToFirstPage();
        }

        private void PreviousPageOnClick(object sender, RoutedEventArgs e)
        {
            ArticleCollectionView.MoveToPreviousPage();
        }

        private void NextPageOnClick(object sender, RoutedEventArgs e)
        {
            ArticleCollectionView.MoveToNextPage();
        }
    }
}
