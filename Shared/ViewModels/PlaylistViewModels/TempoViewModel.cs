using System.ComponentModel.DataAnnotations;

namespace MoodSwings.Shared.ViewModels.PlaylistViewModels
{
    public class TempoViewModel
    {
        [Required]
        [Range(75, 360)]
        public int Tempo { get; set; } = 180;

        public int Precision { get; set; }

        public bool IncludeHalftime { get; set; } = false;

    }
    public class TracksDefinitionViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public TempoViewModel TempoModel { get; set; }
    }
}