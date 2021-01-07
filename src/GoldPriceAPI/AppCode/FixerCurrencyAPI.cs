using System;
public class FixerCurrencyAPI
{

    

}

public class RequestParam
{
    public string AccessKey { get; set; }
    public string FromSymbol { get; set; }  
    public string ToSymbol { get; set; }
    public decimal Amount { get; set; }
    public DateTime DateVal { get; set; }
}