using System.Collections.Generic;
using System.Text.RegularExpressions;
using HarmonyLib;
using Qud.UI;
using AbsolutelyNoHotkey.Configs;

namespace AbsolutelyNoHotkey.HarmonyPatches
{
    [HarmonyPatch(typeof(XRL.UI.Popup))]
    class AbsolutelyNoHotkey_Harmony_XRL_UI_Popup
    {
        /// <summary>
        /// Written based on game version 2.0.202.79 Beta
        /// - Replaces all hotkey prefix with a symbol in moderns and legacy popup UI.
        /// - Removes all hotkey functionality in modern and legacy popup UI.
        /// </summary>
        [HarmonyPrefix]
        [HarmonyPatch("ShowOptionList")]
        static void PrefixShowOptionList(ref char[] Hotkeys)
        {
            for (int i = 0; i < Hotkeys.Length; i++)
            {
                Hotkeys[i] = CHOICES.SYMBOL;
            }
        }

        // /// <summary>
        // /// Written based on game version 2.0.202.79 Beta
        // /// - Replaces all hotkey prefix with a symbol in modern conversation UI.
        // /// - Removes all hotkey functionality in modern conversation UI.
        // /// *The string pattern used to replace and UI checking condition was based on values
        // /// assigned in XRL/UI/Popup.cs-> ShowConversation() method.
        // /// </summary>
        // [HarmonyPrefix]
        // [HarmonyPatch("WaitNewPopupMessage")]
        // static void PrefixWaitNewPopupMessage(List<QudMenuItem> options)
        // {
        //     string regexPattern = @"^{{w\|\[\d\]}} ";
        //     string replaceWith = "{{w|[" + CHOICES.SYMBOL + "]}} ";
        //     for (int i = 0; i < options.Count; i++)
        //     {
        //         // Check if current popup is really a conversation UI
        //         // if (Regex.IsMatch(options[i].text, regexPattern) && options[i].command.StartsWith("Alpha"))
        //         if (Regex.IsMatch(options[i].text, regexPattern))
        //         {
        //             // options[i] = new QudMenuItem
        //             // {
        //             //     text = Regex.Replace(options[i].text, regexPattern, replaceWith),
        //             //     command = options[i].command,
        //             //     hotkey = null,
        //             // };
        //         }
        //     }
        // }
    }
}
