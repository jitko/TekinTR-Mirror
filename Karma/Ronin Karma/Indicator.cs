﻿using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using System.Drawing;
using SharpDX;
using static Eclipse.SpellsManager;
using static Eclipse.Menus;
using Eclipse.Modes;
using Eclipse;

//Credits to JOKER !
namespace Eclipse
{
    public static class Indicator
    {
        public delegate float DamageToUnitDelegate(AIHeroClient hero);

        private const int xOffset = 5;
        private const int yOffset = 20;
        private const int Width = 103;
        private const int Height = 8;

        public static DamageToUnitDelegate DamageToUnit { get; set; }
        public static Text TextKillable { get; private set; }
        public static Text TextMinion { get; private set; }

        static Indicator()
        {
            TextKillable = new Text("", new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)) { Color = System.Drawing.Color.Red };
            TextMinion = new Text("", new Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)) { Color = System.Drawing.Color.LimeGreen };

            Drawing.OnDraw += Drawing_OnDraw;
        }

        static void Drawing_OnDraw(EventArgs args)
        {
            if (DrawingsMenu.GetCheckBoxValue("showkilla"))
            {
                foreach (var unit in ObjectManager.Get<AIHeroClient>().Where(h => h.IsValid && h.IsHPBarRendered && h.IsEnemy))
                {

                    var barPos = unit.HPBarPosition;
                    var damage = DamageToUnit(unit);
                    var percentHealthAfterDamage = Math.Max(0, unit.Health - damage) / unit.MaxHealth;
                    var yPos = barPos.Y + yOffset;
                    var xPosDamage = barPos.X + xOffset + Width * percentHealthAfterDamage;
                    var xPosCurrentHp = barPos.X + xOffset + Width * unit.Health / unit.MaxHealth;

                    if (damage > unit.Health)
                    {
                        TextKillable.Position = new Vector2((int)barPos.X - 15, (int)barPos.Y + yOffset + 20);
                        TextKillable.TextValue = "Kombo ile ölür";
                        TextKillable.Color = System.Drawing.Color.LimeGreen;
                    }
                    else
                    {
                        TextKillable.Position = new Vector2((int)barPos.X, (int)barPos.Y + yOffset + 20);
                        TextKillable.TextValue = "Öldürülemez";
                        TextKillable.Color = System.Drawing.Color.Red;
                    }

                    TextKillable.Draw();
                }
            }
        }

        public static void Initialize()
        {

        }
    }
}
