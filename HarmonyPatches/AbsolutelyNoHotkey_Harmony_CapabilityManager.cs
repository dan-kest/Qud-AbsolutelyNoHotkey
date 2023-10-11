using HarmonyLib;

namespace AbsolutelyNoHotkey.HarmonyPatches
{
    [HarmonyPatch(typeof(CapabilityManager))]
    class AbsolutelyNoHotkey_Harmony_CapabilityManager
    {
        /// <summary>
        /// Written based on game version 2.0.206.3 Early Access
        /// - Removes all hotkey functionality from modern UI.
        /// </summary>
        [HarmonyPostfix]
        [HarmonyPatch(nameof(CapabilityManager.AllowKeyboardHotkeys), MethodType.Getter)]
        static void PostfixAllowKeyboardHotkeysGetter(ref bool __result)
        {
            __result = false;
        }
    }
}
