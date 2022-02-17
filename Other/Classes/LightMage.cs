//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreFarms.cs
//cs_include Scripts/CoreAdvanced.cs
using RBot;
public class LightMage
{
    public CoreBots Core => CoreBots.Instance;
    public CoreFarms Farm = new CoreFarms();
    public CoreAdvanced Adv = new CoreAdvanced();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        GetLM();

        Core.SetOptions(false);
    }

    public void GetLM(bool rankUpClass = true)
    {
        if (Core.CheckInventory("LightMage"))
            return;

        Core.BuyItem("celestialrealm", 1353, "Evolved LightCaster");
        Core.BuyItem("celestialrealm", 1613, "LightMage Class Token A");
        Core.BuyItem("celestialrealm", 1612, "LightMage", shopItemID: 5987);

        if (rankUpClass)
            Adv.rankUpClass("LightMage");
    }
}