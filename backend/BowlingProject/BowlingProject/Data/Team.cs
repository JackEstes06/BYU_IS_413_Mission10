using System.ComponentModel.DataAnnotations;

namespace BowlingProject.Data;

public class Team
{
    [Key]
    public int TeamID { get; set; }
    [Required]
    public string TeamName { get; set; }
    public int CaptainID { get; set; }
}