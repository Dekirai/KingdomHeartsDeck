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

        public static void RefillHP()
        {
            GetPID();
            mem.WriteMemory($"{process}+2D592CC", "int", $"{mem.ReadInt($"{process}+2D592D0")}");
        }
        public static void RefillMP()
        {
            GetPID();
            mem.WriteMemory($"{process}+2D592D4", "int", $"{mem.ReadInt($"{process}+2D592D8")}");
        }

        public static void SoftReset()
        {
            GetPID();
            mem.WriteMemory($"{process}+22E86E0", "byte", "0x01");
            mem.WriteMemory($"{process}+22E86DC", "byte", "0x02");
            mem.WriteMemory($"{process}+233C240", "byte", "0x01");
        }
    }

}
