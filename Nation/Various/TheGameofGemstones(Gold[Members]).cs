//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/Nation/CoreNation.cs
using Skua.Core.Interfaces;

public class TheGameofGemstones
{
    public IScriptInterface Bot => IScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreNation Nation = new();
    public CoreFarms Farm = new();

    public void ScriptMain(IScriptInterface bot)
    {
        Core.BankingBlackList.AddRange(new[] {"Tendurrr The Assistant", "Unidentified 13"});
        Core.SetOptions();

        Gold();

        Core.SetOptions(false);
    }

    public void Gold(int quant = 100000000)
    {
        if (!Core.IsMember)
            return;

        Nation.FarmUni13();

        Bot.Quests.UpdateQuest(597);
        Core.RegisterQuests(5815);
        while (!Bot.ShouldExit && Bot.Player.Gold < quant)
        {
            Nation.ApprovalAndFavor(1, 0);
            Core.HuntMonster("Lavarun", "Mega Tyndarius", "Archfiend's Amber", isTemp: false);
            Core.HuntMonster("Catacombs", "Dr. De'Sawed", "Phantasmia's Charoite", isTemp: false);
            Farm.BludrutBrawlBoss("Yoshino's Citrine");
            Core.HuntMonster("Wolfwing", "Wolfwing", "Tendou's Moonstone", isTemp: false);
            Core.HuntMonster("baconcatyou", "*", "Asuka's Ruby", isTemp: false);
        }
        Core.CancelRegisteredQuests();
    }
}
