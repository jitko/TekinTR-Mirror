using EloBuddy.SDK;

namespace Jinx
{
    using EloBuddy;
    using EloBuddy.SDK.Menu;
    using EloBuddy.SDK.Menu.Values;

    internal class Config
    {
        /// <summary>
        /// Initializes and Contains the Menu.
        /// </summary>
        public static Menu ConfigMenu;

        /// <summary>
        /// Initializes and Contains the Menu.
        /// </summary>
        public static Menu ComboMenu;

        /// <summary>
        /// Initializes and Contains the Menu.
        /// </summary>
        public static Menu LastHitMenu;

        /// <summary>
        /// Initializes and Contains the Menu.
        /// </summary>
        public static Menu HarassMenu;

        /// <summary>
        /// Initializes and Contains the Menu.
        /// </summary>
        public static Menu LaneClearMenu;

        /// <summary>
        /// Initializes and Contains the Menu.
        /// </summary>
        public static Menu KillStealMenu;

        /// <summary>
        /// Initializes and Contains the Menu.
        /// </summary>
        public static Menu JungleClearMenu;

        /// <summary>
        /// Initializes and Contains the Menu.
        /// </summary>
        public static Menu JungleStealMenu;

        /// <summary>
        /// Initializes and Contains the Menu.
        /// </summary>
        public static Menu FleeMenu;

        /// <summary>
        /// Initializes and Contains the Menu.
        /// </summary>
        public static Menu DrawingMenu;

        /// <summary>
        /// Initializes and Contains the Menu.
        /// </summary>
        public static Menu MiscMenu;

        /// <summary>
        /// Creates the Menu
        /// </summary>
        public static void Initialize()
        {
            ConfigMenu = MainMenu.AddMenu("Jin-XXX", "Jin-XXX");
            ConfigMenu.AddGroupLabel("Bu eklenti KarmaPanda tarafindan yapidi ve herhangi bir sekilde yeniden dagitilmamalidir.");
            ConfigMenu.AddGroupLabel("Yetkisi olmayan izinsiz yeniden dagitim, ciddi sonuclar doguracaktir.");
            ConfigMenu.AddGroupLabel("Bu eklentiyi kullandiginiz ve eglendiginiz icin tesekkur ederiz!");

            ComboMenu = ConfigMenu.AddSubMenu("Combo", "Combo");
            ComboMenu.AddLabel("Combo Settings");
            ComboMenu.Add("useQ", new CheckBox("Kullan Q"));
            ComboMenu.Add("useW", new CheckBox("Kullan W"));
            ComboMenu.Add("useE", new CheckBox("Kullan E"));
            ComboMenu.Add("useR", new CheckBox("Kullan R"));
            ComboMenu.AddLabel("ManaManager");
            ComboMenu.Add("manaQ", new Slider("Q icin mana ayari", 25));
            ComboMenu.Add("manaW", new Slider("W icin mana ayari", 25));
            ComboMenu.Add("manaE", new Slider("E icin mana ayari", 25));
            ComboMenu.Add("manaR", new Slider("R icin mana ayari", 25));
            ComboMenu.AddLabel("Hit on Champion is Prioritized first over Minion");
            ComboMenu.Add("qCountC", new Slider("Kullan Q deyicekse {0} dusmana(s)", 3, 1, 5));
            ComboMenu.Add("rCountC", new Slider("Kullan R deyicekse {0} dusmana(s)", 5, 1, 5));
            ComboMenu.AddLabel("Prediction Settings");
            ComboMenu.Add("wSlider", new Slider("Kullan W vurma sansi % is {0}", 80));
            ComboMenu.Add("eSlider", new Slider("Kullan E vurma sansi % is {0}", 80));
            ComboMenu.Add("rSlider", new Slider("Kullan R vurma sansi % is {0}", 80));
            ComboMenu.AddLabel("Extra Settings");
            ComboMenu.Add("wRange2", new Slider("Only Use W if Player Range from Target is more than {0}", 150, 0, 1500));
            ComboMenu.Add("eRange", new Slider("Only Use E if Player Range from Target is more than {0}", 150, 0, 900));
            ComboMenu.Add("eRange2", new Slider("Max E uzakligi", 900, 0, 900));
            ComboMenu.Add("rRange2", new Slider("Max R uzakligi", 3000, 0, 3000));

            LastHitMenu = ConfigMenu.AddSubMenu("LastHit", "LastHit");
            LastHitMenu.AddGroupLabel("LastHit Settings");
            LastHitMenu.Add("useQ", new CheckBox("Kullan Q"));
            LastHitMenu.Add("qCountM", new Slider("Kullan Q carpicaksa {0} minyona", 3, 1, 7));
            LastHitMenu.AddLabel("ManaManager");
            LastHitMenu.Add("manaQ", new Slider("Mana ayari Q", 25));

            HarassMenu = ConfigMenu.AddSubMenu("Harass", "Harass");
            HarassMenu.AddLabel("Harass Settings");
            HarassMenu.Add("useQ", new CheckBox("Kullan Q"));
            HarassMenu.Add("useW", new CheckBox("Kullan W"));
            HarassMenu.AddLabel("ManaManager");
            HarassMenu.Add("manaQ", new Slider("Mana ayari Q", 15));
            HarassMenu.Add("manaW", new Slider("Mana ayari W", 35));
            HarassMenu.AddLabel("Hit on Champion is Prioritized first over Minion");
            HarassMenu.Add("qCountC", new Slider("Kullan Q deyicekse {0} dusmana(s)", 3, 1, 5));
            HarassMenu.Add("qCountM", new Slider("Kullan Q carpicaksa {0} minyona(s)", 3, 1, 7));
            HarassMenu.AddLabel("Prediction Settings");
            HarassMenu.Add("wSlider", new Slider("Kullan W vurma sansi % is {0}", 95));
            HarassMenu.AddLabel("Extra Settings");
            HarassMenu.Add("wRange2", new Slider("Kullanma W hedeflenen oyuncu uzaksa {0}", 0, 0, 1450));

            LaneClearMenu = ConfigMenu.AddSubMenu("Lane Clear", "LaneClear");
            LaneClearMenu.AddLabel("Lane Clear Settings");
            LaneClearMenu.Add("useQ", new CheckBox("Kullan Q"));
            LaneClearMenu.Add("lastHit", new CheckBox("Menzil disindaki minyona", false));
            LaneClearMenu.Add("killQ", new CheckBox("Kullan sadece Q oldurulebilir minyonalara"));
            LaneClearMenu.Add("manaQ", new Slider("Mana ayari Q", 25));
            LaneClearMenu.Add("qCountM", new Slider("Kullan Q carpicaksa {0} minyona(s)", 3, 1, 7));

            KillStealMenu = ConfigMenu.AddSubMenu("Kill Steal", "KillSteal");
            KillStealMenu.Add("toggle", new CheckBox("Kullan Kill Steal"));
            KillStealMenu.Add("useW", new CheckBox("Kullan W KS"));
            KillStealMenu.Add("useR", new CheckBox("Kullan R KS"));
            KillStealMenu.AddLabel("ManaManager");
            KillStealMenu.Add("manaW", new Slider("Mana ayari W", 25));
            KillStealMenu.Add("manaR", new Slider("Mana ayari R", 25));
            KillStealMenu.AddLabel("Prediction Settings");
            KillStealMenu.Add("wSlider", new Slider("Kullan W vurma sansi % is {0}", 80));
            KillStealMenu.Add("rSlider", new Slider("Kullan R vurma sansi % is {0}", 80));
            KillStealMenu.AddLabel("Spell Settings");
            KillStealMenu.Add("wRange", new Slider("En az uzaklik W", 450, 0, 1500));
            KillStealMenu.Add("rRange", new Slider("En fazla uzaklik R", 3000, 0, 3000));

            JungleClearMenu = ConfigMenu.AddSubMenu("Jungle Clear", "JungleClear");
            JungleClearMenu.AddLabel("Jungle Clear Settings");
            JungleClearMenu.Add("useQ", new CheckBox("Kullan Q"));
            JungleClearMenu.Add("useW", new CheckBox("Kullan W", false));
            JungleClearMenu.AddLabel("ManaManager");
            JungleClearMenu.Add("manaQ", new Slider("Mana ayari Q", 25));
            JungleClearMenu.Add("manaW", new Slider("Mana ayari W", 25));
            JungleClearMenu.AddLabel("Misc Settings");
            JungleClearMenu.Add("wSlider", new Slider("Kullan W vurma sansi % is {0}", 85));

            JungleStealMenu = ConfigMenu.AddSubMenu("Jungle Steal", "JungleSteal");
            JungleStealMenu.AddLabel("Jungle Steal Settings");
            JungleStealMenu.Add("toggle", new CheckBox("Kullan orman temizleme", false));
            JungleStealMenu.Add("manaR", new Slider("Mana ayari R", 25));
            JungleStealMenu.Add("rRange", new Slider("Kullanmadan once mob araligi R", 3000, 0, 3000));
            if (Game.MapId == GameMapId.SummonersRift)
            {
                JungleStealMenu.AddLabel("Epics");
                JungleStealMenu.Add("SRU_Baron", new CheckBox("Baron"));
                JungleStealMenu.Add("SRU_Dragon", new CheckBox("Ejder"));
                JungleStealMenu.AddLabel("Buffs");
                JungleStealMenu.Add("SRU_Blue", new CheckBox("Mavi", false));
                JungleStealMenu.Add("SRU_Red", new CheckBox("Kirmisi", false));
                JungleStealMenu.AddLabel("Small Camps");
                JungleStealMenu.Add("SRU_Gromp", new CheckBox("Gromp", false));
                JungleStealMenu.Add("SRU_Murkwolf", new CheckBox("Kurt", false));
                JungleStealMenu.Add("SRU_Krug", new CheckBox("Kayacil", false));
                JungleStealMenu.Add("SRU_Razorbeak", new CheckBox("Keskin gaga", false));
                JungleStealMenu.Add("Sru_Crab", new CheckBox("Yengec", false));
            }

            if (Game.MapId == GameMapId.TwistedTreeline)
            {
                JungleStealMenu.AddLabel("Epics");
                JungleStealMenu.Add("TT_Spiderboss8.1", new CheckBox("Vilemaw"));
                JungleStealMenu.AddLabel("Camps");
                JungleStealMenu.Add("TT_NWraith1.1", new CheckBox("Wraith", false));
                JungleStealMenu.Add("TT_NWraith4.1", new CheckBox("Wraith", false));
                JungleStealMenu.Add("TT_NGolem2.1", new CheckBox("Golem", false));
                JungleStealMenu.Add("TT_NGolem5.1", new CheckBox("Golem", false));
                JungleStealMenu.Add("TT_NWolf3.1", new CheckBox("Wolf", false));
                JungleStealMenu.Add("TT_NWolf6.1", new CheckBox("Wolf", false));
            }

            FleeMenu = ConfigMenu.AddSubMenu("Flee", "Flee");
            FleeMenu.AddLabel("Flee Settings");
            FleeMenu.Add("useW", new CheckBox("Kacarken W kullan"));
            FleeMenu.Add("useE", new CheckBox("Kacarken E kullan"));
            FleeMenu.Add("wSlider", new Slider("kullan W vurma sansi is {0}", 75));
            FleeMenu.Add("eSlider", new Slider("kullan E vurma sansi is {0}", 75));

            DrawingMenu = ConfigMenu.AddSubMenu("Drawing", "Drawing");
            DrawingMenu.AddLabel("Drawing Settings");
            DrawingMenu.Add("drawQ", new CheckBox("Goster Q Menzili"));
            DrawingMenu.Add("drawW", new CheckBox("Goster W Menzili"));
            DrawingMenu.Add("drawE", new CheckBox("Goster E Menzili", false));
            DrawingMenu.AddLabel("Prediction Drawings");
            DrawingMenu.Add("predW", new CheckBox("Goster W Tahmini"));
            DrawingMenu.Add("predR", new CheckBox("Goster R Tahmini (In consideration of Range before R)", false));
            DrawingMenu.AddLabel("DamageIndicator");
            DrawingMenu.Add("draw.Damage", new CheckBox("Draw Damage"));
            DrawingMenu.Add("draw.Q", new CheckBox("Hesapla Q Hasari", false));
            DrawingMenu.Add("draw.W", new CheckBox("Hesapla W Hasari"));
            DrawingMenu.Add("draw.E", new CheckBox("Hesapla E Hasari", false));
            DrawingMenu.Add("draw.R", new CheckBox("Hesapla R Hasari"));
            DrawingMenu.AddLabel("Color Settings for Damage Indicator");
            DrawingMenu.Add("draw_Alpha", new Slider("Alpha: ", 255, 0, 255));
            DrawingMenu.Add("draw_Red", new Slider("Kirmisi: ", 255, 0, 255));
            DrawingMenu.Add("draw_Green", new Slider("Yesil: ", 0, 0, 255));
            DrawingMenu.Add("draw_Blue", new Slider("Mavi: ", 0, 0, 255));

            MiscMenu = ConfigMenu.AddSubMenu("Misc Menu", "Misc");
            MiscMenu.AddLabel("Interrupter");
            MiscMenu.Add("interruptE", new CheckBox("Kullan E ile kesme"));
            MiscMenu.Add("interruptmanaE", new Slider("Mana % kullanmadan once E ile kesme", 25));
            MiscMenu.AddLabel("Gapcloser");
            MiscMenu.Add("gapcloserE", new CheckBox("Kullan E atilma yapan sampiyona"));
            MiscMenu.Add("gapclosermanaE", new Slider("Mana % kullanmadan once E atilma yapan sampiyona", 25));
            MiscMenu.AddLabel("Spell Settings");
            MiscMenu.Add("autoW", new CheckBox("Bazi durumlarda otomatik olarak W kullan"));
            MiscMenu.Add("autoE", new CheckBox("Bazi durumlarda otomatik olarak E kullan"));
            MiscMenu.Add("qRange", new Slider("Ekstra Q Etkinlestirme Araligi", 25, 0, 100));
            MiscMenu.Add("wRange", new CheckBox("Yalnizca hedef AA araliginda ise W kullanin", false));
            MiscMenu.Add("rRange", new Slider("Oyuncu su menzilde ise R kullanma is {0}", 500, 0, 3000));
            MiscMenu.AddLabel("Auto W Settings (You must have Auto W on)");
            MiscMenu.Add("stunW", new CheckBox("Saskin Düsman üzerinde W kullanin", false));
            MiscMenu.Add("charmW", new CheckBox("Kullan W on Charmed dusman", false));
            //MiscMenu.Add("tauntW", new CheckBox("Use W on Taunted Enemy", false));
            MiscMenu.Add("fearW", new CheckBox("Kullan W Korkan dusman", false));
            MiscMenu.Add("snareW", new CheckBox("Kullan W Kapandaki dusmana", false));
            MiscMenu.Add("wRange2", new Slider("Kullan sadece W su mesafeden uzakta ise {0}", 450, 0, 1500));
            MiscMenu.AddLabel("Prediction Settings");
            MiscMenu.Add("wSlider", new Slider("Kullan W vurma sansi % is {0}", 75));
            MiscMenu.Add("eSlider", new Slider("Kullan E vurma sansi % is {0}", 75));
            /*MiscMenu.AddLabel("Allah Akbar");
            MiscMenu.Add("allahAkbarT", new CheckBox("Play Allah Akbar after casting R", false));*/
        }
    }
}
