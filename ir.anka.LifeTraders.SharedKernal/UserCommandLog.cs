namespace ir.anka.LifeTraders.SharedKernel;

public class UserCommandLog
{
    public Guid LogId { get; set; }

    public DateTime CommandDate { get; set; }

    public string UserId { get; set; } = string.Empty;

    public string CommandName { get; set; } = string.Empty;

    public string CommandValue { get; set; } = string.Empty;
}