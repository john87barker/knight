using System.ComponentModel.DataAnnotations;
namespace knight.Models
{
    public class Knight
    {
      public string Name { get; set; }
      public string Mission { get; set; }
      public int Id { get; set; }

      public string CastleId { get; set; }
  }
}