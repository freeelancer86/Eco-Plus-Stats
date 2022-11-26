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
    [RequireComponent(typeof(OnOffComponent))]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(PowerGridComponent))]
    [RequireComponent(typeof(PowerConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class WoodenCeilingLightObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(WoodenCeilingLightItem);
        public override LocString DisplayName => Localizer.DoStr("Wooden Ceiling Light");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<PowerConsumptionComponent>().Initialize(60);
            this.GetComponent<PowerGridComponent>().Initialize(10, new ElectricPower());
            this.GetComponent<HousingComponent>().HomeValue = WoodenCeilingLightItem.homeValue;
            this.ModsPostInitialize();
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Wooden Ceiling Light")]
    [Ecopedia("Housing Objects", "Lights", createAsSubPage: true)]
    [Tag("Housing", 1)]
    [Tag("Small Lumber Furnishing", 1)]
    public partial class WoodenCeilingLightItem : WorldObjectItem<WoodenCeilingLightObject>
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A more modern way to light up a room.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Up
                ;
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            Category                 = RoomCategory.General,
            HouseValue               = 2,
            TypeForRoomLimit         = Localizer.DoStr("Lights"),
            DiminishingReturnPercent = 0.7f
        };

        [Tooltip(7)] private LocString PowerConsumptionTooltip => Localizer.Do($"Consumes: {Text.Info(60)}w of {new ElectricPower().Name} power");
    }

    [RequiresSkill(typeof(CarpentrySkill), 5)]
    public partial class WoodenCeilingLightRecipe : RecipeFamily
    {
        public WoodenCeilingLightRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "WoodenCeilingLight",  //noloc
                Localizer.DoStr("Wooden Ceiling Light"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CopperWiringItem), 4, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                    new IngredientElement("Lumber", 6, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), //noloc
                    new IngredientElement("WoodBoard", 4, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), //noloc
                    new IngredientElement("Fabric", 6, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), //noloc
                    new IngredientElement(typeof(LightBulbItem), 1, true),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<WoodenCeilingLightItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 3;
            this.LaborInCalories = CreateLaborInCaloriesValue(120, typeof(CarpentrySkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(WoodenCeilingLightRecipe), 4, typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Wooden Ceiling Light"), typeof(WoodenCeilingLightRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(SawmillObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
