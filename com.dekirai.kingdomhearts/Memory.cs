using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory;

namespace com.dekirai.kingdomhearts
{
    public class Memory
    {
        public static Mem mem = new Mem();
        public static string process = "KINGDOM HEARTS FINAL MIX.exe";

        public static int GetPID()
        {
            int pid = mem.GetProcIdFromName("KINGDOM HEARTS FINAL MIX");
            bool openProc = false;

            if (pid > 0) openProc = mem.OpenProcess(pid);
            return pid;
        }

        //public static void RefillHP()
        //{
        //    GetPID();
        //    mem.WriteMemory($"{process}+2A20C98", "int", $"{mem.ReadInt($"{process}+2A20C9C")}");
        //}
        //public static void RefillMP()
        //{
        //    GetPID();
        //    mem.WriteMemory($"{process}+2A20E18", "int", $"{mem.ReadInt($"{process}+2A20E1C")}");
        //    mem.WriteMemory($"{process}+2A20E54", "float", "0");
        //}

        //public static void SoftReset()
        //{
        //    GetPID();
        //    mem.WriteMemory($"{process}+AB845A", "byte", "0x01");
        //    mem.WriteMemory($"{process}+751310", "byte", "0x01");
        //    mem.WriteMemory($"{process}+2AE3478", "byte", "0x00");
        //}
    }

}
