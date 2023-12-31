using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using SharedData;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapPost("/verify", ([FromBody] DataDto data) =>
{
    var cert = new X509Certificate2(SharedData.SharedData.CertificatePathAddress, SharedData.SharedData.Password);

    using var rsa = cert.GetRSAPublicKey();

    var isSignatureValid = rsa.VerifyData(Encoding.UTF8.GetBytes(data.Value), data.Signature, HashAlgorithmName.SHA3_512, RSASignaturePadding.Pkcs1);

    Console.WriteLine(isSignatureValid);
});

app.Run();

