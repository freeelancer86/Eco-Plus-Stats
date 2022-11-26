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
    [LocDisplayName("Wheat")]
    [Weight(10)]
    [Yield(typeof(WheatItem), typeof(FarmingSkill), new float[] {1f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2.0f})]
    [Crop]
    [Tag("Crop", 1)]
    [Tag("Harvestable", 1)]
    [Tag("Grain", 1)]
    [Tag("Raw Food", 1)]
    [Ecopedia("Food", "Produce", createAsSubPage: true)]
    public partial class WheatItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Wheat");
        public override LocString DisplayDescription    => Localizer.DoStr("A common grain that is significantly more useful processed.");

        public override float Calories                  => 15;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 6, Fat = 0, Protein = 2, Vitamins = 0};
        protected override int BaseShelfLife            => (int)TimeUtil.HoursToSeconds(48);
    }

}
