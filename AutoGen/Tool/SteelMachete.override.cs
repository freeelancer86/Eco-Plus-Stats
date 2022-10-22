﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Shared.Math;
    using Eco.Core.Controller;


    [RequiresSkill(typeof(AdvancedSmeltingSkill), 1)]
    public partial class SteelMacheteRecipe : RecipeFamily
    {
        public SteelMacheteRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "SteelMachete",  //noloc
                Localizer.DoStr("Steel Machete"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(SteelBarItem), 10, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)),
                    new IngredientElement("Lumber", 5, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<SteelMacheteItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(AdvancedSmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SteelMacheteRecipe), 0.5f, typeof(AdvancedSmeltingSkill), typeof(AdvancedSmeltingFocusedSpeedTalent), typeof(AdvancedSmeltingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Steel Machete"), typeof(SteelMacheteRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Steel Machete")]
    [Tier(3)]
    [RepairRequiresSkill(typeof(AdvancedSmeltingSkill), 0)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Tag("Steel Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class SteelMacheteItem : MacheteItem
    {
                                                                                                                                                                                                                                           // Static values
        private static IDynamicValue caloriesBurn           = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(SteelMacheteItem), typeof(GatheringToolEfficiencyTalent)), CreateCalorieValue(15, typeof(FarmingSkill), typeof(SteelMacheteItem)));
        private static IDynamicValue exp                    = new ConstantValue(0.1f);
        private static IDynamicValue tier                   = new MultiDynamicValue(MultiDynamicOps.Sum, new ConstantValue(3), new TalentModifiedValue(typeof(SteelMacheteItem), typeof(GatheringToolStrengthTalent), 0));
        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(8, AdvancedSmeltingSkill.MultiplicativeStrategy, typeof(AdvancedSmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);

        private static Vector2i[] areaBlocks = new Vector2i[]
        {
            new Vector2i(-1, 0),
            new Vector2i(0, 1),
            new Vector2i(1, 0),
        };

        // Tool overrides

        public override LocString DisplayDescription    => Localizer.DoStr("A machete used to quickly clear plants.");
        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override Type ExperienceSkill            => typeof(FarmingSkill);
        public override IDynamicValue ExperienceRate    => exp;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 1000f;
        public override Item RepairItem                 => Item.Get<SteelBarItem>();
        public override int FullRepairAmount            => 8;
        public override Vector2i[] AreaBlocks           => areaBlocks;
    }
}
