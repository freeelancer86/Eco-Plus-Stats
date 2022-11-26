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

    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(SolidAttachedSurfaceRequirementComponent))]
    public partial class SmallStandingSaguaroSignObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(SmallStandingSaguaroSignItem);
        public override LocString DisplayName => Localizer.DoStr("Small Standing Saguaro Sign");
        public override TableTextureMode TableTexture => TableTextureMode.Wood;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<CustomTextComponent>().Initialize(700);
            this.ModsPostInitialize();
        }

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Small Standing Saguaro Sign")]
    [Ecopedia("Crafted Objects", "Signs", createAsSubPage: true)]
    [Tag("Small Hewn Furnishing", 1)]
    public partial class SmallStandingSaguaroSignItem : WorldObjectItem<SmallStandingSaguaroSignObject>, IPersistentData
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A small sign for all of your smaller text needs!");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;

        [Serialized, SyncToView, TooltipChildren, NewTooltipChildren(CacheAs.Instance)] public object PersistentData { get; set; }
    }

    [RequiresSkill(typeof(CarpentrySkill), 1)]
    [ForceCreateView]
    public partial class SmallStandingSaguaroSignRecipe : Recipe
    {
        public SmallStandingSaguaroSignRecipe()
        {
            this.Init(
                "SmallStandingSaguaroSign",  //noloc
                Localizer.DoStr("Small Standing Saguaro Sign"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(SaguaroRibItem), 5, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                    new IngredientElement("WoodBoard", 2, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), //noloc
                    new IngredientElement("HewnLog", 4, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)), //noloc
                },
                new List<CraftingElement>
                {
                    new CraftingElement<SmallStandingSaguaroSignItem>()
                });
            this.ModsPostInitialize();
            CraftingComponent.AddTagProduct(typeof(CarpentryTableObject), typeof(SmallStandingWoodSignRecipe), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
