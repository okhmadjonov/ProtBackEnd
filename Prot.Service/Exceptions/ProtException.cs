namespace Prot.Service.Exceptions;

public class ProtException : Exception
{

    public int Code { get; set; }
    public bool? Global { get; set; }

    public ProtException(int code, string message, bool? global = true) : base(message)
    {

        Code = code;
        Global = global;
    }

}
