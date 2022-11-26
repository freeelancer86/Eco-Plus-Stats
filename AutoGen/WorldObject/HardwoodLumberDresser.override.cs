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
    [RequireComponent(typeof(LinkComponent))]
    [RequireComponent(typeof(HousingComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class HardwoodLumberDresserObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(HardwoodLumberDresserItem);
        public override LocString DisplayName => Localizer.DoStr("Hardwood Lumber Dresser");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<HousingComponent>().HomeValue = HardwoodLumberDresserItem.homeValue;
            var storage = this.GetComponent<PublicStorageComponent>();
            storage.Initialize(16);
            storage.Storage.AddInvRestriction(new NotCarriedRestriction()); // can't store block or large itemsa
            this.ModsPostInitialize();
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Hardwood Lumber Dresser")]
    [Ecopedia("Housing Objects", "Bedroom", createAsSubPage: true)]
    [Tag("Housing", 1)]
    [Tag("Small Lumber Furnishing", 1)]
    public partial class HardwoodLumberDresserItem : WorldObjectItem<HardwoodLumberDresserObject>
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A lumber dresser that lets you store your clothing and quickly switch between a designated outfit and whatever you are currently wearing.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            Category                 = RoomCategory.Bedroom,
            HouseValue               = 1.5f,
            TypeForRoomLimit         = Localizer.DoStr("Dresser"),
            DiminishingReturnPercent = 0.6f
        };

    }

    [RequiresSkill(typeof(CarpentrySkill), 5)]
    [ForceCreateView]
    public partial class HardwoodLumberDresserRecipe : Recipe
    {
        public HardwoodLumberDresserRecipe()
        {
            this.Init(
                "HardwoodLumberDresser",  //noloc
                Localizer.DoStr("Hardwood Lumber Dresser"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(HardwoodLumberItem), 6, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                    new IngredientElement(typeof(NailItem), 8, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                    new IngredientElement("WoodBoard", 8, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<HardwoodLumberDresserItem>()
                });
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(SawmillObject), typeof(LumberDresserRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
