using System.Net;
using System.Net.Sockets;
using Microsoft.Maui.Devices; // MAUI-projekteille, jos laitetiedot tarvitaan alustariippuvaisesti

public class DeviceInfoService
{
    public string IPAddress { get; private set; }
    public string DevicePlatform { get; private set; }
    public string DeviceModel { get; private set; }

    public DeviceInfoService()
    {
        IPAddress = GetLocalIPAddress();
        DevicePlatform = DeviceInfo.Platform.ToString();
        DeviceModel = DeviceInfo.Model;
    }

    private string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork) // IPv4
            {
                return ip.ToString();
            }
        }
        throw new Exception("No network adapters with an IPv4 address in the system!");
    }
}
