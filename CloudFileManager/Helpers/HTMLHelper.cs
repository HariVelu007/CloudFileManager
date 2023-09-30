namespace CloudFileManager.Helpers
{
    public class HTMLHelper
    {
        public static string Alert(string mode, string message)
        {
            string alertDiv = "";
            switch (mode)
            {
                case "success":
                    alertDiv = "<div class='alert alert-success alert-dismissable fade show' role='alert'><button type='button' class='close' data-dismiss='alert'><span aria-hidden='true'>&times;</span></button><strong> Success!</ strong > " + message + "</a>.</div>";
                    break;
                case "info":
                    alertDiv = "<div class='alert alert-info alert-dismissable fade show' role='alert'><button type='button' class='close' data-dismiss='alert'><span aria-hidden='true'>&times;</span></button><strong> Info!</ strong > " + message + "</a>.</div>";
                    break;
                case "warning":
                    alertDiv = "<div class='alert alert-warning alert-dismissable fade show' role='alert'><button type='button' class='close' data-dismiss='alert'><span aria-hidden='true'>&times;</span></button><strong> Warning!</ strong > " + message + "</a>.</div>";
                    break;
                case "danger":
                    alertDiv = "<div class='alert alert-danger alert-dismissable fade show' role='alert'><button type='button' class='close' data-dismiss='alert'><span aria-hidden='true'>&times;</span></button><strong> Danger!</ strong > " + message + "</a>.</div>";
                    break;
            }
            return alertDiv;
        }
    }
}
