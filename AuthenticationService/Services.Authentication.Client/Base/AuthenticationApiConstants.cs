namespace Services.Authentication.Client.Base
{
    public static class AuthenticationApiConstants
    {
        #region Authentication

        public const string AuthenticationLogin = "Authentication/Login";
        public const string AuthenticationRegister = "Authentication/Register";
        public const string AuthenticationForgotPassword = "Authentication/ForgotPassword";
        public const string AuthenticationResetPassword = "Authentication/ResetPassword";
        public const string AuthenticationValidateEmail = "Authentication/ValidateEmail";
        public const string AuthenticationValidateCompanyAccess = "Authentication/ValidateCompanyAccess";
        public const string AuthenticationChangeAccount = "Authentication/ChangeAccount";

        #endregion

        #region User

        public const string UserAdd = "User/Add";
        public const string UserGet = "User/Get";
        public const string UserGetAll = "User/GetAll";
        public const string UserUpdate = "User/Update";
        public const string UserUpdatePassword = "User/UpdatePassword";
        public const string UserDelete = "User/Delete";
        public const string AssignRole = "User/AssignRole";
        public const string UnassignRole = "User/UnassignRole";

        #endregion

        #region Role

        public const string RoleAdd = "Role/Add";
        public const string RoleGet = "Role/Get";
        public const string RoleGetAll = "Role/GetAll";
        public const string RoleUpdate = "Role/Update";
        public const string RoleDelete = "Role/Delete";
        public const string RoleAddClaim = "Role/AddClaim";
        public const string RoleGetClaims = "Role/GetClaims";
        public const string RoleDeleteClaim = "Role/DeleteClaim";

        #endregion


    }
}
