using HarmonyLib;
using ConsoleLib.Console;
using AbsolutelyNoHotkey.Configs;

namespace AbsolutelyNoHotkey.HarmonyPatches
{
    [HarmonyPatch(typeof(XRL.UI.ConversationUI))]
    class AbsolutelyNoHotkey_Harmony_XRL_UI_ConversationUI
    {
        /// <summary>
        /// Written based on game version 2.0.202.79 Beta
        /// - Replaces all hotkey prefix with a symbol in legacy conversation UI.
        /// </summary>
        [HarmonyPostfix]
        [HarmonyPatch("GetChoiceDisplayChar")]
        static void PostfixGetChoiceDisplayChar(ref string __result)
        {
            __result = CHOICES.SYMBOL.ToString();
        }

        /// <summary>
        /// Written based on game version 2.0.202.79 Beta
        /// - Removes all hotkey functionality in legacy conversation UI.
        /// </summary>
        [HarmonyPostfix]
        [HarmonyPatch("GetChoiceNumber")]
        static void PostfixGetChoiceNumber(ref Keys k, ref int __result)
        {
            if (k >= Keys.D1 && k <= Keys.D9)
            {
                __result = -1000;
            }
        }
    }
}
