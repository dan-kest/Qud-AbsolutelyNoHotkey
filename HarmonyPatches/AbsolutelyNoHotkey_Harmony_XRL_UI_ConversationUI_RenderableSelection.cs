using HarmonyLib;
using XRL.UI;
using AbsolutelyNoHotkey.Concepts;

namespace AbsolutelyNoHotkey.HarmonyPatches
{
    [HarmonyPatch(typeof(ConversationUI.RenderableSelection))]
    class AbsolutelyNoHotkey_Harmony_XRL_UI_ConversationUI_RenderableSelection
    {
        /// <summary>
        /// Written based on game version 2.0.206.3 Early Access
        /// - Replaces all hotkey symbols in legacy conversation UI.
        /// </summary>
        [HarmonyPostfix]
        [HarmonyPatch(nameof(ConversationUI.RenderableSelection.DisplayChar), MethodType.Getter)]
        static void PostfixDisplayChar(ref char __result)
        {
            __result = Symbol.ITEM;
        }
    }
}
