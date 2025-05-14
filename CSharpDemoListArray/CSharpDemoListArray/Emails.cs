class Emails
{
    public List<string> All { get; } = new List<string>();	
    private readonly NamesValidator _namesValidator2 = new NamesValidator();

    public void AddNames(List<string> names)
    {
        foreach (var name in names)
        {
            AddName(name);
        }
    }
    public void AddName(string name)
    {
        if (_namesValidator2.IsValid(name))
        {
            All.Add(name);
        }
    }

}