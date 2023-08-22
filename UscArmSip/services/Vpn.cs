using FluentAssertions;

namespace UscArmSip
{
    public static class Vpn
    {
        private const string _vpnName = "SapphireVPN";
        private const string _vpnType = "Sstp";
        private const string _serverName = "vpn.nposapfir.ru";
        private const string _login = "Konev_AV";
        private const string _password = "nQ5LsCLw5W\\\"&\\\"#uum1";

        public static void Connect()
        {
            if (Powershell.Run($"Get-VPNconnection -Name '{_vpnName}'", true).Contains("not found"))
                Powershell.Run($"Add-VpnConnection -Name '{_vpnName}' -ServerAddress '{_serverName}' -TunnelType '{_vpnType}'");

            Powershell.Run($"rasdial {_vpnName} {_login} {_password}");
            Powershell.Run($"rasdial", true).Should().ContainAll($"Connected to", $"{_vpnName}");
        }

        public static void Disconnect()
        {
            Powershell.Run($"rasdial \"{_vpnName}\" /disconnect");
            Powershell.Run($"Get-VPNconnection '{_vpnName}'", true).Should().Contain("Disconnected");
        }
    }
}
