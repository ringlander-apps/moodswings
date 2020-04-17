namespace MoodSwings.Shared.Models.DTO
{
    public class RequestDTO
    {
        public string access_token { get; set; }
        public OptionsDTO options { get; set; }

    }

    public class TempoDefinitionRequestDTO : RequestDTO
    {
        public string playlist { get; set; }
        public TempoCriteriaDTO criteria { get; set; }
    }

    public class TempoCriteriaDTO
    {
        public string type { get; set; }
        public TempoDTO parameters { get; set; }
    }

    public class TempoDTO
    {
        public int value { get; set; }
        public int precision { get; set; }

        public bool halfTempoAllowed { get; set; }
    }

    public class OptionsDTO
    {
        public int offset { get; set; }
        public int limit { get; set; }
    }



}