using System.Security.Cryptography.X509Certificates;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Serialization;

namespace NFe.Wsdl.Status
{
    [WebServiceBinding(Name = "NfeStatusServico2Soap12", Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico2")]
    public class NfeStatusServico2 : SoapHttpClientProtocol, INfeServico
    {
        public NfeStatusServico2(string url, X509Certificate certificado, int timeOut)
        {
            SoapVersion = SoapProtocolVersion.Soap12;
            Url = url;
            Timeout = timeOut;
            ClientCertificates.Add(certificado);
        }

        [XmlAttribute(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico2")]
        public nfeCabecMsg nfeCabecMsg { get; set; }

        [SoapHeader("nfeCabecMsg", Direction = SoapHeaderDirection.InOut)]
        [SoapDocumentMethod("http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico2/nfeStatusServicoNF2", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Bare)]
        [WebMethod(MessageName = "nfeStatusServicoNF2")]
        [return: XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico2")]
        public XmlNode Execute([XmlElement(Namespace = "http://www.portalfiscal.inf.br/nfe/wsdl/NfeStatusServico2")] XmlNode nfeDadosMsg)
        {
            var results = Invoke("nfeStatusServicoNF2", new object[] {nfeDadosMsg});
            return ((XmlNode) (results[0]));
        }
    }
}