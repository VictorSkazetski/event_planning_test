﻿namespace event_planning_test_api.App.Routes;

public static class RouteParts
{
    public const string Account = "account";
    public const string Registration = "registration";
    public const string AccountRegistration = Account + "/" + Registration;
    public const string Verify = "verify";
    public const string AccountVerify = Account + "/" + Verify;
    public const string Login = "login";
    public const string Accountlogin = Account + "/" + Login;
    public const string Admin = "admin";
    public const string User = "user";
}
