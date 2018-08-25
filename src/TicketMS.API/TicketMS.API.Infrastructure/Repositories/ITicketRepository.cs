﻿using System;
using System.Collections.Generic;
using TicketMS.API.Data.Entity;
using TicketMS.API.Data.Entity.Secondary;
using TicketMS.API.Infrastructure.DTO.Ticket;

namespace TicketMS.API.Infrastructure.Repositories
{
    public interface ITicketRepository : IRepository
    {
        IEnumerable<TicketEM> GetTickets(IPaging paging);
        IEnumerable<TicketEM> GetTickets(DateTime startDate, DateTime endDate);

        IEnumerable<TicketEM> GetHappyTickets(IPaging paging);
        IEnumerable<TicketEM> GetUnallocatedTickets();
        IEnumerable<TicketEM> GetReversibleTickets();
        IEnumerable<TicketEM> GetConsistentTickets();
        IEnumerable<TicketEM> GetDuplicatedTickets();

        IEnumerable<TicketEM> GetByPackage(int packageId);
        IEnumerable<TicketEM> GetDuplicatesWith(int id);

        IEnumerable<TicketEM> Filter(TicketFilterDTO filterDTO);

        TicketsTotalEM CountTickets();
        int CountTickets(TicketFilterDTO filterDTO);

        TicketEM GetTicket(int id);
        TicketEM GetRandomTicket();

        int CreateTicket(TicketDTO ticketDTO);
        void EditTicket(int id, TicketDTO ticketDTO);
        void DeleteTicket(int id);

        void MoveTicket(int ticketId, int packageId);
        void MoveManyTickets(IEnumerable<int> ticketsIds, int packageId);

        bool NumberExists(string number);
    }
}