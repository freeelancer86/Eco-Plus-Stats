﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Items;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Core.Controller;


    public partial class TorchRecipe : RecipeFamily
    {
        public TorchRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "Torch",  //noloc
                Localizer.DoStr("Torch"),
                new List<IngredientElement>
                {
                    new IngredientElement("Wood", 10), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<TorchItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.LaborInCalories = CreateLaborInCaloriesValue(50);
            this.CraftMinutes = CreateCraftTimeValue(0.5f);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Torch"), typeof(TorchRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(WorkbenchObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [Serialized]
    [LocDisplayName("Torch")]
    [Weight(500)]
    [Fuel(8000)][Tag("Fuel")]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]
    [Tag("Torch", 1)]
    [Tag("Primitive Tool", 1)]
    public partial class TorchItem : ToolItem
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("A little bit of light to help beat back the night."); } }
    }
}