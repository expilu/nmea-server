using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NMEAServerLib
{
    public class NMEAServer
    {
        private int port;
        private int rateMs;
        private TcpListener server;
        private List<TcpClient> clients = new List<TcpClient>();
        private InstrumentsData instrumentsData;
        private CancellationTokenSource cancellationToken;

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
            cancellationToken = new CancellationTokenSource();
            server.Start();
            _started = true;
            new Thread(ConnectionsLoop).Start();
            new Thread(SendDataLoop).Start();
        }

        public void Stop()
        {
            cancellationToken.Cancel();
            server.Stop();
            _started = false;
        }

        private void ConnectionsLoop()
        {
            while (_started && !cancellationToken.IsCancellationRequested)
            {
                try
                {
                    TcpClient client = server.AcceptTcpClient();
                    clients.Add(client);
                }
                catch (SocketException e)
                {
                    if (e.SocketErrorCode == SocketError.Interrupted)
                    {
                        break;
                    }
                    else
                    {
                        throw e;
                    }
                }
            }
        }

        private void SendDataLoop()
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
                    }
                    else
                    {
                        try
                        {
                            NetworkStream stream = client.GetStream();
                            Byte[] data = Encoding.ASCII.GetBytes(instrumentsData.generateNMEA());
                            stream.Write(data, 0, data.Length);
                        }
                        catch (System.IO.IOException e)
                        {
                            // ignore
                        }
                    }
                }

                Thread.Sleep(rateMs);
            }
        }
    }
}
