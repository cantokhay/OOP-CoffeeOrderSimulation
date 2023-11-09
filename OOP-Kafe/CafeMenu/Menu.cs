namespace OOP_Kafe.CafeMenu
{
    public class Menu
    {

        //indexer 
        public MenuItem? this[string itemName]
        {
            get
            {
               return MenuItems.First(x => x.Name == itemName);
            }
        }

        //menu Items
        public MenuItem[] MenuItems { get; }

        public Menu(params MenuItem[] menuItems)
        {
            
            MenuItems = menuItems;
        }

       
    }
}
