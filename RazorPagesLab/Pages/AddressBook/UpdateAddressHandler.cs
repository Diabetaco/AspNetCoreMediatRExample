/*using System;
using System.Collections.Generic;
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
        IEnumerable<AddressBookEntry> AddressBookEntries = _repo.Find(new AllEntriesSpecification());

        foreach (AddressBookEntry entry in AddressBookEntries)
        {
            if (entry.Id == request.Id)
            {
                _repo.Update(entry);
                return await Task.FromResult(entry.Id);
            } 
        }

        return await Task.FromResult(entry.Id);
    }
}*/