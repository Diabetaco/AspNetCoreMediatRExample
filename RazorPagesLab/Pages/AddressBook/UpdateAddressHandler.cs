using System;
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
      
        IEnumerable<AddressBookEntry> AddressBookEntries = _repo.Find(new AllEntriesSpecification());

        int i = 0;
        foreach (AddressBookEntry entry in AddressBookEntries)
        {
            if (entry.Id == request.Id)
            {
                break;
            }
            i++;
        }
        AddressBookEntries.ElementAt(i).Update(AddressBookEntries.ElementAt(i));
        return await Task.FromResult(AddressBookEntries.ElementAt(i).Id);
    }

}