public class Issue
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Desc { get; set; }

    public override string ToString()
    {
        return $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}, {nameof(Desc)}: {Desc}";
    }
}