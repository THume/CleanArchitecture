using System;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Events;
using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Core.Handlers
{
    public class GuestbookNotificationHandler : IHandle<EntryAddedEvent>
    {
        private readonly IRepository<Guestbook> _guestbookRepository;
        private readonly IMessageSender _messageSender;

        public GuestbookNotificationHandler(IRepository<Guestbook> guestbookRepository, IMessageSender messageSender)
        {
            _guestbookRepository = guestbookRepository;
            _messageSender = messageSender;
        }

        public void Handle(EntryAddedEvent entryAddedEvent)
        {
            var guestbook = _guestbookRepository.GetById(entryAddedEvent.GuestbookId);
            foreach (var entry in guestbook.Entries)
            {
                if (entry.DateTimeCreated.Date == DateTime.UtcNow.Date)
                {
                    _messageSender.SendNotificationEmail(entry.EmailAddress, entryAddedEvent.Entry.Message);
                }
            }
        }
    }
}
