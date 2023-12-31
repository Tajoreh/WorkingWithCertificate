namespace SharedData;

public static class SharedData
{
    public const string Password = "g41M8I#'J#xU";

    public const string CertificatePathAddress =
        "C:\\Users\\z.daneshi\\Desktop\\TestCrypto\\CertificateGenerator\\bin\\Debug\\net8.0\\certificate.pfx";

    public const string BaseAddressOfServerApi = "https://localhost:7292";

}

public class DataDto
{
    public string Value { get; set; }
    public byte[] Signature { get; set; }
}