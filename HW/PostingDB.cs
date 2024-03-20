namespace HW;

public static class PostingDB
{
    private static long _postingCounter = 1;
    public static Dictionary<long, Posting> Postings { get; } = new Dictionary<long, Posting>();

    public static void Add(IEnumerable<Posting> postings)
    {
        foreach (var posting in postings)
        {
            Postings[_postingCounter] = posting;
            _postingCounter++;
        }
    }
}
