namespace ReflectionAndAttributes.Repository
{
    public class EmployeeRepository<T>
    {
        private readonly List<T> _storage = new List<T>();

        public void Create(T item)
        {
            _storage.Add(item);
        }

        public T Read(Func<T, bool> predicate)
        {
            return _storage.FirstOrDefault(predicate);
        }

        public void Update(T item)
        {
            var existingItem = _storage.FirstOrDefault(i => GetKey(i).Equals(GetKey(item)));
            if (existingItem != null)
            {
                _storage.Remove(existingItem);
                _storage.Add(item);
            }
        }

        public void Delete(T item)
        {
            _storage.Remove(item);
        }

        private object GetKey(T item)
        {
            var keyProp = typeof(T).GetProperties().FirstOrDefault(p => p.Name == "Id");
            return keyProp?.GetValue(item);
        }
    }

}
