using System.Collections.Generic;
using System.Text.RegularExpressions;
using HarmonyLib;
using Qud.UI;
using XRL.UI;
using AbsolutelyNoHotkey.Concepts;

namespace AbsolutelyNoHotkey.HarmonyPatches
{
    [HarmonyPatch(typeof(Popup))]
    class AbsolutelyNoHotkey_Harmony_XRL_UI_Popup
    {
        /// <summary>
        /// Written based on game version 2.0.206.3 Early Access
        /// - Removes all hotkeys functionality and symbol from modern popup UI.
        /// </summary>
        [HarmonyPrefix]
        [HarmonyPatch(nameof(Popup.ShowOptionList))]
        static void PrefixShowOptionList(ref IList<char> Hotkeys)
        {
            Hotkeys = null;
        }

        /// <summary>
        /// Written based on game version 2.0.206.3 Early Access
        /// - Removes all hotkeys functionality from modern conversation UI.
        /// - Replaces all hotkey symbols in modern conversation UI.
        /// </summary>
        [HarmonyPrefix]
        [HarmonyPatch(nameof(Popup.WaitNewPopupMessage))]
        static void PrefixWaitNewPopupMessage(ref List<QudMenuItem> options)
        {
            if (options != null)
            {
                string pattern = @"^({{.+\|\[)[0-9a-zA-Z](\]}}.*)";
                for (int i = 0; i < options.Count; i++)
                {
                    string text = options[i].text;
                    Match match = Regex.Match(text, pattern, RegexOptions.Singleline);
                    if (match.Success)
                    {
                        text = match.Groups[1].Value + Symbol.ITEM + match.Groups[2].Value;
                    }
                    options[i] = new QudMenuItem() {
                        text = text,
                        command = options[i].command,
                        icon = options[i].icon,
                        hotkey = "",
                    };
                }
            }
        }
    }
}
