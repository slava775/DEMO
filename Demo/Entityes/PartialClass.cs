namespace Demo.Entityes
{
    partial class Tovar
    {
        public string AdminControllerVisibility
        {
            get
            {
                if (App.CurrentUser.IdRole == 2)
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
        }
    }
}
