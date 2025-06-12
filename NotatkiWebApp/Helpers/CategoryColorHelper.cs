namespace NotatkiWebApp.Helpers
{
    public static class CategoryColorHelper
    {
        public static string GetBadgeClass(string category)
        {
            return category switch
            {
                "Praca" => "bg-primary",
                "Prywatne" => "bg-success",
                "Szkoła" => "bg-warning text-dark",
                "Inne" => "bg-secondary",
                "Brak" => "bg-dark"
            };
        }
    }
}
