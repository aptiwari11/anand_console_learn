﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Management;
using System.Text;

namespace ConsoleApp_Learn
{
    /// <summary>
    /// This class includes methods to call and check the IIS services and perfrom the requested actions on them.
    /// </summary>
    public class IISService
    {
        public static bool IsServiceRunning(string serviceName)
        {
            try
            {
                ServiceController service = new ServiceController(serviceName);
                return (service.Status == ServiceControllerStatus.Running);
            }
            catch
            {
                return false;
            }
        }

        public bool IsApplicationPoolRunning(string servername, string strAppPool)
        {
            string sb = ""; // String to store return value

            // Connection options for WMI object
            ConnectionOptions options = new ConnectionOptions();

            // Packet Privacy means authentication with encrypted connection.
            options.Authentication = AuthenticationLevel.PacketPrivacy;

            // EnablePrivileges : Value indicating whether user privileges 
            // need to be enabled for the connection operation. 
            // This property should only be used when the operation performed 
            // requires a certain user privilege to be enabled.
            options.EnablePrivileges = true;

            // Connect to IIS WMI namespace \\root\\MicrosoftIISv2
            ManagementScope scope = new ManagementScope(@"\\" +
                servername + "\\root\\MicrosoftIISv2", options);

            // Query IIS WMI property IISApplicationPoolSetting
            ObjectQuery oQueryIISApplicationPoolSetting =
                new ObjectQuery("SELECT * FROM IISApplicationPoolSetting");

            // Search and collect details thru WMI methods
            ManagementObjectSearcher moSearcherIISApplicationPoolSetting =
                new ManagementObjectSearcher(scope, oQueryIISApplicationPoolSetting);
            ManagementObjectCollection collectionIISApplicationPoolSetting =
                            moSearcherIISApplicationPoolSetting.Get();

            // Loop thru every object
            foreach (ManagementObject resIISApplicationPoolSetting
                in collectionIISApplicationPoolSetting)
            {
                // IISApplicationPoolSetting has a property called Name which will 
                // return Application Pool full name /W3SVC/AppPools/DefaultAppPool
                // Extract Application Pool Name alone using Split()
                if (resIISApplicationPoolSetting
                    ["Name"].ToString().Split('/')[2] == strAppPool)
                {
                    // IISApplicationPoolSetting has a property 
                    // called AppPoolState which has following values
                    // 2 = started 4 = stopped 1 = starting 3 = stopping
                    if (resIISApplicationPoolSetting["AppPoolState"].ToString() != "2")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void performRequestedAction(String servername, String AppPoolName, String action)
        {
            StringBuilder sb = new StringBuilder();
            ConnectionOptions options = new ConnectionOptions();
            options.Authentication = AuthenticationLevel.PacketPrivacy;
            options.EnablePrivileges = true;
            ManagementScope scope = new ManagementScope(@"\\" +
                servername + "\\root\\MicrosoftIISv2", options);

            // IIS WMI object IISApplicationPool to perform actions on IIS Application Pool
            ObjectQuery oQueryIISApplicationPool =
                new ObjectQuery("SELECT * FROM IISApplicationPool");

            ManagementObjectSearcher moSearcherIISApplicationPool =
                new ManagementObjectSearcher(scope, oQueryIISApplicationPool);
            ManagementObjectCollection collectionIISApplicationPool =
                moSearcherIISApplicationPool.Get();
            foreach (ManagementObject resIISApplicationPool in collectionIISApplicationPool)
            {
                if (resIISApplicationPool["Name"].ToString().Split('/')[2] == AppPoolName)
                {
                    // InvokeMethod - start, stop, recycle can be passed as parameters as needed.
                    resIISApplicationPool.InvokeMethod(action, null);
                }
            }
        }

    }
}
