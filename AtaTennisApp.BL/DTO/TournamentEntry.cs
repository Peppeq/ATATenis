using AtaTennisApp.BL.DTO;

public class TournamentEntryDTO
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public int PlayerId { get; set; }
    public virtual TournamentDTO Tournament { get; set; }
    public virtual PlayerDTO Player { get; set; }
}