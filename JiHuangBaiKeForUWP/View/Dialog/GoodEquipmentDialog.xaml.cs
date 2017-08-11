﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using JiHuangBaiKeForUWP.Model;
using JiHuangBaiKeForUWP.UserControls;

namespace JiHuangBaiKeForUWP.View.Dialog
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class GoodEquipmentDialog : Page
    {
        public GoodEquipmentDialog(GoodEquipment c)
        {
            this.InitializeComponent();
            GoodImage.Source = new BitmapImage(new Uri(c.Picture));
            GoodName.Text = c.Name;
            GoodEnName.Text = c.EnName;
            if (c.Attack== 0 && c.MinAttack == 0 && c.MaxAttack == 0 && string.IsNullOrEmpty(c.AttackString) && c.AttackOnBoat == 0 &&
                c.AttackWet == 0 && string.IsNullOrEmpty(c.Durability) && c.Wet == 0 && c.Heat == 0 && c.Sanity == 0 && c.Hunger == 0 && c.Defense == 0)
            {
                BarChartGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                if (c.Attack == 0 && c.MinAttack == 0 && c.MaxAttack == 0 && string.IsNullOrEmpty(c.AttackString) && c.AttackOnBoat == 0 &&
                    c.AttackWet == 0 && string.IsNullOrEmpty(c.Durability))
                {
                    BarChartStackPanel1.Visibility = Visibility.Collapsed;
                    BarChartStackPanel2.HorizontalAlignment = HorizontalAlignment.Center;
                    BarChartGridColumn1.Width = new GridLength(0);
                }
                if (c.Wet == 0 && c.Heat == 0 && c.Sanity == 0 && c.Hunger == 0 && c.Defense == 0)
                {
                    BarChartStackPanel2.Visibility = Visibility.Collapsed;
                    BarChartStackPanel1.HorizontalAlignment = HorizontalAlignment.Center;
                    BarChartGridColumn2.Width = new GridLength(0);
                }
            }
            if (c.Attack != 0)
            {
                GoodAttack.Value = c.Attack;
                GoodAttack.BarColor = Global.ColorRed;
            }
            else
            {
                GoodAttack.Visibility = Visibility.Collapsed;
            }
            if (c.MinAttack != 0)
            {
                GoodMinAttack.Value = c.MinAttack;
                GoodMinAttack.BarColor = Global.ColorRed;
            }
            else
            {
                GoodMinAttack.Visibility = Visibility.Collapsed;
            }
            if (c.MaxAttack != 0)
            {
                GoodMaxAttack.Value = c.MaxAttack;
                GoodMaxAttack.BarColor = Global.ColorRed;
            }
            else
            {
                GoodMaxAttack.Visibility = Visibility.Collapsed;
            }
            GoodAttackString.Visibility = string.IsNullOrEmpty(c.AttackString) ? Visibility.Collapsed : Visibility.Visible;
            if (c.AttackOnBoat != 0)
            {
                GoodAttackOnBoat.Value = c.AttackOnBoat;
                GoodAttackOnBoat.BarColor = Global.ColorRed;
            }
            else
            {
                GoodAttackOnBoat.Visibility = Visibility.Collapsed;
            }
            if (c.AttackWet != 0)
            {
                GoodAttackWet.Value = c.AttackWet;
                GoodAttackWet.BarColor = Global.ColorRed;
            }
            else
            {
                GoodAttackWet.Visibility = Visibility.Collapsed;
            }
            if (string.IsNullOrEmpty(c.Durability) == false)
            {
                try
                {
                    var regularExpressionsResult = System.Text.RegularExpressions.Regex.Replace(c.Durability, @"[^0-9]+", "");
                    var doubleResult = double.Parse(regularExpressionsResult);
                    GoodDurability.Value = doubleResult;
                    GoodDurability.BarColor = Global.ColorBlue;
                }
                catch
                {
                    // ignored
                }
            }
            else
            {
                GoodDurability.Visibility = Visibility.Collapsed;
            }
            if (c.Wet != 0)
            {
                GoodWet.Value = c.Wet;
                GoodWet.BarColor = Global.ColorCyan;
            }
            else
            {
                GoodWet.Visibility = Visibility.Collapsed;
            }
            if (c.Heat != 0)
            {
                GoodHeat.Value = c.Heat;
                GoodHeat.BarColor = Global.ColorOrange;
            }
            else
            {
                GoodHeat.Visibility = Visibility.Collapsed;
            }
            if (c.Sanity != 0)
            {
                GoodSanity.Value = c.Sanity;
                GoodSanity.BarColor = Global.ColorPink;
            }
            else
            {
                GoodSanity.Visibility = Visibility.Collapsed;
            }
            if (c.Hunger != 0)
            {
                GoodHunger.Value = c.Hunger;
                GoodHunger.BarColor = Global.ColorPurple;
            }
            else
            {
                GoodHunger.Visibility = Visibility.Collapsed;
            }
            if (c.Defense != 0)
            {
                GoodDefense.Value = c.Defense;
                GoodDefense.BarColor = Global.ColorYellow;
            }
            else
            {
                GoodDefense.Visibility = Visibility.Collapsed;
            }
            // 特殊能力
            if (c.Ability.Count == 0)
            {
                AbilityTextBlock.Visibility = Visibility.Collapsed;
                AbilityStackPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                foreach (var str in c.Ability)
                {
                    var textBlock = new TextBlock
                    {
                        HorizontalAlignment = HorizontalAlignment.Left,
                        TextWrapping = TextWrapping.Wrap,
                        Text = str
                    };
                    AbilityStackPanel.Children.Add(textBlock);
                }
            }
            // 来源于生物
            if (string.IsNullOrEmpty(c.DropBy))
            {
                GoodSourceStackPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                GoodSourcePicButton.Source = Global.GetGameResourcePath(c.DropBy);
            }
            // 介绍
            GoodIntroduction.Text = c.Introduction;
            // 控制台
            if (c.Console != null)
            {
                Console.Text = $"c_give(\"{c.Console}\",10)";
            }
            else
            {
                CopyGrid.Visibility = Visibility.Collapsed;
            }
        }

        private void Copy_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var dataPackage = new DataPackage();
            dataPackage.SetText(Console.Text);
            Clipboard.SetContent(dataPackage);
        }
    }
}