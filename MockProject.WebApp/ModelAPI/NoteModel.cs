namespace MockProject.WebApp.ModelAPI
{
    public class NoteModel
    {
        public string Title { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; } //Admin
    }
}
