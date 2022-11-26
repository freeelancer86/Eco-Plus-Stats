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
    using Eco.Gameplay.Modules;
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

    [RequiresSkill(typeof(GlassworkingSkill), 3)]
    public partial class AdvancedUpgradeLvl2Recipe : RecipeFamily
    {
        public AdvancedUpgradeLvl2Recipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "AdvancedUpgradeLvl2",  //noloc
                Localizer.DoStr("Advanced Upgrade 2"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(GlassItem), 12, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)),
                    new IngredientElement(typeof(SandItem), 10, typeof(GlassworkingSkill), typeof(GlassworkingLavishResourcesTalent)),
                    new IngredientElement(typeof(AdvancedUpgradeLvl1Item), 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<AdvancedUpgradeLvl2Item>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 4;
            this.LaborInCalories = CreateLaborInCaloriesValue(90, typeof(GlassworkingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(AdvancedUpgradeLvl2Recipe), 6, typeof(GlassworkingSkill), typeof(GlassworkingFocusedSpeedTalent), typeof(GlassworkingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Advanced Upgrade 2"), typeof(AdvancedUpgradeLvl2Recipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(KilnObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Advanced Upgrade 2")]
    [Weight(1)]
    [Ecopedia("Upgrade Modules", "Advanced Upgrades", createAsSubPage: true)]                                                                      //_If_EcopediaPage_
    [Tag("Upgrade", 1)]
    [Tag("AdvancedUpgrade", 1)]
    public partial class AdvancedUpgradeLvl2Item :
        EfficiencyModule
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Advanced Upgrade 2"); } }
        public override LocString DisplayDescription { get { return Localizer.DoStr("Advanced Upgrade that increases crafting efficiency."); } }

        public AdvancedUpgradeLvl2Item() : base(
            ModuleTypes.ResourceEfficiency | ModuleTypes.SpeedEfficiency,
            0.875f         
        ) { }
    }
}
