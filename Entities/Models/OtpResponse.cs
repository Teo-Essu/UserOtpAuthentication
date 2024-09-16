using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public  class OtpResponse
    {
        public int Id { get; set; }
        public string? message { get; set; }
        [ForeignKey("DataId")]
        public Data? data { get; set; }
    }

    public class Data
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Otp")]
        public Otp? otp { get; set; }
    }

    public class Otp
    {
        [Key]
        public int Id { get; set; }
        public string? prefix { get; set; }
        public string? requestId { get; set; }
        public Guid userId { get; set; }
    }

    public class VerifyOtp
    {
        public string? code { get; set; }
        public string? requestId { get; set; }
        public Guid userId { get; set; }
    }

    public class verifiedOtp
    {
        public string? message { get; set; }
    }
}
