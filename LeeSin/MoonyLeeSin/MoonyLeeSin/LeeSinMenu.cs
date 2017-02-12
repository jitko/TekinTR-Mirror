using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace MoonyLeeSin
{
    static class LeeSinMenu
    {
        public static void AddStringList(this Menu m, string uniqueId, string displayName, string[] values, int defaultValue)
        {
            var mode = m.Add(uniqueId, new Slider(displayName, defaultValue, 0, values.Length - 1));
            mode.DisplayName = displayName + ": " + values[mode.CurrentValue];
            mode.OnValueChange += delegate (ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
            {
                sender.DisplayName = displayName + ": " + values[args.NewValue];
            };
        }

        public static Menu config,
            comboMenu, harassMenu, clearMenu, insecMenu, insecExtensionsMenu, 
            multiRMenu, starComboMenu, bubbaKushMenu, smiteMenu;

        private static Menu helpMenu;
        public static void Init()
        {
            config = MainMenu.AddMenu("MoonyLeeSin", "__MoonyLeeSin");
            config.AddGroupLabel("by DanThePman");

            comboMenu = config.AddSubMenu("Combo", "ComboMenu");
            comboMenu.AddGroupLabel("Gank Combo");
            comboMenu.Add("useQ", new CheckBox("Kullan Q"));
            comboMenu.Add("useWGap", new CheckBox("Kullan W atilma yapanlara"));
            comboMenu.Add("noWAtQ2", new CheckBox("Kullanilmasin W Q2 olanakli ise"));
            comboMenu.Add("noWAtQ1Fly", new CheckBox("Bekle Q1 Sonra kullan atilma yapana W"));
            comboMenu.Add("useE", new CheckBox("Kullan E"));
            comboMenu.Add("useRKs", new CheckBox("R ile Oldur", false));
            comboMenu.Add("useItems", new CheckBox("Kullan Tiamat/Hydra"));
            comboMenu.AddSeparator();
            comboMenu.AddGroupLabel("Fight Combo");
            comboMenu.Add("useQFight", new CheckBox("Kullan Q"));
            comboMenu.Add("useWFight", new CheckBox("Kullan W"));
            comboMenu.Add("useEFight", new CheckBox("Kullan E"));
            comboMenu.Add("useRFight", new CheckBox("Kullan R"));
            comboMenu.Add("useItemsFight", new CheckBox("Kullan Tiamat/Hydra"));
            comboMenu.AddSeparator();
            comboMenu.AddStringList("currentComboMethod", "Current Combo Style", new [] {"Gank", "Fight"}, 0);
            comboMenu.Add("comboSytleSwitch",
                new KeyBind("Switch Combo Style (Toggle)", false, KeyBind.BindTypes.PressToggle));
            comboMenu.AddSeparator();

            comboMenu.AddGroupLabel("Misc");
            comboMenu.Add("useWardJump", new CheckBox("Kacarken toteme atla"));
            comboMenu.Add("useWardJumpMaxRange", new CheckBox("Kullan Maximum Menzil"));
            comboMenu.Add("useRKs_General", new CheckBox("Mumkunse genel olarak R ile oldur", false));

            harassMenu = config.AddSubMenu("Harass", "HarassMenu");
            harassMenu.Add("useQ", new CheckBox("Kullan Q1 Durtme"));
            harassMenu.Add("useE", new CheckBox("Kullan E Durtme"));


            clearMenu = config.AddSubMenu("Clears", "WaveClearMenu");
            clearMenu.AddGroupLabel("WaveClear");
            clearMenu.Add("useQW", new CheckBox("Kullan Q DalgaTemizleme"));
            clearMenu.Add("useWW", new CheckBox("Kullan W DalgaTemizleme"));
            clearMenu.Add("useEW", new CheckBox("Kullan E DalgaTemizleme"));
            clearMenu.Add("useItemsW", new CheckBox("Kullan Tiamat/Hydra DalgaTemizleme"));
            clearMenu.AddSeparator();

            clearMenu.AddGroupLabel("JungleClear");
            clearMenu.Add("useQJ", new CheckBox("Kullan Q Orman"));
            clearMenu.Add("useWJ", new CheckBox("Kullan W Orman"));
            clearMenu.Add("useEJ", new CheckBox("Kullan E Orman"));
            clearMenu.Add("useItemsJ", new CheckBox("Kullan Tiamat/Hydra Orman"));


            insecMenu = config.AddSubMenu("Insec", "LeeSinInsec");
            insecMenu.Add("insecFrequency", new Slider("Gecikme guncelle ms", 0, 0, 500));
            insecMenu.AddLabel("Daha fazla Fps almak icin");
            insecMenu.Add("wardDistanceToTarget", new Slider("Totem mesafesi dusmana", 230, 200, 300));
            insecMenu.AddSeparator();

            insecMenu.Add("_insecKey", new KeyBind("Lee Sin Insec Tusu", false, KeyBind.BindTypes.HoldActive));
            insecMenu.Add("moonSec", new CheckBox("Aktif MoonSec", false));
            insecMenu.AddLabel("^ Sadece fantezi icin (Kusacaktim!) ^");
            insecMenu.AddSeparator();

            insecMenu.AddGroupLabel("Drawings");
            insecMenu.Add("dashDebug", new KeyBind("Toteme atilma konumu goster (Degistir)", true, KeyBind.BindTypes.PressToggle));





            insecExtensionsMenu = config.AddSubMenu("InsecExtensions", "InsecExtensionsMenu");
            insecExtensionsMenu.Add("insecToMouseSpot", new CheckBox("Insec i fare konumunda etkinlestir", false));
            insecExtensionsMenu.AddLabel("Click On Ground");
            insecExtensionsMenu.AddSeparator();
            insecExtensionsMenu.Add("waitForQBefore_WardFlashKick", new CheckBox("Inseci aninda calistirma"));
            insecExtensionsMenu.AddLabel("Wait For Using Q Before Instantly Do Ward->Flash->Kick");
            insecExtensionsMenu.AddLabel("(Doesn't Matter If The Q Hits)");
            insecExtensionsMenu.AddSeparator();
            insecExtensionsMenu.Add("WardFlashKickOnlyWithQ", new CheckBox("Sadece aktif Totem->Sicra->Tekme Q eger isabet ederse", false));
            insecExtensionsMenu.AddSeparator();
            insecExtensionsMenu.Add("useFlashCorrection", new CheckBox("Yanlis totem atlamasi icin sicra kullan"));
            insecExtensionsMenu.Add("flashCorrectionDistance", new Slider("Uzaklik sapmasi daha buyukse sicra ile duzelt", 200, 100, 350));
            insecExtensionsMenu.AddSeparator();
            insecExtensionsMenu.Add("dontFlash", new CheckBox("Insecde herkes icin sicra kullanmayin", false));
            insecExtensionsMenu.AddSeparator();

            //insecExtensionsMenu.Add("correctInsecWithOtherSpells", new CheckBox("Correct Insec With Other Spells (e.g. Flash)"));
            //insecExtensionsMenu.AddLabel("If Your End Position Behind The Enemy is Inaccurate");
            //insecExtensionsMenu.AddSeparator();

            insecExtensionsMenu.Add("useMovementPrediction", new CheckBox("Hareket tahmini kullan"));
            insecExtensionsMenu.AddLabel("If The Target Is Running Away, The Ward Distance To It Increases");



            multiRMenu = config.AddSubMenu("Multiple R", "multiRMoonyLeeSin");
            multiRMenu.Add("multiREnabled", new CheckBox("Komboda kullan (R Sadece)", false));
            multiRMenu.Add("targetAmount", new Slider("Minimum Dusman", 2, 2, 5));
            multiRMenu.AddSeparator();
            multiRMenu.AddGroupLabel("Insec");
            multiRMenu.Add("multiREnabledInsec", new CheckBox("Insec modu aktif"));
            multiRMenu.Add("rotationAngle", new Slider("Kick angle [in Degrees]", 30, 0, 90));
            multiRMenu.AddLabel("45° => Addon,Birden Fazla Hedefi Vurmussa,Insec Sirasinda 45°lik Kenar yirticisina izin verir");





            starComboMenu = config.AddSubMenu("Star Combo", "StarComboMenu");
            starComboMenu.Add("starComboKey", new KeyBind("Star Combo", false, KeyBind.BindTypes.HoldActive));
            starComboMenu.AddLabel("Select Enemy");
            starComboMenu.AddSeparator();

            starComboMenu.Add("starComboMultiR", new CheckBox("Birden Fazla Dene R"));
            starComboMenu.Add("starComboMultiRHitCount", new Slider("En az kac Dusmana Star Combo", 2, 2, 5));
            starComboMenu.AddSeparator();

            starComboMenu.Add("starComboUseWard", new CheckBox("Kullan Totem"));
            starComboMenu.Add("starComboUseFlash", new CheckBox("Kullan Sicra"));
            starComboMenu.Add("starComboUseAlly", new CheckBox("Kullan Muttefiklere atilma"));
            starComboMenu.AddLabel("Prefers Ward/Ally Over Flash");
            starComboMenu.AddSeparator();

            starComboMenu.Add("starComboMovementPrediction", new CheckBox("Kullan Hareket Tahmini"));
            starComboMenu.AddLabel("For Wardjumps");





            bubbaKushMenu = config.AddSubMenu("BubbaKush", "bubbaKushMenu");
            bubbaKushMenu.Add("bubbaKey", new KeyBind("Bubba Kush", false, KeyBind.BindTypes.HoldActive));
            bubbaKushMenu.AddLabel("Select Enemy");
            bubbaKushMenu.AddSeparator();

            bubbaKushMenu.Add("useAlliesBubba", new CheckBox("Kullan Dostlar"));
            bubbaKushMenu.Add("useMovementPredictionBubba1", new CheckBox("Kullan Hareket Tahmini Hedef icin"));
            bubbaKushMenu.Add("useMovementPredictionBubba2", new CheckBox("Kullan Hareket Tahmini Kalan dusmanlar icin"));
            bubbaKushMenu.AddSeparator();

            bubbaKushMenu.Add("betterCalculationBubba", new CheckBox("Daha hassas hesaplama kullan"));
            bubbaKushMenu.AddLabel("Attends The Distance Of Hitted Enemies To The Ultimate-Rectangle-Hitbox Edge");




            smiteMenu = config.AddSubMenu("Smite", "SmiteMenu");
            smiteMenu.Add("smiteToggleKey", new KeyBind("Kullan Carp (Tus)", true, KeyBind.BindTypes.PressToggle));
            smiteMenu.AddSeparator();
            smiteMenu.Add("useSmiteLargeChamps", new CheckBox("Kullan Genis kamplar icin"));
            smiteMenu.AddLabel("Blue, Red");
            smiteMenu.AddSeparator();

            smiteMenu.Add("useForEpicCamps", new CheckBox("Kullan Epik Kamplar icin"));
            smiteMenu.AddLabel("All Dragons, Baron, Rift Herald, Spider Boss");
            smiteMenu.AddSeparator();

            smiteMenu.Add("useSmiteKs", new CheckBox("Kullan Carp Ks"));
            smiteMenu.AddSeparator();

            smiteMenu.Add("useSmiteQCombo", new CheckBox("Kullan Carp->Q Komboda"));
            smiteMenu.Add("useSmiteQInsec", new CheckBox("Kullan Carp->Q Insecde "));



            helpMenu = config.AddSubMenu("Help", "helpMenu");
            helpMenu.AddGroupLabel("Found A Bug? Scroll down");
            helpMenu.AddGroupLabel("How to insec");
            helpMenu.AddLabel("1. Make sure that insec spells are ready (at least R->W->Ward or R->Flash)", 35);
            helpMenu.AddLabel("2. Select enemy (blue circle)", 35);
            helpMenu.AddLabel("3. Select ally (blue circle 2)", 35);
            helpMenu.AddLabel("Afterwards, a white arrow from the enemy to the target will be drawn", 35);
            helpMenu.AddLabel("4. Press insec key and hold it down", 35);
            helpMenu.AddLabel("5. To cancel the insec, release the button", 35);
            helpMenu.AddSeparator();
            helpMenu.AddGroupLabel("Error?");
            helpMenu.AddGroupLabel("For Insec:");
            helpMenu.AddLabel("If your spells are not ready or you have not selected a valid target/ally", 35);
            helpMenu.AddLabel("          then a red font will be drawn below your hero to inform you.", 35);
            helpMenu.AddSeparator();
            helpMenu.AddGroupLabel("For Jungle- or WaveClear: Do not bind them to the same key");
            helpMenu.AddSeparator();
            helpMenu.AddGroupLabel("For Bubba Kush: Select a target and make sure your distance to it is <= WardRange");
            helpMenu.AddSeparator();
            helpMenu.AddGroupLabel("Anything still does not work: Reload the addon");
        }
    }
}
