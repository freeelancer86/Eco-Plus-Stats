﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Controller;

    /// <summary>
    /// <para>
    /// Server side food item definition for the "RootCampfireSalad" item. 
    /// This object inherits the FoodItem base class to allow for consumption mechanics.
    /// </para>
    /// <para>More information about FoodItem objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.FoodItem.html</para>
    /// </summary>
    /// <remarks>
    /// This is an auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization. 
    /// If you wish to modify this class, please create a new partial class or follow the instructions in the "UserCode" folder to override the entire file.
    /// </remarks>
    [Serialized] // Tells the save/load system this object needs to be serialized. 
    [LocDisplayName("Root Campfire Salad")] // Defines the localized name of the item.
    [Weight(200)] // Defines how heavy the RootCampfireSalad is.
    [Tag("CampfireSalad", 1)]
    [Ecopedia("Food", "Campfire", createAsSubPage: true)]
    public partial class RootCampfireSaladItem : FoodItem
    {

        /// <summary>The tooltip description for the food item.</summary>
        public override LocString DisplayDescription    => Localizer.DoStr("A myriad of plants that make a healthy and odd blend.");

        /// <summary>The amount of calories awarded for eating the food item.</summary>
        public override float Calories                  => 950;
        /// <summary>The nutritional value of the food item.</summary>
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 8, Fat = 4, Protein = 5, Vitamins = 11};

        /// <summary>Defines the default time it takes for this item to spoil. This value can be modified by the inventory this item currently resides in.</summary>
        protected override int BaseShelfLife            => (int)TimeUtil.HoursToSeconds(30);
    }


    /// <summary>
    /// <para>Server side recipe definition for "RootCampfireSalad".</para>
    /// <para>More information about RecipeFamily objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.RecipeFamily.html</para>
    /// </summary>
    /// <remarks>
    /// This is an auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization. 
    /// If you wish to modify this class, please create a new partial class or follow the instructions in the "UserCode" folder to override the entire file.
    /// </remarks>
    [RequiresSkill(typeof(CampfireCookingSkill), 1)]
    public partial class RootCampfireSaladRecipe : RecipeFamily
    {
        public RootCampfireSaladRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "RootCampfireSalad",  //noloc
                displayName: Localizer.DoStr("Root Campfire Salad"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(CamasBulbItem), 4.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(TaroRootItem), 4.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)),
                    new IngredientElement("Greens", 4.5f, typeof(CampfireCookingSkill), typeof(CampfireCookingLavishResourcesTalent)), //noloc
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<RootCampfireSaladItem>(1)
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 1; // Defines how much experience is gained when crafted.
            
            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(15, typeof(CampfireCookingSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(RootCampfireSaladRecipe), start: 1, skillType: typeof(CampfireCookingSkill), typeof(CampfireCookingFocusedSpeedTalent), typeof(CampfireCookingParallelSpeedTalent));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Root Campfire Salad"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Root Campfire Salad"), recipeType: typeof(RootCampfireSaladRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(CampfireObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}