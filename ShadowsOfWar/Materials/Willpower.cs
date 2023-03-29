/*
name: Farms Willpower
description: Farms the Willpower from Shadows of War
tags: Willpower, shadows of war
*/
//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
//cs_include Scripts/CoreStory.cs
//cs_include Scripts/ShadowsOfWar/CoreSOfWar.cs
//cs_include Scripts/Story/ShadowsOfWar/CoreSoW.cs
using Skua.Core.Interfaces;

public class UnboundThread
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreSOfWar SOfWar = new CoreSOfWar();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.Add("Willpower");

        Core.SetOptions();

        SOfWar.Willpower();

        Core.SetOptions(false);
    }
}
