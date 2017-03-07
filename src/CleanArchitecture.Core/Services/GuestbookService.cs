using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;

namespace CleanArchitecture.Core.Services
{
    public class GuestbookService : IGuestbookService
    {
        private readonly IRepository<Guestbook> _guestbookRepository;
        private readonly IMessageSender _messageSender;

        public GuestbookService(IRepository<Guestbook> guestbookRepository, IMessageSender messageSender)
        {
            _guestbookRepository = guestbookRepository;
            _messageSender = messageSender;
        }

        public void RecordEntry(Guestbook guestbook, GuestbookEntry newEntry)
        {
            foreach (var entry in guestbook.Entries)
            {
                if (entry.DateTimeCreated.Date == DateTime.UtcNow.Date)
                {
                    _messageSender.SendNotificationEmail(entry.EmailAddress, newEntry.Message);
                }
            }
        }
    }
}
