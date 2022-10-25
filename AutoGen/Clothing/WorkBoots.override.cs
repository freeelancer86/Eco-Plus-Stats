﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Mods.TechTree;
    using Eco.Shared.Items;
    using Eco.Core.Items;
    using Eco.Shared.Gameplay;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Core.Controller;
    
    [Serialized]
    [LocDisplayName("Work Boots")]
    [Weight(100)]
    [Tag("Clothes", 1)]
    [Tag("Textile", 1)]
    [Ecopedia("Items", "Clothing", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class WorkBootsItem :
        ClothingItem
    {
        public override LocString DisplayDescription  { get { return Localizer.DoStr("Boots designed to be rugged and reduce muscle strain while working.\n\n(Decreases calories consumed when using tools by 10\u0025)"); } }
        public override string Slot             { get { return ClothingSlots.Shoes; } }
        public override bool Starter            { get { return false ; } }

        private static Dictionary<UserStatType, float> flatStats = new Dictionary<UserStatType, float>()
        {
            { UserStatType.CalorieRate, -0.1f },
        };
        public override Dictionary<UserStatType, float> GetFlatStats() { return flatStats; }
    }
    

    [RequiresSkill(typeof(TailoringSkill), 3)]
    public partial class WorkBootsRecipe : RecipeFamily
    {
        public WorkBootsRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "WorkBoots",  //noloc
                Localizer.DoStr("Work Boots"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CelluloseFiberItem), 10, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),
                    new IngredientElement(typeof(LeatherHideItem), 20, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),
                    new IngredientElement("Fabric", 20, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<WorkBootsItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 3;
            this.LaborInCalories = CreateLaborInCaloriesValue(600, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(1);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Work Boots"), typeof(WorkBootsRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
