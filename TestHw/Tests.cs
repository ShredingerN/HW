using HW;
using Bogus;
using FluentAssertions;

namespace TestHW;

public class Tests
{
    [Fact] 
    public void PostingTest()
    {
        //Arrange
        List<Posting> postings = new List<Posting>
        {
            new Posting("ABC123"),
            new Posting("DEF456"),
            new Posting("GHI789"),
            new Posting("GH7789"),
            new Posting("G9I789"),
            new Posting("ABC120"),
            new Posting("67F456"),
            new Posting("EZ7KK1EY"),
            new Posting("88789"),
            new Posting("SD789"),
        };
        //Act
        PostingDB.Add(postings);
        long postingId = 7;
        var checkPosting = PostingDB.Postings[postingId].Code;
        int count = 0;
        foreach (var posting in PostingDB.Postings.Values)
        {
            if (checkPosting == posting.Code)
            {
                count++;
            }
        }

        //Assert
        Assert.Equal(1, count);
        Assert.Equal(postings.Count, PostingDB.Postings.Count);
    }

    private Faker _randomcodes = new Faker();

    [Fact] 
    public void PostingTest1()
    {
        var postings = new List<Posting>();
        for (var i = 0; i < 10; i++)
        {
            postings.Add(new Posting(_randomcodes.Random.Words()));
        }

        PostingDB.Add(postings);
        var indexId = 6;
        var posting = postings[indexId];
        var db = PostingDB.Postings;
        db.Should().HaveCount(postings.Count);
        db.Should().ContainSingle(x => x.Value.Code == posting.Code);
    }
}