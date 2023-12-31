using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Text;
using Client;

var cert = new X509Certificate2(SharedData.SharedData.CertificatePathAddress, SharedData.SharedData.Password);

var dataToSend = "My name is AFSANEH!";

using var rsa = cert.GetRSAPrivateKey();
{
    var signature = rsa.SignData(Encoding.UTF8.GetBytes(dataToSend), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

    await Helper.SendDataToWebApp(dataToSend, signature);
}


