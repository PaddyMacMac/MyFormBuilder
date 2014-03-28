using System;
using System.Collections.Generic;
using myFormBuilder.Model.Enums;
using myFormBuilder.Model.POCO;

namespace myFormBuilder.Model.Services.WSHandlers
{
    public class ListServiceHandler : IServiceHandler
    {
        public string SaveItemList(IDictionary<string, ItemService.Item> items, string locationId)
        {
            var itemList = MakeItemListFromItems(items, locationId);
            try
            {
                if (itemList.ItemListElements.Length > 0)
                {
                    using (var service = new ListService.ListService())
                    {
                        service.user = GetServiceUser(ServiceTypesEnum.ListService) as ListService.User;
                        itemList = service.SaveItemList(itemList);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Can not save an Empty Item List, please ensure to provide Vailid Master codes before trying to Save..."), e);
            }
            return itemList.ListId;
        }

        private ListService.ItemList MakeItemListFromItems(IDictionary<string, ItemService.Item> items, string locationId)
        {
            var itemList = new ListService.ItemList();
            itemList.LocationId = locationId;
            itemList.CreatedDatetime = DateTime.Now.ToString();
            itemList.CreatedUser = User.Instance.UserName;
            itemList.ListId = Guid.NewGuid().ToString();
            itemList.ListName = string.Format("Erica Item List ({0})", DateTime.Now.ToString());
            itemList.State = "New";

            var itemListElementList = new List<ListService.ItemListElement>();
            int ordinal = 0;
            foreach (var item in items.Values)
            {
                var itemListElement = new ListService.ItemListElement()
                {
                    ItemId = item.id,
                    Ordinal = ++ordinal,
                    Scored = true,
                    Selectable = true,
                    FormWeight = 1,
                    Key = item.multikey,
                    NewElement = false,
                    Equator = false
                };
                itemListElementList.Add(itemListElement);
            }
            itemList.ItemListElements = itemListElementList.ToArray();
            return itemList;
        }
    }
}