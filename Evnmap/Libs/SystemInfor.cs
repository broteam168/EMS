using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace LDSong.Libs
{
    class SystemInfor
    {
        public static string getOperatingSystemInfo()
        {
            string sName = "";
            //Create an object of ManagementObjectSearcher class and pass query as parameter.
            ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementObject managementObject in mos.Get())
            {
                if (managementObject["Caption"] != null)
                {
                    sName = "Operating System Name  :  " + managementObject["Caption"].ToString().ToString();   //Display operating system caption
                }
                if (managementObject["OSArchitecture"] != null)
                {
                    sName = "Operating System Architecture  :  " + managementObject["OSArchitecture"].ToString().ToString();   //Display operating system architecture.
                }
                if (managementObject["CSDVersion"] != null)
                {
                    sName = "Operating System Service Pack   :  " + managementObject["CSDVersion"].ToString().ToString();     //Display operating system version.
                }
            }
            string name = "User name of PC :" + Environment.UserName; // User name of PC
            string Machine = "Machine name :" + Environment.MachineName;// Machine name
            return sName + "-" + name + "-" + Machine;
        }

        //Processor Name...
        public static string getProcessorInfo()
        {
            RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

            if (processor_name != null)
            {
                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    return processor_name.GetValue("ProcessorNameString").ToString();   //Display processor ingo.
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
