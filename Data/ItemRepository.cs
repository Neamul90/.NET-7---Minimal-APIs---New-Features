namespace dotnet_seven_api.Data
{
    public record Item(int Id, string title, bool completed);

    public class ItemRepository
    {
        private readonly Dictionary<int, Item> _Items = new Dictionary<int, Item>();
        public ItemRepository()
        {
            var item1 = new Item(1, "Go to the Gym", false);
            var item2 = new Item(2, "Go to the School", false);
            var item3 = new Item(3, "Go to the University", false);
            var item4 = new Item(4, "Go to the Home", false);
            _Items.Add(item1.Id, item1);
            _Items.Add(item2.Id, item2);
            _Items.Add(item3.Id, item3);
            _Items.Add(item4.Id, item4);
        }
        public List<Item> GetAll() => _Items.Values.ToList();
        public Item GetById(int id) => _Items.ContainsKey(id) ? _Items[id]:null;
        public void Add(Item obj) => _Items.Add(obj.Id, obj);
        public void Update(Item obj) => _Items[obj.Id] = obj;
        public void Delete(int id) => _Items.Remove(id);
    }
}
