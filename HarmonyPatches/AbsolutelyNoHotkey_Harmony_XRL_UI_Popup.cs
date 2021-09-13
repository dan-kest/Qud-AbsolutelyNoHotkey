using HarmonyLib;
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

    }
}
