using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RazorPagesLab.Pages.AddressBook;

public class DeleteAddressHandler
        : IRequestHandler<DeleteAddressRequest, Guid>
{
    private readonly IRepo<AddressBookEntry> _repo;

    public DeleteAddressHandler(IRepo<AddressBookEntry> repo)
    {
        _repo = repo;
    }

    public async Task<Guid> Handle(DeleteAddressRequest request, CancellationToken cancellationToken)
    {
        var reqEntry = AddressBookEntry.Create("", "", "", "", "");

        IEnumerable<AddressBookEntry> AddressBookEntries = _repo.Find(new AllEntriesSpecification());

        int i = 0;
        foreach (AddressBookEntry entry in AddressBookEntries)
        {
            if (entry.Id == request.Id) break;

            i++;
        }

        reqEntry.Id = AddressBookEntries.ElementAt(i).Id;

        _repo.Remove(reqEntry);
        return await Task.FromResult(request.Id);
    }
}
