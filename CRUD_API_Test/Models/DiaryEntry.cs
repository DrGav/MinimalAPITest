namespace CRUD_API_Test.Models
{
    public class DiaryEntry
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int AppointmentOwnerId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
