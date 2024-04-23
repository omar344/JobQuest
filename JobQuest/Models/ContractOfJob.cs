namespace JobQuest.Models
{
	public class ContractOfJob
	{
		public int JobID { get; set; }
		public Job Job { get; set; }
		public int ContractID { get; set; }
		public Contract Contract { get; set; }
	}
}
