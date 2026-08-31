using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using UnityEngine;

namespace GameDevUtils.Network
{
    public struct Ipv4Data
    {
        public IPAddress address;
        public IPAddress mask;
    }
    
    public static class NetworkUtils
    {
        public static IEnumerable<Ipv4Data> GetLocalNetworkAddress()
        {
            var ipv4Interfaces = 
                NetworkInterface.GetAllNetworkInterfaces()
                    .Where(x => x.OperationalStatus == OperationalStatus.Up &&
                                x.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    .Select(x => x.GetIPProperties())
                    .ToArray();
            
            var addrBytes = new byte[16];

            foreach (var ipInterface in ipv4Interfaces)
            {
                foreach (var unicastAddress in ipInterface.UnicastAddresses)
                {
                    var address = unicastAddress.Address;
                    address.TryWriteBytes(addrBytes,out var addrBytesWritten);
                    if (addrBytesWritten == 4)
                    {
                        yield return new(){address = unicastAddress.Address,mask = unicastAddress.IPv4Mask} ;
                    }
                }
            }
        }

        public static IEnumerable<IPAddress> GetLocalBroadCastAddress()
        {
            var ipBytes = new byte[4];
            var maskBytes = new byte[4];
            var broadCastIpBytes = new byte[4];
            
            foreach (var ipData in GetLocalNetworkAddress())
            {
                ipData.address.TryWriteBytes(ipBytes,out _);
                ipData.mask.TryWriteBytes(maskBytes,out _);

                for (var i = 0; i < ipBytes.Length; i++)
                {
                    // mask 1100
                    // addr 1001
                    // boar 1011
                    broadCastIpBytes[i] = (byte)(~maskBytes[i] | ipBytes[i]);
                }
                yield return new IPAddress(broadCastIpBytes);
            }
        }
    }
}