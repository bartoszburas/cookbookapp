using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ServiceLayer
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        List<RecipeSimplifiedDto> GetRecipeList();      

        [OperationContract]
        RecipeDto GetRecipe(int id);

        [OperationContract]
        void AddRecipe(RecipeDto recipe);
    }

    [DataContract]
    public class RecipeSimplifiedDto
    {
        public DataTransferObjects.RecipeSimplifiedDto adaptee;

        [DataMember]
        public int IdRecipe { get { return adaptee.IdRecipe; } set { adaptee.IdRecipe = value; } }
        [DataMember]
        public string Name { get { return adaptee.Name; } set { adaptee.Name = value; } }
        [DataMember]
        public byte[] Picture { get { return adaptee.Picture; } set { adaptee.Picture = value; } }
    }

    [DataContract]
    public class RecipeDto
    {
        [DataMember]
        public DataTransferObjects.RecipeDto adaptee;
        [DataMember]
        public int IdRecipe { get { return adaptee.IdRecipe; } set { adaptee.IdRecipe = value; } }
        [DataMember]
        public string Name { get { return adaptee.Name; } set { adaptee.Name = value; } }
        [DataMember]
        public TimeSpan PreparationTime { get { return adaptee.PreparationTime; } set { adaptee.PreparationTime = value; } }
        [DataMember]
        public string SkillLevel { get { return adaptee.SkillLevel; } set { adaptee.SkillLevel = value; } }
        [DataMember]
        public int Amount { get { return adaptee.Amount; } set { if(adaptee == null) adaptee = new DataTransferObjects.RecipeDto(); adaptee.Amount = value; } }
        [DataMember]
        public byte[] Picture { get { return adaptee.Picture; } set { adaptee.Picture = value; } }
        [DataMember]
        public string PreparationDescription { get { return adaptee.PreparationDescription; } set { adaptee.PreparationDescription = value; } }
        [DataMember]
        public ICollection<IngredientDto> RecipeIngredient { get { return adaptee.Ingredients; } set { adaptee.Ingredients = value; } }


    }
}
