﻿using EloBuddy;
using EloBuddy.SDK;
using ReGaren.ReCore.ConfigList;
using ReGaren.ReCore.Managers;
using ReGaren.ReCore.Utility;

namespace ReGaren.ReCore.Core.Spells
{
    class Barrier : ISpell
    {
        public void Execute()
        {
            if (Player.Instance.HealthPercent > MenuHelper.GetSliderValue(Summoners.Menu, "Summoners.Barrier.Health"))
                return;

            var enemies = Player.Instance.CountEnemyChampionsInRange(300);
            if (MenuHelper.GetCheckBoxValue(Summoners.Menu, "Summoners.Barrier.Dangerous"))
            {
                if (enemies > 0 && Player.Instance.IsInDanger(MenuHelper.GetSliderValue(Summoners.Menu, "Summoners.Barrier.Health")))
                    SummonerManager.Barrier.Cast();
            }
            else
                SummonerManager.Barrier.Cast();
        }

        public bool ShouldGetExecuted()
        {
            if (!SummonerManager.Barrier.IsReady() || !MenuHelper.GetCheckBoxValue(Summoners.Menu, "Summoners.Barrier.Status"))
                return false;
            return true;
        }

        public void OnDraw()
        {
            
        }

        public void OnEndScene()
        {
            
        }
    }
}
