using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass
namespace MatrixLucian
{
    // I can't really help you with my layout of a good config class
    // since everyone does it the way they like it most, go checkout my
    // config classes I make on my GitHub if you wanna take over the
    // complex way that I use
    public static class Config
    {
        private const string MenuName = "Matrix Lucian";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Hosgeldin Matrix Lucian by TopGunner");

            // Initialize the modes
            Modes.Initialize();

        }

        public static void Initialize()
        {
        }


        public static class Misc
        {

            private static readonly Menu Menu;
            public static readonly CheckBox _drawQ;
            public static readonly CheckBox _drawW;
            public static readonly CheckBox _drawE;
            public static readonly CheckBox _drawR;
            public static readonly CheckBox _drawReady;
            public static readonly CheckBox _ksQ;
            public static readonly CheckBox _ksE;
            public static readonly CheckBox _ksW;
            public static readonly CheckBox _ksR;
            private static readonly CheckBox _useHeal;
            private static readonly CheckBox _useQSS;
            private static readonly CheckBox _useEOnGapcloser;
            private static readonly CheckBox _useEToMouse;
            private static readonly CheckBox _autoBuyStartingItems;
            private static readonly CheckBox _autolevelskills;
            private static readonly Slider _skinId;
            public static readonly CheckBox _useSkinHack;
            private static readonly CheckBox _cleanseStun;
            private static readonly Slider _cleanseEnemies;
            private static readonly CheckBox[] _useHealOn = { new CheckBox("", false), new CheckBox("", false), new CheckBox("", false), new CheckBox("", false), new CheckBox("", false) };

            public static bool useHealOnI(int i)
            {
                return _useHealOn[i].CurrentValue;
            }
            public static bool drawReady
            {
                get { return _drawReady.CurrentValue; }
            }
            public static bool ksQ
            {
                get { return _ksQ.CurrentValue; }
            }
            public static bool ksW
            {
                get { return _ksW.CurrentValue; }
            }
            public static bool ksE
            {
                get { return _ksE.CurrentValue; }
            }
            public static bool ksR
            {
                get { return _ksR.CurrentValue; }
            }
            public static bool useHeal
            {
                get { return _useHeal.CurrentValue; }
            }
            public static bool useQSS
            {
                get { return _useQSS.CurrentValue; }
            }
            public static bool useEOnGapcloser
            {
                get { return _useEOnGapcloser.CurrentValue; }
            }
            public static bool UseEToMouse
            {
                get { return _useEToMouse.CurrentValue; }
            }
            public static bool autoBuyStartingItems
            {
                get { return _autoBuyStartingItems.CurrentValue; }
            }
            public static bool autolevelskills
            {
                get { return _autolevelskills.CurrentValue; }
            }
            public static int skinId
            {
                get { return _skinId.CurrentValue; }
            }
            public static bool UseSkinHack
            {
                get { return _useSkinHack.CurrentValue; }
            }
            public static int cleanseEnemies
            {
                get { return _cleanseEnemies.CurrentValue; }
            }
            public static bool cleanseStun
            {
                get { return _cleanseStun.CurrentValue; }
            }


            static Misc()
            {
                // Initialize the menu values
                Menu = Config.Menu.AddSubMenu("Misc");
                _drawQ = Menu.Add("drawQ", new CheckBox("Goster Q"));
                _drawW = Menu.Add("drawW", new CheckBox("Goster W"));
                _drawE = Menu.Add("drawE", new CheckBox("Goster E"));
                _drawR = Menu.Add("drawR", new CheckBox("Goster R"));
                _drawReady = Menu.Add("drawReady", new CheckBox("Sadece hazir olani goster"));
                Menu.AddSeparator();
                _ksQ = Menu.Add("ksQ", new CheckBox("KS icin Q"));
                _ksW = Menu.Add("ksW", new CheckBox("KS icin W"));
                _ksE = Menu.Add("ksE", new CheckBox("Kullan E yardimci KS"));
                _ksR = Menu.Add("ksR", new CheckBox("KS icin R"));
                Menu.AddSeparator();
                _useHeal = Menu.Add("useHeal", new CheckBox("Sifa kullan"));
                _useQSS = Menu.Add("useQSS", new CheckBox("Kullan QSS"));
                Menu.AddSeparator();
                for (int i = 0; i < EntityManager.Heroes.Allies.Count; i++)
                {
                    _useHealOn[i] = Menu.Add("useHeal" + i, new CheckBox("Sifa kaydedici kullan " + EntityManager.Heroes.Allies[i].ChampionName));
                }
                Menu.AddSeparator();
                _useEOnGapcloser = Menu.Add("useEOnGapcloser", new CheckBox("Atilma yapanlara E kullan", false));
                _useEToMouse = Menu.Add("useEToMouse", new CheckBox("Fareye dogru E", false));
                Menu.AddSeparator();
                _autolevelskills = Menu.Add("autolevelskills", new CheckBox("Oto skll seviye atlatici", false));
                _autoBuyStartingItems = Menu.Add("autoBuyStartingItems", new CheckBox("Oto baslangic itemi (SR Sadece)", false));
                Menu.AddSeparator();
                _useSkinHack = Menu.Add("useSkinHack", new CheckBox("Skin secici kullan", false));
                _skinId = Menu.Add("skinId", new Slider("Skin ID", 6, 1, 7));
            }

            public static void Initialize()
            {
            }

        }

        public static class Modes
        {
            private static readonly Menu Menu;

            static Modes()
            {
                // Initialize the menu
                Menu = Config.Menu.AddSubMenu("Modes");

                // Initialize all modes
                // Combo
                Combo.Initialize();
                Menu.AddSeparator();

                // Harass
                Harass.Initialize();
                LaneClear.Initialize();
                JungleClear.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useE;
                private static readonly CheckBox _useR;
                private static readonly CheckBox _trackR;
                private static readonly CheckBox _useBurstMode;
                private static readonly CheckBox _useBOTRK;
                private static readonly CheckBox _useYOUMOUS;
                private static readonly CheckBox _useQVision;
                private static readonly CheckBox _useWardVision;
                private static readonly CheckBox _useTrinketVision;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }
                public static bool trackRTarget
                {
                    get { return _trackR.CurrentValue; }
                }
                public static bool UseBurstMode
                {
                    get { return _useBurstMode.CurrentValue; }
                }
                public static bool useWardVision
                {
                    get { return _useWardVision.CurrentValue; }
                }
                public static bool useTrinketVision
                {
                    get { return _useTrinketVision.CurrentValue; }
                }
                public static bool useBOTRK
                {
                    get { return _useBOTRK.CurrentValue; }
                }
                public static bool useYOUMOUS
                {
                    get { return _useYOUMOUS.CurrentValue; }
                }
                public static bool RPressed
                {
                    get { return Menu["RHotkey"].Cast<KeyBind>().CurrentValue; }
                }


                static Combo()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Combo");
                    _useQ = Menu.Add("comboUseQ", new CheckBox("Kullan Q"));
                    _useW = Menu.Add("comboUseW", new CheckBox("Kullan W"));
                    _useE = Menu.Add("comboUseE", new CheckBox("Kullan E"));
                    _useR = Menu.Add("comboUseR", new CheckBox("Kullan R"));
                    _trackR = Menu.Add("comboTrackR", new CheckBox("Komboda R ile hedefi takip et", false));
                    _useBurstMode = Menu.Add("burstCombo", new CheckBox("Kullan Seri-Combo", false));
                    _useBOTRK = Menu.Add("useBotrk", new CheckBox("Kullan mahvolmus (Akilli) ve Pala"));
                    _useYOUMOUS = Menu.Add("useYoumous", new CheckBox("Kullan Youmous"));
                    _useQVision = Menu.Add("useWVision", new CheckBox("Gorus icin W kullan"));
                    _useWardVision = Menu.Add("useWardVision", new CheckBox("Gorus icin totem kullan"));
                    _useTrinketVision = Menu.Add("useTrinketVision", new CheckBox("Uzak gorus totemi kullan"));
                    Menu.Add("RHotkey", new KeyBind("Track R Target", false, KeyBind.BindTypes.HoldActive, 'G'));
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                public static bool UseQ
                {
                    get { return Menu["harassUseQ"].Cast<CheckBox>().CurrentValue; }
                }
                public static bool UseE
                {
                    get { return Menu["harassUseE"].Cast<CheckBox>().CurrentValue; }
                }
                public static int Mana
                {
                    get { return Menu["harassMana"].Cast<Slider>().CurrentValue; }
                }

                static Harass()
                {
                    // Here is another option on how to use the menu, but I prefer the
                    // way that I used in the combo class
                    Menu.AddGroupLabel("Harass");
                    Menu.Add("harassUseQ", new CheckBox("Kullan Q"));
                    Menu.Add("harassUseE", new CheckBox("Kullan E")); // Default false

                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
                    Menu.Add("harassMana", new Slider("En az mana durtme icin ({0}%)", 40));
                }
                public static void Initialize()
                {
                }
            }

            public static class LaneClear
            {
                private static readonly CheckBox _useQ;
                private static readonly Slider _mana;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static int mana
                {
                    get { return _mana.CurrentValue; }
                }

                static LaneClear()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Lane Clear");
                    _useQ = Menu.Add("clearUseQ", new CheckBox("Kullan Q"));
                    _mana = Menu.Add("clearMana", new Slider("En az mana koridor temizleme ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }
            public static class JungleClear
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useE;
                private static readonly Slider _mana;

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }
                public static bool UseE
                {
                    get { return _useE.CurrentValue; }
                }
                public static int mana
                {
                    get { return _mana.CurrentValue; }
                }

                static JungleClear()
                {
                    // Initialize the menu values
                    Menu.AddGroupLabel("Jungle Clear");
                    _useQ = Menu.Add("jglUseQ", new CheckBox("Kullan Q"));
                    _useE = Menu.Add("jglUseE", new CheckBox("Kullan E"));
                    _mana = Menu.Add("jglMana", new Slider("En az mana orman temizleme ({0}%)", 40));
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}
