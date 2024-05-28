namespace CashFlow.Communication.Responses;

public class ResponseErrorJson
{
    public string ErrorMessage { get; set; } = string.Empty;

    // Construtor, executa uma vez quando instancia uma classe, forçando sempre passar um error message
    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}

