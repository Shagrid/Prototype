using System.Collections.Generic;


namespace BottomlessCloset
{
    public sealed class AssetsPathItem
    {
        #region Fields

        public static readonly Dictionary<ItemType, string> Item = new Dictionary<ItemType, string>
        {
            {
                ItemType.Shirt, "Prefabs/Items/Prefabs_Items_Shirt"
            },
            {
                ItemType.Underpants, "Prefabs/Items/Prefabs_Items_Underpants"
            },
            {
                ItemType.Circle, "Prefabs/Items/Prefabs_Items_Circle"
            },
            {
                ItemType.Square, "Prefabs/Items/Prefabs_Items_Square"
            },
            {
                ItemType.Triangle, "Prefabs/Items/Prefabs_Items_Triangle"
            },
            {
                ItemType.Rectangle, "Prefabs/Items/Prefabs_Items_Rectangle"
            },
            {
                ItemType.Pentagon, "Prefabs/Items/Prefabs_Items_Pentagon"
            }
        };

        #endregion
    }
}
