using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Collections.Generic;

namespace PADIBook.Utils
{
    public sealed class Config
    {
        private static Config instance = null;
        public static Config Instance
        {
            get {
                if (instance == null)
                    instance = new Config();
                return instance;
            }
        }

        private int nreplicas = 1;
        public int NumberOfReplicas
        {
            get { return nreplicas; }
        }

        private int freezeTime = 0;
        private readonly static object freezeTimeMonitor = new object();
        public int FreezeTime
        {
            get
            {
                lock (freezeTimeMonitor)
                {
                    return freezeTime;
                }
            }
            set
            {
                lock (freezeTimeMonitor)
                {
                    freezeTime = value;
                }
            }
        }

        private readonly string configFileName = "../../../configuration.xml";

        private List<ServerConfig> servers;

        private readonly List<ClientConfig> clients;

        private Config() {
            FreezeTime = 0;

            try
            {
                XDocument xd = XDocument.Load(configFileName);

                clients = (from client in xd.Element("configurations").Elements("client")
                           let tmp_servers = client.Elements("server")
                           select new ClientConfig
                           {
                               Name = client.Attribute("id").Value,
                               Port = Int32.Parse(client.Attribute("port").Value),
                               Address = client.Attribute("address").Value,
                               ServerConfigs = tmp_servers.Select(x => new ServerConfig
                               {
                                   Name = x.Attribute("id").Value,
                                   Address = x.Attribute("address").Value,
                                   Port = Int32.Parse(x.Attribute("port").Value)                                   
                               }).ToList<ServerConfig>()
                           }).ToList<ClientConfig>();

            }
            catch (FormatException fe)
            {
                throw new Exception("Falha ao fazer parsing de um porto no ficheiro de configuração", fe);
            }
            catch (NullReferenceException nre)
            {
                throw new Exception("Erro ao fazer parsing do ficheiro de configuração. Alguns elementos não têm todos os atributos necessários.",nre);
            }
        }

        public void ChooseClientSetOfReplicas(string clientName)
        {
            servers = clients.Where(x => x.Name == clientName).First().ServerConfigs;
            nreplicas = servers.Count;
        }

        public List<ServerConfig> ServersConfiguration
        {
            get { return servers; }
        }

        public List<ClientConfig> ClientsConfiguration
        {
            get { return clients; }
        }
    }

    public class ClientConfig
    {
        public string Name
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public int Port
        {
            get;
            set;
        }
        public List<ServerConfig> ServerConfigs
        {
            get;
            set;
        }
    }

    public class ServerConfig
    {
        public string Address
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
