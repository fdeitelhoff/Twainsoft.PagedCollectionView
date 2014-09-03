﻿using System.Collections.Generic;
using FluentAssertions;
using Machine.Specifications;

namespace Twainsoft.PagedCollectionView.Tests
{
    [Subject(typeof(Data.PagedCollectionView), "Paging")]
    public class When_a_new_paged_collection_view_has_a_max_page_size
    {
        static Data.PagedCollectionView result;
        static IEnumerable<string> input;

        Establish context = () =>
        {
            input = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        };

        Because of =
            () => result = new Data.PagedCollectionView(input) {PageSize = 3};

        It should_have_two_pages =
            () => result.PageCount.Should().Be(3);

        It should_be_on_the_first_page =
            () => result.CurrentPage.Should().Be(1);
    }
}
