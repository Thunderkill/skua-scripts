﻿//cs_include Scripts/CoreBots.cs
using Skua.Core.Interfaces;

public class BloodMoonToken
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;

    public void ScriptMain(IScriptInterface bot)
    {
        Core.SetOptions();

        BMToken();

        Core.SetOptions(false);
    }

    public void BMToken()
    {
        if (Core.CheckInventory("Blood Moon Token", 300))
            return;

        Core.FarmingLogger("Blood Moon Token", 300);
        Core.AddDrop("Blood Moon Token");

        Core.RegisterQuests(6059);
        while (!Bot.ShouldExit && !Core.CheckInventory("Blood Moon Token", 300))
        {
            Core.HuntMonster("bloodmoon", "Black Unicorn", "Black Blood Vial", 1, false);
            Core.HuntMonster("bloodmoon", "Lycan Guard", "Moon Stone", 1, false);

            Bot.Wait.ForPickup("Blood Moon Token");
        }
    }
}