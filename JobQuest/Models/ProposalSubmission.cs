namespace JobQuest.Models
{
	public class ProposalSubmission
	{
		public string Status { get; set; }
		public DateTime SubmittedAt { get; set; }
		public int ProposalID { get; set; }
		public Proposal Proposal { get; set; }
		public int jobID { get; set; }
		public Job Job { get; set; }
	}
}
