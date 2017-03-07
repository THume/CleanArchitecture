using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.SharedKernel;

namespace CleanArchitecture.Core.Events
{
    public class EntryAddedEvent : BaseDomainEvent
    {
        public GuestbookEntry Entry { get; set; }
        public int GuestbookId { get; set; }

        public EntryAddedEvent(GuestbookEntry entry, int guestbookId)
        {
            Entry = entry;
            GuestbookId = guestbookId;
        }
    }
}
