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
        public static Menu AutoHarassMenu;
        public static Menu LaneClearMenu;
        public static Menu JungleClearMenu;
        public static Menu KillStealMenu;
        public static Menu DrawingsMenu;
        public static Menu MiscMenu;

        public static ColorSlide QColorSlide;
        public static ColorSlide WColorSlide;
        public static ColorSlide EColorSlide;
        public static ColorSlide RColorSlide;
        public static ColorSlide DamageIndicatorColorSlide;

        public const string ComboMenuID = "combomenuid";
        public const string AutoHarassMenuID = "autoharassmenuid";
        public const string LaneClearMenuID = "laneclearmenuid";
        public const string JungleClearMenuID = "jungleclearmenuid";
        public const string KillStealMenuID = "killstealmenuid";
        public const string DrawingsMenuID = "drawingsmenuid";
        public const string MiscMenuID = "miscmenuid";

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("Ronin "+Player.Instance.ChampionName, Player.Instance.ChampionName.ToLower() + "taazuma");
			FirstMenu.AddGroupLabel("Yapımcı Taazuma / Kullandığınız için teşekkürler");
            FirstMenu.AddLabel("Herhangi bir hata bulduysanız, bunu benim Konuma bildirin.");
            FirstMenu.AddLabel("Oynarken eğlenin");
            FirstMenu.AddLabel("Çeviri TekinTR");
            FirstMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            FirstMenu.Add(SpellsManager.Q.Slot + "hit", new ComboBox("Q Vurma sansi", 0, "Yüksek", "Orta", "Düşük"));
            FirstMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            ComboMenu = FirstMenu.AddSubMenu("Combo", ComboMenuID);
            AutoHarassMenu = FirstMenu.AddSubMenu("AutoHarass", AutoHarassMenuID);
            LaneClearMenu = FirstMenu.AddSubMenu("LaneClear", LaneClearMenuID);
            JungleClearMenu = FirstMenu.AddSubMenu("JungleClear", JungleClearMenuID);
            KillStealMenu = FirstMenu.AddSubMenu("KillSteal", KillStealMenuID);
            DrawingsMenu = FirstMenu.AddSubMenu("Drawings", DrawingsMenuID);
            MiscMenu = FirstMenu.AddSubMenu("Misc", MiscMenuID);

            ComboMenu.AddGroupLabel("ComboMenu");
            ComboMenu.AddSeparator(10);
            // --------------------------------------------------------------COMBO LOGICS-------------------------------------------------------------- //
            ComboMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            ComboMenu.AddLabel("Combo");
            ComboMenu.AddSeparator(7);
            ComboMenu.CreateCheckBox(" - Kullan Q", "qUse");
            ComboMenu.CreateCheckBox(" - Kullan W", "wUse");
            ComboMenu.CreateCheckBox(" - Kullan E", "eUse");
            ComboMenu.CreateCheckBox(" - Kullan R", "rUse");
            ComboMenu.Add("combouseE", new Slider("Kullan E komboda canım azsa hp < ({0}%)", 60));
            ComboMenu.Add("comboEnemies", new Slider("E en az düşman >=", 2, 1, 5));
            ComboMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            AutoHarassMenu.AddGroupLabel("AutoHarass");
            AutoHarassMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            AutoHarassMenu.CreateCheckBox(" - Kullan Q", "qUse");
            AutoHarassMenu.CreateCheckBox(" - Kullan RQ", "rqUse", false);
            AutoHarassMenu.AddGroupLabel("Settings");
            AutoHarassMenu.CreateKeyBind("Enable/Disable AutoHrass", "autoHarassKey", 'Z', 'U');
            AutoHarassMenu.CreateSlider("Mana daha yüksek olmalı [{0}%] otomatik dürtmek için", "manaSlider", 65);
            AutoHarassMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            LaneClearMenu.AddGroupLabel("LaneClear/Lasthit");
            LaneClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            LaneClearMenu.CreateCheckBox(" - Kullan Q", "qUse");
            LaneClearMenu.AddGroupLabel("Settings");
            LaneClearMenu.CreateSlider("Mana daha yüksek olmalı [{0}%] otomatik koridor temizleme", "manaSlider", 70);
            LaneClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            JungleClearMenu.AddGroupLabel("JungleClear");
            JungleClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            JungleClearMenu.CreateCheckBox(" - Kullan Q", "qUse");
            JungleClearMenu.CreateCheckBox(" - Kullan W", "wUse", false);
            JungleClearMenu.CreateCheckBox(" - Kullan E", "eUse", false);
            JungleClearMenu.CreateCheckBox(" - Kullan R", "rUse");
            JungleClearMenu.AddGroupLabel("Settings");
            JungleClearMenu.CreateSlider("Mana daha yüksek olmalı [{0}%] otomatik orman temizleme", "manaSlider", 10);
            JungleClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            KillStealMenu.AddGroupLabel("KillSteal");
            KillStealMenu.CreateCheckBox("Kullan Q BETA", "qUse");
            KillStealMenu.AddGroupLabel("Settings");
            KillStealMenu.CreateSlider("Mana daha yüksek olmalı [{0}%] otomatik öldürme icin", "manaSlider", 30);

            DrawingsMenu.AddGroupLabel("Settings");
            DrawingsMenu.CreateCheckBox("Sadece hazır olduklarında çizimleri göster.", "readyDraw");
            DrawingsMenu.CreateCheckBox("Verilecek hasarı göster.", "damageDraw", false);
            DrawingsMenu.CreateCheckBox("Hasar göstergesi yüzdesini çiz.", "perDraw", false);
            DrawingsMenu.CreateCheckBox("Hasar göstergesi istatistikleri çiz.", "statDraw", false);
            DrawingsMenu.AddGroupLabel("Spells");
            DrawingsMenu.CreateCheckBox("Göster Q.", "qDraw", false);
            DrawingsMenu.CreateCheckBox("Göster W.", "wDraw", false);
            DrawingsMenu.CreateCheckBox("Göster E.", "eDraw", false); //No one like Drawings kappa
            DrawingsMenu.CreateCheckBox("Göster R.", "rDraw", false );
            DrawingsMenu.CreateCheckBox("Öldürülebilirliği Göster", "showkilla", false);
            DrawingsMenu.AddSeparator(10);
            DrawingsMenu.AddGroupLabel("Tracker Draws");
            DrawingsMenu.Add("me", new CheckBox("Benim yolum", false));
            DrawingsMenu.Add("ally", new CheckBox("Takım yolu", false));
            DrawingsMenu.Add("enemy", new CheckBox("Düsman yolu", true));
            DrawingsMenu.AddLabel("Tracker Misc");
            DrawingsMenu.Add("toggle", new KeyBind("Buton Aç/Kapa", true, KeyBind.BindTypes.PressToggle, 'G'));
            DrawingsMenu.Add("eta", new CheckBox("Tahmini Varış Zamanı (Sadece ben)", true));
            DrawingsMenu.Add("name", new CheckBox("Sampiyon ismi", true));
            DrawingsMenu.Add("thick", new Slider("Çizgi Kalınlığı", 2, 1, 5));
            DrawingsMenu.AddGroupLabel("Orbwalk'ı kullanırken devre dışı bırak");
            DrawingsMenu.Add("combo", new CheckBox("Kombo", true));
            DrawingsMenu.Add("harass", new CheckBox("Dürtme", true));
            DrawingsMenu.Add("laneclear", new CheckBox("Koridor temizleme", false));
            DrawingsMenu.Add("lasthit", new CheckBox("Son vuruş", true));
            DrawingsMenu.Add("flee", new CheckBox("Kaçış", false));
            DrawingsMenu.AddSeparator(15);
            DrawingsMenu.AddGroupLabel("Drawings Color");
            QColorSlide = new ColorSlide(DrawingsMenu, "qColor", Color.Red, "Q Color:");
            WColorSlide = new ColorSlide(DrawingsMenu, "wColor", Color.Purple, "W Color:");
            EColorSlide = new ColorSlide(DrawingsMenu, "eColor", Color.Orange, "E Color:");
            RColorSlide = new ColorSlide(DrawingsMenu, "rColor", Color.DeepPink, "R Color:");
            DamageIndicatorColorSlide = new ColorSlide(DrawingsMenu, "healthColor", Color.YellowGreen, "DamageIndicator Color:");

            MiscMenu.AddGroupLabel("Settings");
            MiscMenu.AddLabel("Level Up Function");
            MiscMenu.Add("lvlup", new CheckBox("Otomatik seviye yükselt", false));
            MiscMenu.Add("Lvldelay", new Slider("Lvlup Gecikmesi (ms)", 0, 0, 500));
            MiscMenu.AddSeparator(15);
            MiscMenu.CreateCheckBox("Skin seçici aktif", "skinhax", false);
            MiscMenu.Add("skinID", new ComboBox("Skin seç", 1, "Skin yok", "Sakura Karma", "Sun Goddess Karma", "Geleneksel Karma", "Lotus çicegi Karma", "Gardiyan Karma"));
            MiscMenu.AddSeparator(10);
            MiscMenu.AddLabel("Some Settings:");
            MiscMenu.Add("predictionHit", new Slider("Q vurma şansı", 70));
            MiscMenu.Add("autoShieldTurret", new CheckBox("Kule altı oto kalkan", true));
            MiscMenu.Add("autoShieldSpell", new CheckBox("Otomatik kalkan büyüsü", false));
            MiscMenu.Add("antiGapCloser", new CheckBox("Atılma önleyicisi", true));
        }

        public static int comboUseRW
        {
            get { return ComboMenu["comboUseRW"].Cast<Slider>().CurrentValue; }
        }
        public static bool autoShieldTurret
        {
            get { return MiscMenu["autoShieldTurret"].Cast<CheckBox>().CurrentValue; }
        }
        public static bool autoShieldSpell
        {
            get { return MiscMenu["autoShieldSpell"].Cast<CheckBox>().CurrentValue; }
        }
        public static bool antiGapCloser
        {
            get { return MiscMenu["antiGapCloser"].Cast<CheckBox>().CurrentValue; }
        }
        public static double predictionHit
        {
            get { return ComboMenu["predictionHit"].Cast<Slider>().CurrentValue; }
        }
        public static bool BlockSpells
        {
            get { return MiscMenu["blockSpellsE"].Cast<CheckBox>().CurrentValue; }
        }
        public static int Lvldelay { get { return MiscMenu["Lvldelay"].Cast<Slider>().CurrentValue; } }
    }
}
