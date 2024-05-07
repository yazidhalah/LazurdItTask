using LazurdItTask.Data;

namespace LazurdItTask.Services
{
    public class ContactService
    {
        private List<Contact> contacts = new();
        private int nextId = 1;

        public List<Contact> GetAll()
        {
            return contacts;
        }
        public Contact GetById(int id)
        {
            if (contacts != null)
            {
                var contact = contacts.OrderBy(x => x.Id).FirstOrDefault(c => c.Id == id);
                return contact != null ? contact : new Contact();
            }
            else
            {
                return new Contact();
            }
        }
        public void Add(Contact contact)
        {
            contact.Id = nextId++;
            contacts.Add(contact);
        }
        public void Update(Contact contact)
        {
            var index = contacts.FindIndex(c => c.Id == contact.Id);
            if (index != -1)
                contacts[index] = contact;
        }
        public void Delete(int id)
        {
            contacts.RemoveAll(c => c.Id == id);
        }
    }
}
