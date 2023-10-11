using System;
using HarmonyLib;
using ConsoleLib.Console;
using Qud.UI;
using XRL.UI;
using System.Reflection;

namespace AbsolutelyNoHotkey.HarmonyPatches
{
    [HarmonyPatch(typeof(ConversationUI))]
    class AbsolutelyNoHotkey_Harmony_XRL_UI_ConversationUI
    {
        /// <summary>
        /// Written based on game version 2.0.206.3 Early Access
        /// - Removes all hotkeys functionality from legacy conversation UI.
        /// </summary>
        [HarmonyPrefix]
        [HarmonyPatch(nameof(ConversationUI.Select))]
        static bool PrefixSelect(ref bool __result)
        {
            Keys keys = Keyboard.vkCode;
            if (!UIManager.UseNewPopups && ((keys >= Keys.D1 && keys <= Keys.D9) || (keys >= Keys.A && keys <= Keys.Z)))
            {
                Assembly asm = typeof(ConversationUI).Assembly;
                Type typ = asm.GetType("XRL.UI.CommandBindingManager") ?? asm.GetType("XRL.UI.LegacyKeyMapping");
                MethodInfo method = typ?.GetMethod("MapKeyToCommand", BindingFlags.Public | BindingFlags.Static, null,
                        new Type[] {typeof(int), typeof(string[])}, null);
                string cmd = (string) method?.Invoke(null, new object[] {Keyboard.MetaKey, null});
                if (cmd == "CmdMoveS")
                {
                    ConversationUI.SelectedChoice++;
                }
                if (cmd == "CmdMoveN")
                {
                    ConversationUI.SelectedChoice--;
                }
                __result = true;
                return false;
            }
            return true;
        }
    }
}
