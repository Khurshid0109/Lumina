namespace Lumina.Service.Exceptions;
public class LuminaException:Exception
{
    public int StatusCode { get; set; }
    public LuminaException(int code, string msg) : base(msg)
    {
        StatusCode = code;
    }
}
