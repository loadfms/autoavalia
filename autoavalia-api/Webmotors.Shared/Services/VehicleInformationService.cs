using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Webmotors.Shared.Servicos.CorrectData;

namespace Webmotors.Shared.Services
{
    //webmotors //12123
    public class VehicleInformationService
    {
        private IProdutos Service { get; set; }

        public VehicleInformationService()
        {
            //Service.ClientCredentials.UserName.UserName = ReturnUsername();
            //Service.ClientCredentials.UserName.Password = ReturnPassword();
        }

        public VehicleInformation GetVehicleInformation(string placa)
        {
            try
            {
                //TODO: MOVER PARA O CONSTRUTOR
                var binding = new WSHttpBinding {
                    Security = {
                        Mode = SecurityMode.Transport,
                        Transport = {ClientCredentialType = HttpClientCredentialType.Basic}
                    }
                };
                var endPoint = new EndpointAddress("https://www.correctdata.com.br/Manager/Services/Produtos.svc");
                Service = new ProdutosClient(binding, endPoint);


                var carro = Service.Agregados(placa);
                var proprietarios = Service.ProprietariosAnteriores(placa);
                var recall = Service.Recall(carro.CHASSI);
                var leilao = Service.Leilao(placa,carro.CHASSI);
                var furto = Service.HistRouboFurto(placa);
                var sinistros = Service.IndSinPerTot(placa);
            
                return new VehicleInformation
                {
                    OnwerQuantity = Convert.ToInt32(proprietarios.QT_PROPRIETARIO),
                    Recall = !(recall.NuCdRetorno == null || recall.NuCdRetorno == 1009),
                    Accidents = string.IsNullOrEmpty(sinistros.EXISTE_PT),
                    Auction = string.IsNullOrEmpty(leilao.EXISTE_LEILAO),
                    Roberry = furto.OCORRENCIAS.Length
                };
            }
            catch (Exception)
            {
                return new VehicleInformation();
            }
        }
    }
}
