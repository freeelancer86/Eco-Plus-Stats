﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Core.Controller;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>

    [RequiresSkill(typeof(FertilizersSkill), 5)]
    public partial class CrushSmallStoneFurnishingLv3Recipe : RecipeFamily
    {
        public CrushSmallStoneFurnishingLv3Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "CrushedMixedRock",  //noloc
                Localizer.DoStr("Crushed Small Stone Furnishing Lv3"),
                new List<IngredientElement>
                {
                    new IngredientElement("Small Mortared Stone Furnishing", 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<CrushedMixedRockItem>(2),
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(FertilizersSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CrushSmallStoneFurnishingLv3Recipe), 0.5f, typeof(FertilizersSkill));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Crushed Small Stone Furnishing Lv3"), typeof(CrushSmallStoneFurnishingLv3Recipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(JawCrusherObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
