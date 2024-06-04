namespace CashFlow.Communication.Responses;

public class ResponseErrorJson
{
    public List<string> ErrorMessages { get; set; } = [];

    // Construtor, executa uma vez quando instancia uma classe, forçando sempre passar um error message

    // quando chega um erro
    public ResponseErrorJson(string errorMessage)
    {
        ErrorMessages = [errorMessage];
    }

    // quando chega mais de 1 erro
    public ResponseErrorJson(List<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}

