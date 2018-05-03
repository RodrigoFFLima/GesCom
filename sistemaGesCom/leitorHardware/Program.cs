using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;

namespace leitorHardware
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Server=tcp:gescomserver.database.windows.net,1433;Initial Catalog=GesCom;Persist Security Info=False;User ID=Rodrigo;Password=afl@2015;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

            string maq_nome = "";
            string maq_procNome = "";
            string maq_memoriaRam = "";
            string maq_memoriaHD = "";
            string maq_placaVideo = "";
            string maq_sisOperacional = "";

            string path = @"C:\Users\rodri\Desktop\Example.txt";
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    //tb_maquinario maq = new tb_maquinario();

                    maq_nome = getComponent("Win32_DiskDrive", "SystemName").ToString();
                    maq_procNome = getComponent("Win32_Processor", "Name").ToString();
                    maq_memoriaRam = getComponent("win32_PhysicalMemory ", "Capacity").ToString();
                    maq_memoriaHD = getComponent("Win32_DiskDrive", "Size").ToString();
                    maq_placaVideo = getComponent("Win32_VideoController ", "Name").ToString();
                    maq_sisOperacional = getComponent("Win32_OperatingSystem", "Name").ToString();

                    //int maq_id = (new MaquinaBusiness()).InserirMaquina(maq);

                    string sql = "INSERT INTO tb_maquinario (maq_nome, maq_procNome, maq_memoriaRam, maq_memoriaHD, maq_placaVideo, maq_sisOperacional) "
                      + "VALUES ('" + maq_nome + "', '" + maq_procNome + "', '" + maq_memoriaRam + "', '" + maq_memoriaHD + "', '" + maq_placaVideo + "', '" + maq_sisOperacional + "')";

                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            Console.WriteLine("Cadastro realizado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro: " + ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }

                    tw.WriteLine(maq_nome);
                    tw.WriteLine(maq_procNome);
                    tw.WriteLine(maq_memoriaRam);
                    tw.WriteLine(maq_memoriaHD);
                    tw.WriteLine(maq_placaVideo);
                    tw.WriteLine(maq_sisOperacional);

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

                    //tb_maquinario maq = new tb_maquinario();
                    maq_nome = quebrado[0];
                    maq_procNome = quebrado[1];
                    maq_memoriaRam = quebrado[2];
                    maq_memoriaHD = quebrado[3];
                    maq_placaVideo = quebrado[4];
                    maq_sisOperacional = quebrado[5];

                    string sql = "UPDATE tb_maquinario SET maq_procNome='" + maq_procNome + "', maq_memoriaRam = '" + maq_memoriaRam + "', " + "maq_memoriaHD='" + maq_memoriaHD + "', maq_placaVideo='" + maq_placaVideo +
                            "', maq_sisOperacional = '" + maq_sisOperacional + "'" + " WHERE maq_nome='" + maq_nome + "'";


                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    try
                    {
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            Console.WriteLine("Cadastro realizado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro: " + ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }

                    //(new MaquinaBusiness()).AlterarMaquina(maq);
                }
            }
        }

        private static string getComponent(string hwclass, string syntax)
        {
            string ret = "";
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM " + hwclass);
            foreach (ManagementObject mj in mos.Get())
            {
                if (syntax == "Size" || syntax == "Capacity")
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
