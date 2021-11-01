using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rarirty_Score.Models
{
    public class CheckRarityFormModel
    {
        [Required]
        [StringLength(maximumLength: 44, MinimumLength = 44, ErrorMessage = "Wallet address needs to be 44 character long.")]
        public string WalletAddress { get; set; }
        [Required]
        [Range(1, 8620, ErrorMessage = "Accommodation invalid (1-8620).")]
        public int TerranautId { get; set; }
    }
}
