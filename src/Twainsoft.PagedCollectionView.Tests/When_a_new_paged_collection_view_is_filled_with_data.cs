using System.Collections.Generic;
using FluentAssertions;
using Machine.Specifications;

namespace Twainsoft.PagedCollectionView.Tests
{
    [Subject(typeof(Data.PagedCollectionView), "Creating")]
    public class When_a_new_paged_collection_view_is_filled_with_data
    {
        static Data.PagedCollectionView result;
        static IEnumerable<string> input;
            
        Establish context = () =>
        {
            input = new List<string> {"1", "2", "3"};
        };

        Because of = 
            () => result = new Data.PagedCollectionView(input);

        It should_not_be_an_empty_view =
            () => result.Count.Should().NotBe(null);

        It should_contain_exact_three_elements =
            () => result.Count.Should().Be(3);

        It should_have_equal_elements =
            () => result.SourceCollection.Should().BeSameAs(input);

        It should_have_zero_pages =
            () => result.PageCount.Should().Be(0);
    }
}
