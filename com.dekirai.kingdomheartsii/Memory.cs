using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Memory;

namespace com.dekirai.kingdomheartsii
{
    public class Memory
    {
        public static Mem mem = new Mem();
        public static string process = "KINGDOM HEARTS II FINAL MIX.exe";

        private static void GetPID()
        {
            int pid = mem.GetProcIdFromName("KINGDOM HEARTS II FINAL MIX");
            bool openProc = false;

            if (pid > 0) openProc = mem.OpenProcess(pid);
        }

        public static void RefillHP()
        {
            GetPID();
            mem.WriteMemory($"{process}+2A20C98", "int", $"{mem.ReadInt($"{process}+2A20C9C")}");
        }
        public static void RefillMP()
        {
            GetPID();
            mem.WriteMemory($"{process}+2A20E18", "int", $"{mem.ReadInt($"{process}+2A20E1C")}");
            mem.WriteMemory($"{process}+2A20E54", "float", "0");
        }
        public static void RefillDrive()
        {
            GetPID();
            mem.WriteMemory($"{process}+2A20E49", "byte", $"{mem.ReadByte($"{process}+2A20E4A")}");
            mem.WriteMemory($"{process}+2A20E48", "byte", "0x63");
        }
        public static void TriggerValorForm()
        {
            GetPID();
            var CharCheck = mem.Read2Byte($"{process}+2A22A00");
            var CurrForm = mem.ReadByte($"{process}+9AA5D4");
            var keyblade = mem.ReadByte($"{process}+9AA484");
            if (CharCheck == 0x0054 || CharCheck == 0x0657 || CharCheck == 0x0656 || CharCheck == 0x0955 || CharCheck == 0x02B5 || CharCheck == 0x028A)
            {
                if (keyblade == 0)
                    mem.WriteMemory($"{process}+9AA3A4", "bytes", "0x29 0x00");
                if (CurrForm > 0)
                {
                    mem.WriteMemory($"{process}+2A5A096", "bytes", "0x05 0x00 0x01 0x00"); //Revert incase we are in a form already
                    Thread.Sleep(500);
                }
                mem.WriteMemory($"{process}+2A5A096", "bytes", "0x04 0x00 0x01 0x00");
                Thread.Sleep(400);
                mem.WriteMemory($"{process}+2A5A096", "bytes", "0x00 0x00 0x00 0x00");
            }
        }
        public static void TriggerWisdomForm()
        {
            GetPID();
            var CharCheck = mem.Read2Byte($"{process}+2A22A00");
            var CurrForm = mem.ReadByte($"{process}+9AA5D4");
            if (CharCheck == 0x0054 || CharCheck == 0x0657 || CharCheck == 0x0656 || CharCheck == 0x0955 || CharCheck == 0x02B5 || CharCheck == 0x028A)
            {
                if (CurrForm > 0)
                {
                    mem.WriteMemory($"{process}+2A5A096", "bytes", "0x05 0x00 0x02 0x00"); //Revert incase we are in a form already
                    Thread.Sleep(500);
                }
                mem.WriteMemory($"{process}+2A5A096", "bytes", "0x04 0x00 0x02 0x00");
                Thread.Sleep(400);
                mem.WriteMemory($"{process}+2A5A096", "bytes", "0x00 0x00 0x00 0x00");
            }
        }
        public static void TriggerLimitForm()
        {
            GetPID();
            var CharCheck = mem.Read2Byte($"{process}+2A22A00");
            var CurrForm = mem.ReadByte($"{process}+9AA5D4");
            if (CharCheck == 0x0054 || CharCheck == 0x0657 || CharCheck == 0x0656 || CharCheck == 0x0955 || CharCheck == 0x02B5 || CharCheck == 0x028A)
            {
                if (CurrForm > 0)
                {
                    mem.WriteMemory($"{process}+2A5A096", "bytes", "0x05 0x00 0x01 0x00"); //Revert incase we are in a form already
                    Thread.Sleep(500);
                }
                mem.WriteMemory($"{process}+2A5A096", "bytes", "0x04 0x00 0x03 0x00");
                Thread.Sleep(1000);
                mem.WriteMemory($"{process}+2A5A096", "bytes", "0x00 0x00 0x00 0x00");
            }
        }
        public static void TriggerMasterForm()
        {
            GetPID();
            var CharCheck = mem.Read2Byte($"{process}+2A22A00");
            var CurrForm = mem.ReadByte($"{process}+9AA5D4");
            var keyblade = mem.ReadByte($"{process}+9AA484");
            if (CharCheck == 0x0054 || CharCheck == 0x0657 || CharCheck == 0x0656 || CharCheck == 0x0955 || CharCheck == 0x02B5 || CharCheck == 0x028A)
            {
                if (keyblade == 0)
                    mem.WriteMemory($"{process}+9AA44C", "bytes", "0x29 0x00");
                if (CurrForm > 0)
                {
                    mem.WriteMemory($"{process}+2A5A096", "bytes", "0x05 0x00 0x01 0x00"); //Revert incase we are in a form already
                    Thread.Sleep(500);
                }
                mem.WriteMemory($"{process}+2A5A096", "bytes", "0x04 0x00 0x04 0x00");
                Thread.Sleep(400);
                mem.WriteMemory($"{process}+2A5A096", "bytes", "0x00 0x00 0x00 0x00");
            }
        }
        public static void TriggerFinalForm()
        {
            GetPID();
            var CharCheck = mem.Read2Byte($"{process}+2A22A00");
            var CurrForm = mem.ReadByte($"{process}+9AA5D4");
            var keyblade = mem.ReadByte($"{process}+9AA484");
            if (CharCheck == 0x0054 || CharCheck == 0x0657 || CharCheck == 0x0656 || CharCheck == 0x0955 || CharCheck == 0x02B5 || CharCheck == 0x028A)
            {
                if (keyblade == 0)
                    mem.WriteMemory($"{process}+9AA484", "bytes", "0x29 0x00");
                if (CurrForm > 0)
                {
                    mem.WriteMemory($"{process}+2A5A096", "bytes", "0x05 0x00 0x01 0x00"); //Revert incase we are in a form already
                    Thread.Sleep(500);
                }
                mem.WriteMemory($"{process}+2A5A096", "bytes", "0x04 0x00 0x05 0x00");
                Thread.Sleep(400);
                mem.WriteMemory($"{process}+2A5A096", "bytes", "0x00 0x00 0x00 0x00");
            }
        }
        public static void TriggerAntiForm()
        {
            GetPID();
            var CharCheck = mem.Read2Byte($"{process}+2A22A00");
            var CurrForm = mem.ReadByte($"{process}+9AA5D4");
            var keyblade = mem.ReadByte($"{process}+9AA484");
            if (CharCheck == 0x0054 || CharCheck == 0x0657 || CharCheck == 0x0656 || CharCheck == 0x0955 || CharCheck == 0x02B5 || CharCheck == 0x028A)
            {
                if (keyblade == 0)
                    mem.WriteMemory($"{process}+9AA3A4", "bytes", "0x29 0x00");
                if (CurrForm > 0)
                {
                    mem.WriteMemory($"{process}+2A5A096", "bytes", "0x05 0x00 0x01 0x00"); //Revert incase we are in a form already
                    Thread.Sleep(500);
                }
                mem.WriteMemory($"{process}+2A5A096", "bytes", "0x04 0x00 0x06 0x00");
                Thread.Sleep(400);
                mem.WriteMemory($"{process}+2A5A096", "bytes", "0x00 0x00 0x00 0x00");
            }
        }
        public static void TriggerRevert()
        {
            GetPID();
            mem.WriteMemory($"{process}+2A5A096", "bytes", "0x05 0x00 0x01 0x00");
            Thread.Sleep(400);
            mem.WriteMemory($"{process}+2A5A096", "bytes", "0x00 0x00 0x00 0x00");
        }
    }

}
