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


    [RequiresSkill(typeof(SmeltingSkill), 1)]
    public partial class IronMacheteRecipe : RecipeFamily
    {
        public IronMacheteRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "IronMachete",  //noloc
                Localizer.DoStr("Iron Machete"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(IronBarItem), 4, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)),
                    new IngredientElement("WoodBoard", 4, typeof(SmeltingSkill), typeof(SmeltingLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<IronMacheteItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.1f;
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(SmeltingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(IronMacheteRecipe), 0.5f, typeof(SmeltingSkill), typeof(SmeltingFocusedSpeedTalent), typeof(SmeltingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Iron Machete"), typeof(IronMacheteRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(AnvilObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Iron Machete")]
    [Tier(2)]
    [RepairRequiresSkill(typeof(SmeltingSkill), 0)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool", 1)]
    [Tag("Iron Tool", 1)]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]
    public partial class IronMacheteItem : MacheteItem
    {
                                                                                                                                                                                                                                           // Static values
        private static IDynamicValue caloriesBurn           = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(IronMacheteItem), typeof(GatheringToolEfficiencyTalent)), CreateCalorieValue(17, typeof(FarmingSkill), typeof(IronMacheteItem)));
        private static IDynamicValue exp                    = new ConstantValue(0.1f);
        private static IDynamicValue tier                   = new MultiDynamicValue(MultiDynamicOps.Sum, new ConstantValue(2), new TalentModifiedValue(typeof(IronMacheteItem), typeof(GatheringToolStrengthTalent), 0));
        private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(4, SmeltingSkill.MultiplicativeStrategy, typeof(SmeltingSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);


        // Tool overrides

        public override LocString DisplayDescription    => Localizer.DoStr("A machete used to quickly clear plants.");
        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override Type ExperienceSkill            => typeof(FarmingSkill);
        public override IDynamicValue ExperienceRate    => exp;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 500f;
        public override Item RepairItem                 => Item.Get<IronBarItem>();
        public override int FullRepairAmount            => 4;
    }
}
