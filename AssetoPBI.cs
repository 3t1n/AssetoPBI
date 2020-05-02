using Asseto;
using AssettoCorsaSharedMemory;
using RestSharp;
using System;
using System.Text.Json;

namespace AssetoPBIConsole
{
    class AssetoPBI

    {
        public static string UrlCarro = "COLOQUE A URL DA API DO POWERBI";
        public static string UrlVolta = "COLOQUE A URL DA API DO POWERBI";

        static void Main(string[] args)
        {
            //insancia a api do assetto corsa
            AssettoCorsa ac = new AssettoCorsa();
            //seta o intervalo de tempo do evento
            ac.PhysicsInterval = 1000; 
            ac.GraphicsInterval = 1000;
            //chama os eventos
            ac.GraphicsUpdated += ac_GrapichUpdated;
            ac.PhysicsUpdated += ac_PhysicsUpdated;
            ac.Start();   
            Console.ReadKey();
        }

        static void sendRequest(string url, string json,string tipo)
        {
            //envia as requisicoes
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine("[Resquest] Send Request for " + tipo);
            Console.WriteLine(response.Content);
        }
        static void ac_GrapichUpdated(object sender, GraphicsEventArgs ge)
        {
            Voltas volta = new Voltas();
            volta.VoltasCompletadas = ge.Graphics.CompletedLaps;
            volta.Posicao = ge.Graphics.Position;
            volta.VoltaCorrente = ge.Graphics.CurrentTime;
            volta.UltimaVolta = ge.Graphics.LastTime;
            volta.MelhorVolta = ge.Graphics.BestTime;
            volta.Setor = ge.Graphics.CurrentSectorIndex;
            volta.TempoSetor = ge.Graphics.Split;
            volta.UltimoTempoSetor = ge.Graphics.LastSectorTime;
            volta.DistanciaPercorrida = ge.Graphics.DistanceTraveled;
            volta.TimeVolta = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
           
            string jsonstring = JsonSerializer.Serialize(volta);
            //é gambiarra eu sei...
            string jsonarrumado = "[" + jsonstring + "]";

            sendRequest(UrlVolta, jsonarrumado, "Volta");

        }

        static void ac_PhysicsUpdated(object sender, PhysicsEventArgs pe)
        {
            Carro carro = new Carro();
            carro.Velocidade = pe.Physics.SpeedKmh;
            carro.RPM = pe.Physics.Rpms;
            carro.Gasolina = pe.Physics.Fuel;
            carro.Acelerador = pe.Physics.Gas;
            carro.Brake = pe.Physics.Brake;
            carro.Embragem = pe.Physics.Clutch;
            carro.Marcha = pe.Physics.Gear;
            carro.DensidadeAR = pe.Physics.AirDensity;
            carro.TemperaturaAR = pe.Physics.AirTemp;
            carro.TemperaturaPista = pe.Physics.RoadTemp;
            carro.DanoFrente = pe.Physics.CarDamage[0];
            carro.DanoTraseira = pe.Physics.CarDamage[1];
            carro.DanoLateralEsquerda = pe.Physics.CarDamage[2];
            carro.DanoLateralDireita = pe.Physics.CarDamage[3];
            carro.BrakeBias = pe.Physics.BrakeBias;
            carro.TemperaturaBrakeFrenteEsquerdo = pe.Physics.BrakeTemp[0];
            carro.TemperaturaBrakeFrenteDireito = pe.Physics.BrakeTemp[1];
            carro.TemperaturaBrakeTraseiroEsquerdo = pe.Physics.BrakeTemp[2];
            carro.TemperaturaBrakeTraseiroDireito = pe.Physics.BrakeTemp[3];
            carro.PressaoPneuFrenteEsquerdo = pe.Physics.WheelsPressure[0];
            carro.PressaoPneuFrenteDireito = pe.Physics.WheelsPressure[1];
            carro.PressaoPneuTraseiroEsquerdo = pe.Physics.WheelsPressure[2];
            carro.PressaoPneuTraseiroDireito = pe.Physics.WheelsPressure[3];
            carro.TemperaturaPneuCoreFrenteEsquerdo = pe.Physics.TyreCoreTemperature[0];
            carro.TemperaturaPneuCoreFrenteDireito = pe.Physics.TyreCoreTemperature[1];
            carro.TemperaturaPneuCoreTraseiroEsquerdo = pe.Physics.TyreCoreTemperature[2];
            carro.TemperaturaPneuCoreTraseiroDireito = pe.Physics.TyreCoreTemperature[3];
            carro.TemperaturaPneuInteriorFrenteEsquerdo = pe.Physics.TyreTempI[0];
            carro.TemperaturaPneuInteriorFrenteDireito = pe.Physics.TyreTempI[1];
            carro.TemperaturaPneuInteriorTraseiroEsquerdo = pe.Physics.TyreTempI[2];
            carro.TemperaturaPneuInteriorTraseiroDireito = pe.Physics.TyreTempI[3];
            carro.TemperaturaPneuMeioFrenteEsquerdo = pe.Physics.TyreTempM[0];
            carro.TemperaturaPneuMeioFrenteDireito = pe.Physics.TyreTempM[1];
            carro.TemperaturaPneuMeioTraseiroEsquerdo = pe.Physics.TyreTempM[2];
            carro.TemperaturaPneuMeioTraseiroDireito = pe.Physics.TyreTempM[3];
            carro.TemperaturaPneuForaFrenteEsquerdo = pe.Physics.TyreTempO[0];
            carro.TemperaturaPneuForaFrenteDireito = pe.Physics.TyreTempO[1];
            carro.TemperaturaPneuForaTraseiroEsquerdo = pe.Physics.TyreTempO[2];
            carro.TemperaturaPneuForaTraseiroDireito = pe.Physics.TyreTempO[3];
            carro.DesgastePneuFrenteEsquerdo = pe.Physics.TyreWear[0];
            carro.DesgastePneuFrenteDireito = pe.Physics.TyreWear[1];
            carro.DesgastePneuTraseiroEsquerdo = pe.Physics.TyreWear[2];
            carro.DesgastePneuTraseiroDireito = pe.Physics.TyreWear[3];
            carro.Time = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            string jsonstring = JsonSerializer.Serialize(carro);
            //é gambiarra eu sei...
            string jsonarrumado = "[" + jsonstring + "]";

            sendRequest(UrlCarro, jsonarrumado, "Carro");

        }
    }
}