public class TaskModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }

   public TaskModel()
    {
        Title = string.Empty;
        Description = string.Empty;
        Status = string.Empty;
        Priority = string.Empty;
    }
}