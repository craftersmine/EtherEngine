using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using craftersmine.EtherEngine.Utilities;

namespace craftersmine.EtherEngine.Core
{
    /// <summary>
    /// Contains static methods to handle crashes
    /// </summary>
    public static class CrashHandler
    {
        private static string[] crashMessages = {
            "I've cookies!",
            "What have you done...",
            "Ah, here we go again...",
            "I've blown up some TNT",
            "RUN AWAY!",
            "2 + 2 = 5",
            "missingno",
            "You could probably wait for next patch",
            "Did you saved it?",
            "Bloop!",
            "0x0000c418",
            "I don't have any boost!",
            "Is this green thing can explode or not?",
            "IT'S TIME TO STOP!",
            "Contains cats!",
            "Powered by electricity!",
            "Catch it!",
            "Let's think outside the box",
            "Argon doesn't react...",
            "// Is this a comment?",
            "Broke everything? I don't care",
            "Isn't the Earth is Base for everything?",
            "Just make NOT it!",
            "Gluten free!",
            "Nya!",
            "1993 Graphics, 2019 RAM Usage",
            "Pyyxels!",
            "F3 + C for 6 and more seconds",
            "Where is the universe?",
            "Blackwoody",
            "Steamy",
            "Vurp!",
            "Not physics-based!",
            "I've lost the gear",
            "Chilly...",
            "This is probably 0x...",
            "Fork and Pull!",
            "There so many symbols!...",
            "Far, far away...",
            "Ethernal...",
            "bits and bytes",
            "ac969dac8b9e8ddf968cdfac969d9a8d969e91dfb89e92969198dfbc939e91de",
            "Noice!",
            "Helium falls, Ferrum floats up",
            "1",
            "Keep calm and Debug",
            "You've catch on fire!",
            "Hmm, is it two?",
            "c3BvdGlmeTp0cmFjazo0TnNQZ1JZVWRIdTJRNUpSTmdYWVU1",
            "Never gonna give You up!"
        };

        /// <summary>
        /// Handles specified exception, writes it into log, shows user crash message and after closing crash message exits the game
        /// </summary>
        /// <param name="ex">Thrown exception</param>
        public static void Handle(Exception ex)
        {
            int rnd = new Random().Next(0, crashMessages.Length + 1);
            Debugging.Log(LogEntryType.Crash, crashMessages[rnd]);
            Debugging.LogException(LogEntryType.Crash, ex);
            new CrashHandlerForm(ex).ShowDialog();
            Game.Exit(ex.HResult);
        }
    }
}
