using System.Collections.Generic;

public class MethodResult<T>
{
    public bool Succeeded { get; set; }
    public bool RequiresTwoFactor { get; set; }
    public bool IsLockedOut { get; set; }
    public IEnumerable<string> Errors { get; set; }
}