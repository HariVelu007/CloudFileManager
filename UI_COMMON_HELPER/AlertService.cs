using UI_COMMON_HELPER.Helper;

namespace UI_COMMON_HELPER
{
    public static class AlertService
    {
        public static string Show(Alert obj,string message)
        {
            string alertDiv = "";
            switch(obj)
            {
                case Alert.Success:
                    alertDiv = "<div class=\"alert alert-success alert-dismissable fade show\" id=\"alert\" role=\"alert\">" +
                        $"<strong> {message} </ strong>" +
                        $"<div class=\"float-end\"><button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button></div></div>";
                    break;
                case Alert.Danger:
                    alertDiv = "<div class=\"alert alert-danger alert-dismissable fade show\" id=\"alert\" role=\"alert\">" +
                        $"<strong> {message} </ strong>" +
                        $"<div class=\"float-end\"><button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button></div></div>";
                    break;
                case Alert.Info:
                    alertDiv = "<div class=\"alert alert-info alert-dismissable fade show\" id=\"alert\" role=\"alert\">" +
                        $"<strong> {message} </ strong>" +
                        $"<div class=\"float-end\"><button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button></div></div>";
                    break;
                case Alert.Warning:
                    alertDiv = "<div class=\"alert alert-warning alert-dismissable fade show\" id=\"alert\" role=\"alert\">" +
                        $"<strong> {message} </ strong>" +
                        $"<div class=\"float-end\"><button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button></div></div>";
                    break;
            }
            return alertDiv;
        }
    }
}