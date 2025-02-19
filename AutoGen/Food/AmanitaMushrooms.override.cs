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
    [LocDisplayName("Amanita Mushrooms")]
    [Weight(10)]
    [Yield(typeof(AmanitaMushroomsItem), typeof(FarmingSkill), new float[] {1f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f, 2.0f})]
    [Crop]
    [Tag("Crop", 1)]
    [Tag("Harvestable", 1)]
    [Tag("Fungus", 1)]
    [Ecopedia("Food", "Produce", createAsSubPage: true)]
    public partial class AmanitaMushroomsItem : FoodItem
    {
        public override LocString DisplayDescription    => Localizer.DoStr("A potentially poisonous mushroom. It might not be wise to eat it raw, but it can be detoxified when prepared properly by a chef. Eat at your own risk!");

        public override float Calories                  => -20;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 0, Fat = 0, Protein = 0, Vitamins = 0};
        protected override int BaseShelfLife            => (int)TimeUtil.HoursToSeconds(48);
    }

}
