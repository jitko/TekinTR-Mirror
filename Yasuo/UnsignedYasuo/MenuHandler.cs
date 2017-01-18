﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace UnsignedYasuo
{
    class MenuHandler
    {
        public static Menu mainMenu, Combo, Harass, AutoHarass, Killsteal, LaneClear, JungleClear, LastHit, Flee, Ult, Items, Drawing;

        public static void Initialize()
        {
            #region CreateMenus
            mainMenu = MainMenu.AddMenu("Unsigned Yasuo", "UnsignedYasuo");
            Combo = AddSubMenu(mainMenu, "Combo");
            Harass = AddSubMenu(mainMenu, "Harass");
            AutoHarass = AddSubMenu(mainMenu, "Auto Harass");
            LaneClear = AddSubMenu(mainMenu, "Lane Clear");
            JungleClear = AddSubMenu(mainMenu, "Jungle Clear");
            LastHit = AddSubMenu(mainMenu, "Last Hit");
            Killsteal = AddSubMenu(mainMenu, "Kill Steal");
            Flee = AddSubMenu(mainMenu, "Flee");
            Ult = AddSubMenu(mainMenu, "Ult");
            Drawing = AddSubMenu(mainMenu, "Drawing");
            Items = AddSubMenu(mainMenu, "Items");
            #endregion

            #region Set Menu Values
            mainMenu.Add("Creator", new Label("Chaos tarafindan yapilan Unsigned Serisinin bir parcasi."));
            AddComboBox(mainMenu, "Prediction Type:", 0, "EloBuddy", "Current Position");

            AddCheckboxes(ref Combo, "Kullan Q", "Kullan Q3", "Use E_false", "Use EQ_false", "Use E Under Tower_false", "Kullan R", "Kullan Item", "Beyblade");
            AddComboBox(Combo, "Dash Mode: ", 0, "Gapclose", "To Mouse", "Disable");
            AddCheckboxes(ref Harass, "Kullan Q", "Kullan Q3", "Kullan Q Son vurus Minions_false", "Kullan Q3 son vurus Minions_false", "Kullan E_false", "Kullan EQ_false", "Kullan E Under Tower_false", "Kullan R_false", "Kullan Item");
            AddCheckboxes(ref AutoHarass, "Kullan Q", "Kullan Q3", "Kullan E_false", "Use EQ_false", "Kullan E Kule Tower_false", "Kullan Item");
            AddCheckboxes(ref LaneClear, "Kullan Q", "Kullan Q3", "Kullan E_false", "Kullan E sadece son vurus", "Kullan EQ_false", "Kullan E Kule Tower_false", "Kullan Item");
            AddCheckboxes(ref JungleClear, "Kullan Q", "Kullan Q3", "Kullan E", "Kullan E sadece son vurus Hit_false", "Kullan EQ_false", "Kullan Item");
            AddCheckboxes(ref LastHit, "Kullan Q", "Kullan Q3", "Use E", "Use EQ_false", "Use E Under Tower_false", "Use Items");
            AddCheckboxes(ref Killsteal, "Olum vurusu etkin", "Kullan Q", "Kullan Q3", "Kullan E", "Kullan EQ", "Kule alti E kullan", "Kullan Item", "Kullan Tutustur");
            AddCheckboxes(ref Flee, "Kullan E", "Kullan E Kule alti", "Biriktir Q", "Duvar Cizgisi");
            AddSlider(Flee, "Wall Dash Extra Space", 20, 10, 200);
            AddCheckboxes(ref Ult, "Son Saniyede R kullanin", "Menzildeki Tum Dusmanlarda R kullanin", "Use R for Flow_false", "Use R at 10% HP_false", "Hedef Secicinin Hedefi uzerinde R kullan");
            AddSlider(Ult, "Use R on x Enemies or more:", 3, 1, 5);
            AddSlider(Ult, "Use R on Target Selector Target and x or more Enemies:", 2, 1, 4);

            AddCheckboxes(ref Drawing, "Goster Q", "Goster W_false", "Goster E", "Draw E End Position on Target_false", "Draw E End Position on Target - Detailed_false", "Draw EQ_false", "Draw EQ on Target_false", "Goster R", "Goster Beyblade", "Draw Wall Dashes", "Goster Kule Menzili", "Goster Combo Hasari");
            AddSlider(Drawing, "Autos used in Combo", 2, 0, 5);
            AddSlider(Drawing, "Q's used in Combo", 2, 0, 5);
            AddCheckboxes(ref Items, "Civali Kusak kullan", "Kullan civali kilic", "Kullan Tiamat", "Kullan Vahsi Hydra", "Kullan Hasmetli Hydra", "Kullan Youmuus", "Kullan Bilgewater Palasi", "Kullan Hextech Silahkilic", "Kullan Mahvolmus Kiralin Kilici");
            WindWall.Initialize();
            #endregion
        }
        public static void AddCheckboxes(ref Menu menu, params string[] checkBoxValues)
        {
            foreach (string s in checkBoxValues)
            {
                if (s.Length > "_false".Length && s.Contains("_false"))
                    AddCheckbox(ref menu, s.Remove(s.IndexOf("_false"), 6), false);
                else
                    AddCheckbox(ref menu, s, true);
            }
        }
        public static Menu AddSubMenu(Menu startingMenu, string text)
        {
            Menu menu = startingMenu.AddSubMenu(text, text + ".");
            menu.AddGroupLabel(text + " Settings");
            return menu;
        }
        public static CheckBox AddCheckbox(ref Menu menu, string text, bool defaultValue = true)
        {
            return menu.Add(menu.UniqueMenuId + text, new CheckBox(text, defaultValue));
        }
        public static CheckBox GetCheckbox(Menu menu, string text)
        {
            return menu.Get<CheckBox>(menu.UniqueMenuId + text);
        }
        public static bool GetCheckboxValue(Menu menu, string text)
        {
            CheckBox checkbox = GetCheckbox(menu, text);

            if (checkbox == null)
                Console.WriteLine("Checkbox (" + text + ") not found under menu (" + menu.DisplayName + "). Unique ID (" + menu.UniqueMenuId + text + ")");

            return checkbox.CurrentValue;
        }
        public static ComboBox AddComboBox(Menu menu, string text, int defaultValue = 0, params string[] values)
        {
            return menu.Add(menu.UniqueMenuId + text, new ComboBox(text, defaultValue, values));
        }
        public static ComboBox GetComboBox(Menu menu, string text)
        {
            return menu.Get<ComboBox>(menu.UniqueMenuId + text);
        }
        public static string GetComboBoxText(Menu menu, string text)
        {
            return menu.Get<ComboBox>(menu.UniqueMenuId + text).SelectedText;
        }
        public static Slider GetSlider(Menu menu, string text)
        {
            return menu.Get<Slider>(menu.UniqueMenuId + text);
        }
        public static int GetSliderValue(Menu menu, string text)
        {
            return menu.Get<Slider>(menu.UniqueMenuId + text).CurrentValue;
        }
        public static Slider AddSlider(Menu menu, string text, int defaultValue, int minimumValue, int maximumValue)
        {
            return menu.Add(menu.UniqueMenuId + text, new Slider(text, defaultValue, minimumValue, maximumValue));
        }
    }
}
