using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\rodri\Desktop\Example.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    tb_maquinario maq = new tb_maquinario();
                    maq.maq_procNome = getComponent("Win32_Processor", "Name").ToString();
                    maq.maq_memoriaRam = getComponent("win32_PhysicalMemory ", "Capacity").ToString();
                    maq.maq_memoriaHD = getComponent("Win32_DiskDrive", "Size").ToString();
                    maq.maq_placaVideo = getComponent("Win32_VideoController ", "Name").ToString();
                    maq.maq_sisOperacional = getComponent("Win32_OperatingSystem", "Name").ToString();

                    int maq_id = (new MaquinaBusiness()).InserirMaquina(maq);

                    tw.WriteLine(maq_id);
                    tw.WriteLine(maq.maq_procNome);
                    tw.WriteLine(maq.maq_memoriaRam);
                    tw.WriteLine(maq.maq_memoriaHD);
                    tw.WriteLine(maq.maq_placaVideo);
                    tw.WriteLine(maq.maq_sisOperacional);

                    tw.Close();
                }
                
            }
            else
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadToEnd();
                    Console.WriteLine(line);

                    string original = (Convert.ToString(line));
                    string[] quebrado = Regex.Split(original, @"\r\n");

                    tb_maquinario maq = new tb_maquinario();
                    maq.maq_id = Convert.ToInt32(quebrado[0]);
                    maq.maq_procNome = quebrado[1];
                    maq.maq_memoriaRam = quebrado[2];
                    maq.maq_memoriaHD = quebrado[3];
                    maq.maq_placaVideo = quebrado[4];
                    maq.maq_sisOperacional = quebrado[5];

                    (new MaquinaBusiness()).AlterarMaquina(maq);
                }
            }
            
            Console.Read();
        }

        private static string getComponent(string hwclass, string syntax)
        {
            string ret = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
            foreach (ManagementObject mj in mos.Get())
            {
                if(syntax == "Size" || syntax == "Capacity")
                  return FormatByteSize(Convert.ToDouble((mj[syntax])));
                if (hwclass == "Win32_OperatingSystem")
                {
                    string original = (Convert.ToString(mj[syntax]));
                    string[] quebrado = original.Split('|');
                    string sistemaOperacional = quebrado[0];

                    return sistemaOperacional;

                }
                else
                    return (Convert.ToString(mj[syntax]));
            }

            return ret;
        }

        private static string FormatByteSize(double bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            int index = 0;
            do { bytes /= 1024; index++; }
            while (bytes >= 1024);
            return String.Format("{0:0.00} {1}", bytes, Suffix[index]);
        }
    }
}
