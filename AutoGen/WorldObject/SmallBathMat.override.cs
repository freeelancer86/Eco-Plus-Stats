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
    public partial class SmallBathMatObject : WorldObject, IRepresentsItem
    {
        public virtual Type RepresentedItemType => typeof(SmallBathMatItem);
        public override LocString DisplayName => Localizer.DoStr("Small Bath Mat");
        public override TableTextureMode TableTexture => TableTextureMode.Canvas;

        protected override void Initialize()
        {
            this.ModsPreInitialize();
            this.GetComponent<HousingComponent>().HomeValue = SmallBathMatItem.homeValue;
            this.ModsPostInitialize();
        }

 

        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Small Bath Mat")]
    [Ecopedia("Housing Objects", "Washroom", createAsSubPage: true )]
    [Tag("Housing", 1)]
    [Tag("Textile", 1)]
    public partial class SmallBathMatItem : WorldObjectItem<SmallBathMatObject>
    {
        
        public override LocString DisplayDescription => Localizer.DoStr("A small bath mat when a normal rug does not cover your bathroom needs.");


        public override DirectionAxisFlags RequiresSurfaceOnSides { get;} = 0
                    | DirectionAxisFlags.Down
                ;
        public override HomeFurnishingValue HomeValue => homeValue;
        public static readonly HomeFurnishingValue homeValue = new HomeFurnishingValue()
        {
            Category                 = RoomCategory.Bathroom,
            HouseValue               = 1,
            TypeForRoomLimit         = Localizer.DoStr("Rug"),
            DiminishingReturnPercent = 0.5f
        };

    }

    [RequiresSkill(typeof(TailoringSkill), 3)]
    public partial class SmallBathMatRecipe : RecipeFamily
    {
        public SmallBathMatRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                "SmallBathMat",  //noloc
                Localizer.DoStr("Small Bath Mat"),
                new List<IngredientElement>
                {
                    new IngredientElement(typeof(CelluloseFiberItem), 10, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),
                    new IngredientElement(typeof(CottonFabricItem), 20, typeof(TailoringSkill), typeof(TailoringLavishResourcesTalent)),
                },
                new List<CraftingElement>
                {
                    new CraftingElement<SmallBathMatItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(30, typeof(TailoringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(SmallBathMatRecipe), 4, typeof(TailoringSkill), typeof(TailoringFocusedSpeedTalent), typeof(TailoringParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Small Bath Mat"), typeof(SmallBathMatRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(LoomObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}
