using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string RecipeAdded = "Tarif eklendi.";
        public static string RecipeUpdated = "Tarif güncellendi";
        public static string RecipeDeleted = "Tarif silindi";
        public static string RecipeListed = "Tarif listelendi";
        public static string RecipeNameAlreadyExist = "Tarif başlığı sistemde mevcut. Farklı bir başlık giriniz";
        public static string RecipeIdDoesntExist = "Tarif bulunamadı";

        public static string CategoryAdded = "Kategori eklendi.";
        public static string CategoryUpdated = "Kategori güncellendi";
        public static string CategoryDeleted = "Kategori silindi";
        public static string CategoryListed = "Kategori listelendi";

        public static string DirectionAdded = "Adım eklendi.";
        public static string DirectionUpdated = "Adım güncellendi";
        public static string DirectionDeleted = "Adım silindi";
        public static string DirectionListed = "Adım listelendi";

        public static string InfoAdded = "Bilgi eklendi.";
        public static string InfoUpdated = "Bilgi güncellendi";
        public static string InfoDeleted = "Bilgi silindi";
        public static string InfoListed = "Bilgi listelendi";

        public static string IngredientAdded = "Malzeme eklendi.";
        public static string IngredientUpdated = "Malzeme güncellendi";
        public static string IngredientDeleted = "Malzeme silindi";
        public static string IngredientListed = "Malzeme listelendi";

        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserListed = "Kullanıcı listelendi";

        

        public static string AuthorizationDenied = "Yetkisiz işlem";
    }
}
