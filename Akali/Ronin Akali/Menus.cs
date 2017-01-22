using System.Drawing;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace Eclipse
{
    internal class Menus
    {
        public static Menu FirstMenu;
        public static Menu ComboMenu;
        public static Menu HarassMenu;
        public static Menu LaneClearMenu;
        public static Menu LasthitMenu;
        public static Menu JungleClearMenu;
        public static Menu KillStealMenu;
        public static Menu DrawingsMenu;
        public static Menu MiscMenu;

        public const string ComboMenuID = "combomenuid";
        public const string HarassMenuID = "harassmenuid";
        public const string LaneClearMenuID = "laneclearmenuid";
        public const string LastHitMenuID = "lasthitmenuid";
        public const string JungleClearMenuID = "jungleclearmenuid";
        public const string KillStealMenuID = "killstealmenuid";
        public const string DrawingsMenuID = "drawingsmenuid";
        public const string MiscMenuID = "miscmenuid";

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("Ronin "+Player.Instance.ChampionName, Player.Instance.ChampionName.ToLower() + "ronin");
			FirstMenu.AddGroupLabel("Addon sahibi Taazuma / Kullandığınız için teşekkürler");
            FirstMenu.AddLabel("Herhangi bir hata bulduysanız, bunu benim Konuma bildirin.");
            FirstMenu.AddLabel("Oynarken eğlenin");
            ComboMenu = FirstMenu.AddSubMenu("Combo", ComboMenuID);
            HarassMenu = FirstMenu.AddSubMenu("Harass", HarassMenuID);
            LaneClearMenu = FirstMenu.AddSubMenu("LaneClear", LaneClearMenuID);
            //LasthitMenu = FirstMenu.AddSubMenu("LastHit", LastHitMenuID);
            JungleClearMenu = FirstMenu.AddSubMenu("JungleClear", JungleClearMenuID);
            KillStealMenu = FirstMenu.AddSubMenu("KillSteal", KillStealMenuID);
            DrawingsMenu = FirstMenu.AddSubMenu("Drawings", DrawingsMenuID);
            MiscMenu = FirstMenu.AddSubMenu("Misc", MiscMenuID);

            ComboMenu.AddGroupLabel("ComboMenu");
            ComboMenu.AddGroupLabel("ONLY USE ON COMBO");
            ComboMenu.AddSeparator(15);
            // --------------------------------------------------------------COMBO LOGICS-------------------------------------------------------------- //
            ComboMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            ComboMenu.AddLabel("Logics");
            ComboMenu.AddSeparator(4);
            ComboMenu.Add("Comba", new ComboBox(" Kombo Türü ", 0, "Normal", "Genis", "Uzak", "Insec"));
            ComboMenu.Add("WC", new ComboBox(" W Pozisyonu ", 1, "W Fare", "W Dusman", "W Güvenli"));
            ComboMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            ComboMenu.AddLabel("Spells");
            ComboMenu.CreateCheckBox(" - Kullan Q", "qUse");
            ComboMenu.CreateCheckBox(" - Kullan W", "wUse");
            ComboMenu.CreateCheckBox(" - Kullan E", "eUse");
            ComboMenu.CreateCheckBox(" - Kullan R", "rUse");
            ComboMenu.AddLabel("Humanizer Settings");
            ComboMenu.Add("Qdelay", new Slider("Q Gecikmesi (ms)", 0, 0, 300));
            ComboMenu.Add("Edelay", new Slider("E Gecikmesi (ms)", 0, 0, 300));
            ComboMenu.Add("Rdelay", new Slider("R Gecikmesi (ms)", 0, 0, 300));
            ComboMenu.AddSeparator(10);
            ComboMenu.AddLabel("Logic Infos");
            ComboMenu.AddLabel("1. Combo Q - AA - R - E - W");
            ComboMenu.AddSeparator(6);
            ComboMenu.AddLabel("2. Combo Q - AA - E - R - W");
            ComboMenu.AddSeparator(6);
            ComboMenu.AddLabel("3. Combo R - Q - AA - E - W");
            ComboMenu.AddSeparator(6);
            ComboMenu.AddLabel("4. Combo (0 Checks) in a sec");
            ComboMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            HarassMenu.AddGroupLabel("Harass");
            HarassMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            HarassMenu.CreateCheckBox(" - Kullan Q", "qUse", false);
            HarassMenu.CreateCheckBox(" - Kullan AA Reset", "qUse", false);
            HarassMenu.CreateCheckBox(" - Kullan E", "eUse");
            HarassMenu.AddGroupLabel("Settings");
            HarassMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            LaneClearMenu.AddGroupLabel("LaneClear");
            LaneClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            LaneClearMenu.CreateCheckBox(" - Kullan Q", "qUse");
            LaneClearMenu.CreateCheckBox(" - Kullan AA Reset", "aaclear");
            LaneClearMenu.CreateCheckBox(" - Kullan E", "eUse");
            LaneClearMenu.CreateCheckBox(" - Kullan R", "rUse", false);
            LaneClearMenu.AddGroupLabel("Settings");
            LaneClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            JungleClearMenu.AddGroupLabel("JungleClear");
            JungleClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            JungleClearMenu.CreateCheckBox(" - Kullan Q", "qUse");
            JungleClearMenu.CreateCheckBox(" - Kullan AA Reset", "abclear");
            JungleClearMenu.CreateCheckBox(" - Kullan E", "eUse");
            JungleClearMenu.CreateCheckBox(" - Kullan R", "rUse", false);
            JungleClearMenu.AddGroupLabel("Settings");
            JungleClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            KillStealMenu.AddGroupLabel("KillSteal");
            KillStealMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            KillStealMenu.CreateCheckBox(" - Kullan Q", "qUse", false);
            KillStealMenu.CreateCheckBox(" - Kullan E", "eUse");
            KillStealMenu.CreateCheckBox("- Kullan R", "rUse", false);
            KillStealMenu.AddGroupLabel("News");
            KillStealMenu.AddLabel("Yoyo new KS");
            KillStealMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            DrawingsMenu.AddGroupLabel("Settings");
            DrawingsMenu.AddGroupLabel("Tracker Draws");
            DrawingsMenu.Add("me", new CheckBox("Benim yolum", false));
            DrawingsMenu.Add("ally", new CheckBox("Takım yolu", false));
            DrawingsMenu.Add("enemy", new CheckBox("Düsman yolu", true));
            DrawingsMenu.AddLabel("Tracker Misc");
            DrawingsMenu.Add("toggle", new KeyBind("Degistir Acık/Kapali", true, KeyBind.BindTypes.PressToggle, 'G'));
            DrawingsMenu.Add("eta", new CheckBox("Tahmini Varıs Zamanı (Sadece ben)", true));
            DrawingsMenu.Add("name", new CheckBox("Sampiyon ismi", true));
            DrawingsMenu.Add("thick", new Slider("Çizgi Kalınlığı", 2, 1, 5));
            DrawingsMenu.AddGroupLabel("Disable while use orbwalk");
            DrawingsMenu.Add("combo", new CheckBox("Kombo", true));
            DrawingsMenu.Add("harass", new CheckBox("Durtme", true));
            DrawingsMenu.Add("laneclear", new CheckBox("Koridor temizle", false));
            DrawingsMenu.Add("lasthit", new CheckBox("Son vurus", true));
            DrawingsMenu.Add("flee", new CheckBox("Kacis", false));

            MiscMenu.AddGroupLabel("Settings");
            MiscMenu.CreateCheckBox("Auto Q", "autoq", false);
            MiscMenu.CreateCheckBox("W when low", "wlow", false);
            MiscMenu.CreateCheckBox("Use Items", "useitems");
            MiscMenu.AddLabel("Level Up Function");
            MiscMenu.Add("lvlup", new CheckBox("Auto Level Up Spells", false));
            //MiscMenu.Add("Lvldelay", new Slider("Lvlup Delay (ms)", 0, 0, 500));
            MiscMenu.AddSeparator(15);
            MiscMenu.CreateCheckBox("Skin secici aktif", "skinhax", false);
            MiscMenu.Add("skinID", new ComboBox("Skin Sec", 0, "Default", "Kızıl Akali", "DeserGecer Akali", "Fırtına forvet Akali", "Hemsire Akali", "Kanlı ay Akali", "Gümüsdis Akali", "Kafa Avcisi Akali", "Susici Akali"));
        }
        public static int Qdelay { get { return ComboMenu["Qdelay"].Cast<Slider>().CurrentValue; } }
        public static int Edelay { get { return ComboMenu["Edelay"].Cast<Slider>().CurrentValue; } }
        public static int Rdelay { get { return ComboMenu["Rdelay"].Cast<Slider>().CurrentValue; } }
        public static int Lvldelay { get { return MiscMenu["Lvldelay"].Cast<Slider>().CurrentValue; } }
    }
}
