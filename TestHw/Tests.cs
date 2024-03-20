using HW;

namespace TestHW;

public class Tests
{
    [Fact] 
    public void PostingCountTest()
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
        // Assert
        Assert.Equal(postings.Count, PostingDB.Postings.Count);
    }

    [Fact] 
    public void PostingIsUniqTest()
    {
        long postingId = 7;

        // Act
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
    }
}
