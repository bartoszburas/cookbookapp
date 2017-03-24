﻿using DataAccessLayer;
using DataTransferObjects;
using WebApiService.Cache;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApiService.Controllers
{
    public class RecipeController : ApiController
    {
        private IDataAccessObjectFactory daoFactory = DatabaseFactory.GetInstance();
        private MemoryCacher cache = new MemoryCacher();

        public RecipeController() { }

        public RecipeController(IDataAccessObjectFactory daoFactory)
        {
            this.daoFactory = daoFactory;
        }

        public RecipeDto Get(int id)
        {
            var result = (RecipeDto)cache.GetValue(id.ToString());
            if(result == null)
            {
                IDataAccessObject dao = daoFactory.GetDao();
                result = dao.GetRecipe(id);
                if(result != null)
                    cache.Add(id.ToString(), result, DateTimeOffset.UtcNow.AddMinutes(15));
            }
            return result;
        }

        public List<RecipeSimplifiedDto> Get()
        {
            var result = (List<RecipeSimplifiedDto>)cache.GetValue("List");
            if(result == null)
            {
                IDataAccessObject dao = daoFactory.GetDao();
                List<RecipeSimplifiedDto> list = dao.GetRecipeList();
                result = new List<RecipeSimplifiedDto>();
                foreach (RecipeSimplifiedDto recipe in list)
                    result.Add(recipe);
                cache.Add("List", result, DateTimeOffset.UtcNow.AddMinutes(15));
            }
           
            return result;
        }

        [Authorize]
        public void Post(RecipeDto recipe)
        {
            IDataAccessObject dao = daoFactory.GetDao();
            dao.AddRecipe(recipe);
        }
    }
}
