namespace Business.Constants
{
    public static class Messages
    {
    public static string CarAdded = "Car added";
    public static string CarDeleted = "Car deleted";
    public static string CarUpdated = "Car updated";
    public static string CarsListed = "Cars listed";
    public static string CarListed = "Car listed";
    public static string CarNotExist = "Car does not exist";

    public static string BrandAdded = "Brand added";
    public static string BrandDeleted = "Brand deleted";
    public static string BrandUpdated = "Brand updated";
    public static string BrandsListed = "Brands listed";
    public static string BrandListed = "Brand listed";
    public static string BrandNotExist = "Brand does not exist";
    public static string BrandExist = "Brand already exists";

    public static string ColorAdded = "Color added";
    public static string ColorDeleted = "Color deleted";
    public static string ColorUpdated = "Color updated";
    public static string ColorsListed = "Colors listed";
    public static string ColorListed = "Color listed";
    public static string ColorNotExist = "Color does not exist";
    public static string ColorNameExist = "Color already exists";

    public static string UserAdded = "User added";
    public static string UserDeleted = "User deleted";
    public static string UserUpdated = "User updated";
    public static string UsersListed = "Users listed";
    public static string UserListed = "User listed";
    public static string UserNotExist = "User does not exist";
    public static string UserEmailExist = "Email already registered";
    public static string UserEmailNotAvailable = "User email is invalid";

        public static string DocumentProofsListed = "Document proofs listed successfully.";
        public static string DocumentProofListed = "Document proof listed successfully.";
        public static string DocumentProofAdded = "Document proof added successfully.";
        public static string ErrorAddingDocumentProof = "Error adding document proof.";
        public static string DocumentProofUpdated = "Document proof updated successfully.";
        public static string ErrorUpdatingDocumentProof = "Error updating document proof.";
        public static string DocumentProofDeleted = "Document proof deleted successfully.";
        public static string ErrorDeletingDocumentProof = "Error deleting document proof.";
        public static string NoDocumentProofs = "No document proofs found.";
        public static string DocumentProofsDeleted = "Document proofs deleted successfully.";
        public static string DocumentProofIdNotExist = "Document proof with the provided ID does not exist.";
        public static string DocumentProofLimitExceeded = "Document proof limit exceeded.";
        public static string NoDocumentProofsForUser = "No document proofs found for the user.";
        public static string DocumentProofsListedByUserId = "Document proofs listed by user ID successfully.";


        public static string CustomerAdded = "Customer added";
    public static string CustomerDeleted = "Customer deleted";
    public static string CustomerUpdated = "Customer updated";
    public static string CustomersListed = "Customers listed";
    public static string CustomerListed = "Customer listed";
    public static string CustomerNotExist = "Customer does not exist";
    public static string NotAddedCustomer = "An issue occurred while adding the customer";

    public static string RentalAdded = "Rental added";
    public static string RentalDeleted = "Rental deleted";
    public static string RentalUpdated = "Rental updated";
    public static string RentalsListed = "Rentals listed";
    public static string RentalListed = "Rental listed";
    public static string RentalCarNotAvailable = "The requested car for rental has been previously rented";
    public static string RentalNotExist = "Rental does not exist";
    public static string ReservationBetweenSelectedDatesExist = "There is already a reservation between the selected dates";
    public static string CarCanBeRentedBetweenSelectedDates = "Car can be rented within the selected dates";
    public static string CarAlreadyRentedByTheReservationDate = "Car has been rented until the reservation date";
    public static string RentDateMustBeGreaterThanReturnDate = "Rental date must be later than the return date";
    public static string RentalSuccessful = "Rental successful";

    public static string CarImagesListed = "Car images listed";
    public static string CarsImagesListed = "All car images listed";
    public static string CarImageListed = "Car image listed";
    public static string CarImageAdded = "Car image added";
    public static string CarImageDeleted = "Car image deleted";
    public static string CarImageUpdated = "Car image updated";
    public static string ErrorUpdatingImage = "An error occurred while updating the image";
    public static string ErrorDeletingImage = "An error occurred while deleting the image";
    public static string CarImageLimitExceeded = "More images cannot be added to this car";
    public static string CarImageIdNotExist = "Car image does not exist";
    public static string UserAlreadyCustomer = "User is already a customer";
    public static string GetDefaultImage = "Default image is provided as the car has no images";
    public static string NoPictureOfTheCar = "There are no pictures of the car";


    public static string AuthorizationDenied = "You are not authorized to perform this operation";
    public static string UserRegisterFailed = "User registration Failed!";
    public static string UserRegistered = "User registration successful";
    public static string UserNotFound = "User not found";
    public static string PasswordError = "Incorrect password";
    public static string SuccessfulLogin = "Login successful";
    public static string UserAlreadyExists = "User is already registered in the system";
    public static string AccessTokenCreated = "Token successfully created";
    public static string PasswordChanged = "Password changed successfully";

    public static string DeliveryStatusMustBeNull = "Delivery status must be null";
    public static string DeliveryStatusMustBeFalse = "Delivery status must be false";
    public static string DeliveryStatusCanNotBeNull = "Delivery status cannot be null";

    public static string CreditCardNotValid = "Credit card information could not be verified";
    public static string PaymentSuccessful = "Payment successfully completed";
    public static string InsufficientCardBalance = "Insufficient card balance";

    public static string StringMustConsistOfNumbersOnly = "String must consist of numbers only";
    public static string LeastOneCustomerIdDoesNotMatch = "At least one customer ID does not match in the payment";
    public static string TotalAmountNotMatch = "Total amount in rentals does not match the total to be paid";
    public static string InsufficientFindexScore = "Insufficient Findex score to rent some vehicles";

    public static string CreditCardListed = "Credit card listed";
    public static string CreditCardNotFound = "Credit card not found";
    public static string CustomersCreditCardsListed = "Customer's credit cards listed";
    public static string CustomerCreditCardFailedToSave = "Customer's credit card could not be saved";
    public static string CustomerCreditCardNotFound = "Customer's credit card not found";
    public static string CustomerCreditCardDeleted = "Customer's credit card successfully deleted";
    public static string CustomerCreditCardNotDeleted = "Customer's credit card could not be deleted";
    public static string CustomerCreditCardSaved = "Customer's credit card successfully saved";
    public static string CustomerCreditCardAlreadySaved = "Credit card is already saved";

    public static string CreditCardSaved = "Credit Card added";

  }
}
