public class AuthorData
{
    public int Id { get; set; }
    public string Biography { get; set; }
    
    public int AuthorId { get; set; }
    
    public Author Author { get; set; }
}