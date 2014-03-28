using System;
using System.Collections.Generic;
using myFormBuilder.Model.Enums;

namespace myFormBuilder.Model.Services.WSHandlers
{
    public class ItemServiceHandler : IServiceHandler
    {
        private IDictionary<string, ItemService.Item> _items;
        private int _itemAmount = 0;
        private int _currentItem = 0;

        public int ItemAmount { get { return _itemAmount; } }
        public int CurrentItem { get { return _currentItem; } }

        public ItemServiceHandler()
        {
            _items = new Dictionary<string, ItemService.Item>();
        }

        public IDictionary<string, ItemService.Item> LoadItems(IList<string> itemIds)
        {
            _itemAmount = itemIds.Count;
            foreach (string itemId in itemIds)
            {
                LoadItem(itemId);
            }
            return _items;
        }

        private void LoadItem(string itemId)
        {
            try
            {
                using (var service = new ItemService.ItemService())
                {
                    service.user = GetServiceUser(ServiceTypesEnum.ItemService) as ItemService.User;
                    var item = service.LoadItem(itemId);
                    if (!_items.Keys.Contains(itemId))
                    {
                        _items.Add(itemId, item);
                        _currentItem++;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("The provided Master Code: {0}, does not match any Item, please provide only valid Master Codes", itemId), e);
            }
        }
    }
}