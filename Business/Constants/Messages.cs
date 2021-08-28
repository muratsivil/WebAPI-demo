using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product Added.";
        public static string ProductNameInValid = "Product name Invalid.";
        public static string MaintenanceTime = "System Maintenance.";
        public static string ProductListed = "Products Listed.";
        public static string ProductCountOfCategoryError = "Category can be up to 10 pieces.";
        public static string ProductNameAlreadyExists = "There is already another product with this name.";
        public static string CategoryLimitExceeded = "Category limit exceeded.";
        public static string AuthorizationDenied = "You have no authority.";
        public static string UserRegistered = "User has registered.";
        public static string UserNotFound = "User Not Found.";
        public static string PasswordError = "Password Error.";
        public static string SuccessfulLogin = "Successfully Login.";
        public static string UserAlreadyExists = "User Already Exists.";
        public static string AccessTokenCreated = "Access Token Created.";
    }
}
