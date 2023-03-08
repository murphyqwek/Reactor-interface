using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Reactor_Interface.Classes
{
    public static class Internet_checker
    {
        private static string ip = "142.250.185.106"; //google api drive IP
        public enum Status
        {
            Success,
            NoInternet,
            Unknown
        }

        public static Status CheckInternet()
        {
            Ping ping = new Ping();
            PingReply response;
            IPAddress google_api_ip = IPAddress.Parse(ip);
            try
            {
                response = ping.Send(google_api_ip);
                if (response.Status == IPStatus.Success)
                    return Status.Success;
                else if (response.Status == IPStatus.HardwareError)
                    return Status.NoInternet;
                else
                    return Status.Unknown;
            }
            catch (PingException)
            {
                return Status.NoInternet;
            }
        }
    }
}
