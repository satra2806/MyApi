namespace MyApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProcessType { get; set; } = default!;
        public string ProjectName { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ProblemStatement { get; set; } = default!;
        public string ProposedSolution { get; set; } = default!;
        public string Assumptions { get; set; } = default!;
        public string Constraints { get; set; } = default!;
        public string Benefits { get; set; } = default!;
        public string ProjectCode { get; set; } = default!;
        public string OriginatorROM { get; set; } = default!;
    }
}
