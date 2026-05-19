using HarmonyLib;
using UnityEngine;
using Rewired;

public static class GamepadFix
{
    static Harmony harmony;

    public static void Main()
    {
        Debug.Log("Patching...");
        harmony = Harmony.CreateAndPatchAll(typeof(Patch));
    }

    public static void Unload()
    {
        if (harmony != null)
        {
            Debug.Log("Unpatching...");
            harmony.UnpatchSelf();
        }
    }
}

class Patch
{
    [HarmonyPatch(typeof(GameController), "Update")]
    [HarmonyPostfix]
    static void GameController_Update()
    {
        var player = ReInput.players.GetPlayer(0);

        if (player == null)
        {
            return;
        }

        foreach (var joystick in ReInput.controllers.GetJoysticks())
        {
            player.controllers.AddController(joystick, true);
        }
    }
}
