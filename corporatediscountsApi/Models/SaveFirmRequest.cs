namespace corporatediscountsApi.Models
{
    public class SaveFirmRequest
    {
        public UpdatedFirmRow[] UpdatedFirmRows { get; set; }
        public InsertedFirmRow[] InsertedFirmRows { get; set; }

        public int[] DeletedFirmRows { get; set; }

    }
}
