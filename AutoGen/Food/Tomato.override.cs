﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using Eco.Core.Items;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Controller;

    [Serialized]
    [LocDisplayName("Tomato")]
    [Weight(10)]
    [Yield(typeof(TomatoItem), typeof(FarmingSkill), new float[] {1f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2.0f})]
    [Crop]
    [Tag("Crop", 1)]
    [Tag("Harvestable", 1)]
    [Tag("Vegetable", 1)]
    [Tag("Raw Food", 1)]
    [Ecopedia("Food", "Produce", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class TomatoItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("Intelligence is knowing this is a fruit; wisdom is not putting it in a fruit salad.");

        public override float Calories                  => 240;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 5, Fat = 0, Protein = 1, Vitamins = 2};
        protected override int BaseShelfLife            => (int)TimeUtil.HoursToSeconds(120);
    }

}
