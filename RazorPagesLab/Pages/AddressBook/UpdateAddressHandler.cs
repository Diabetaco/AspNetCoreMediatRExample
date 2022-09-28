﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RazorPagesLab.Pages.AddressBook;

public class UpdateAddressHandler
    : IRequestHandler<UpdateAddressRequest, Guid>
{
    private readonly IRepo<AddressBookEntry> _repo;

    public UpdateAddressHandler(IRepo<AddressBookEntry> repo)
    {
        _repo = repo;
    }

    public async Task<Guid> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
    {
        var reqEntry = AddressBookEntry.Create(request.Line1, request.Line2, request.City, request.State,
        request.PostalCode);

        IEnumerable<AddressBookEntry> AddressBookEntries = _repo.Find(new AllEntriesSpecification());

        int i = 0;
        foreach (AddressBookEntry entry in AddressBookEntries)
        {
            if (entry.Id == request.Id) break;

            i++;
        }

        reqEntry.Id = AddressBookEntries.ElementAt(i).Id;

        _repo.Update(reqEntry);
        return await Task.FromResult(request.Id);
    }

}