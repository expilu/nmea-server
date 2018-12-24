using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace NMEALib
{
    public class NMEAServer
    {
        private int port;
        private int rateMs;
        private TcpListener server;
        private List<TcpClient> clients = new List<TcpClient>();
        private InstrumentsData instrumentsData;

        private bool _started;

        public NMEAServer(ref InstrumentsData instrumentsData, int port, int rateMs)
        {
            this.instrumentsData = instrumentsData;
            this.port = port;
            this.rateMs = rateMs;

            #pragma warning disable 612, 618
            server = new TcpListener(port);
        }

        public bool Started
        {
            get
            {
                return _started;
            }
        }

        public void Start()
        {
            server.Start();
            ConnectionsLoop();
            SendDataLoop();
            _started = true;
            Debug.WriteLine("Server started");
        }

        public void Stop()
        {
            server.Stop();
            _started = false;
            Debug.WriteLine("Server stopped");
        }

        private void ConnectionsLoop()
        {
            Task.Run(async () =>
            {
                Debug.WriteLine("Waiting for connections... ");
                while (_started)
                {
                    TcpClient client = await server.AcceptTcpClientAsync();
                    clients.Add(client);
                    Debug.WriteLine("Client connected!");
                }
            });
        }

        private void SendDataLoop()
        {
            Task.Run(async () =>
            {
                while (_started)
                {
                    for (int i = 0; i < clients.Count; i++)
                    {
                        TcpClient client = clients[i];

                        if (!client.Connected)
                        {
                            clients.Remove(client);
                            i--;
                            Debug.WriteLine("Client disconnected!");
                        }
                        else
                        {
                            try
                            {
                                NetworkStream stream = client.GetStream();
                                Byte[] data = Encoding.ASCII.GetBytes(instrumentsData.generateNMEA());
                                stream.Write(data, 0, data.Length);
                            } catch (System.IO.IOException e)
                            {
                                // ignore
                            }
                        }
                    }

                    await Task.Delay(rateMs);
                }
            });
        }
    }
}
