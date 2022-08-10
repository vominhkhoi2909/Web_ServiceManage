namespace MockProject.WebApp.ModelAPI
{
    public class NotificationModel
    {
        public int NotifId { get; set; }
        public DateTime CreateAt { get; set; }
        public string Title { get; set; }
        public int Type { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string SendTo { get; set; }
        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public string User_Avatar { get; set; }
        public int CreateBy { get; set; }
        public string Admin_Name { get; set; }
        public string Admin_Email { get; set; }
        public string Admin_Avatar { get; set; }
        public string Link { get; set; }
        public int Status { get; set; }
    }
}
