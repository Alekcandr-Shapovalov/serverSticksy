using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using SticksyProtocol;
using AnswerMethods;

namespace serverSticksy
{
    class Server
    {
        public TcpListener server { get; }
        public AnswerMethods answerMethods;

        public Server(IPEndPoint iP)
        {
            server = new TcpListener(iP);
            answerMethods = new AnswerMethods(server);
        }

        public void Listen()
        {
            while (true)
            {
                try {
                    TcpClient client = server.AcceptTcpClient();
                    ListenClientAsync(client);
                }
                catch { }
            }
        }

        private async void ListenClientAsync(TcpClient client)
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        IData data = Transfer.ReceiveData(client);
                        if (data is GetUsers)
                        {
                            answerMethods.getUsers(data as GetUsers);
                        }
                        else if (data is )
                        {

                        }
                    }
                    catch
                    {}
                }
            });
        }

    }
}
