using System.Collections.Generic;
using System.Collections.ObjectModel;
using Twainsoft.PCV.Data;
using Twainsoft.PCV.WPF.TestApplication.Model;

namespace Twainsoft.PCV.WPF.TestApplication
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var data = new ObservableCollection<Article> { new Article("Test 1", "Author 1", 3),
                new Article("Test 2", "Author 2", 3.3f), new Article("Test 3", "Author 3", 17.9f) };

            var pagedCollectionView = new PagedCollectionView(data);

            DataGrid.ItemsSource = pagedCollectionView;
        }
    }
}
