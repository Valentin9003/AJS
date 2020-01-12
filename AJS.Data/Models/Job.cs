using AJS.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// Job Data Model
    /// </summary>
    public class Job
    {
        [Required]
        public string JobId { get; set; }

        [Required]
        [StringLength(DataConstants.JobTitleMaximumLength, MinimumLength = DataConstants.JobTitleMinimumLength)] // TODO: Add Multilingual Error Message
        public string Title { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public User Creator { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public JobCategory Category { get; set; }

        public string PictureId { get; set; }

        public JobPicture Picture { get; set; }

        [Required]
        public string LocationId { get; set; }

        public JobLocation Location { get; set; }

        [Required]
        public string DescriptionId { get; set; }

        public JobDescription Description { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        [Required]
        public JobLanguage Language { get; set; }
    }
}
