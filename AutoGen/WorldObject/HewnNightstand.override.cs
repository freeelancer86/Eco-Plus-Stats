﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated from WorldObjectTemplate.tt />

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Economy;
    using Eco.Gameplay.Housing;
    using Eco.Gameplay.Interactions;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Modules;
    using Eco.Gameplay.Minimap;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Property;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Gameplay.Pipes.LiquidComponents;
    using Eco.Gameplay.Pipes.Gases;
    using Eco.Gameplay.Systems.Tooltip;
    using Eco.Shared;
    using Eco.Shared.Math;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.View;
    using Eco.Shared.Items;
    using Eco.Gameplay.Pipes;
    using Eco.World.Blocks;
    using Eco.Gameplay.Housing.PropertyValues;
    using Eco.Gameplay.Civics.Objects;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Core.Controller;
    using static Eco.Gameplay.Housing.PropertyValues.HomeFurnishingValue;

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class HewnNightstandObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(HewnNightstandItem);
        public override LocString DisplayName => Localizer.DoStr("Hewn Nightstand");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<HousingComponent>().HomeValue = HewnNightstandItem.homeValue;
            this.ModsPostInitialize();
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Hewn Nightstand")]
    [Ecopedia("Housing Objects", "Bedroom", createAsSubPage: true)]
    [Tag("Housing", 1)]
    [Tag("Hewn Furnishing", 1)]
    public partial class HewnNightstandItem : WorldObjectItem<HewnNightstandObject>
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A simple hewn wooden nightstand you can pile unread books on.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            Category                 = RoomCategory.Bedroom,
            HouseValue               = 1.5f,
            TypeForRoomLimit         = Localizer.DoStr("Nightstand"),
            DiminishingReturnPercent = 0.6f
        };

    }

    [RequiresSkill(typeof(CarpentrySkill), 4)]
    public partial class HewnNightstandRecipe : RecipeFamily
    {
        public HewnNightstandRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "HewnNightstand",  //noloc
                Localizer.DoStr("Hewn Nightstand"),
                new List<IngredientElement>
                {
                    new IngredientElement("HewnLog", 14, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), //noloc
                    new IngredientElement("WoodBoard", 8, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<HewnNightstandItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2;
            this.LaborInCalories = CreateLaborInCaloriesValue(60, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(HewnNightstandRecipe), 4, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Hewn Nightstand"), typeof(HewnNightstandRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(CarpentryTableObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
