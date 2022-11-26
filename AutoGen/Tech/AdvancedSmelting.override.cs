﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using Eco.Core.Items;
    using Eco.Core.Utils;
    using Eco.Core.Utils.AtomicAction;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Services;
    using Eco.Shared.Utils;
    using Gameplay.Systems.Tooltip;
    using Eco.Core.Controller;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>
    [Serialized]
    [LocDisplayName("Advanced Smelting")]
    [Ecopedia("Professions", "Smith", createAsSubPage: true)]
    [RequiresSkill(typeof(SmithSkill), 0), Tag("Smith Specialty"), Tier(4)]
    [Tag("Specialty")]
    [Tag("Teachable")]
    public partial class AdvancedSmeltingSkill : Skill
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Advanced smelting aids in the production of steel - a key ingredient in the progress of any group. Levels up by crafting advanced smelting recipes."); } }

        public override void OnLevelUp(User user)
        {
            user.Skillset.AddExperience(typeof(SelfImprovementSkill), 20, Localizer.DoStr("for leveling up another specialization."));
        }


        public static MultiplicativeStrategy MultiplicativeStrategy =
            new MultiplicativeStrategy(new float[] { 
                1,
                1 - 0.2f,
                1 - 0.25f,
                1 - 0.3f,
                1 - 0.35f,
                1 - 0.4f,
                1 - 0.45f,
                1 - 0.5f,
            });
        public override MultiplicativeStrategy MultiStrategy => MultiplicativeStrategy;

        public static AdditiveStrategy AdditiveStrategy =
            new AdditiveStrategy(new float[] { 
                0,
                0.5f,
                0.55f,
                0.6f,
                0.65f,
                0.7f,
                0.75f,
                0.8f,
            });
        public override AdditiveStrategy AddStrategy => AdditiveStrategy;
        public override int MaxLevel { get { return 7; } }
        public override int Tier { get { return 4; } }
    }

    [Serialized]
    [LocDisplayName("Advanced Smelting Skill Book")]
    [Ecopedia("Items", "Skill Books", createAsSubPage: true)]
    public partial class AdvancedSmeltingSkillBook : SkillBook<AdvancedSmeltingSkill, AdvancedSmeltingSkillScroll> {}

    [Serialized]
    [LocDisplayName("Advanced Smelting Skill Scroll")]
    public partial class AdvancedSmeltingSkillScroll : SkillScroll<AdvancedSmeltingSkill, AdvancedSmeltingSkillBook> {}


    public partial class AdvancedSmeltingSkillBookRecipe : RecipeFamily
    {
        public AdvancedSmeltingSkillBookRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "AdvancedSmelting",  //noloc
                Localizer.DoStr("Modern Advanced Smelting Research Project"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CulinaryResearchPaperAdvancedItem), 50, typeof(SmeltingSkill)),
                    new IngredientElement(typeof(CulinaryResearchPaperModernItem), 25, typeof(SmeltingSkill)),
                    new IngredientElement(typeof(DendrologyResearchPaperAdvancedItem), 50, typeof(SmeltingSkill)),
                    new IngredientElement(typeof(DendrologyResearchPaperModernItem), 100, typeof(SmeltingSkill)),
                    new IngredientElement(typeof(GeologyResearchPaperAdvancedItem), 100, typeof(SmeltingSkill)),
                    new IngredientElement(typeof(GeologyResearchPaperModernItem), 50, typeof(SmeltingSkill)),
                    new IngredientElement(typeof(MetallurgyResearchPaperBasicItem), 300, typeof(SmeltingSkill)),
                    new IngredientElement(typeof(MetallurgyResearchPaperAdvancedItem), 350, typeof(SmeltingSkill)),
                    new IngredientElement(typeof(EngineeringResearchPaperAdvancedItem), 50, typeof(SmeltingSkill)),
                    new IngredientElement(typeof(EngineeringResearchPaperModernItem), 50, typeof(SmeltingSkill)),
                    new IngredientElement(typeof(AgricultureResearchPaperAdvancedItem), 50, typeof(SmeltingSkill)),
                    new IngredientElement(typeof(AgricultureResearchPaperModernItem), 125, typeof(SmeltingSkill)),
                    new IngredientElement(typeof(AdvancedBakingSkillScroll), 1, typeof(BasicEngineeringSkill)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<AdvancedSmeltingSkillBook>(),
                    new CraftingElement<AdvancedSmeltingSkillScroll>(100)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.CraftMinutes = CreateCraftTimeValue(1);
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Modern Research 3: Advanced Smelting"), typeof(AdvancedSmeltingSkillBookRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(LaboratoryObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
