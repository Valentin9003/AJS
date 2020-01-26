using System;
using System.ComponentModel.DataAnnotations;

namespace AJS.Data.Models
{
    /// <summary>
    /// Message Data Model
    /// </summary>
    public class Message
    {
        [Required]
        public string MessageId { get; set; }

        [Required]
        public string SenderId { get; set; }

        public User Sender { get; set; }

        [Required]
        public string ReceivedId { get; set; }

        public User Received { get; set; }

        [StringLength(DataConstants.MessageTextMaximumLength, MinimumLength = DataConstants.MessageTextMinimumLength)]
        public string TextMessage { get; set; }

        [StringLength(DataConstants.MessageTitleMaximumLength, MinimumLength = DataConstants.MessageTitleMinimumLength)]
        public string Title { get; set; }

        [Required]
        public DateTime TimeSend { get; set; }

        public DateTime TimeSeen { get; set; }
    }
}
