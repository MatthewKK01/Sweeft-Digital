using System.ComponentModel.DataAnnotations;

namespace Teacher_api.Models;

public class Pupil
{
    [Key]
    public int PupilID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Class { get; set; }

    public ICollection<Teacher> Teachers { get; set; }
}