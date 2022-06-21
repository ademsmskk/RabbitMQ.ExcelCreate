using System.ComponentModel.DataAnnotations.Schema;

namespace RabbitMQ.ExcelCreate.Models
{
    public enum FileStatus
    {
        Creating,
        Completed
    }
    public class UserFile
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public string fileName { get; set; }
        public string filePath { get; set; }
        public DateTime? createdDate { get; set; }
        public FileStatus fileStatus { get; set; }

        [NotMapped]
        public string GetCreatedDate=>createdDate.HasValue ? createdDate.Value.ToShortDateString() : "-";
    }
}
