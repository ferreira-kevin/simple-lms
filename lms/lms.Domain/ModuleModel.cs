public class ModuleModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<MaterialModel> Materials { get; set; } = new();
}
