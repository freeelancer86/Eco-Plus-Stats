﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Controller;

    [Serialized]
    [LocDisplayName("Prepared Meat")]
    [Weight(400)]
    [Ecopedia("Food", "Raw Meat", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class PreparedMeatItem : FoodItem
    {
        public override LocString DisplayNamePlural     => Localizer.DoStr("Prepared Meat");
        public override LocString DisplayDescription    => Localizer.DoStr("Carefully butchered meat, ready to cook.");

        public override float Calories                  => 600;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 0, Fat = 6, Protein = 4, Vitamins = 0};
        protected override int BaseShelfLife            => (int)TimeUtil.HoursToSeconds(72);
    }


    [RequiresSkill(typeof(HuntingSkill), 4)]
    public partial class PreparedMeatRecipe : RecipeFamily
    {
        public PreparedMeatRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "PreparedMeat",  //noloc
                Localizer.DoStr("Prepared Meat"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(RawMeatItem), 4, typeof(HuntingSkill), typeof(ButcheryLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<PreparedMeatItem>(1),
                    new CraftingElement<ScrapMeatItem>(4),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(15, typeof(HuntingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PreparedMeatRecipe), 0.8f, typeof(HuntingSkill), typeof(ButcheryFocusedSpeedTalent), typeof(ButcheryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Prepared Meat"), typeof(PreparedMeatRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(ButcheryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
