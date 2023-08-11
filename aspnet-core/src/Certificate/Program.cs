using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

using var algorithm = RSA.Create(keySizeInBits: 2048);

var subject = new X500DistinguishedName("CN=Fabrikam Encryption Certificate");
var request = new CertificateRequest(
    subject, algorithm, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
request.CertificateExtensions.Add(
    new X509KeyUsageExtension(X509KeyUsageFlags.KeyEncipherment, critical: true));

var certificate = request.CreateSelfSigned(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(2));

File.WriteAllBytes("encryption-certificate.pfx",
    certificate.Export(X509ContentType.Pfx, "Aa!00000000"));





//using var algorithm = RSA.Create(keySizeInBits: 2048);

//var subject = new X500DistinguishedName("CN=Fabrikam Signing Certificate");
//var request = new CertificateRequest(
//    subject, algorithm, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
//request.CertificateExtensions.Add(
//    new X509KeyUsageExtension(X509KeyUsageFlags.DigitalSignature, critical: true));

//var certificate = request.CreateSelfSigned(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(2));

//File.WriteAllBytes("signing-certificate.pfx",
//    certificate.Export(X509ContentType.Pfx, "Aa!00000000"));