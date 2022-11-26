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
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(FuelSupplyComponent))]
    [RequireComponent(typeof(FuelConsumptionComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class MortaredGraniteFireplaceObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(MortaredGraniteFireplaceItem);
        public override LocString DisplayName => Localizer.DoStr("Mortared Granite Fireplace");
        public override TableTextureMode TableTexture => TableTextureMode.Stone;
        private static string[] fuelTagList = new[] { "Burnable Fuel" }; //noloc

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<FuelSupplyComponent>().Initialize(2, fuelTagList);
            this.GetComponent<FuelConsumptionComponent>().Initialize(1);
            this.GetComponent<HousingComponent>().HomeValue = MortaredGraniteFireplaceItem.homeValue;
            this.ModsPostInitialize();
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Mortared Granite Fireplace")]
    [Ecopedia("Housing Objects", "Decoration", createAsSubPage: true)]
    [Tag("Housing", 1)]
    [Tag("Mortared Stone Furnishing", 1)]
    public partial class MortaredGraniteFireplaceItem : WorldObjectItem<MortaredGraniteFireplaceObject>
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A basic stone fireplace. Not much to look at it but a great source of heat.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            Category                 = RoomCategory.LivingRoom,
            HouseValue               = 1.5f,
            TypeForRoomLimit         = Localizer.DoStr("Fireplace"),
            DiminishingReturnPercent = 0.1f
        };

        [Tooltip(7)] private LocString PowerConsumptionTooltip => Localizer.Do($"Consumes: {Text.Info(1)}w of {new HeatPower().Name} power from fuel");
    }

    [RequiresSkill(typeof(MasonrySkill), 5)]
    [ForceCreateView]
    public partial class MortaredGraniteFireplaceRecipe : Recipe
    {
        public MortaredGraniteFireplaceRecipe()
        {
            this.Init(
                "MortaredGraniteFireplace",  //noloc
                Localizer.DoStr("Mortared Granite Fireplace"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(MortaredGraniteItem), 40, typeof(MasonrySkill), typeof(MasonryLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<MortaredGraniteFireplaceItem>()
                });
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(MasonryTableObject), typeof(MortaredStoneFireplaceRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
