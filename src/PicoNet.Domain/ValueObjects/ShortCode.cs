namespace PicoNet.Domain.ValueObjects;

public record ShortCode
{
    public string Value { get; }
    
    public ShortCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Short code cannot be empty", nameof(value));
        
        if (value.Length < 3 || value.Length > 20)
            throw new ArgumentException("Short code must be between 3 and 20 characters", nameof(value));
        
        if (!value.All(c => char.IsLetterOrDigit(c) || c == '-' || c == '_'))
            throw new ArgumentException("Short code contains invalid characters", nameof(value));
        
        Value = value;
    }
    
    public static implicit operator string(ShortCode code) => code.Value;
    public static explicit operator ShortCode(string value) => new(value);
    
    public override string ToString() => Value;
}