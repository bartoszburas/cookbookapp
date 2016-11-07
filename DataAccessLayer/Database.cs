using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataTransferObjects;
using System.Data.Entity.Validation;

namespace DataAccessLayer
{ 
    public class Database : IDataAccessObject
    {
        private MapperConfiguration config;
        private IMapper mapper;

        public Database()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RecipeDto, Recipe>();
                cfg.CreateMap<RecipeDto, Preparation>().ForMember(dest => dest.description,
                    opts => opts.MapFrom(src => src.PreparationDescription));
                cfg.CreateMap<Preparation, RecipeDto>().ForMember(dest => dest.PreparationDescription,
                    opts => opts.MapFrom(src => src.description));
                cfg.CreateMap<IngredientDto, Ingredient>().ForMember(dest => dest.name,
                    opts => opts.MapFrom(src => src.IngredientName));
                cfg.CreateMap<Recipe, RecipeDto>();
                cfg.CreateMap<Ingredient, IngredientDto>().ForMember(dest => dest.IngredientName,
                    opts => opts.MapFrom(src => src.name)); ;
                cfg.CreateMap<Recipe, RecipeSimplifiedDto>();
            });

            mapper = config.CreateMapper();
        }

        public void AddRecipe(RecipeDto recipe)
        {
            using (var db = new cookbookdbEntities())
            {
                Recipe recipeEntity = mapper.Map<Recipe>(recipe);
                Preparation preparationEntity = mapper.Map<Preparation>(recipe);
                List<Ingredient> ingredientEntities = mapper.Map<List<Ingredient>>(recipe.Ingredients);

                db.Recipes.Add(recipeEntity);
                db.Preparations.Add(preparationEntity);

                db.SaveChanges();
            }
        }

        public void DeleteRecipe(string name)
        {
            using (var db = new cookbookdbEntities())
            {
                foreach (Recipe r in db.Recipes.Where(r => r.name == name))
                    db.Recipes.Remove(r);

                db.SaveChanges();
            }
        }

        public RecipeDto GetRecipe(int id)
        {
            using (var db = new cookbookdbEntities())
            {
                var query = from r in db.Recipes
                            where r.idRecipe == id
                            select r;
                
                RecipeDto recipe = mapper.Map<RecipeDto>(query.FirstOrDefault());

                var query2 = from r in db.Preparations
                            where r.idRecipe == id
                            select r;

                recipe.PreparationDescription = query2.FirstOrDefault().description;

                return recipe;
            }
        }

        public List<RecipeSimplifiedDto> GetRecipeList()
        {
            using (var db = new cookbookdbEntities())
            {
                List<RecipeSimplifiedDto> list = mapper.Map<List<RecipeSimplifiedDto>>(db.Recipes);
                return list;
            }
        }
    }
}
