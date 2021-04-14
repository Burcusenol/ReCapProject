using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car added.";
        public static string MaintenanceTime = "System is under maintenance.";
        public static string CarListed = "Cars listed.";
        public static string DailyPriceInValid = "The daily price must be greater than zero.";
        public static string CarDeleted = "Car deleted.";
        public static string CarUpdated = "Car updated.";

        public static string BrandNameInValid="Brand name must be greater than 2 characters.";
        public static string BrandAdded = "Brand added.";
        public static string BrandListed = "Brand listed..";
        public static string BrandUpdated = "Brand updated.";
        public static string BrandDeleted = "Brand deleted.";


        public static string ColorAdded = "Color added.";
        public static string ColorListed = "Color listed..";
        public static string ColorUpdated = "Color updated.";
        public static string ColorDeleted = "Color deleted.";


        public static string UserAdded = "User added.";
        public static string UserListed = "User listed..";
        public static string UserUpdated = "User updated.";
        public static string UserDeleted = "User deleted.";

        public static string CustomerAdded = "Customer added.";
        public static string CustomerListed = "Customer listed..";
        public static string CustomerUpdated = "Customer updated.";
        public static string CustomerDeleted = "Customer deleted.";
        public static string CustomerIdAlreadyExists = "Customer already registered!";

        public static string RentalAdded = "Rental added.";
        public static string RentalListed = "Rental listed..";
        public static string RentalUpdated = "Rental updated.";
        public static string RentalDeleted = "Rental deleted.";
        public static string RentalNotAvailable = "Car is not avaliable for rent.";
        
        public static string CarImageLımıted=" Car image can be the most 5.";
        public static string CarImageAdded = "Car image added.";
        public static string CarImageListed = "Car image listed..";
        public static string CarImageUpdated = "Car image updated.";
        public static string CarImageDeleted = "Car image deleted.";
        public static string CheckIfAnyCarImageExists=" Car image already registered!";
       
        
        public static string AuthorizationDenied="You are not authorized.";
        public static string UserRegistered="User registered";
        public static string UserNotFound="User not found.";
        public static string PasswordError="PasswordError";
        public static string SuccessfulLogin="Login is succesful.";
        public static string UserAlreadyExists="User already Exists";
        public static string AccessTokenCreated="Access token created.";
    }
}
