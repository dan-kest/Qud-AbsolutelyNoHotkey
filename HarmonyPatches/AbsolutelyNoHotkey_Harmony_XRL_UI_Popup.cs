using System.Collections.Generic;
using HarmonyLib;
using Qud.UI;
using XRL.UI;

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
        /// </summary>
        [HarmonyPrefix]
        [HarmonyPatch(nameof(Popup.WaitNewPopupMessage))]
        static void PrefixWaitNewPopupMessage(ref List<QudMenuItem> options)
        {
            if (options != null)
            {
                for (int i = 0; i < options.Count; i++)
                {
                    options[i] = new QudMenuItem() {
                        text = options[i].text,
                        command = options[i].command,
                        icon = options[i].icon,
                        hotkey = "",
                    };
                }
            }
        }
    }
}
