using System.ComponentModel.DataAnnotations;

namespace Teacher_api.Models;

public class Teacher
{
    [Key]
    public int TeacherID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Subject { get; set; }

    public ICollection<Pupil> Pupils { get; set; }
}