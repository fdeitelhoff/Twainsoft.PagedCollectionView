using System.Collections.Generic;
using Machine.Specifications;

namespace Twainsoft.PagedCollectionView.Tests
{
    [Subject(typeof(Data.PagedCollectionView), "")]
    public class When_a_new_paged_collection_view_is_filled_with_data
    {
        static Data.PagedCollectionView subject;

        Establish context = () =>
        {
            subject = new Data.PagedCollectionView(new List<string> {"1", "2", "3"});
        };


    }
}
