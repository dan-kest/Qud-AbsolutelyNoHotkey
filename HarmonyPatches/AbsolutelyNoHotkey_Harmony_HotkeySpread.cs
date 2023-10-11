using HarmonyLib;
using AbsolutelyNoHotkey.Concepts;

namespace AbsolutelyNoHotkey.HarmonyPatches
{
    [HarmonyPatch(typeof(HotkeySpread))]
    class AbsolutelyNoHotkey_Harmony_HotkeySpread
    {
        /// <summary>
        /// Written based on game version 2.0.206.3 Early Access
        /// - Replaces all hotkey symbols in legacy menu UI.
        /// </summary>
        [HarmonyPostfix]
        [HarmonyPatch(nameof(HotkeySpread.charAt))]
        static void PostfixCharAt(int n, ref char __result)
        {
            __result = Symbol.GetHotkey(n);
        }
    }
}
