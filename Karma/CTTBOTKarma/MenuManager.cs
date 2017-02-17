using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CTTBOTKarma
{
    class MenuManager
    {
        public static bool getCheckBoxItem(Menu m, string item)
        {
            return m[item].Cast<CheckBox>().CurrentValue;
        }

        public static int getSliderItem(Menu m, string item)
        {
            return m[item].Cast<Slider>().CurrentValue;
        }

        public static bool getKeyBindItem(Menu m, string item)
        {
            return m[item].Cast<KeyBind>().CurrentValue;
        }

        public static int getBoxItem(Menu m, string item)
        {
            return m[item].Cast<ComboBox>().CurrentValue;
        }

        public static Menu Main, Cizimler, Kombo, Durtme, Karisik;

        public static void LoadMenu()
        {
            Main = MainMenu.AddMenu("Karma", "Karma");

            Kombo = Main.AddSubMenu("Combo");
            Kombo.Add("UseQ", new CheckBox("Kullan Q", true));
            Kombo.Add("UseW", new CheckBox("Kullan W", true));
            Kombo.Add("UseR", new CheckBox("Kullan R", true));

            Durtme = Main.AddSubMenu("Harass");
            Durtme.Add("UseQ", new CheckBox("Kullan Q", true));
            Durtme.Add("UseR", new CheckBox("Kullan R", true));
            Durtme.Add("ManaHarass", new Slider("Durtmek icin mana ayari", 60, 0, 100));

            Karisik = Main.AddSubMenu("Misc");
            Karisik.Add("ESheild", new CheckBox("Make E Shield"));
            Karisik.Add("egapclose", new CheckBox("Kullan E atilma yapana"));
            Karisik.Add("qgapclose", new CheckBox("Kullan Q atilma yapana"));
            Karisik.Add("skinHack", new CheckBox("Kostum Sec"));
            Karisik.Add("SkinID", new Slider("Skin", 0, 0, 8));

            Cizimler = Main.AddSubMenu("Draw");
            Cizimler.AddGroupLabel("Draw Spell");
            Cizimler.Add("qRange", new CheckBox("Goster Q Menzili", false));
            Cizimler.Add("wRange", new CheckBox("Goster W Menzili", false));
            Cizimler.Add("eRange", new CheckBox("Goster E Menzili", false));
            Cizimler.Add("onlyRdy", new CheckBox("Sadece hazir olanlari goster", true));
        }
    }
}
