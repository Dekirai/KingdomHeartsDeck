using System.Threading.Tasks;
using System.Timers;
using StreamDeckCS;
using StreamDeckCS.EventsReceived;

namespace com.dekirai.kingdomheartsii
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Plugin plugin = new Plugin(args);
            await plugin.startPluginAsync();
        }

        public class Plugin
        {
            StreamdeckCore core;
            //Timer timer;

            // fields
            //private int numPressed = 0;
            //private int timerDuration = 2000;
            //private string context = null;

            public Plugin(string[] args)
            {
                core = new StreamdeckCore(args);
                //timer = new Timer(timerDuration);

                // subscribe to events
                //timer.Elapsed += Timer_Elapsed;
                core.KeyUpEvent += Core_KeyUpEvent;
                core.KeyDownEvent += Core_KeyDownEvent;
                core.WillAppearEvent += Core_WillAppearEvent;

                //timer.Enabled = true;

            }

            // raises when button is held for timerDuration (2000 ms i.e 2 seconds), resets counter
            private void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                //Not used for now
            }
            private void Core_KeyDownEvent(object sender, KeyDown e)
            {
                if (Memory.GetPID() == 0)
                {
                    core.showAlert(e.context);
                    return;
                }
                else
                    core.showOk(e.context);
                switch (e.action)
                {
                    case "com.dekirai.kingdomheartsii.refillhp":
                        Memory.RefillHP();
                        break;
                    case "com.dekirai.kingdomheartsii.refillmp":
                        Memory.RefillMP();
                        break;
                    case "com.dekirai.kingdomheartsii.refilldrive":
                        Memory.RefillDrive();
                        break;
                    case "com.dekirai.kingdomheartsii.valorform":
                        Memory.TriggerValorForm();
                        break;
                    case "com.dekirai.kingdomheartsii.wisdomform":
                        Memory.TriggerWisdomForm();
                        break;
                    case "com.dekirai.kingdomheartsii.masterform":
                        Memory.TriggerMasterForm();
                        break;
                    case "com.dekirai.kingdomheartsii.limitform":
                        Memory.TriggerLimitForm();
                        break;
                    case "com.dekirai.kingdomheartsii.finalform":
                        Memory.TriggerFinalForm();
                        break;
                    case "com.dekirai.kingdomheartsii.antiform":
                        Memory.TriggerAntiForm();
                        break;
                    case "com.dekirai.kingdomheartsii.revert":
                        Memory.TriggerRevert();
                        break;
                    case "com.dekirai.kingdomheartsii.softreset":
                        Memory.SoftReset();
                        break;
                }
            }

            // when we release key, stop timer and set title of the key to next num in fibonacci sequence
            private void Core_KeyUpEvent(object sender, KeyUp e)
            {
                //timer.Stop();
            }

            // when the key appears on the stream deck, set title to "Fib"
            private void Core_WillAppearEvent(object sender, WillAppear e)
            {
                //Not used for now
            }

            // starts the plugin
            public async Task startPluginAsync()
            {
                await core.Start();
            }

        }
    }
}